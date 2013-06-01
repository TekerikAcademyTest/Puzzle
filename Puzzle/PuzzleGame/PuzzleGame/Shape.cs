using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Microsoft.Xna.Framework.Graphics;

namespace PuzzleGame
{
    public class Shape : IComparable<Shape>
    {
        public bool Visible { get; set; } //if the shape is not visible then it won't be shown
        public Texture2D Image;
        private Point topLeft;

        public int UniqueNumber { get; set; } //every piece have unique number - from 1 to 9
               
        public Point TopLeft
        {
            get
            {
                return this.topLeft;
            }
            set
            {
                this.topLeft = value;
            }
        }

        public Shape(Texture2D image)
        {
            this.Image = image;
            this.Visible = true;
            this.UniqueNumber = 1;
           
        }

        #region IComparable<Shape> Members


        public int CompareTo(Shape other)
        {
            return this.UniqueNumber.CompareTo(other.UniqueNumber);
        }

        #endregion
    }
}
