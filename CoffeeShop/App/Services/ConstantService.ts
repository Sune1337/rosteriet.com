module App.Services {

    interface IConstant {
        apiEmailUri: string;
    }

    export class ConstantService implements IConstant {
        apiEmailUri: string;

        constructor() {
            this.apiEmailUri = "/api/email/";
        }
    }

    angular
        .module("app")
        .service("constantService", ConstantService);

}
