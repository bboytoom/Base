'use strict';

let gulp = require('gulp');
let sass = require('gulp-sass');
let autoprefixer = require('gulp-autoprefixer');
let concat = require('gulp-concat');
let uglify = require('gulp-uglify');
let cssnano = require('gulp-cssnano');
let imagemin = require('gulp-imagemin');

var browserify = require('browserify');
var source = require('vinyl-source-stream');
var tsify = require('tsify');
var sourcemaps = require('gulp-sourcemaps');
var buffer = require('vinyl-buffer');

let GlobalSass = './src/sass/main.scss';
let ManagerSass = './src/sass/custom-manager.scss';
let BaseImage = './src/images/';

let Jquery = './node_modules/jquery/dist/jquery.min.js';
let Popper = './node_modules/popper.js/dist/umd/popper.min.js';
let BootstrapJs = './node_modules/bootstrap/dist/js/bootstrap.min.js';
let MaterialJs = './node_modules/material-design-lite/material.min.js';

let Destino = './Administrator/Assets/';

gulp.task('global-css', function () {
    return gulp.src(GlobalSass)
        .pipe(sass({ outputStyle: 'compressed' }).on('error', sass.logError))
        .pipe(autoprefixer({
            browsers: ['last 2 versions'],
            cascade: false
        }))
        .pipe(concat('build.min.css'))
        .pipe(gulp.dest(Destino + 'css'));
});

gulp.task('manager-css', function () {
    return gulp.src(ManagerSass)
        .pipe(sass({ outputStyle: 'compressed' }).on('error', sass.logError))
        .pipe(autoprefixer({
            browsers: ['last 2 versions'],
            cascade: false
        }))
        .pipe(concat('build-manager.min.css'))
        .pipe(gulp.dest(Destino + 'css'));
});

gulp.task('global-image', function () {
    return gulp.src(BaseImage + '/*')
        .pipe(imagemin())
        .pipe(gulp.dest(Destino + 'images'))
});

gulp.task('global-js', function () {
    return gulp.src([Jquery, Popper])
        .pipe(concat('build.min.js'))
        .pipe(uglify())
        .pipe(gulp.dest(Destino + 'js'));
});

gulp.task('globalLibs-js', function () {
    return gulp.src([BootstrapJs, MaterialJs])
        .pipe(concat('build-libs.min.js'))
        .pipe(uglify())
        .pipe(gulp.dest(Destino + 'js'));
});

gulp.task('custom-js', function () {
    return browserify({
            basedir: '.',
            debug: true,
            entries: ['src/ts/main.ts'],
            cache: {},
            packageCache: {}
        })
        .plugin(tsify)
        .transform('babelify', {
            presets: ['es2015'],
            extensions: ['.ts']
        })
        .bundle()
        .pipe(source('bundle.js'))
        .pipe(buffer())
        .pipe(sourcemaps.init({ loadMaps: true }))
        .pipe(sourcemaps.write('./'))
        .pipe(gulp.dest(Destino + 'js'));
});

gulp.watch(Destino + 'css/*.css', gulp.series('global-css', 'manager-css'));
gulp.watch(Destino + 'js/*.js', gulp.series('global-js', 'globalLibs-js', 'custom-js'));

gulp.task('default',
    gulp.parallel(
        'global-css',
        'manager-css',
        'global-image',
        'global-js',
        'globalLibs-js',
        'custom-js'
    )
);
