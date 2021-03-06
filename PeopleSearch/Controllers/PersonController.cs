﻿using PeopleSearch.Models;
using PeopleSearch.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading;
using System.Web.Http;

namespace PeopleSearch.Controllers
{
    public class PersonController : ApiController
    {
        private IPeopleRepository peopleRepo;

        private const int MAX_PAGE_SIZE = 100;

        public PersonController() : base() {
            this.peopleRepo = new PeopleRepository();
        }

        public PersonController(PeopleRepository peopleRepo)
        {
            this.peopleRepo = peopleRepo;
        }

        /// <summary>
        /// Search for people by first/last name.
        /// </summary>
        /// <param name="limit">Number of results to return per request, maximum is 100.</param>
        /// <param name="offset">Number of records to skip (for paging).</param>
        /// <param name="sort">Sort direction for last name ['asc'|'dsc']</param>
        /// <param name="query">The name of the person being serched for. Example: "Ben Smith"</param>
        public ApiCollectionWrapper Get(int limit = 10, int offset = 0, string sort = "asc", string query = null)
        {
            // validate limit
            if(limit < 0)
            {
                throw new ArgumentOutOfRangeException("limit", "The limit must be greater than or equal to 1.");
            }
            else if(limit > MAX_PAGE_SIZE)
            {
                limit = MAX_PAGE_SIZE;
            }

            // validate sort
            if(sort != "asc" && sort != "dsc")
            {
                throw new ArgumentException("sort", "Sort must be either 'asc' or 'dsc'.");
            }

            ApiCollectionWrapper wrapper = new ApiCollectionWrapper();

            // get total count
            wrapper.Total = peopleRepo.Count(query);

            // a limit of 0 indicates that the consumer is only interested in the count, not the actual data. 
            if (limit != 0)
            {
                // simulate some processing time, between 1 and 5 seconds
                Random rnd = new Random();
                Thread.Sleep(rnd.Next(1000, 5000));
                wrapper.Data = peopleRepo.Search(limit, offset, sort, query);
            } else
            {
                wrapper.Data = new object[0];
            }

            wrapper.Limit = limit;
            wrapper.Offset = offset;
            wrapper.Sort = sort;
            wrapper.Query = query;            

            return wrapper;
        }
    }
}
