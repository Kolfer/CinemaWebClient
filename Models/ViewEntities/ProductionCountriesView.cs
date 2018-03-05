using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaWebClient.Models.ViewEntities
{
    public class ProductionCountriesView
    {
        public int Id;

        public string iso_3166_1;

        public string Name;

        public IList<MovieView> movies;

    }
}