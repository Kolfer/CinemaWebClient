using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaWebClient.Models.ViewEntities
{
    public class CastView
    {
        public string character;

        public string Name;

        public int Gender;

        public int Orders;

        public PeopleView people;

        public MovieView movie;
    }
}