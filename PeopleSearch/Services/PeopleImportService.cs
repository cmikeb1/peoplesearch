using Newtonsoft.Json;
using PeopleSearch.Models;
using PeopleSearch.Repositories;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;


namespace PeopleSearch.Services
{

    public class PeopleImportService
    {        
        private IPeopleRepository peopleRepo;
        private IRandomPeopleRepository randomPeopleRepo;

        private const int MAX_LOCAL_PEOPLE = 1000;

        public PeopleImportService()
        {
            this.peopleRepo = new PeopleRepository();
            this.randomPeopleRepo = new RandomPeopleRepository();
        }

        public PeopleImportService(IPeopleRepository peopleRepo, IRandomPeopleRepository randomPeopleRepo)
        {
            this.peopleRepo = peopleRepo;
            this.randomPeopleRepo = randomPeopleRepo;
        }

        public List<Person> ImportPeople(int importCount)
        {
            int currentPeopleCount = peopleRepo.Count();

            if(currentPeopleCount + importCount > MAX_LOCAL_PEOPLE)
            {
                throw new ArgumentOutOfRangeException("importCount", String.Format("The maximum number of people in the local database must not exceed {0}", MAX_LOCAL_PEOPLE));
            }

            var randomPeople = randomPeopleRepo.FetchRandomPeople(importCount).ToList();
            var people = randomPeople.ConvertAll(ConvertRandomPersonToPerson);

            return peopleRepo.Add(people).ToList();
        }

        public int Purge()
        {
            int currentPeopleCount = peopleRepo.Count();

            if(currentPeopleCount == 0)
            {
                return 0;
            }

            peopleRepo.Purge();

            return currentPeopleCount;
        }

        private Person ConvertRandomPersonToPerson(RandomPerson randomPerson)
        {
            var person = new Person();

            // name
            person.NameFirst = randomPerson.name.first;
            person.NameLast = randomPerson.name.last;
            person.NameTitle = randomPerson.name.title;

            // address
            person.AddressStreet = randomPerson.location.street;
            person.AddressCity = randomPerson.location.city;
            person.AddressPostcode = randomPerson.location.postcode;
            person.AddressState = randomPerson.location.state;

            // phone
            person.Phone = randomPerson.phone;

            // username
            person.Username = randomPerson.login.username;

            // picture
            person.PictureLarge = randomPerson.picture.large;
            person.PictureMedium = randomPerson.picture.medium;
            person.PictureThumbnail = randomPerson.picture.thumbnail;

            return person;
        }
    }
}