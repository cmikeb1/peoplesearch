using PeopleSearch.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PeopleSearch.Repositories
{
    public interface IRandomPeopleRepository
    {
        IEnumerable<RandomPerson> FetchRandomPeople(int importCount);
    }
}