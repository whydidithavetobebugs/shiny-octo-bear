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

        public List<int> CreateListOfAllPossibleGridValues()
        {
            var gridValues = new List<int>();

            var n = 0;
            while(n++ < 9)
            {
                var i = 0;
                while(i++ < 9)
                {
                    gridValues.Add(i);
                }
            }

            return gridValues;
        }

        public Dictionary<string, int> ChooseValueForLabel(TableLayoutControlCollection controls, List<int> gridValues)
        {
            var labelNameAndChosenValue = new Dictionary<string, int>();

            foreach(Control control in controls)
            {
                var r = rnd.Next(gridValues.Count);

                labelNameAndChosenValue.Add(control.Name, gridValues[r]);
                control.Text = gridValues[r].ToString();
            }

            return labelNameAndChosenValue;
        }
    }
}
