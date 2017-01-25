var peoplesearch = angular.module('peoplesearch', []);

peoplesearch.controller('PeoplesearchController', function PeopleimportController($scope, $http, $log, Person) {

    var queryButtonTextStd = "Search";
    var queryButtonTextBsy = "Searching...";

    $scope.queryButtonText = function () {
        return $scope.queryInProgress ? queryButtonTextBsy : queryButtonTextStd;
    }

    $scope.queryInProgress = false;


    $scope.triggerQuery = function () {
        var queryStartTime = new Date();
        $scope.queryInProgress = true;

        var people = Person.query({ limit: 10 }, function () {
            $scope.queryTime = (new Date() - queryStartTime) * .001;
            $scope.queryInProgress = false;
            $scope.result = people;
        });

    };

});