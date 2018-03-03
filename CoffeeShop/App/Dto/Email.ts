module App.Dto {

    export interface IEmail {
        from?: string;
        message?: string;
    }

    export class Email implements IEmail {
        constructor(
            public from?: string,
            public message?: string
        ) {

        }
    }

}
