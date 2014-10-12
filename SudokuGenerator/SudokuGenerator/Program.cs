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

        Random rnd = new Random();

        private string CalculateNumbers(Control label)
        {
            var value = rnd.Next(1, 10);

            label.Text = value.ToString();

            return label.Text;
        }

        public Dictionary<int, List<Control>> CollectLabels(TableLayoutControlCollection controls)
        {

            var rows = new Dictionary<int, List<Control>>();// Create a dictionary with the row number as a Key and a list of Control objects in that row as the Value
            // At this point the Control objects do not have a value

            var rowOne = new List<Control>();
            var rowTwo = new List<Control>();
            var rowThree = new List<Control>();
            var rowFour = new List<Control>();
            var rowFive = new List<Control>();
            var rowSix = new List<Control>();
            var rowSeven = new List<Control>();
            var rowEight = new List<Control>();
            var rowNine = new List<Control>();

            rows.Add(1, rowOne);
            rows.Add(2, rowTwo);
            rows.Add(3, rowThree);
            rows.Add(4, rowFour);
            rows.Add(5, rowFive);
            rows.Add(6, rowSix);
            rows.Add(7, rowSeven);
            rows.Add(8, rowEight);
            rows.Add(9, rowNine);

            foreach (Control control in controls)
            {

                var cell = LabelNameToNumber(control);

                if (cell >= 1 && cell < 10)
                {
                    rowOne.Add(control);
                }
                else if (cell >= 10 && cell < 19)
                {
                    rowTwo.Add(control);
                }
                else if (cell >= 19 && cell < 28)
                {
                    rowThree.Add(control);
                }
                else if (cell >= 28 && cell < 37)
                {
                    rowFour.Add(control);
                }
                else if (cell >= 37 && cell < 46)
                {
                    rowFive.Add(control);
                }
                else if (cell >= 46 && cell < 55)
                {
                    rowSix.Add(control);
                }
                else if (cell >= 55 && cell < 64)
                {
                    rowSeven.Add(control);
                }
                else if (cell >= 64 && cell < 73)
                {
                    rowEight.Add(control);
                }
                else if (cell >= 73 && cell < 82)
                {
                    rowNine.Add(control);
                }
                else
                {

                }
            }

            return rows;
        }

        public void ProcessCollections(Dictionary<int, List<Control>> rows, TableLayoutControlCollection controls)
        {
            var labelNameAndValue = new Dictionary<int, string>();// Create a dictionary with a label's tag as the 

            foreach (Control control in controls)
            {
                var labelValue = CalculateNumbers(control);// This is a string, since the text of a label is always a string
                var labelName = LabelNameToNumber(control);// This is an integer, denoting the label's name (i.e. 1 to 81)

                labelNameAndValue.Add(labelName, labelValue);
            }

            var temp = 1;
        }

        private int LabelNameToNumber(Control control)
        {
            var name = control.Name;

            var nameTag = name.Substring(5);

            var LabelNumber = Convert.ToInt32(nameTag);

            return LabelNumber;
        }
    }
}
