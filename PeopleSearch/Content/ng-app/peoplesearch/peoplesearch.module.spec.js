describe('PeoplesearchController', function () {
    var $controller;

    beforeEach(function () {
        jasmine.addCustomEqualityTester(angular.equals);
    });

    beforeEach(module('peoplesearch'));

    beforeEach(inject(function (_$controller_) {
        $controller = _$controller_;
    }));

    describe('$scope.queryButtonText()', function () {
        it('should return std value', function () {
            var $scope = {};
            var controller = $controller('PeoplesearchController', { $scope: $scope });
            $scope.queryInProgress = false;
            var actual = $scope.queryButtonText();

            expect(actual).toEqual("Search");
        });

        it('should return bsy value during query', function () {
            var $scope = {};
            var controller = $controller('PeoplesearchController', { $scope: $scope });
            $scope.queryInProgress = true;
            var actual = $scope.queryButtonText();

            expect(actual).toEqual("Searching...");
        });
    });
});