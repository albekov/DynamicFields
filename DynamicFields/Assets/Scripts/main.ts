﻿/// <reference path="typings/angularjs/angular.d.ts" />

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
        this.form.FormFields.push({ FieldType: 0, FormId: this.form.Id, Label: 'headline text' });
    }

    addField(f) {
        //console.log(f);
        this.form.FormFields.push({
            FieldType: 1,
            FormId: this.form.Id,
            Label: f.Label,
            FieldId: f.Id,
            IsRequired: true,
            ShowLabel: true,
            Reference: f.Reference
        });
    }

    deleteField(f) {
        let idx = this.form.FormFields.indexOf(f);
        if (idx > -1)
            this.form.FormFields.splice(idx, 1);
    }

    upField(f) {
        let idx = this.form.FormFields.indexOf(f);
        this.form.FormFields.move(idx, idx - 1);
    }

    downField(f) {
        let idx = this.form.FormFields.indexOf(f);
        this.form.FormFields.move(idx, idx + 1);
    }

    form: IFormData;
    foo: any;
}

app.controller('EditForm', EditFormController);

Array.prototype['move'] = function (old_index, new_index) {
    if (new_index >= this.length) {
        var k = new_index - this.length;
        while ((k--) + 1) {
            this.push(undefined);
        }
    }
    this.splice(new_index, 0, this.splice(old_index, 1)[0]);
    return this; // for testing purposes
};