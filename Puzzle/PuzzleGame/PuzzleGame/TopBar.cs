using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PuzzleGame
{
    public class TopBar : ContentToDraw
    {
        public TopBar()
        {
        }

        public TopBar(List<Shape> shapes)
        {
            this.parts = new List<Shape>();
            this.parts.AddRange(shapes);
        }

        public override void DrawField(SpriteBatch spriteBatch, Texture2D pixel = null)
        {
            spriteBatch.Begin(SpriteSortMode.Texture, BlendState.Opaque);
            int width = 60;
            int height = 60;

            for (int i = 0; i < parts.Count(); i++)
            {
                if (parts[i].Visible)
                {
                    Rectangle element = new Rectangle(10 + i * width + i * 10, 50, width, height);
                    parts[i].TopLeft = new Point(10 + i * width + i * 10, 50);
                    spriteBatch.Draw(parts[i].Image, element, Color.White);
                }
            }
            spriteBatch.End();
        }
    }
}
