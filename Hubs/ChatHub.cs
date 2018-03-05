using Microsoft.AspNet.SignalR;
using System.Threading.Tasks;
using Microsoft.AspNet.SignalR.Hubs;
using System;
using CinemaWebClient.Models;

namespace CinemaWebService.Hubs
{
    [HubName("chatHub")]
    public class ChatHub : Hub
    {

        //----------------------------------------------------------------//

        public void SendPersonal(string message, string lastDate, int lastMsgId)
        {
            DateTime date;
            bool IsParse = DateTime.TryParse(lastDate, out date);
            var str_date = Extension.PublishDate(DateTime.Now, ref date);
            Clients.Caller.addMessage( lastMsgId, message, DateTime.Now.ToShortTimeString(),
                                       "message message-green", "right", str_date  );
            Clients.Others.addMessage(message, DateTime.Now.ToShortTimeString(),
                                       "message", "left", str_date);
        }

        //----------------------------------------------------------------//

        public void Typing(string sender)
        {
            Clients.Others.typing(sender);
        }

        //----------------------------------------------------------------//

        //TO DO
        public void SendGroup(string mailSender, string message, int chatId)
        {

        }

        //----------------------------------------------------------------//

        //TO DO 
        public void Connect(string userName)
        {

        }

        //----------------------------------------------------------------//

        //TO DO
        public override Task OnDisconnected(bool stopCalled)
        {

            return base.OnDisconnected(stopCalled);
        }

        //----------------------------------------------------------------//

    }
}