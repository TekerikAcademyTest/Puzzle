using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PuzzleGame
{
    static class ListExtensions
    {
        public static void Shuffle<T>(this List<T> elements)
        {
            List<T> shuffledResult = new List<T>(elements.Count);
            
            //creating array of shuffled indexes
            List<int> indexes = new List<int>();
            Random randomGenerator = new Random();
            for (int i = 0; i < elements.Count(); i++)
			{
                int randomIndex = randomGenerator.Next(0, elements.Count());
                while (indexes.Contains(randomIndex))
                {
                    randomIndex = randomGenerator.Next(0, elements.Count());
                }
                indexes.Add(randomIndex);
			}
            for (int i = 0; i < indexes.Count; i++)
            {
                shuffledResult.Add(elements[indexes[i]]);
            }
            elements.Clear();
            elements.AddRange(shuffledResult);
        }
    }
}
