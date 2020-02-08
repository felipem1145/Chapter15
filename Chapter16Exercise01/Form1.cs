using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chapter16Exercise01
{
    public partial class Form1 : Form
    {
        private const int MAXNUM = 100; // Max random numbers
        static List<int> numbers = new List<int>(); // static list

        public Form1()
        {
            InitializeComponent();
            GenerateRandomValues();
        }



        private void BtnCalc_Click(object sender, EventArgs e)
        {
            int lo;
            int hi;

            lstOutput.Items.Clear();
            SetTheLimits(out lo, out hi);
            DoLINQQuery(lo, hi);
        }

        private void DoLINQQuery(int lo, int hi)
        {
            var query = from p in numbers // The "Query"
                        where p > lo && p < hi
                        select p;
            foreach (var val in query) // Display results
            {
                lstOutput.Items.Add(val.ToString());
            }
        }

        private void SetTheLimits(out int lo, out int hi)
        {
            bool flag = int.TryParse(txtLow.Text, out lo); // Input validation
            if (flag == false)
            {
                MessageBox.Show("Numeric only, 0 to 100", "Input Error");
                txtLow.Focus();
            }
            flag = int.TryParse(txtHi.Text, out hi);
            if (flag == false)
            {
                MessageBox.Show("Numeric only, 0 to 100", "Input Error");
                txtHi.Focus();
            }
        }

        private void GenerateRandomValues()
        {
            int temp;
            DateTime current = DateTime.Now;
            Random rnd = new Random((int)current.Ticks);
            for (int i = 0; i < MAXNUM; i++) // Random values
            {
                temp = rnd.Next(MAXNUM);
                numbers.Add(temp); // Copy into list
                lstFull.Items.Add(temp.ToString());
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
