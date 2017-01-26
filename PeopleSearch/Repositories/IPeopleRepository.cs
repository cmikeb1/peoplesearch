using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleSearch.Repositories
{
    public interface IPeopleRepository
    {
        Person Add(Person person);
        IEnumerable<Person> Add(IEnumerable<Person> person);
        IEnumerable<Person> Search(int limit, int offset, String sort, String query = null);
        int Count(String query = null);
        void Purge();
    }
}