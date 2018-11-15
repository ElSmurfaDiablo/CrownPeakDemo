using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace GameOfLife
{
    public class GOL
    {
        /// <summary>
        /// I take a list of Cells that defines the Current neighbourhood and return a neighbourhood that will replace the current one.
        /// </summary>
        /// <param name="neighbourhood"></param>
        /// <returns></returns>
        public List<Cell> EvolveNeighbourhood(List<Cell> neighbourhood)
        {
            List<Cell> newNeighbourhood = new List<Cell>();
            int count = 0;
            SetNeighbourCounts(neighbourhood);

            for (int i = 0; i < neighbourhood.Count; i++)
            {
                count = neighbourhood[i].NeighbourCount;
                if (neighbourhood[i].Living)
                {
                    if (count < 2)//underpopulationcheck
                    {
                        newNeighbourhood.Add(new Cell(neighbourhood[i].Height, neighbourhood[i].Width, false));
                    }
                    else if (count > 3)//overcrowding check
                    {
                        newNeighbourhood.Add(new Cell(neighbourhood[i].Height, neighbourhood[i].Width, false));
                    }
                    else//no change
                    {
                        newNeighbourhood.Add(neighbourhood[i]);
                    }
                }
                else if (!neighbourhood[i].Living)
                {
                    if (count == 3)//repopulation
                    {
                        newNeighbourhood.Add(new Cell(neighbourhood[i].Height, neighbourhood[i].Width, true));
                    }
                    else//no change
                    {
                        newNeighbourhood.Add(neighbourhood[i]);
                    }
                }
            }
           return newNeighbourhood;
        }

        /// <summary>
        /// I set the neighbour count on each cell for evolution rules
        /// </summary>
        /// <param name="neighbourhood"></param>
        public void SetNeighbourCounts(List<Cell> neighbourhood)
        {
            const int lowerLimit = 1;
            int count = 0;
            int upperHeightLimit = neighbourhood.Max(c => c.Height);
            int upperWidthLimit = neighbourhood.Max(c => c.Width);
            //I think this can be refactored maybe with a linq query or two but I'm not fast enough at linq yet to do it. 
            //but for the sake of the excercise and lack of time, it'll have to wait until a next iteration
            for (int i = 0; i < neighbourhood.Count; i++)
            {
                count = 0;
                //cell is on the first row
                if (neighbourhood[i].Height == lowerLimit && (neighbourhood[i].Width <= upperWidthLimit) && (neighbourhood[i].Width >= lowerLimit))
                {
                    //top row middles
                    if (neighbourhood[i].Width > lowerLimit && neighbourhood[i].Width < upperWidthLimit)
                    {
                        count += neighbourhood.Where(cell => cell.Height == lowerLimit && cell.Width == neighbourhood[i].Width - 1 && cell.Living).Count();
                        count += neighbourhood.Where(cell => cell.Height == lowerLimit && cell.Width == neighbourhood[i].Width + 1 && cell.Living).Count();
                        count += neighbourhood.Where(cell => cell.Height == lowerLimit + 1 && cell.Width == neighbourhood[i].Width - 1 && cell.Living).Count();
                        count += neighbourhood.Where(cell => cell.Height == lowerLimit + 1 && cell.Width == neighbourhood[i].Width && cell.Living).Count();
                        count += neighbourhood.Where(cell => cell.Height == lowerLimit + 1 && cell.Width == neighbourhood[i].Width + 1 && cell.Living).Count();
                    }
                    //Upper left corner
                    if (neighbourhood[i].Width == lowerLimit)
                    {
                        count += neighbourhood.Where(cell => cell.Height == lowerLimit + 1 && cell.Width == neighbourhood[i].Width && cell.Living).Count();
                        count += neighbourhood.Where(cell => cell.Height == lowerLimit + 1 && cell.Width == neighbourhood[i].Width + 1 && cell.Living).Count();
                        count += neighbourhood.Where(cell => cell.Height == lowerLimit && cell.Width == neighbourhood[i].Width + 1 && cell.Living).Count();
                    }
                    //upper right corner
                    if (neighbourhood[i].Width == upperWidthLimit)
                    {
                        count += neighbourhood.Where(cell => cell.Height == lowerLimit + 1 && cell.Width == neighbourhood[i].Width && cell.Living).Count();
                        count += neighbourhood.Where(cell => cell.Height == lowerLimit + 1 && cell.Width == neighbourhood[i].Width - 1 && cell.Living).Count();
                        count += neighbourhood.Where(cell => cell.Height == lowerLimit && cell.Width == neighbourhood[i].Width - 1 && cell.Living).Count();
                    }
                }
                //cell is in the middle somewhere
                if ((neighbourhood[i].Height > lowerLimit && neighbourhood[i].Height < upperHeightLimit) && (neighbourhood[i].Width >= lowerLimit) && (neighbourhood[i].Width <= upperWidthLimit))
                {
                    int _h = neighbourhood[i].Height;
                    //middle of the table
                    if (neighbourhood[i].Width > lowerLimit && neighbourhood[i].Width < upperWidthLimit)
                    {
                        count += neighbourhood.Where(cell => cell.Height == _h + 1 && cell.Width == neighbourhood[i].Width - 1 && cell.Living).Count();
                        count += neighbourhood.Where(cell => cell.Height == _h + 1 && cell.Width == neighbourhood[i].Width  && cell.Living).Count();
                        count += neighbourhood.Where(cell => cell.Height == _h + 1 && cell.Width == neighbourhood[i].Width + 1 && cell.Living).Count();
                        count += neighbourhood.Where(cell => cell.Height == _h && cell.Width == neighbourhood[i].Width - 1 && cell.Living).Count();
                        count += neighbourhood.Where(cell => cell.Height == _h && cell.Width == neighbourhood[i].Width + 1 && cell.Living).Count();
                        count += neighbourhood.Where(cell => cell.Height == _h - 1 && cell.Width == neighbourhood[i].Width - 1 && cell.Living).Count();
                        count += neighbourhood.Where(cell => cell.Height == _h - 1 && cell.Width == neighbourhood[i].Width && cell.Living).Count();
                        count += neighbourhood.Where(cell => cell.Height == _h - 1 && cell.Width == neighbourhood[i].Width + 1 && cell.Living).Count();
                    }
                    //left rail
                    if (neighbourhood[i].Width == lowerLimit)
                    {
                        count += neighbourhood.Where(cell => cell.Height == _h - 1 && cell.Width == neighbourhood[i].Width && cell.Living).Count();
                        count += neighbourhood.Where(cell => cell.Height == _h - 1 && cell.Width == neighbourhood[i].Width + 1 && cell.Living).Count();
                        count += neighbourhood.Where(cell => cell.Height == _h && cell.Width == neighbourhood[i].Width + 1 && cell.Living).Count();
                        count += neighbourhood.Where(cell => cell.Height == _h + 1 && cell.Width == neighbourhood[i].Width && cell.Living).Count();
                        count += neighbourhood.Where(cell => cell.Height == _h + 1 && cell.Width == neighbourhood[i].Width + 1 && cell.Living).Count();
                    }
                    //right rail
                    if (neighbourhood[i].Width == upperWidthLimit)
                    {
                        count += neighbourhood.Where(cell => cell.Height == _h - 1 && cell.Width == neighbourhood[i].Width && cell.Living).Count();
                        count += neighbourhood.Where(cell => cell.Height == _h - 1 && cell.Width == neighbourhood[i].Width - 1 && cell.Living).Count();
                        count += neighbourhood.Where(cell => cell.Height == _h && cell.Width == neighbourhood[i].Width - 1 && cell.Living).Count();
                        count += neighbourhood.Where(cell => cell.Height == _h + 1 && cell.Width == neighbourhood[i].Width && cell.Living).Count();
                        count += neighbourhood.Where(cell => cell.Height == _h + 1 && cell.Width == neighbourhood[i].Width - 1 && cell.Living).Count();
                    }
                   
                }
                //cell is on the last row
                if (neighbourhood[i].Height == upperHeightLimit && (neighbourhood[i].Width <= upperWidthLimit) && (neighbourhood[i].Width >= lowerLimit))
                {
                    //last row in the middle
                    if (neighbourhood[i].Width > lowerLimit && neighbourhood[i].Width < upperWidthLimit)
                    {
                        count += neighbourhood.Where(cell => cell.Height == upperHeightLimit && cell.Width == neighbourhood[i].Width - 1 && cell.Living).Count();
                        count += neighbourhood.Where(cell => cell.Height == upperHeightLimit && cell.Width == neighbourhood[i].Width + 1 && cell.Living).Count();
                        count += neighbourhood.Where(cell => cell.Height == upperHeightLimit - 1 && cell.Width == neighbourhood[i].Width - 1 && cell.Living).Count();
                        count += neighbourhood.Where(cell => cell.Height == upperHeightLimit - 1 && cell.Width == neighbourhood[i].Width && cell.Living).Count();
                        count += neighbourhood.Where(cell => cell.Height == upperHeightLimit - 1 && cell.Width == neighbourhood[i].Width + 1 && cell.Living).Count();
                    }
                    //lower left corner
                    if (neighbourhood[i].Width == lowerLimit)
                    {
                        count += neighbourhood.Where(cell => cell.Height == upperHeightLimit - 1 && cell.Width == neighbourhood[i].Width && cell.Living).Count();
                        count += neighbourhood.Where(cell => cell.Height == upperHeightLimit - 1 && cell.Width == neighbourhood[i].Width + 1 && cell.Living).Count();
                        count += neighbourhood.Where(cell => cell.Height == upperHeightLimit && cell.Width == neighbourhood[i].Width + 1 && cell.Living).Count();
                    }
                    //lower right corner
                    if (neighbourhood[i].Width == upperWidthLimit)
                    {
                        count += neighbourhood.Where(cell => cell.Height == upperHeightLimit - 1 && cell.Width == neighbourhood[i].Width && cell.Living).Count();
                        count += neighbourhood.Where(cell => cell.Height == upperHeightLimit - 1 && cell.Width == neighbourhood[i].Width - 1 && cell.Living).Count();
                        count += neighbourhood.Where(cell => cell.Height == upperHeightLimit && cell.Width == neighbourhood[i].Width - 1 && cell.Living).Count();
                    }
                }
                neighbourhood[i].NeighbourCount = count;
            }
        }

        /// <summary>
        /// I set a neighbourhood based on the provided example
        /// </summary>
        /// <returns></returns>
        public List<Cell> SetNeighbourhood(int[] rawData, int numRows, int numCols)
        {
            List<Cell> neighbourhood = new List<Cell>();
            Cell ncell = new Cell();
            int width = 0;
            int h = 0;
            for (int w = 0; w < rawData.Length; w++)
            {
                Math.DivRem(w, numCols, out width);
                h = width == 0 ? h+1 : h;
                ncell = new Cell(h, width + 1, (rawData[w] == 0 ? false : true));
                neighbourhood.Add(ncell);
            }

            return neighbourhood;
        }

    }

}
