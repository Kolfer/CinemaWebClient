using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaWebClient.Models.ViewEntities
{
    public class JobView
    {
        public string name;

        public DepartmentView department;

        public IList<PeopleView> peoples;

    }
}