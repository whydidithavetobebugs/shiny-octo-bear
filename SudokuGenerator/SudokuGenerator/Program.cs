using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SudokuGenerator
{
    public class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

        static Random rnd = new Random();

        private List<int> CreateListOfOneToNine()
        {
            // Create a list of the integers from 1 to 9
            var gridValues = new List<int>();

            var n = 0;
            while(n++ < 9)
            {
                gridValues.Add(n);
            }

            return gridValues;
        }

        public Dictionary<string, List<Control>> CreateLabelCollections(TableLayoutControlCollection controls)
        {
            // Create a dictionary containing a string representing the row as the Key, and a List of all labels in that row as the Value
            var rowsAndLabels = new Dictionary<string, List<Control>>();

            var rowOne = new List<Control>();
            var rowTwo = new List<Control>();
            var rowThree = new List<Control>();
            var rowFour = new List<Control>();
            var rowFive = new List<Control>();
            var rowSix = new List<Control>();
            var rowSeven = new List<Control>();
            var rowEight = new List<Control>();
            var rowNine = new List<Control>();

            foreach(Control control in controls)
            {
                var labelNumber = labelNameToNumber(control);

                if (labelNumber < 10)
                {
                    rowOne.Add(control);
                }
                else if (labelNumber < 19)
                {
                    rowTwo.Add(control);
                }
                else if (labelNumber < 28)
                {
                    rowThree.Add(control);
                }
                else if (labelNumber < 37)
                {
                    rowFour.Add(control);
                }
                else if (labelNumber < 46)
                {
                    rowFive.Add(control);
                }
                else if (labelNumber < 55)
                {
                    rowSix.Add(control);
                }
                else if (labelNumber < 64)
                {
                    rowSeven.Add(control);
                }
                else if (labelNumber < 73)
                {
                    rowEight.Add(control);
                }
                else
                {
                    rowNine.Add(control);
                }
            }

            rowsAndLabels.Add("rowOne", rowOne);
            rowsAndLabels.Add("rowTwo", rowTwo);
            rowsAndLabels.Add("rowThree", rowThree);
            rowsAndLabels.Add("rowFour", rowFour);
            rowsAndLabels.Add("rowFive", rowFive);
            rowsAndLabels.Add("rowSix", rowSix);
            rowsAndLabels.Add("rowSeven", rowSeven);
            rowsAndLabels.Add("rowEight", rowEight);
            rowsAndLabels.Add("rowNine", rowNine);

            return rowsAndLabels;
        }

        private int labelNameToNumber(Control control)
        {
            // Take a label's name (e.g. "label45"), isolate the number, and convert to an integer (e.g. 45)
            var nameTag = control.Name.Substring(5);

            var number = Convert.ToInt32(nameTag);

            return number;
        }

        public List<int> ChooseAndSetValueForLabel(KeyValuePair<string, List<Control>> row, List<List<int>> valuesInAllRows)
        {
            var controls = row.Value;// Get all Control objects in the given row

            var gridValues = CreateListOfOneToNine();// Create a list of integers from 1 to 9

            var rowValues = new List<int>();

            for (var i = 0; i < controls.Count; i++)
            {
                var r = rnd.Next(gridValues.Count);

                while (!CheckColumns(valuesInAllRows, gridValues[r], i))
                {
                    // Within each list of integers, compare gridValue[r] against the element in the list at index i
                    // If this returns false, regenerate a random r and check again
                    r = rnd.Next(gridValues.Count);
                }

                controls[i].Text = gridValues[r].ToString();// Set the label's text to be the given value

                rowValues.Add(gridValues[r]);

                gridValues.RemoveAt(r);
            }

            return rowValues;
        }

        private bool CheckColumns(List<List<int>> valuesInAllRows, int value, int i)
        {
            // Check each list at the same index for the given value; if value doesn't appear, return true, otherwise, return false
            foreach (var row in valuesInAllRows)
            {
                if (row[i] == value)
                {
                    return false;
                }
            }

            return true;
        }
    }
}
