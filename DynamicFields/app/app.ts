/// <reference path="../typings/globals/angular/index.d.ts" />

import './main.less';

declare var form: any;
declare var saveFormUrl: string;
declare var editFormUrl: string;

let app = angular.module('form', []);

interface IFormData {
    Id: number;
    FormFields: any[];
    Fields: {
        DbFields: any[];
    }
}

class EditFormController {
    static $inject = ['$http'];
    constructor(private $http: ng.IHttpService) {
        this.form = form;
    }

    save() {
        this.saving = true;
        this.$http
            .post<any>(saveFormUrl, this.form)
            .then(res => {
                this.saving = false;
                if (this.form.Id === 0)
                    window.location.replace(editFormUrl + '/' + res.data.id);
            });
    }

    addHeadline() {
        this.form.FormFields.push({
            FieldType: 0,
            FormId: this.form.Id,
            Label: 'headline text'
        });
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
        move(this.form.FormFields, idx, idx - 1);
    }

    downField(f) {
        let idx = this.form.FormFields.indexOf(f);
        move(this.form.FormFields, idx, idx + 1);
    }

    getField(id) {
        return this.form.Fields.DbFields.filter(f => f.Id === id)[0];
    }

    form: IFormData;
    foo: any;
    saving: boolean;
}

app.controller('EditForm', EditFormController);

function move(arr, old_index, new_index) {
    if (new_index >= arr.length) {
        var k = new_index - arr.length;
        while ((k--) + 1) {
            this.push(undefined);
        }
    }
    arr.splice(new_index, 0, arr.splice(old_index, 1)[0]);
    return arr;
};