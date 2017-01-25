using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PeopleSearch.Repositories
{
    public class PeopleContextFactory : IPeopleContextFactory
    {
        public PeopleContext CreatePeopleContext()
        {
            return new PeopleContext();
        }
    }
}