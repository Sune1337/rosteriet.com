module App.Controllers {

    interface INavbarController {
        
    }

    class NavbarController implements INavbarController {

        static $inject = ['$location'];

        constructor(private $location: ng.ILocationService) {
        }

        public isActive(url: string, hash: string = "") {
            return this.$location.path().indexOf(url) === 0 && this.$location.hash().indexOf(hash) === 0;
        }

    }

    angular
        .module("app")
        .controller("NavbarController", NavbarController);

}
