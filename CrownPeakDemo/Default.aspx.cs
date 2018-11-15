using GameOfLife;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace CrownPeakDemo
{
    public partial class _Default : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int numRows = 0; 
            int numCols = 0;
            string nbrhood = "";
            string[] neighbourhoodStringArray;
            if (Request.Params["rowdata"] != null)//we opened this page by submitting a form with appropriate data
            {
                string[] parameters = (Request.Params["rowdata"]).Split(',');
                numRows = parameters.Length;
                numCols = parameters[0].Replace(" ", "").Length;

                StringBuilder formboard = new StringBuilder();
                for (int datarowIndex = 0; datarowIndex < parameters.Length; datarowIndex++)
                {
                    formboard.Append(parameters[datarowIndex]);
                }
                formboard.Replace(" ","");

                for (int i = 0; i < formboard.Length; i++)
                {
                    nbrhood += formboard[i].ToString() + ",";
                }
                nbrhood = nbrhood.Trim(',',' ');
                neighbourhoodStringArray = nbrhood.Split(',');
            }
            else//we opened this page by itself and will run with test data from web.config
            {
                var appSettings = ConfigurationManager.AppSettings;
                numRows = int.Parse(appSettings["rows"]);
                numCols = int.Parse(appSettings["columns"]);
                nbrhood = appSettings["neighbourhood"];
                neighbourhoodStringArray = nbrhood.Split(',');
            }

            GOL GameOfLifeHandle = new GOL();
                        
            int[] neighbourhood =  Array.ConvertAll(neighbourhoodStringArray, s => int.Parse(s));
 
            List<Cell> currentNeighbourhood = GameOfLifeHandle.SetNeighbourhood(neighbourhood, numRows, numCols);
            Table htmlTable = new Table();
            TableRow tableRow = new TableRow();
            TableCell tableCell = new TableCell();
            htmlTable.CssClass = "currentneighbourhood";
            for (int i = 1; i < numRows+1; i++)
            {
                tableRow = new TableRow();
                for (int j = 1; j < numCols+1; j++)
                {
                    tableCell = new TableCell();
                    tableCell.Text = currentNeighbourhood.Where(cell => cell.Height == i && cell.Width == j).First().Living ? "1" : "0";//converted so it displays as intended
                    tableRow.Cells.Add(tableCell);
                }
                htmlTable.Rows.Add(tableRow);
            }
            CurrentNeighbourhood.Controls.Add(htmlTable);

            List<Cell> evolvedNeighbourhood = GameOfLifeHandle.EvolveNeighbourhood(currentNeighbourhood);
            htmlTable = new Table();
            for (int i = 1; i < numRows+1; i++)
            {
                tableRow = new TableRow();
                for (int j = 1; j < numCols+1; j++)
                {
                    tableCell = new TableCell();
                    tableCell.Text = evolvedNeighbourhood.Where(cell => cell.Height == i && cell.Width == j).First().Living ? "1" : "0";//converted so it displays as intended
                    tableRow.Cells.Add(tableCell);
                }
                htmlTable.Rows.Add(tableRow);
            }
            htmlTable.CssClass = "newneighbourhood";
            NewNeighbourhood.Controls.Add(htmlTable);

        }
    }
}