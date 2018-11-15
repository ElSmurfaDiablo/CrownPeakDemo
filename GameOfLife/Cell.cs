using System;
using System.Collections.Generic;
using System.Text;

namespace GameOfLife
{
    /// <summary>
    /// I represent each cell in the game of life. I have position values Height and Width and a 'Living' value 1 or 0
    /// </summary>
    public class Cell
    {
        public Cell() { }
        public Cell(int height, int width, bool living)
        {
            Height = height;
            Width = width;
            Living = living;
        }
        public int Height { get; set; }
        public int Width { get; set; }
        public bool Living { get; set; }
        public int NeighbourCount { get; set; }
    }
}
