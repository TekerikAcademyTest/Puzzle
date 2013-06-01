using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace PuzzleGame
{
    public abstract class ContentToDraw : IDrawable
    {
        public List<Shape> parts;

        public abstract void DrawField(SpriteBatch spriteBatch, Texture2D pixel);
    }
}
