using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PeopleSearch.Models
{
    public class ApiCollectionWrapper
    {
        public int Total { get; set; }
        public int Limit { get; set; }
        public int Offset { get; set; }
        public string Sort { get; set; }
        public string Query { get; set; }
        public IEnumerable<object> Data;
    }
}