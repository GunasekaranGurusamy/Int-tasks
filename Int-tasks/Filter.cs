namespace Int_tasks
{
    public class Filter
    {
        List<Player> cricketPlayerList=new List<Player>
        {
            new Player{PlayerId=1, PlayerName ="Ramesh"},
            new Player{PlayerId=2, PlayerName ="Senthil"},
            new Player{PlayerId=3, PlayerName ="Rahul"},
            new Player{PlayerId=4, PlayerName ="Deepak"},
            new Player{PlayerId=5, PlayerName ="Balaji"}
        };

 		List<Player> footballPlayerList = new List<Player>
        {
            new Player{PlayerId=1, PlayerName ="Vinay"},
            new Player{PlayerId=2, PlayerName ="Divya"},
            new Player{PlayerId=3, PlayerName ="Balaji"},
            new Player{PlayerId=4, PlayerName ="Partha"}            
        };

		List<Player> playerList = new List<Player>
        {
            new Player{PlayerId=1, PlayerName ="Senthil"},
            new Player{PlayerId=2, PlayerName ="Divya"},
            new Player{PlayerId=3, PlayerName ="Balaji"},
            new Player{PlayerId=4, PlayerName ="Deepak"},
            new Player{PlayerId=6, PlayerName ="Amith"}
        };

        //Print each player from above playerList as CricketPlayer or FootballPlayer or both or none based on data.
        public void findPlayersName()
        {
            var rstd = playerList.OrderByDescending(x => x.PlayerId).Skip(1).Take(1).ToList();

            foreach (var player in playerList)
            {
                bool isCricketPlayer = cricketPlayerList.Any(cp => cp.PlayerId == player.PlayerId);
                bool isFootballPlayer = footballPlayerList.Any(fp => fp.PlayerId == player.PlayerId);

                if (isCricketPlayer && isFootballPlayer)
                {
                    Console.WriteLine($"{player.PlayerName} is both a cricket and football player.");
                }
                else if (isCricketPlayer)
                {
                    Console.WriteLine($"{player.PlayerName} is a cricket player.");
                }
                else if (isFootballPlayer)
                {
                    Console.WriteLine($"{player.PlayerName} is a football player.");
                }
                else
                {
                    Console.WriteLine($"{player.PlayerName} is not a cricket or football player.");
                }
            }
        }

        public void findPlayers()
        {
            var result1 = playerList.Where(item => cricketPlayerList.Any(x => x.PlayerName == item.PlayerName) 
            || footballPlayerList.Any(x => x.PlayerName == item.PlayerName))
                .Select(x => new Player() { PlayerId = x.PlayerId, PlayerName = x.PlayerName});

            // output the result
            foreach (var item in result1)
            {
                Console.WriteLine($"Item Id: {item.PlayerId}, Name: {item.PlayerName}");
            }

            //Console.WriteLine(result);
            Console.Read();
        }
    }


    public class Result
    {

        public string PlayerName { get; set; }
        public string Type { get; set; }
    }


    public class Player
    {
        public string PlayerName { get; set; }
        public int PlayerId { get; set; }
    }

}
