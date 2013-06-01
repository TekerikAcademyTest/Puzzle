using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace PuzzleGame
{
    public class Cut : ICuttable
    {
        /// <summary>
        /// It gets picture and splits it into 9 parts (3x3).
        /// </summary>
        /// <param name="image">the picture that sholud be splitted</param>
        /// <param name="width">into parts with width = <paramref name="width"/></param>
        /// <param name="height">into parts with height = height</param>
        /// <param name="xCount">rows</param>
        /// <param name="yCount">columns</param>
        /// <returns></returns>
        public List<Shape> Split(Texture2D image, int width, int height, int xCount = 3, int yCount = 3)
        {
            List<Shape> result = new List<Shape>();
            int dataPerPart = width * height;
            int uniqueIndexer = 1;
            Color[] originalData = new Color[image.Width * image.Height];
            image.GetData<Color>(originalData);

            for (int y = 0; y < yCount * height; y += height)
                for (int x = 0; x < xCount * width; x += width)
                {
                    Texture2D part = new Texture2D(image.GraphicsDevice, width, height);
                    Color[] partData = new Color[dataPerPart];

                    for (int py = 0; py < height; py++)
                        for (int px = 0; px < width; px++)
                        {
                            int partIndex = px + py * width;
                            if (y + py >= image.Height || x + px >= image.Width)
                                partData[partIndex] = Color.Transparent;
                            else
                                partData[partIndex] = originalData[(x + px) + (y + py) * image.Width];
                        }
                    part.SetData<Color>(partData);
                    Shape shape = new Shape(part);
                    shape.UniqueNumber = uniqueIndexer;
                    uniqueIndexer++;
                    result.Add(shape);
                }

            return result;
        }
    }
}
