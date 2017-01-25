describe('PeopleimportController', function () {

    beforeEach(module('peopleimport'));

    it('should return a string representing the import button text', inject(function ($controller) {
        var scope = {},
            http = {},
            log = {},
            person = {};

        var ctrl = $controller('PeopleimportController', { $scope: scope, $http: http, $log: log, Person: person  });

        expect(scope.importButtonText()).toBe('Import');
    }));
});