using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Chapter16Exercise02
{
    public partial class Form1 : Form
    {
        static int passes = 0;
        static int count;

        public Form1()
        {
            InitializeComponent();
        }

        private void Label1_Click(object sender, EventArgs e)
        {

        }

        private void BtnCalc_Click(object sender, EventArgs e)
        {
            ShowAll();
        }

        private void ShowAll()
        {
            int i;
            var friends = new[] {
new {name = "Tom", state = "IN"},
new {name = "Terry", state = "MT"},
new {name = "Tammy", state = "IN"},
new {name = "Jane", state = "OH"},
new {name = "Don", state = "IN"},
new {name = "John", state = "IN"},
new {name = "Linda", state = "FL"},
};
            if (passes == 0)
            {
                count = friends.GetUpperBound(0);
                i = 0;
                for (i = 0; i <= count; i++)
                {
                    lstFull.Items.Add(friends[i].name + " " + friends[i].state);
                }
                passes++;
            }
            else
            {
                lstOutput.Items.Clear();
                var query = from p in friends // The "Query"
                            where p.state == txtState.Text.ToUpper()
                            select p;
                foreach (var val in query) // Display results
                    lstOutput.Items.Add(val.name + " " + val.state);
            }
        }

        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
