using System;

namespace _2CP.Game
{
    /// <summary>
    /// Two Card Poker Game
    /// </summary>
    public class _2CP_Game : IGame
    {        
        /// <summary>
        /// Run Game
        /// </summary>
        public void Run()
        {
            IsRunning = true;
        }

        /// <summary>
        /// Game is running
        /// </summary>
        /// <value></value>
        public bool IsRunning{ get; private set; }
        
    }
}
