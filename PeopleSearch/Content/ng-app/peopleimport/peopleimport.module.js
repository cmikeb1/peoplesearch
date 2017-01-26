var peopleimport = angular.module('peopleimport', ['person']);


peopleimport.controller('PeopleimportController', function PeopleimportController($scope, $http, $log, Person) {

    var importButtonTextStd = "Import";
    var importButtonTextBsy = "Importing...";

    var purgeButtonTextStd = "Start the purge";
    var purgeButtonTextBsy = "Purging...";

    $scope.importButtonText = function () {
        return $scope.importInProgress ? importButtonTextBsy : importButtonTextStd;
    }
    $scope.purgeButtonText = function () {
        return $scope.purgeInProgress ? purgeButtonTextBsy : purgeButtonTextStd;
    }

    $scope.importInProgress = false;
    $scope.purgeInProgress = false;

    $scope.triggerImport = function () {
        $scope.importInProgress = true;
        $scope.personCount = undefined;
        $http({
            method: 'POST',
            url: '/PeopleImport/Import',
            data: $.param({ importCount: $scope.importCount }),
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
        }).then(function successCallback(response) {
            $scope.importInProgress = false;
            $scope.addAlert('Success!', 'Imported ' + response.data.length + ' people.', 'success');
            $scope.importCount = null;
            updatePersonCount();
        }, function errorCallback(response) {
            $log.error(response);
            $scope.importInProgress = false;
            $scope.addAlert('Whoops!', response.data.message, 'danger')
        });
    }

    $scope.triggerPurge = function () {
        $scope.purgeInProgress = true;
        $http({
            method: 'POST',
            url: '/PeopleImport/Purge',
            headers: { 'Content-Type': 'application/x-www-form-urlencoded' }
        }).then(function successCallback(response) {
            $scope.purgeInProgress = false;
            $scope.addAlert('Success!', response.data.message, 'success');
            updatePersonCount();
        }, function errorCallback(response) {
            $log.error(response);
            $scope.purgeInProgress = false;
            $scope.addAlert('Whoops!', response.data.message, 'danger')
        });
    }

    $scope.debug = function (debug) {
        $log.info(debug);
        return false;
    }

    function updatePersonCount() {
        var people = Person.query({ limit: 0 }, function () {
            $scope.personCount = people.Total;
        });       
    }

    updatePersonCount();
});