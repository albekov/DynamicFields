/// <reference path="typings/angularjs/angular.d.ts" />
var app = angular.module('form', []);
var EditFormController = (function () {
    function EditFormController($http) {
        this.$http = $http;
        this.foo = 'bar';
        this.form = form;
    }
    EditFormController.prototype.save = function () {
        this.$http.post(saveFormUrl, this.form);
    };
    EditFormController.prototype.addHeadline = function () {
        this.form.FormFields.push({ FieldType: 0, FormId: this.form.Id, Label: 'headline text' });
    };
    EditFormController.prototype.addField = function (f) {
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
    };
    EditFormController.prototype.deleteField = function (f) {
        var idx = this.form.FormFields.indexOf(f);
        if (idx > -1)
            this.form.FormFields.splice(idx, 1);
    };
    EditFormController.prototype.upField = function (f) {
        var idx = this.form.FormFields.indexOf(f);
        this.form.FormFields.move(idx, idx - 1);
    };
    EditFormController.prototype.downField = function (f) {
        var idx = this.form.FormFields.indexOf(f);
        this.form.FormFields.move(idx, idx + 1);
    };
    EditFormController.$inject = ['$http'];
    return EditFormController;
}());
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
