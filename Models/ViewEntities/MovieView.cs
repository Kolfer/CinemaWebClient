using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaWebClient.Models.ViewEntities
{
    public class MovieView
    {
        public int Id;

        public Dictionary<string, string> belongs_to_collection;

        public bool adult;

        public string backdrop_path;

        public int Budget;

        public string Imdb_id;

        public string Original_language;

        public string Original_titile;

        public string overview;

        public string Popularity;

        public string poster_path;

        public string release_date;

        public int revenue;

        public int? Runtime;

        public string title;

        public double vote_average;

        public int vote_count;

        public string tagline;

        public string Status;

        public IList<CastView> casts;

        public IList<CrewView> crews;

        public IList<GenreView> genre;

        public IList<ProductionCompaniesView> productionCompanies;

        public IList<ProductionCountriesView> productionCountries;

        public override string ToString()
        {
            return title;
        }
    }
}