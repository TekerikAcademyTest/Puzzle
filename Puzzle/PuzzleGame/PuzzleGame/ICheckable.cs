using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PuzzleGame
{
    public interface ICheckable
    {
        void CheckPosition(Shape elementTopBar, Shape elementMainArea);
        void Update(Shape elementTopBar, Shape elementMainArea);
    }
}
