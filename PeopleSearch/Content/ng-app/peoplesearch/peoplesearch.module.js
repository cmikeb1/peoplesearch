var peoplesearch = angular.module('peoplesearch', []);

peoplesearch.controller('PeoplesearchController', function PeopleimportController($scope, $http, $log, Person) {    

    $scope.page = {};
    $scope.sort = 'asc';

    var queryButtonTextStd = "Search";
    var queryButtonTextBsy = "Searching...";    

    $scope.queryButtonText = function () {
        return $scope.queryInProgress ? queryButtonTextBsy : queryButtonTextStd;
    }

    $scope.queryInProgress = false;

    $scope.toggleSort = function () {
        if ($scope.sort === 'asc') {
            $scope.sort = 'dsc';
        } else {
            $scope.sort = 'asc';
        }
    }

    $scope.triggerQuery = function () {             
        $scope.page.current = 1;
        runQuery();
    };

    $scope.triggerPageChange = function () {
        runQuery();
    }

    function runQuery() {
        var queryStartTime = new Date();
        $scope.queryInProgress = true;
        var people = Person.query({ limit: 10, offset: ($scope.page.current - 1) * 10, sort: $scope.sort, query: $scope.query }, function () {
            $scope.queryTime = (new Date() - queryStartTime) * .001;
            $scope.queryInProgress = false;
            $scope.result = people;
        });
    }    

});