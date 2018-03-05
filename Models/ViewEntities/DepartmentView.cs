using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaWebClient.Models.ViewEntities
{
    public class DepartmentView
    {

        public string name;

        public IList<JobView> jobs;

    }
}