ngApp.service("departmentService", function ($http) {

    this.GetDepartments = function () {
        return $http.get('/Departments/GetDepartments');
    };

    this.CreateDepartment = function (data) {
        return $http.post('/Departments/Create', data);
    };

    this.EditDepartment = function (id, data) {
        return $http.post('/Departments/Edit/' + id, data);
    };

    this.DeleteDepartment = function (id) {
        return $http.delete('/Departments/Delete/' + id);
    };

});

