
ngApp.service('employeeService', function ($http) {
    this.GetEmployees = function () {
        return $http.get('/Employees/GetEmployees');
    };
    this.GetDepartments = function () {
        return $http.get('/Departments/GetDepartments');
    };
    this.CreateEmployee = function (data) {
        return $http.post('/Employees/Create', data);
    };

    this.Edit = function (id, data) {
        return $http.post('/Employees/Edit/' + id, data);
    };

    this.DeleteEmployee = function (id) {
        return $http.delete('/Employees/Delete/' + id);
    };
    this.Details = function (id) {
        return $http.get('/Employees/Details/' + id);
    }
});


