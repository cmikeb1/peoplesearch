﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PeopleSearch.Repositories
{
    public interface IPeopleContextFactory
    {
        PeopleContext CreatePeopleContext();
    }
}