using PeopleSearch.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PeopleSearch.Services
{

    public class PeopleImportService
    {
        IPeopleRepository peopleRepo = new PeopleRepository();

        public int PeopleCount()
        {
            return peopleRepo.PeopleCount();
        }
    }
}