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

        public IEnumerable<Person> Search(int limit, int offset, string sort, string query = null)
        {
            using (var db = peopleContextFactory.CreatePeopleContext())
            {
                IQueryable<Person> queryable = db.People;
                        
                if (!string.IsNullOrEmpty(query))
                {
                    queryable = queryable.Intersect(FormulatePersonNameClause(query, db));                    
                }

                if(sort == "asc")
                {
                    queryable = queryable.OrderBy(p => p.NameLast);
                } else
                {
                    queryable = queryable.OrderByDescending(p => p.NameLast);
                }

                return queryable.Skip(offset).Take(limit).ToList();                
            }
        }

        public int Count(string query = null)
        {
            using (var db = peopleContextFactory.CreatePeopleContext())
            {
                IQueryable<Person> queryable = db.People;

                if (!string.IsNullOrEmpty(query))
                {
                    queryable = queryable.Intersect(FormulatePersonNameClause(query, db));
                }

                return queryable.Count();
            }
        }

        public void Purge()
        {
            using (var db = peopleContextFactory.CreatePeopleContext())
            {
                db.Database.ExecuteSqlCommand("delete from People");
            }
        }

        private IQueryable<Person> FormulatePersonNameClause(String query, PeopleContext db)
        {
            var querySplit = query.Split(' ');
            IQueryable<Person> queryableAggregate = null;

            foreach (var queryPart in querySplit)
            {
                var curQueryable = Queryable.Where(db.People, p => p.NameFirst.ToLower().Contains(queryPart.ToLower())
                        || p.NameLast.ToLower().Contains(queryPart.ToLower()));

                queryableAggregate = queryableAggregate == null ? queryableAggregate = curQueryable : queryableAggregate.Intersect(curQueryable);
            }

            return queryableAggregate;
        }
    }
}