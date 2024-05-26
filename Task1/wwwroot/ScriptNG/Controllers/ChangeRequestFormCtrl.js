ngApp.controller('changeRequestFormCtrl', ['$scope', 'changeRequestFormService', 'gridregistrationservice', 'uiGridConstants', function ($scope, changeRequestFormService, gridregistrationservice, uiGridConstants) {
    'use strict'; 
     $scope.id = '';
    $scope.projectName = '';
    $scope.moduleName = '';
    $scope.empId = '';
    $scope.requestDate = '';
    $scope.changeRequestDetails = '';
    $scope.status = '';
    $scope.signature = '';
    $scope.changeRequestForms = [];
    $scope.GetEmployees = [];
    $scope.editMode = false;
    $scope.modalData = {};

 
    $scope.GetChangeRequestForms = function () {
        changeRequestFormService.GetChangeRequestForms().then(function (response) {
            console.log(response.data);
            $scope.changeRequestForms = response.data;
        }).catch(function (error) {
            console.error('Error fetching change request forms:', error);
        });
    };

    $scope.GetChangeRequestForms();

    $scope.GetEmployees = function () {
        changeRequestFormService.GetEmployees().then(function (response) {
            $scope.employees = response.data;
        }).catch(function (error) {
            console.error('Error fetching change request forms:', error);
        });
    };

    $scope.GetEmployees();
    //GetChangeRequestForms();
   
    $scope.Create = function () {
        console.log("projectName:", $scope.projectName);
        console.log("moduleName:", $scope.moduleName);
        console.log("requestById:", $scope.requestById);
        console.log("requestDate:", $scope.requestDate);
        console.log("changeRequestDetails:", $scope.changeRequestDetails);
        console.log("status:", $scope.status);
        console.log("signature:", $scope.signature);
        
        var data = {            
            projectName: $scope.projectName,
            moduleName: $scope.moduleName,
            requestById: parseInt($scope.requestById),
            requestDate: $scope.requestDate,
            changeRequestDetails: $scope.changeRequestDetails,
            status: $scope.status,
            signature: $scope.signature  
            //no image
        }
        console.log(projectName, moduleName, requestById, requestDate, changeRequestDetails, status, signature);
        changeRequestFormService.Create(data).then(function (response) {
            console.log(response.data)
           alert(response.data);
           $scope.GetChangeRequestForms();
           $scope.resetfields();
        });
    };

    $scope.Edit = function (id, projectName, moduleName, requestById, requestDate, changeRequestDetails, status, signature) {
            $scope.id = id,
            $scope.projectName = projectName;
            $scope.moduleName = moduleName;
            $scope.requestById = requestById;
            $scope.requestDate = new Date(requestDate.start);
            $scope.changeRequestDetails = changeRequestDetails;
            $scope.status = status;
            $scope.signature = signature;
            $scope.editMode = true;
    };

    $scope.Update = function () {
        var data = {
            Id: $scope.id,
            ProjectName: $scope.projectName,
            ModuleName: $scope.moduleName,
            RequestBy: $scope.requestById,
            RequestDate: $scope.requestDate,
            ChangeRequestDetails: $scope.changeRequestDetails,
            Status: $scope.status,
            Signature: $scope.signature  

        };
        changeRequestFormService.Edit($scope.id, data).then(response => {
            alert(response.data);
            $scope.GetChangeRequestForms();
            $scope.ResetFields();
        }).catch(function (error) {
            alert("Error: " + error.data);
        });
    };

    $scope.Delete = function (id) {
        if (window.confirm("Are you sure?")) {
            changeRequestFormService.Delete(id).then(response => {
                if (response.data) {
                    alert("Deleted successfully.");
                    $scope.GetChangeRequestForms();
                } else {
                    alert("Something went wrong. Cannot delete.");
                }
            });
        }
    };
   
    $scope.Details = function (id) {
        var selectedForm = $scope.changeRequestForms.find(response => response.id === id);

        if (selectedForm) {
            $scope.modalData = selectedForm;
            $('#detailsModal').modal('show');
        }
    };


    //grid
    $scope.gridOptionsList = gridregistrationservice.GridRegistration("Data");

    $scope.gridOptionsList.onRegisterApi = function (gridApi) {
        $scope.gridApi = gridApi;
        $scope.gridOptionsList.api = gridApi;
    }

    $scope.gridOptionsList.columnDefs = [
        { name: 'Sl.', field: 'ROW_NO', enableFiltering: false, width: 50 },
        { name: 'projectName', field: 'projectName', displayName: 'Project Name', width: '15%' },
        {
            name: 'moduleName', field: 'moduleName', displayName: 'Module Name', width: '10%',
        },
        {
            name: 'requestByName', field: 'requestByName', displayName: 'Requested By', width: '20%'
        },
        //{
        //     name: 'requestByDeptName', field: 'requestByDeptName', displayName: 'Department', width: '10%',
        //},
        //{
        //    name: 'requestDate', field: 'requestDate', displayName: 'Request Date', width: '10%',
        //},
        //{
        //    name: 'changeRequestDetails', field: 'changeRequestDetails', displayName: 'Details', width: '10%',
        //},
        //{
        //    name: 'status', field: 'status', displayName: 'Status', width: '10%',
        //},
        //{
        //    name: 'authorizedSignature', field: 'authorizedSignature', displayName: 'Signature', width: '10%',
        //},
        //{
        //    name: 'employeeName', field: 'employeeName', displayName: 'Employee Name', width: '10%',
        //},
        {
            name: 'action', field: 'action', displayName: 'Actions', width: '10%',
        },
    ]
    $scope.gridOptionsList.showColumnFooter = true;
    $scope.gridOptionsList.data = [];






   

    $scope.resetFields = function () {
        $scope.id = '';
        $scope.projectName = '';
        $scope.moduleName = '';
        $scope.empId = '';
        $scope.requestDate = '';
        $scope.changeRequestDetails = '';
        $scope.status = '';
        $scope.signature = '';
        $scope.editMode = false;
    };

}]);
