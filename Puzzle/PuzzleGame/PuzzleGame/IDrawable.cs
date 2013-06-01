using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Graphics;

namespace PuzzleGame
{
    public interface IDrawable
    {
        void DrawField(SpriteBatch spriteBatch, Texture2D pixel);
    }
}
