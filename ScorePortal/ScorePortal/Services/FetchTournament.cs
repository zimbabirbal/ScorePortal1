using RestSharp;
using ScorePortal.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ScorePortal.Services
{
    public class FetchTournament
    {
        public static Task<List<Tournament>> FetchTournamentsAsync()
        {
            var client = new RestClient(Constants.UrlConstant.BaserUrl);
            var request = new RestRequest(string.Format(Constants.UrlConstant.AllTournamentRequest), DataFormat.Json);
            var response = client.GetAsync<List<Tournament>>(request);
            return response;
        }
    }
}
