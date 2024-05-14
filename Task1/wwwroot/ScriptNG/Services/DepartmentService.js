ngApp.service("departmentService", function ($http) {

    this.GetDepartments = function () {
        return $http.get('/Departments/GetDepartments');
    }
    this.DeleteDepartment = function (id) {
        return $http.delete('/Departments/Delete/' + id);
    }
    this.EditDepartment = function (id) {
        return $http.delete('/Departments/Edit/' + id);
    }
})
