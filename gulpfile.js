'use strict';

let gulp = require('gulp');
let sass = require('gulp-sass');
let autoprefixer = require('gulp-autoprefixer');
let concat = require('gulp-concat');
let uglify = require('gulp-uglify');
let cssnano = require('gulp-cssnano');
let imagemin = require('gulp-imagemin');
const babel = require('gulp-babel');

let GlobalSass = './src/sass/main.scss';
let ManagerSass = './src/sass/custom-manager.scss';
let BaseImage = './src/images/';
let OrigenJs = './src/js/';

let Destino = './Administrator/Assets/';

let SweetAlertCss = './node_modules/sweetalert2/dist/sweetalert2.min.css';

let Jquery = './node_modules/jquery/dist/jquery.min.js';
let Popper = './node_modules/popper.js/dist/umd/popper.min.js';
let BootstrapJs = './node_modules/bootstrap/dist/js/bootstrap.min.js';
let MaterialJs = './node_modules/material-design-lite/material.min.js';
let SweetAlertJs = './node_modules/sweetalert2/dist/sweetalert2.min.js';

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

gulp.task('libs-css', function () {
    return gulp.src(SweetAlertCss)
        .pipe(concat('build-libs.min.css'))
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
    return gulp.src([BootstrapJs, MaterialJs, SweetAlertJs])
        .pipe(concat('build-libs.min.js'))
        .pipe(uglify())
        .pipe(gulp.dest(Destino + 'js'));
});

gulp.task('custom-js', function () {
    return gulp.src(OrigenJs + 'index.js')
        .pipe(babel({
            "presets": ["env"]
        })) 
        .pipe(concat('custom.min.js'))
        .pipe(uglify())
        .pipe(gulp.dest(Destino + 'js'));
});

gulp.task('general-js', function () {
    return gulp.src(OrigenJs + 'general.js')
        .pipe(babel({
            "presets": ["env"]
        })) 
        .pipe(concat('general.min.js'))
        .pipe(uglify())
        .pipe(gulp.dest(Destino + 'js'));
});

gulp.watch(Destino + 'css/*.css', gulp.series('global-css', 'manager-css'));
gulp.watch(Destino + 'js/*.js', gulp.series('global-js', 'globalLibs-js', 'custom-js', 'general-js'));

gulp.task('default',
    gulp.parallel(
        'global-css',
        'manager-css',
        'libs-css',
        'global-image',
        'global-js',
        'globalLibs-js',
        'custom-js',
        'general-js'
    )
);
