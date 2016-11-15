/// <reference path="typings/angularjs/angular.d.ts" />
var app = angular.module('form', []);
var EditFormController = (function () {
    function EditFormController($http) {
        this.$http = $http;
        this.foo = 'bar';
        this.form = form;
    }
    EditFormController.prototype.save = function () {
        var _this = this;
        this.saving = true;
        this.$http
            .post(saveFormUrl, this.form)
            .then(function () { return _this.saving = false; });
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
        move(this.form.FormFields, idx, idx - 1);
    };
    EditFormController.prototype.downField = function (f) {
        var idx = this.form.FormFields.indexOf(f);
        move(this.form.FormFields, idx, idx + 1);
    };
    EditFormController.$inject = ['$http'];
    return EditFormController;
}());
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
}
;
//# sourceMappingURL=main.js.map