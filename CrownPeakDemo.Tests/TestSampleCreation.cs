using System;
using System.Collections.Generic;
using GameOfLife;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CrownPeakDemo.Tests
{
    [TestClass]
    public class TestSampleCreation
    {
        List<Cell> ComparisonNeighbourhood = new List<Cell>();
        //with the intent of matching the sampleneighbourhood these are added manually
        void FillComparisonNeighbourhood()
        {
            ComparisonNeighbourhood.Add(new Cell(1, 1, false));
            ComparisonNeighbourhood.Add(new Cell(1, 2, true));
            ComparisonNeighbourhood.Add(new Cell(1, 3, false));
            ComparisonNeighbourhood.Add(new Cell(1, 4, false));
            ComparisonNeighbourhood.Add(new Cell(1, 5, false));
            ComparisonNeighbourhood.Add(new Cell(2, 1, true));
            ComparisonNeighbourhood.Add(new Cell(2, 2, false));
            ComparisonNeighbourhood.Add(new Cell(2, 3, false));
            ComparisonNeighbourhood.Add(new Cell(2, 4, true));
            ComparisonNeighbourhood.Add(new Cell(2, 5, true));
            ComparisonNeighbourhood.Add(new Cell(3, 1, true));
            ComparisonNeighbourhood.Add(new Cell(3, 2, true));
            ComparisonNeighbourhood.Add(new Cell(3, 3, false));
            ComparisonNeighbourhood.Add(new Cell(3, 4, false));
            ComparisonNeighbourhood.Add(new Cell(3, 5, true));
            ComparisonNeighbourhood.Add(new Cell(4, 1, false));
            ComparisonNeighbourhood.Add(new Cell(4, 2, true));
            ComparisonNeighbourhood.Add(new Cell(4, 3, false));
            ComparisonNeighbourhood.Add(new Cell(4, 4, false));
            ComparisonNeighbourhood.Add(new Cell(4, 5, false));
            ComparisonNeighbourhood.Add(new Cell(5, 1, true));
            ComparisonNeighbourhood.Add(new Cell(5, 2, false));
            ComparisonNeighbourhood.Add(new Cell(5, 3, false));
            ComparisonNeighbourhood.Add(new Cell(5, 4, false));
            ComparisonNeighbourhood.Add(new Cell(5, 5, true));
        }
        /// <summary>
        /// I test the basic table creation from the list and verify that it still works
        /// </summary>
        [TestMethod]
        public void TestSetNeighbourCounts()
        {
            //setup
            GOL TestGame = new GOL();
            //arrange
            List<Cell> SampleNeighbourhood = new List<Cell>();
            int[] rawData = new int[] { 0, 1, 0, 0, 0, 1, 0, 0, 1, 1, 1, 1, 0, 0, 1, 0, 1, 0, 0, 0, 1, 0, 0, 0, 1 };

            SampleNeighbourhood = TestGame.SetNeighbourhood(rawData, 5, 5);
            FillComparisonNeighbourhood();
            
            //assert
            for (int i = 0; i < ComparisonNeighbourhood.Count; i++)
            {
                if (!SampleNeighbourhood[i].Height.Equals(ComparisonNeighbourhood[i].Height) ||
                    !SampleNeighbourhood[i].Width.Equals(ComparisonNeighbourhood[i].Width) ||
                    !SampleNeighbourhood[i].Living.Equals(ComparisonNeighbourhood[i].Living))
                {
                    Assert.Fail();
                }
            }

        }

        /// <summary>
        /// I test that the neighbourcount is running, 
        /// I haven't set it to verify the counts are correct
        /// </summary>
        [TestMethod]
        public void TestNeighbourcount()
        {
            GOL TestGame = new GOL();
            FillComparisonNeighbourhood();
            try
            {
                TestGame.SetNeighbourCounts(ComparisonNeighbourhood);
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }
        }

        /// <summary>
        /// I test that a list is returned from the evolver function
        /// </summary>
        [TestMethod]
        public void TestEvolver()
        {
            GOL TestGame = new GOL();
            FillComparisonNeighbourhood();
            try
            {
                List<Cell> SampleNeighbourhood = TestGame.EvolveNeighbourhood(ComparisonNeighbourhood);
                if (SampleNeighbourhood == null)
                {
                    Assert.Fail("no list was returned");
                }
            }
            catch (Exception ex)
            {
                Assert.Fail(ex.Message);
            }

        }
    }
}
