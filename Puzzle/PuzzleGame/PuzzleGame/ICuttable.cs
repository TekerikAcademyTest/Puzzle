using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace PuzzleGame
{
    public interface ICuttable
    {
        List<Shape> Split(Texture2D image, int width, int height, int xCount = 3, int yCount = 3);
    }
}
