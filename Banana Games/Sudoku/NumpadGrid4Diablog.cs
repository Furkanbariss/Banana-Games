using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Banana_Games.Sudoku
{
    public partial class NumpadGrid4Diablog : Form
    {
        //public NumpadGrid4Diablog()
        //{
        //    InitializeComponent();
        //}

        //private void NumpadGrid4Diablog_Load(object sender, EventArgs e)
        //{

        //}

        //=======================


        /// <summary>
        /// Value Field with default as -1.
        /// </summary>
        public int Value = -1;

        /// <summary>
        /// NumpadGrid4Dialog Constructor
        /// </summary>
        public NumpadGrid4Diablog() => InitializeComponent();

        /// <summary>
        /// Numbers Button Click Event
        /// </summary>
        /// <param name="sender">The Sender</param>
        /// <param name="e">The Event Args</param>
        //private void BtnNumber_Click(object sender, EventArgs e)
        //{
        //    Value = Convert.ToInt32((sender as Button).Text);
        //    Close();
        //}

        /// <summary>
        /// Clear Button Click Event
        /// </summary>
        /// <param name="sender">The Sender</param>
        /// <param name="e">The Event Args</param>
        //private void BtnClear_Click(object sender, EventArgs e)
        //{
        //    Value = 0;
        //    Close();
        //}

        /// <summary>
        /// Cancel Button Click Event
        /// </summary>
        /// <param name="sender">The Sender</param>
        /// <param name="e">The Event Args</param>
        //private void BtnCancel_Click(object sender, EventArgs e)
        //{
        //    Close();
        //}
    }
}
