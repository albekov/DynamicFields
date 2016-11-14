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
        this.form.FormFields.push({ FieldType: 0, Label: 'headline text', FormId: this.form.Id });
    };
    EditFormController.prototype.addField = function (f) {
        //this.form.FormFields.push({ FieldType: 0, Label: 'headline text' });
        console.log('add', f);
    };
    EditFormController.$inject = ['$http'];
    return EditFormController;
}());
app.controller('EditForm', EditFormController);
//# sourceMappingURL=main.js.map