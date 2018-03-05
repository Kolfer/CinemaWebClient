using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaWebClient.Models.ViewEntities
{
    public class UserView
    {
        public string Name;

        public string UserPassword;

        public DateTime AddedDate;

        public DateTime? LastVisitDate;

        public string country;

        public string city;

        public bool? gender;

        public string condition;

        public bool isOnline;

        public string PathOfPhoto;

        public int countChats;

        public int countFriends;

        public int countLikedMovies;

        public int countLikedPeople;

        public int countAppreciated;

        public int countWillWatch;

        public IList<UserView> Friends;

        public IList<ChatView> chats;

        public IList<MovieView> likedMovie;

        public IList<MovieView> willWatch;

        public IList<MovieView> appreciated;

        public IList<PeopleView> likedPeople;

        public IList<MessageView> SentMessages;

        public IList<MessageView> ReceiverMessages;

        //----------------------------------------------------------------//

        public bool HasFriend(string name)
        {
            return Friends.Any(friend => friend.Name == name);
        }

        //----------------------------------------------------------------//

        public string LastSeen()
        {
            string lastSeen = null;
            if (LastVisitDate != null)
            {
                lastSeen = "last seen ";
                TimeSpan diff = DateTime.Now - LastVisitDate.Value;
                if (diff.TotalHours > 23)
                {
                    lastSeen += (diff.TotalDays > 2)
                                ? LastVisitDate.Value.ToLongDateString()
                                : string.Format("{0} {1}",
                                "yesterday", LastVisitDate.Value.ToShortTimeString());
                }
                else
                {
                    lastSeen += (diff.TotalHours > 0)
                                ? Convert.ToInt32(diff.TotalHours) + "hours"
                                : Convert.ToInt32(diff.TotalMinutes.ToString()) + "minutes";
                }
            }
            return lastSeen;
        }

        //----------------------------------------------------------------//
    }
}