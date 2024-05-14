ngApp.controller('deapartmentCtrl', ['$scope', 'departmentService', 'gridregistrationservice', 'notificationservice', function ($scope, departmentService, permissionProvider, gridregistrationservice, notificationservice) {
    'use strict'

    $scope.departments = [];

    $scope.id = "";
    $scope.name = "";

    $scope.GetDepartments = function () {
        departmentService.GetDepartments().then(response => {
            console.log(response.data)
            $scope.departments = response.data;
        })
    }
    $scope.GetDepartments();

    $scope.Delete = function (id) {
        if (window.confirm("Are you sure?")) {
            console.log(id)
            //delete
            departmentService.DeleteDepartment(id).then(response => {
                //notificationservice.Notification("Successfully deleted", response.data, "Cannot delete.")
                if (response.data) {
                    alert("deleted")
                    $scope.GetDepartments();
                }
                else {
                    alert("something went wrong. cannot delete")
                }
            })
        }
    }

    $scope.Create = function () {
        var data = {
            id: $scope.id,
            name: $scope.name
        }
        console.log(data)
        departmentService.Create(data).then(response => {
            console.log(reponse.data);
        })
    }

    $scope.Edit = function (id, name) {
        $scope.id = id;
        $scope.name = name;
    }
}])