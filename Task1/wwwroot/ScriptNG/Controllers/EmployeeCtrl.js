ngApp.controller('employeeCtrl', ['$scope', 'employeeService', function ($scope, employeeService) {
    'use strict';

    $scope.employees = [];
    $scope.departments = [];
    $scope.id = "";
    $scope.name = "";
    $scope.departmentId = "";
    $scope.editMode = false;
    $scope.modalData = {};
    $scope.GetEmployees = function () {
        employeeService.GetEmployees().then(function (response) {
            $scope.employees = response.data;
        });
    };
    $scope.GetEmployees();
    $scope.GetDepartments = function () {
        employeeService.GetDepartments().then(function (response) {
            $scope.departments = response.data;
        });
    };
    $scope.GetDepartments();
    $scope.CreateEmployee = function () {
        var data = {
            name: $scope.name,
            departmentId: $scope.departmentId
        };

        employeeService.CreateEmployee(data).then(function (response) {
            alert(response.data);
            $scope.GetEmployees();
            $scope.ResetFields();
        }).catch(function (error) {
            console.error("Error during creation:", error);
        });
    };

    

    $scope.Delete = function (id) {
        if (window.confirm("Are you sure!")) {
            employeeService.DeleteEmployee(id).then(response => {
                if (response.data) {
                    alert("deleted successfully.");
                    $scope.GetEmployees();
                }
                else {
                    alert("Something went wrong!")
                }
            });
        }
    };


    $scope.Edit = function (id, name, departmentId) {
        $scope.id = id;
        $scope.name = name;
        $scope.departmentId = departmentId;
        $scope.editMode = true;
    };

    $scope.Update = function () {
        var data = {
            id: $scope.id,
            name: $scope.name,
            departmentId: $scope.departmentId
        };
        employeeService.Edit($scope.id, data).then(response => {
            alert(response.data);
            $scope.GetEmployees();
            $scope.ResetFields();
        }).catch(function (error) {
            alert("Error: " + error.data);
        });
    };
    
    $scope.Details = function () {
        var data = $scope.employees.find(response => response.id == id);
        if (data) {
            $scope.modalData = data;
            $('#detailsModal').modal('show');
        }
    }
    $scope.ResetFields = function () {
        $scope.id = "";
        $scope.name = "";
        $scope.departmentId = "";
        $scope.editMode = false;
    };

}]);