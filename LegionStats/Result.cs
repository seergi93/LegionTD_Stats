using System;
using System.Collections.Generic;

namespace LegionStats
{
    public class GameDetail
    {
        public IList<int> workersPerWave { get; set; }
        public IList<int> incomePerWave { get; set; }
        public IList<IList<string>> unitsPerWave { get; set; }
        public IList<IList<string>> mercsSentPerWave { get; set; }
        public DateTime ts { get; set; }
        public string playername { get; set; }
        public string gameresult { get; set; }
        public int overallElo { get; set; }
        public string legionSpell { get; set; }
    }

    public class Game
    {
        public DateTime ts { get; set; }
        public string queuetype { get; set; }
        public IList<GameDetail> gameDetails { get; set; }
    }

    public class Games
    {
        public int count { get; set; }
        public IList<Game> games { get; set; }
    }

    public class Player
    {
        public Games games { get; set; }
    }

    public class Data
    {
        public Player player { get; set; }
    }

    public class Result
    {
        public Data data { get; set; }
    }


}
