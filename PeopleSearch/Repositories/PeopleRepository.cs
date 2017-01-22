using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PeopleSearch.Repositories
{
    public class PeopleRepository : IPeopleRepository
    {
        PeopleContext db = new PeopleContext();

        public int PeopleCount()
        {
            return db.People.Count();
        }
    }
}