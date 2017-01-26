var peopleApp = angular.module('peopleApp', ['person', 'peoplesearch', 'peopleimport', 'ui.bootstrap', 'ngResource']);


peopleApp.controller('PeopleAppController', function PeopleimportController($scope) {

    $scope.alerts = [];

    $scope.addAlert = function (title, message, type) {
        $scope.alerts.push({
            title: title,
            message: message,
            type: type
        });
    }

    $scope.closeAlert = function (index) {
        $scope.alerts.splice(index, 1);
    }
});