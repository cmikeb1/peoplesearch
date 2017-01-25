using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PeopleSearch.Repositories
{
    public class PeopleRepository : IPeopleRepository
    {
        private IPeopleContextFactory peopleContextFactory;

        public PeopleRepository()
        {
            this.peopleContextFactory = new PeopleContextFactory();
        }

        public PeopleRepository(IPeopleContextFactory peopleContextFactory)
        {
            this.peopleContextFactory = peopleContextFactory;
        }

        public Person Add(Person person)
        {
            using (var db = peopleContextFactory.CreatePeopleContext())
            {
                db.People.Add(person);
                db.SaveChanges();
                return person;
            }
        }

        public IEnumerable<Person> Add(IEnumerable<Person> people)
        {
            using (var db = peopleContextFactory.CreatePeopleContext())
            {
                db.People.AddRange(people).ToList();
                db.SaveChanges();
                return people.ToList(); ;
            }
        }

        public IEnumerable<Person> Search(int limit, int offset, string query = null)
        {
            using (var db = peopleContextFactory.CreatePeopleContext())
            {
                if (string.IsNullOrEmpty(query))
                {
                    return db.People.OrderBy(p => p.NameLast).Skip(offset).Take(limit).ToList();
                }

                throw new NotImplementedException();
            }
        }

        public int Count(string query = null)
        {
            using (var db = peopleContextFactory.CreatePeopleContext())
            {
                if (string.IsNullOrEmpty(query))
                {
                    return db.People.Count();
                }

                throw new NotImplementedException();
            }
        }

        public void Purge()
        {
            using (var db = peopleContextFactory.CreatePeopleContext())
            {
                db.Database.ExecuteSqlCommand("delete from People");
            }
        }
    }
}