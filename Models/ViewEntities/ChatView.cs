using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaWebClient.Models.ViewEntities
{
    public class ChatView
    {
        public int NumberId;

        public string Name;

        public bool IsPersonal;

        public string PathOfPhoto;

        public IList<MessageView> messages;

        public IList<UserView> users;

        //----------------------------------------------------------------//

        public Tuple<UserView, UserView> getUserPair(string senderName)
        {
            if (IsPersonal)
            {
                return users[0].Name == senderName
                       ? Tuple.Create(users[0], users[1])
                       : Tuple.Create(users[1], users[0]);
            }          
            return null;
        }

        //----------------------------------------------------------------//

        public UserView getAnotherUser(string senderName)
        {
            if (IsPersonal)
            {
                return users[0].Name != senderName
                       ? users[0] : users[1];
            }
            return null;
        }

        //----------------------------------------------------------------//

    }
}