using System.Collections.Generic;

namespace HearthstoneClone
{
    public class Game
    {
        public Player Player1 => _players[0];
        public Player Player2 => _players[1];
        private readonly List<Player> _players;

        public Game()
        {
            _players = new List<Player>
            {
                new Player(),
                new Player()
            };
        }
    }
}