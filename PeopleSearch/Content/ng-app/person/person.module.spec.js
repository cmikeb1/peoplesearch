describe('Person', function () {
    var $httpBackend;
    var Person;

    beforeEach(function () {
        jasmine.addCustomEqualityTester(angular.equals);
    });

    beforeEach(module('person'));

    beforeEach(inject(function (_$httpBackend_, _Person_) {
        $httpBackend = _$httpBackend_;
        $httpBackend.expectGET('/api/Person?limit=10&offset=0&sort=asc').respond(personData);

        Person = _Person_;
    }));

    // Verify that there are no outstanding expectations or requests after each test
    afterEach(function () {
        $httpBackend.verifyNoOutstandingExpectation();
        $httpBackend.verifyNoOutstandingRequest();
    });

    it('should fetch the person data from `/api/Person`', function () {
        var people = Person.query();

        $httpBackend.flush();
        expect(people).toEqual(personData);
    });

    var personData = {
        "Data": [
          {
              "Id": 337,
              "NameFirst": "sylvia",
              "NameLast": "alexander                                         ",
              "NameTitle": "mrs",
              "AddressStreet": "6959 robinson rd",
              "AddressCity": "aubrey",
              "AddressState": "georgia",
              "AddressPostcode": "55160     ",
              "Username": "beautifulfish652",
              "PictureLarge": "https://randomuser.me/api/portraits/women/61.jpg",
              "PictureMedium": "https://randomuser.me/api/portraits/med/women/61.jpg",
              "PictureThumbnail": "https://randomuser.me/api/portraits/thumb/women/61.jpg",
              "Phone": "(420)-081-4232",
              "CreatedDatetime": "0001-01-01T00:00:00"
          }
        ],
        "Total": 1000,
        "Limit": 1,
        "Offset": 0,
        "Sort": 'dsc',
        "Query": null
    }
});