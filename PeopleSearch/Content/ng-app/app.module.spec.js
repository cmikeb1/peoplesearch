describe('PeopleAppController', function () {
    var $controller;

    beforeEach(function () {
        jasmine.addCustomEqualityTester(angular.equals);
    });

    beforeEach(module('peopleApp'));

    beforeEach(inject(function (_$controller_) {
        $controller = _$controller_;
    }));

    describe('$scope.addAlert', function () {
        it('should add an alert to the alert array', function () {
            var $scope = {};
            var controller = $controller('PeopleAppController', { $scope: $scope });
            $scope.alerts = [];
            $scope.addAlert('title', 'message', 'type');

            expect($scope.alerts.length).toEqual(1);

        });

        it('should add the alert object correctly', function () {
            var $scope = {};
            var controller = $controller('PeopleAppController', { $scope: $scope });
            $scope.alerts = [];
            $scope.addAlert('title', 'message', 'type');

            expect($scope.alerts[0]).toEqual({
                title: 'title',
                message: 'message',
                type: 'type'
            });
        });
    });

    describe('$scope.closeAlert', function () {
        it('should remove remove an alert', function () {
            var $scope = {};
            var controller = $controller('PeopleAppController', { $scope: $scope });
            $scope.alerts = [];
            $scope.addAlert('title1', 'message1', 'type1');
            $scope.addAlert('title2', 'message2', 'type2');

            $scope.closeAlert(0);

            expect($scope.alerts.length).toEqual(1);

        });

        it('should remove the correct alert', function () {
            var $scope = {};
            var controller = $controller('PeopleAppController', { $scope: $scope });
            $scope.alerts = [];
            $scope.addAlert('title1', 'message1', 'type1');
            $scope.addAlert('title2', 'message2', 'type2');

            $scope.closeAlert(0);

            expect($scope.alerts[0]).toEqual({
                title: 'title2',
                message: 'message2',
                type: 'type2'
            });

        });
    });
});