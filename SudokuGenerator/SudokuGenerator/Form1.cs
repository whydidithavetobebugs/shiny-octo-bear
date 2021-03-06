﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SudokuGenerator
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void StartButton_Click(object sender, EventArgs e)
        {
            var p1 = new Program();

            var rowsAndLabels = p1.CreateLabelCollections(tableLayoutPanel1.Controls);

            var valuesInAllRows = new List<List<int>>();

            foreach (var row in rowsAndLabels)
            {
                var rowValues = p1.ChooseAndSetValueForLabel(row, valuesInAllRows);

                valuesInAllRows.Add(rowValues);
            }

            CloseButton.Visible = true;
        }

        private void CloseButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }


    }
}
