'use strict';

/*** Paquetes ***/

let gulp = require('gulp');
let sass = require('gulp-sass');
let autoprefixer = require('gulp-autoprefixer');
let concat = require('gulp-concat');
let uglify = require('gulp-uglify');
let imagemin = require('gulp-imagemin');
let sourcemaps = require("gulp-sourcemaps");
let babel = require('gulp-babel');

/************************************************************************************/

/*** Librerias ***/

let SweetAlertCss = './node_modules/sweetalert2/dist/sweetalert2.min.css';
let Jquery = './node_modules/jquery/dist/jquery.min.js';
let Popper = './node_modules/popper.js/dist/umd/popper.min.js';
let BootstrapJs = './node_modules/bootstrap/dist/js/bootstrap.min.js';
let MaterialJs = './node_modules/material-design-lite/material.min.js';
let SweetAlertJs = './node_modules/sweetalert2/dist/sweetalert2.min.js';

/************************************************************************************/

/*** Rutas origen ***/

let GlobalSass = './src/sass/main.scss';
let ManagerSass = './src/sass/custom-manager.scss';
let BaseImage = './src/images/';
let OrigenJs = './src/js/';

/************************************************************************************/

/*** Rutas destino ***/

let DestinoCss = './Administrator/Content';
let DestinoImagenes = './Administrator/Images';
let DestinoJs = './Administrator/Scripts';

/************************************************************************************/

/*** Tareas ***/

gulp.task('global-css', function () {
    return gulp.src(GlobalSass)
        .pipe(sass({ outputStyle: 'compressed' }).on('error', sass.logError))
        .pipe(autoprefixer({
            browsers: ['last 2 versions'],
            cascade: false
        }))
        .pipe(concat('build.min.css'))
        .pipe(gulp.dest(DestinoCss));
});

gulp.task('libs-css', function () {
    return gulp.src(SweetAlertCss)
        .pipe(concat('build-libs.min.css'))
        .pipe(gulp.dest(DestinoCss));
});

gulp.task('manager-css', function () {                                      
    return gulp.src(ManagerSass)
        .pipe(sass({ outputStyle: 'compressed' }).on('error', sass.logError))
        .pipe(autoprefixer({
            browsers: ['last 2 versions'],
            cascade: false
        }))
        .pipe(concat('build-manager.min.css'))
        .pipe(gulp.dest(DestinoCss));
});


gulp.task('global-image', function () {
    return gulp.src(BaseImage + '/*')
        .pipe(imagemin())
        .pipe(gulp.dest(DestinoImagenes));
});

gulp.task('global-js', function () {
    return gulp.src([Jquery, Popper])
        .pipe(concat('build.min.js'))
        .pipe(uglify())
        .pipe(gulp.dest(DestinoJs));
});

gulp.task('globalLibs-js', function () {
    return gulp.src([BootstrapJs, MaterialJs, SweetAlertJs])
        .pipe(concat('build-libs.min.js'))
        .pipe(uglify())
        .pipe(gulp.dest(DestinoJs));
});

gulp.task('custom-js', function () {
    return gulp.src(OrigenJs + 'index.js')
        .pipe(sourcemaps.init())
        .pipe(babel({
            presets: ["@babel/preset-env"],
            plugins: ["@babel/plugin-transform-classes"]
        }))
        .pipe(concat('custom.min.js'))
        .pipe(uglify())
        .pipe(sourcemaps.write("."))
        .pipe(gulp.dest(DestinoJs));
});

gulp.task('general-js', function () {
    return gulp.src([OrigenJs + 'contexto.js', OrigenJs + 'estrategia.js', OrigenJs + 'grupos.js', OrigenJs + 'usuarios.js', OrigenJs + 'general.js'])
        .pipe(sourcemaps.init())
        .pipe(babel({
            presets: ["@babel/preset-env"],
            plugins: ["@babel/plugin-transform-classes"]
        }))
        .pipe(concat('general.min.js'))
        .pipe(uglify())
        .pipe(sourcemaps.write("."))
        .pipe(gulp.dest(DestinoJs));
});

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
