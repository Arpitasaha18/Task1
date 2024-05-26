ngApp.service("changeRequestFormService", function ($http) {
    this.GetChangeRequestForms = function () {
        return $http.get('/ChangeRequestForms/GetChangeRequestForms');
    };
    this.GetEmployees = function () {
        return $http.get('/ChangeRequestForms/GetEmployees');
    };
    this.Create = function (data) { 
        return $http.post('/ChangeRequestForms/Create', data);
    };

    this.Edit = function (id, data) {
        return $http.post('/ChangeRequestForms/Edit/' + id, data);
    };

    this.Delete= function (id) {
        return $http.delete('/ChangeRequestForms/Delete/' + id);
    };
    this.Details = function (id) {
        return $http.get('/changeRequestForms/Details/' + id);
    };

});
