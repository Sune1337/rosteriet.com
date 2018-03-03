module App.Controllers {

    interface IEmailController {

    }

    class EmailController implements IEmailController {

        private email: Dto.Email;
        private error: string;

        static $inject = ["constantService", "emailService", "$location"];

        constructor(
            private constantService: Services.ConstantService,
            private emailService: Services.EmailService,
            private $location: ng.ILocationService
        ) {
        }

        add() {
            this.emailService.add(this.constantService.apiEmailUri, this.email)
                .then(
                    data => { this.$location.path("/Email/Skickat"); },
                    error => { this.error = error; }
                );
        }

        clearError() {
            this.error = null;
        }
        
    }

    angular
        .module("app")
        .controller("EmailController", EmailController);

}
