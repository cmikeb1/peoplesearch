var peopleApp = angular.module('peopleApp', ['peoplesearch', 'peopleimport', 'ui.bootstrap', 'ngResource']);


peopleApp.controller('PeopleAppController', function PeopleimportController($scope, $http, $log) {

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


peopleApp.factory('Person', ['$resource',
    function ($resource) {
        return $resource('/api/Person/:id', {}, {
            query: {
                method: 'GET',
                params: {limit: 10, offset: 0, query: null},
                isArray: false
            }
        });
    }
]);