using System;
using Newtonsoft.Json;


namespace Players
{
    public class Player
    {
        
        [JsonProperty("Player_ID")]
        public int Player_ID { get; set;}

        [JsonProperty("PLAYER_NAME")]
        public string PLAYER_NAME { get; set; }

        [JsonProperty("AGE")]
        public int AGE { get; set; }
        
        [JsonProperty("GP")]
        public int GP { get; set; }

        [JsonProperty("W")]
        public int W { get; set; }

        [JsonProperty("L")]
        public int L { get; set; }

        [JsonProperty("W_PCT")]
        public decimal W_PCT { get; set; }

        [JsonProperty("MINS")]
        public decimal MINS { get; set; }

        [JsonProperty("FGM")]
        public decimal FGM { get; set; }

        [JsonProperty("FGA")]
        public decimal FGA { get; set; }

        [JsonProperty("FG_PCT")]
        public decimal FG_PCT { get; set; }

        [JsonProperty("FG3M")]
        public decimal FG3M { get; set; }

        [JsonProperty("FG3A")]
        public decimal FG3A { get; set; }

        [JsonProperty("FG3_PCT")]
        public decimal FG3_PCT { get; set; }

        [JsonProperty("FTM")]
        public decimal FTM { get; set; }

        [JsonProperty("FTA")]
        public decimal FTA { get; set; }
        
        [JsonProperty("FT_PCT")]
        public decimal FT_PCT { get; set; }
        
        [JsonProperty("OREB")]
        public decimal OREB { get; set; }

        [JsonProperty("DREB")]
        public decimal DREB { get; set; }

        [JsonProperty("REB")]
        public decimal REB { get; set; }

        [JsonProperty("AST")]
        public decimal AST { get; set; }

        [JsonProperty("TOV")]
        public decimal TOV { get; set; }

        [JsonProperty("STL")]
        public decimal STL { get; set; }

        [JsonProperty("BLK")]
        public decimal BLK { get; set; }

        [JsonProperty("BLKA")]
        public decimal BLKA { get; set; }

        [JsonProperty("PF")]
        public decimal PF { get; set; }

        [JsonProperty("PFD")]
        public decimal PFD { get; set; }

        [JsonProperty("PTS")]
        public decimal PTS { get; set; }

        [JsonProperty("PLUS_MINUS")]
        public decimal PLUS_MINUS { get; set; }

        [JsonProperty("NBA_FANTASY_PTS")]
        public decimal NBA_FANTASY_PTS { get; set; }
        public Player( )
        {
            Player_ID = 000;
            PLAYER_NAME = " ";
            AGE = 0;
            GP = 0;
            W = 0;
            L = 0;
            W_PCT = 0;
            MINS = 0;
            FGM = 0;
            FGA = 0;
            FG_PCT = 0;
            FG3M = 0;
            FG3A = 0;
            FG3_PCT = 0;
            FTM = 0;
            FTA = 0;
            FT_PCT = 0;
            OREB = 0;
            DREB = 0;
            REB = 0;
            AST = 0;
            TOV = 0;
            STL = 0;
            BLK = 0;
            BLKA = 0;
            PF = 0;
            PFD = 0;
            PTS = 0;
            PLUS_MINUS = 0;
            NBA_FANTASY_PTS = 0;
        }

        public Player(int player_ID, string pLAYER_NAME, int aGE, int gP, int w, int l, decimal w_PCT, decimal mINS, decimal fGM, decimal fGA, decimal fG_PCT, decimal fG3M, decimal fG3A, decimal fG3_PCT, decimal fTM, decimal fTA, decimal fT_PCT, decimal oREB, decimal dREB, decimal rEB, decimal aST, decimal tOV, decimal sTL, decimal bLK, decimal bLKA, decimal pF, decimal pFD, decimal pTS, decimal pLUS_MINUS, decimal nBA_FANTASY_PTS)
        {
            Player_ID = player_ID;
            PLAYER_NAME = pLAYER_NAME;
            AGE = aGE;
            GP = gP;
            W = w;
            L = l;
            W_PCT = w_PCT;
            MINS = mINS;
            FGM = fGM;
            FGA = fGA;
            FG_PCT = fG_PCT;
            FG3M = fG3M;
            FG3A = fG3A;
            FG3_PCT = fG3_PCT;
            FTM = fTM;
            FTA = fTA;
            FT_PCT = fT_PCT;
            OREB = oREB;
            DREB = dREB;
            REB = rEB;
            AST = aST;
            TOV = tOV;
            STL = sTL;
            BLK = bLK;
            BLKA = bLKA;
            PF = pF;
            PFD = pFD;
            PTS = pTS;
            PLUS_MINUS = pLUS_MINUS;
            NBA_FANTASY_PTS = nBA_FANTASY_PTS;
        }
    }
}
