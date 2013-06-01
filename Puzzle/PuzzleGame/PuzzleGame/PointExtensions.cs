using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace PuzzleGame
{
    static class PointExtensions
    {
        /// <summary>
        /// Converting Point to Vector. It's nessesarly for showing the result of the Game using XNA
        /// </summary>
        public static Vector2 ConvertPointToVector(this Point result)
        {
            Vector2 points = new Vector2(result.XCoordinate, result.YCoordinate);
            return points;
        }
    }
}
