module App.Services {

    interface IEmailService {
        add(resource: string, entity: Dto.IEmail): ng.IPromise<any>;
    }

    export class EmailService implements IEmailService {
        
        static $inject = ["$http", "$q"];

        constructor(
            private $http: ng.IHttpService,
            private $q: ng.IQService
        ) {

        }

        add(resource: string, entity: Dto.IEmail): ng.IPromise<any> {
            const self = this;

            return this.$http.post(resource, entity)
                .then(
                    result => result.data,
                    error => self.$q.reject(error && error.data && error.data.Message)
                );
        }
    }

    angular
        .module("app")
        .service("emailService", EmailService);

}
