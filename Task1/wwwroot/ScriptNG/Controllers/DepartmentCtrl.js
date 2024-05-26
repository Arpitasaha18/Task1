ngApp.controller('departmentCtrl', ['$scope', 'departmentService', function ($scope, departmentService) {
    'use strict';

    $scope.departments = [];
    $scope.id = "";
    $scope.name = "";
    $scope.editMode = false;

    $scope.GetDepartments = function () {
        departmentService.GetDepartments().then(response => {
            $scope.departments = response.data;
        });
    };
    $scope.GetDepartments();

    $scope.Delete = function (id) {
        if (window.confirm("Are you sure?")) {
            departmentService.DeleteDepartment(id).then(response => {
                if (response.data) {
                    alert("Deleted successfully.");
                    $scope.GetDepartments();
                } else {
                    alert("Something went wrong. Cannot delete.");
                }
            });
        }
    };

    $scope.Create = function () {
        var data = {
            name: $scope.name
        };
        departmentService.CreateDepartment(data).then(response => {
            alert(response.data);
            $scope.GetDepartments();
            $scope.ResetFields();
        });
    };

    $scope.Edit = function (id, name) {
        $scope.id = id;
        $scope.name = name;
        $scope.editMode = true;
    };

    $scope.Update = function () {
        var data = {
            id: $scope.id,
            name: $scope.name
        };
        departmentService.EditDepartment($scope.id, data).then(response => {
            alert(response.data);
            $scope.GetDepartments();
            $scope.ResetFields();
        }).catch(function (error) {
            alert("Error: " + error.data);
        });
    };

    $scope.ResetFields = function () {
        $scope.id = "";
        $scope.name = "";
        $scope.editMode = false;
    };
}]);



