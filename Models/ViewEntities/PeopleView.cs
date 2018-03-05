using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaWebClient.Models.ViewEntities
{
    public class PeopleView
    {
        public int id;

        public string imdb_id;

        public string name;

        public string biography;

        public int gender;

        public string homepage;

        public string birthday;

        public string deathday;

        public string place_of_birth;

        public string profile_path;

        public double popularity;

        public List<CastView> casts;

        public List<CrewView> crews;

        public List<JobView> jobs;

        public List<UserView> usersWhoLiked;


        //----------------------------------------------------------------//

        public double getRatingCast()
        {
            double allVotes = 0;
            casts.ForEach((c) => allVotes += c.movie.vote_average);
            if (allVotes == 0 && casts.Count == 0)
            {
                return 0;
            }
            return allVotes / casts.Count;
        }

        //----------------------------------------------------------------//

        public double getRatingCrew()
        {
            double allVotes = 0;
            crews.ForEach((c) => allVotes += c.movie.vote_average);
            return allVotes / crews.Count;
        }

        //----------------------------------------------------------------//

        public int getCountMovie()
        {
            return casts.Distinct().Count() + crews.Distinct().Count();
        }

        //----------------------------------------------------------------//

        public IEnumerable<GenreView> getGenres()
        {
            List<GenreView> list = new List<GenreView>();
            casts.ForEach((cast) => list.AddRange(cast.movie.genre));
            crews.ForEach((crew) => list.AddRange(crew.movie.genre));
            return list.Distinct();
        }

        //----------------------------------------------------------------//

        public IEnumerable<MovieView> getBestMovies()
        {
            IEnumerable<MovieView> allMovies = casts.Select(c => c.movie).Union(crews.Select(c => c.movie));
            var movies = allMovies.OrderBy((m) => m.vote_average).ThenBy((m) => m.vote_average);
            return movies.Take(10);
        }

        //----------------------------------------------------------------//
    }
}