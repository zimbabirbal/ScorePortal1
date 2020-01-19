using System;
using System.Collections.Generic;
using System.Text;

namespace SportNews.Constants
{
    public class UrlConstant
    {
        public const string BaserUrl = "http://scp.appsthatcrash.com";
        //Team Request
        public const string TeamRequest = "api/Team/{0}";
        public const string AllTeamRequest = "api/Team";
        //Tournament
        public const string AllTournamentRequest = "api/Tournament";
        public const string TournamentRequest = "api/Tournament/{0}";

        //Player
        public const string PlayerRequest = "api/Team/{0}/players";
        public const string AllPlayerRequest = "api/Player";
        public const string PlayerUpdateRequest = "api/Player/{0}";
    }
}
