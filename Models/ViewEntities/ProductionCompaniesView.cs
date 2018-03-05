using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaWebClient.Models.ViewEntities
{
    public class ProductionCompaniesView
    {
        public string name;

        public IList<MovieView> movies;

        public override string ToString()
        {
            return name;
        }

    }
}