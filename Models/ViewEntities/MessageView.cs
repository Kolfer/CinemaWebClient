using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CinemaWebClient.Models.ViewEntities
{
    public class MessageView
    {
        public int id;

        public string Text;

        public bool IsViewed;

        public UserView Sender;

        public UserView Receiver;

        public ChatView Chat;

        public DateTime DateSend;

        public DateTime? DateLastChange;

        //----------------------------------------------------------------//

        public string PartMessage(int maxLengthPart, string substring = null)
        {
            int lengthPoints = 3;
            string points = "...";
            int length = Text.Length > maxLengthPart
                         ? maxLengthPart : Text.Length;
            if (substring == null)
            {
                return (length == Text.Length)
                        ? Text.Substring(0, length)
                        : Text.Substring(0, length - lengthPoints) + points;
            }
            else
            {
                int halfLength = maxLengthPart / 2;
                int indexOfStr = Text.IndexOf(substring);
                int startIndex = indexOfStr > halfLength
                                 ? indexOfStr - halfLength
                                 : 0;
                int count = (startIndex == 0)
                                ? (length < maxLengthPart)
                                  ? length : length - lengthPoints
                                : (Text.Length - startIndex < halfLength)
                                    ? Text.Length - startIndex
                                    : length - lengthPoints;
                return (startIndex == 0 ? string.Empty : points)
                        + Text.Substring(startIndex, count)
                        + (count + startIndex == Text.Length
                           ? string.Empty : points);
            }
        }

        //----------------------------------------------------------------//

    }
}