using DM.JSON;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DM.REST
{
    public class RestService : IOpendotaRestService
    {
        public HttpClient _client;

        private RestService()
        {
            _client = new HttpClient
            {
                BaseAddress = new Uri("https://api.opendota.com/api/")
            };
        }

        public ProfileObject GetPlayerInfo(string urlOptionalPart)
        {
            ProfileObject profile = new ProfileObject();
            Task<HttpResponseMessage> t = _client.GetAsync(_client.BaseAddress + "players/"  + urlOptionalPart);
            if (t.Result.IsSuccessStatusCode)
            {
                string result = t.Result.Content.ReadAsStringAsync().Result;
                profile = JsonConvert.DeserializeObject<ProfileObject>(result);
            }
            return profile;
        }

        public WL GetWLInfo(string urlOptionalPart)
        {
            WL winloses = new WL();
            Task<HttpResponseMessage> t = _client.GetAsync(_client.BaseAddress + "players/" + urlOptionalPart);
            if (t.Result.IsSuccessStatusCode)
            {
                string result = t.Result.Content.ReadAsStringAsync().Result;
                winloses = JsonConvert.DeserializeObject<WL>(result);
            }
            return winloses;
        }

        public List<MatchCropped> GetPlayerRecentMatches(string urlOptionalPart)
        {
            List<MatchCropped> matchesList = new List<MatchCropped>();
            Task<HttpResponseMessage> t = _client.GetAsync(_client.BaseAddress + "players/" + urlOptionalPart);
            if (t.Result.IsSuccessStatusCode)
            {
                matchesList = JsonConvert.DeserializeObject<List<MatchCropped>>(t.Result.Content.ReadAsStringAsync().Result);
            }
            matchesList.TrimExcess();
            matchesList.RemoveRange(10, matchesList.Count - 10);
            return matchesList;
        }

        public List<MostPlayedHero> GetPlayerMostPlayedHeroes(string urlOptionalPart)
        {
            List<MostPlayedHero> heroesList = new List<MostPlayedHero>();
            Task<HttpResponseMessage> t = _client.GetAsync(_client.BaseAddress + "players/" + urlOptionalPart);
            if (t.Result.IsSuccessStatusCode)
            {
                heroesList = JsonConvert.DeserializeObject<List<MostPlayedHero>>(t.Result.Content.ReadAsStringAsync().Result);
            }
            heroesList.TrimExcess();
            heroesList.RemoveRange(10, heroesList.Count - 10);
            return heroesList;
        }

        public List<Hero> GetHeroes()
        {
            List<Hero> heroes = new List<Hero>();
            Task<HttpResponseMessage> t = _client.GetAsync(_client.BaseAddress + "heroes");
            if (t.Result.IsSuccessStatusCode)
            {
                heroes = JsonConvert.DeserializeObject<List<Hero>>(t.Result.Content.ReadAsStringAsync().Result);
            }
            return heroes;
        }

        public static RestService Instance { get { return NestedRestService.instance; } }
        private class NestedRestService
        {
            static NestedRestService()
            {
            }

            internal static readonly RestService instance = new RestService();
        }
    }

    public interface IOpendotaRestService
    {
        ProfileObject GetPlayerInfo(string url);
    }
}
