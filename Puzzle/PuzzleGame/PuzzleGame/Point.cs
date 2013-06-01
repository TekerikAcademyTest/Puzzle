using System;
using System.Text;

namespace PuzzleGame
{
    public struct Point
    {
        /// <summary>
        /// Defining Point Coordinates X and Y
        /// </summary>

        private int xCoordinate;

        public int XCoordinate
        {
            get { return xCoordinate; }
            private set { xCoordinate = value; }
        }

        private int yCordinate;

        public int YCoordinate
        {
            get { return yCordinate; }
            private set { yCordinate = value; }
        }

        public Point(int pointCoordX, int pointCoordY) : this()
        {
            this.XCoordinate = pointCoordX;
            this.YCoordinate = pointCoordY;
        }
    }
}
