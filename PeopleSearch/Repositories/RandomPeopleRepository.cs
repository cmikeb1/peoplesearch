using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using PeopleSearch.Models;
using System.Net;
using System.IO;
using Newtonsoft.Json;

namespace PeopleSearch.Repositories
{
    public class RandomPeopleRepository : IRandomPeopleRepository
    {
        const string RANDOM_USER_URL = "https://randomuser.me/api/?results={0}&nat=us&inc=name,location,login,phone,picture";

        public IEnumerable<RandomPerson> FetchRandomPeople(int importCount)
        {
            var webrequest = (HttpWebRequest)WebRequest.Create(String.Format(RANDOM_USER_URL, importCount));
            var response = webrequest.GetResponse();
            var reader = new StreamReader(response.GetResponseStream());

            var result = reader.ReadToEnd();
            var resultAsString = Convert.ToString(result);

            RandomPersonWrapper randomPeopleWrapper = null;

            randomPeopleWrapper = JsonConvert.DeserializeObject<RandomPersonWrapper>(resultAsString);

            return randomPeopleWrapper.results;
        }
    }
}