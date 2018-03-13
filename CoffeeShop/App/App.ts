module App {

    class Config {

        static $inject = ['$routeProvider', '$locationProvider'];

        constructor($routeProvider: ng.route.IRouteProvider, $locationProvider: ng.ILocationProvider) {
            $routeProvider
                .when("/",
                    {
                        templateUrl: "/App/Templates/Home.html"
                    })
                .when("/Kontakt",
                    {
                        templateUrl: "/App/Templates/Kontakt.html",
                        controller: "EmailController as emailController"
                    })
                .when("/Email/Skickat",
                    {
                        templateUrl: "/App/Templates/EmailSent.html"
                    })
                .when("/Kaffe/Sortiment/LokaltProducerat",
                    {
                        templateUrl: "/App/Templates/Kaffe/Sortiment/LokaltProducerat.html"
                    })
                .when("/Kaffe/Sortiment/Kärnkaffe",
                    {
                        templateUrl: "/App/Templates/Kaffe/Sortiment/Kärnkaffe.html"
                    })
                .when("/Kaffe/Prislista",
                    {
                        templateUrl: "/App/Templates/Kaffe/Prislista.html"
                    })
                .when("/DackeKultur",
                    {
                        templateUrl: "/App/Templates/DackeKultur/Index.html"
                   })
                .when("/ÅsedaHIFI",
                    {
                        templateUrl: "/App/Templates/ÅsedaHIFI/Index.html"
                    })
                .when("/Nyheter",
                    {
                    templateUrl: "/App/Templates/Nyheter.html"
                    })
                .otherwise({ redirectTo: "/" });

            $locationProvider.html5Mode(true);
        }
    }

    angular
        .module("app", ["ngRoute"])
        .config(Config)
        .run([
            "$rootScope", $rootScope => {
                // Register code to run when route changes.
                $rootScope.$on("$routeChangeSuccess",
                    () => {
                        if (typeof window.updateSusnetCounter !== "undefined") {
                            // Invoke Susnet counter.
                            window.updateSusnetCounter();
                        }
                    });
            }
        ]);

}
