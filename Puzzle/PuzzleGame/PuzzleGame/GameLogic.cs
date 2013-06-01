using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PuzzleGame
{
    public class GameLogic : ICheckable
    {        
        private int livesCount;

        public int LivesCount
        {
            get { return livesCount; }
        }
        public GameState State { get; set; }
        /// Constructor - the lives are like parameter to avoid hardcoding

        public GameLogic()
        {
            this.livesCount = 5;
            this.State = GameState.InProgress;
        }

        /// Method Check position - I accept Main area consist of invisible Shape elements
        
        public void CheckPosition(Shape elementTopBar, Shape elementMainArea)
        {
            if (elementTopBar.CompareTo(elementMainArea) == 0)
            {
                this.Update(elementTopBar, elementMainArea);
            }
            else
            {
                this.livesCount--;
                if (this.livesCount == 0)
                {
                    this.State = GameState.Lose;
                }
            }
        }

        public void Update(Shape elementTopBar, Shape elementMainArea)
        {
            elementTopBar.Visible = false;
            elementMainArea.Visible = true;
        }
    }
}
