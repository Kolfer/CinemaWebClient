using CinemaWebClient.Models.Identity;
using CinemaWebClient.Models.ViewEntities;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;


namespace CinemaWebClient.Models
{
    public class ClientService
    {
        private static HttpClient client = new HttpClient();

        private static readonly UserSession userSession = new UserSession();


        //----------------------------------------------------------------//

        public static void AddToken()
        {
            if (!client.DefaultRequestHeaders.Contains("Bearer"))
            {
                client.DefaultRequestHeaders.Authorization =
                   new AuthenticationHeaderValue("Bearer", userSession.BearerToken);
            }
        }

        //----------------------------------------------------------------//

        public static async Task<MovieView> getMovie(int id)
        {
            string movieJson;
            var response = await client.GetAsync(Constans.service + "/Movie/" + id).ConfigureAwait(false);
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            movieJson = await response.Content.ReadAsStringAsync();
            return JsonConvert.DeserializeObject<MovieView>(movieJson);
        }

        //----------------------------------------------------------------//

        public static async Task<Tuple<bool, bool>> LikeOrWatchMovie(string currentUser, int movieId)
        {
            var url = $"{Constans.service}/User/{currentUser}/LikeOrWatch/{movieId}";
            AddToken();
            var response = await client.GetAsync(url).ConfigureAwait(false);
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            string stateJson = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var definiton = new { isLiked = false, isWatching = false };
            var state = JsonConvert.DeserializeAnonymousType(stateJson, definiton);
            return Tuple.Create(state.isLiked, state.isWatching);
        }

        
        //----------------------------------------------------------------//

        public static async Task<UserView> getUser(string name)
        {
            string userJson = null;
            var url = Constans.service + "/User/" + name;
            var response = await client.GetAsync(url).ConfigureAwait(false);
            if (!response.IsSuccessStatusCode)
            {
                return null;
            }
            userJson = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return JsonConvert.DeserializeObject<UserView>(userJson);
        }

        //----------------------------------------------------------------//

        public static async Task<RelationsUsers> IsFriend(string currentUser, string anotherUser)
        {
            string IsFriendJson;
            var url = $"{Constans.service}/User/{currentUser}/HasFriend/{anotherUser}";
            AddToken();
            var response = await client.GetAsync(url).ConfigureAwait(false);
            if (!response.IsSuccessStatusCode)
            {
                return RelationsUsers.NotDefined;
            }
            IsFriendJson = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var definition = new { relationType = "" };
            var IsFriend = JsonConvert.DeserializeAnonymousType(IsFriendJson, definition);
            RelationsUsers type = RelationsUsers.NotDefined;
            bool IsParse = Enum.TryParse(IsFriend.relationType, out type);
            return type;
        }

        //----------------------------------------------------------------//

        public static async Task<HttpStatusCode> Online(string currentUser)
        {
            string url = $"{Constans.service}/User/Online";
            AddToken();
            var response = await client.PostAsJsonAsync(url, currentUser).ConfigureAwait(false);
            return response.StatusCode;
        }

        //----------------------------------------------------------------//

        public static async Task<HttpStatusCode> Offline(string currentUser)
        {
            string url = $"{Constans.service}/User/Offline";
            AddToken();
            var response = await client.PostAsJsonAsync(url, currentUser).ConfigureAwait(false);
            return response.StatusCode;
        }

        //----------------------------------------------------------------//

        public static async Task<ChatView> Chat(int chatId)
        {
            string url = $"{Constans.service}/Chat/{chatId}";
            var response = await client.GetAsync(url).ConfigureAwait(false);
            AddToken();
            if(response.StatusCode != HttpStatusCode.OK)
            {
                return null;
            }
            var chatJson = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var chat = JsonConvert.DeserializeObject<ChatView>(chatJson);
            return chat;
        }

        //----------------------------------------------------------------//
        
        public static async Task<PeopleView> GetPeople(int peopleId)
        {
            string url = $"{Constans.service}/People/{peopleId}";
            var response = await client.GetAsync(url).ConfigureAwait(false);
            if(response.StatusCode != HttpStatusCode.OK)
            {
                return null;
            }
            var peopleJson = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            var people = JsonConvert.DeserializeObject<PeopleView>(peopleJson);
            return people;
        }

        //----------------------------------------------------------------//

        public static async Task<List<GenreView>> GetGenre(string genre, int countMovies, int n_page)
        {
            string url = $"{Constans.service}/api/Movies?genre={genre}&count={countMovies}&n_page={n_page}";
            var response = await client.GetAsync(url).ConfigureAwait(false);
            if(response.StatusCode != HttpStatusCode.OK)
            {
                return null;
            }
            string genreJson = await response.Content.ReadAsStringAsync().ConfigureAwait(false);
            return JsonConvert.DeserializeObject<List<GenreView>>(genreJson);
        }

        //----------------------------------------------------------------//
            
        public void Dispose()
        {
            client.Dispose();
            GC.SuppressFinalize(this);
        }

        //----------------------------------------------------------------//

        ~ClientService()
        {
            client.Dispose();
        }

        //----------------------------------------------------------------//

    }
}