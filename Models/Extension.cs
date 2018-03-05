using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Text;

namespace CinemaWebClient.Models
{
    public static class Extension
    {

        //----------------------------------------------------------------//

        public static string RedirectUrl(Uri preRequest, Uri request)
        {
            if (preRequest != null && preRequest.Host == request.Host 
                            && request != preRequest)
            {
                return preRequest.AbsoluteUri;
            }
            return request.AbsoluteUri.Replace(request.AbsolutePath, "/");
        }

        //----------------------------------------------------------------//

        public static string CollectionAsString<T>(this IEnumerable<T> enumerable)
        {
            StringBuilder stringBuilder = new StringBuilder();
            foreach(var item in enumerable)
            {
                if (item.Equals(enumerable.Last()))
                {
                    stringBuilder.Append(item.ToString());
                }
                else
                {
                    stringBuilder.AppendFormat(item.ToString() + ", ");
                }
            }
            return stringBuilder.ToString();
        }

        //----------------------------------------------------------------//

        public static string GenderAsStr(bool? gender)
        {
            switch (gender)
            {
                case null:
                    return "Unknown";
                case true:
                    return "Female";
                case false:
                    return "Male";
                default:
                    return null;
            }
        }

        //----------------------------------------------------------------//

        public static string PublishDate(DateTime dateTimeMsg, ref DateTime tempDate)
        {
            DateTime currentDate = DateTime.Now;
            if (dateTimeMsg.Date != tempDate.Date)
            {
                if (currentDate.Year - dateTimeMsg.Year > 0)
                {
                    return PublishDate(dateTimeMsg.ToString("D"));
                }
                else if (currentDate.Month - dateTimeMsg.Month > 0)
                {
                    return PublishDate(dateTimeMsg.ToString("M"));
                }
                else
                {
                    return PublishDate(dateTimeMsg.DayOfWeek.ToString());
                }
            }
            return null;
        }

        //----------------------------------------------------------------//

        public static string PublishDate(string date)
        {
            TagBuilder div = new TagBuilder("div");
            div.AddCssClass("row");
            div.AddCssClass("dateOnChat");
            div.InnerHtml += date;
            TagBuilder div2 = new TagBuilder("div");
            div2.MergeAttribute("style", "clear:both");
            return div.ToString() + div2.ToString();
        }

        //----------------------------------------------------------------//

        public static string ToPresentationFormat(this DateTime dateTime)
        {
            if (dateTime != null)
            {
                TimeSpan diff = DateTime.Now - dateTime;
                if (diff.TotalHours > 23)
                {
                    return (diff.TotalDays > 2)
                             ? dateTime.ToString("d")
                             : "yesterday";
                }
                else
                {
                    return dateTime.ToShortTimeString();
                }
            }
            return null;
        }
    }
}