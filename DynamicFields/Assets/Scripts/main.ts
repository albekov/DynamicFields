/// <reference path="typings/angularjs/angular.d.ts" />

declare var form: any;
declare var saveFormUrl: string;

let app = angular.module('form', []);

interface IFormData {
    Id: number;
    FormFields: any[];
}

class EditFormController {
    static $inject = ['$http'];
    constructor(private $http: ng.IHttpService) {
        this.foo = 'bar';
        this.form = form;
    }

    save() {
        this.$http.post(saveFormUrl, this.form);
    }

    addHeadline() {
        this.form.FormFields.push({ FieldType: 0, Label: 'headline text', FormId: this.form.Id });
    }

    addField(f) {
        //this.form.FormFields.push({ FieldType: 0, Label: 'headline text' });
        console.log('add', f);
    }

    form: IFormData;
    foo: any;
}

app.controller('EditForm', EditFormController);
