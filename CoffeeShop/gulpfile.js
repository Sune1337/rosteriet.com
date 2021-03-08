/// <binding AfterBuild='all' Clean='clean' />
var gulp = require("gulp");
var inject = require("gulp-inject");
var concat = require("gulp-concat");
var print = require("gulp-print");
var uglify = require("gulp-uglify");
var uglifycss = require("gulp-uglifycss");
var sourcemaps = require("gulp-sourcemaps");
var clean = require("gulp-clean");
var less = require("gulp-less");
var streamqueue = require("streamqueue");


gulp.task("css-task", gulp.series(
    function () {
        var lessStream = gulp.src([
            "./Styles/bootstrap-theme-3.3.6/bootstrap.less",
            "./Styles/coffeeshop-theme.less"
        ]);

        var customCssStream = gulp.src([
            "./Styles/*.css"
        ]);

        return streamqueue({ objectMode: true },
                lessStream
                .pipe(print())
                .pipe(less()),
                customCssStream
                .pipe(print())
            )
            .pipe(concat("app.css"))
            .pipe(uglifycss())
            .pipe(gulp.dest("dist/css"));
    }
    )
);

gulp.task("vendors-task", gulp.series(
    function () {
        var vendorStream = gulp.src([
            "./bower_components/jquery/dist/jquery.min.js",
            "./bower_components/bootstrap/dist/js/bootstrap.min.js",
            "./bower_components/angularjs-ie8-build/dist/angular.min.js",
            "./bower_components/angular-route/angular-route.min.js",
            "./bower_components/jquery-autosize/jquery.autosize.min.js"
        ]);

        return vendorStream
            .pipe(print())
            .pipe(sourcemaps.init({ loadMaps: true }))
            .pipe(concat("vendors.js"))
            .pipe(sourcemaps.write("."))
            .pipe(gulp.dest("dist/js"));
    }
    )
);

gulp.task("spa-task", gulp.series(
    function () {
        var appStream = gulp.src(["./app/**/*.js"]);

        return appStream
            .pipe(print())
            .pipe(sourcemaps.init({ loadMaps: true }))
            .pipe(concat("app.js"))
            .pipe(uglify())
            .pipe(sourcemaps.write("."))
            .pipe(gulp.dest("dist/js"));
    }
    )
);

gulp.task("fonts-task", gulp.series(
    function () {
        var fontsStream = gulp.src([
            "./bower_components/bootstrap/dist/fonts/*",
            "../ThirdParty/google-fonts/*"
        ]);

        return fontsStream
            .pipe(gulp.dest("./dist/fonts/"));
    }
    )
);

gulp.task("ie8-task", gulp.series(
    function () {
        var scriptsStream = gulp.src([
            "./bower_components/html5shiv/dist/html5shiv.min.js",
            "./bower_components/respond/dest/respond.min.js",
            "./bower_components/es5-shim/es5-shim.min.js"
        ]);

        return scriptsStream
            .pipe(print())
            .pipe(concat("ie8.js"))
            .pipe(gulp.dest("dist/ie8"));
    }
    )
);

gulp.task("clean", gulp.series(
    function () {
        return gulp.src("dist", { read: false })
            .pipe(clean());
    }
    )
);

gulp.task("all", gulp.series(["css-task", "vendors-task", "spa-task", "fonts-task", "ie8-task"]));
