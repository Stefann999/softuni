using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace Basketball
{
    public class Team
    {
        public Team(string name, int openPositions, char group)
        {
            this.Name = name;
            this.OpenPositions = openPositions;
            this.Group = group;
            Players = new List<Player>();
        }


        public string Name { get; set; }
        public int OpenPositions { get; set; }
        public char Group { get; set; }
        public List<Player> Players { get; set; }


        public int Count => this.Players.Count;


        public string AddPlayer(Player player)
        {

            if (string.IsNullOrEmpty(player.Name) || string.IsNullOrEmpty(player.Position))
            {
                return "Invalid player's information.";
            }
            else if (OpenPositions == 0)
            {
                return "There are no more open positions.";
            }
            else if (player.Rating < 80)
            {
                return "Invalid player's rating.";
            }
            else
            {
                this.OpenPositions--;
                this.Players.Add(player);
                return $"Successfully added {player.Name} to the team. Remaining open positions: {this.OpenPositions}.";
            }
        }

        public bool RemovePlayer(string name)
        {
            Player targetCloth = Players.FirstOrDefault(x => x.Name == name);
            if (targetCloth != null)
            {
                Players.Remove(targetCloth);
                OpenPositions++;
                return true;
            }
            return false;
        }

        public int RemovePlayerByPosition(string position)
        {
            int cnt = this.Players.RemoveAll(x => x.Position == position);
            OpenPositions =+ cnt;
            return cnt;
        }

        public Player RetirePlayer(string name)
        {
            var currPlayer = this.Players.FirstOrDefault(y => y.Name == name);

            if (currPlayer == null)
            {
                return null;
            }
            else
            {
                currPlayer.Retired = true;
                return currPlayer;
            }
        }
          public List<Player> AwardPlayers(int games) => this.Players.Where(x => x.Games >= games).ToList();
         public string Report()
         {
             StringBuilder sb = new StringBuilder();
             sb.AppendLine($"Active players competing for Team {this.Name} from Group {this.Group}:");
            foreach (var player in this.Players.Where(x => x.Retired == false).ToList())
            {
                sb.AppendLine(player.ToString());
            }
            return sb.ToString().TrimEnd();
         }

    }

}
