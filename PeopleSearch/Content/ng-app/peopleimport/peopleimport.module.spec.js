describe('PeopleimportController', function () {
    var $controller;

    beforeEach(function () {
        jasmine.addCustomEqualityTester(angular.equals);
    });

    beforeEach(module('peopleimport'));

    beforeEach(inject(function (_$controller_) {
        $controller = _$controller_;
    }));

    describe('$scope.importButtonText()', function () {
        it('should return std value', function () {
            var $scope = {};
            var controller = $controller('PeopleimportController', { $scope: $scope });
            $scope.importInProgress = false;
            var actual = $scope.importButtonText();

            expect(actual).toEqual("Import");
        });

        it('should return bsy value during import', function () {
            var $scope = {};
            var controller = $controller('PeopleimportController', { $scope: $scope });
            $scope.importInProgress = true;
            var actual = $scope.importButtonText();

            expect(actual).toEqual("Importing...");
        });
    });
});