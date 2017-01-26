var person = angular.module('person', ['ngResource']);

person.factory('Person', ['$resource',
        function ($resource) {
            return $resource('/api/Person', {}, {
                query: {
                    method: 'GET',
                    params: { limit: 10, offset: 0, query: null, sort: 'asc' },
                    isArray: false
                }
            });
        }
]);