using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PuzzleGame
{
    class MainArea : ContentToDraw
    {
        public MainArea()
        {

        }
        public MainArea(List<Shape> shapes)
        {
            this.parts = new List<Shape>();
            foreach (Shape shape in shapes)
            {
                Shape currentShape = new Shape(shape.Image);
                currentShape.Visible = false;
                currentShape.UniqueNumber = shape.UniqueNumber;
                this.parts.Add(currentShape);
            }
            int row = 0;
            for (int i = 0; i < this.parts.Count; i++)
            {
                if (i % 3 == 0)
                {
                    row++;
                }
                parts[i].TopLeft = new Point(10 + (i % 3) * 60 + (i % 3) * 5, 100 + 65 * row);

            }
            
        }
        public override void DrawField(SpriteBatch spriteBatch, Texture2D pixel)
        {
            spriteBatch.Begin(SpriteSortMode.Texture, BlendState.Opaque);
            int width = 60;
            int height = 60;
            int row = 0;
            for (int i = 0; i < parts.Count(); i++)
            {
                if (i % 3 == 0)
                {
                    row++;
                }
                if (parts[i].Visible)
                {

                    Rectangle element = new Rectangle(this.parts[i].TopLeft.XCoordinate, this.parts[i].TopLeft.YCoordinate, width, height);
                    spriteBatch.Draw(parts[i].Image, element, Color.White);
                }
            }
            spriteBatch.Draw(pixel, new Rectangle(5, 165, 5, 190), null, Color.Green, 0, Vector2.Zero, SpriteEffects.None, 0);
            spriteBatch.Draw(pixel, new Rectangle(200, 165, 5, 190), null, Color.Yellow, 0, Vector2.Zero, SpriteEffects.None, 0);
            spriteBatch.Draw(pixel, new Rectangle(70, 165, 5, 190), null, Color.Yellow, 0, Vector2.Zero, SpriteEffects.None, 0);
            spriteBatch.Draw(pixel, new Rectangle(135, 165, 5, 190), null, Color.Yellow, 0, Vector2.Zero, SpriteEffects.None, 0);
            spriteBatch.Draw(pixel, new Rectangle(70, 165, 5, 190), null, Color.Yellow, 0, Vector2.Zero, SpriteEffects.None, 0);

            spriteBatch.Draw(pixel, new Rectangle(5, 160, 200, 5), null, Color.Green, 0, Vector2.Zero, SpriteEffects.None, 0);
            spriteBatch.Draw(pixel, new Rectangle(5, 225, 200, 5), null, Color.Green, 0, Vector2.Zero, SpriteEffects.None, 0);
            spriteBatch.Draw(pixel, new Rectangle(5, 290, 200, 5), null, Color.Green, 0, Vector2.Zero, SpriteEffects.None, 0);
            spriteBatch.Draw(pixel, new Rectangle(5, 355, 200, 5), null, Color.Green, 0, Vector2.Zero, SpriteEffects.None, 0);
            spriteBatch.End();
        }
    }
}
