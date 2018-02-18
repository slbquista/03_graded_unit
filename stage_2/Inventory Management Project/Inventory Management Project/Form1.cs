using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Inventory_Management_Project
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'graded_unitDataSet2.gu_batch' table. You can move, or remove it, as needed.
            this.gu_batchTableAdapter2.Fill(this.graded_unitDataSet2.gu_batch);
            // TODO: This line of code loads data into the 'graded_unitDataSet1.gu_batch' table. You can move, or remove it, as needed.
            this.gu_batchTableAdapter1.Fill(this.graded_unitDataSet1.gu_batch);
            // TODO: This line of code loads data into the 'graded_unitDataSet.gu_batch' table. You can move, or remove it, as needed.
            this.gu_batchTableAdapter.Fill(this.graded_unitDataSet.gu_batch);

        }
    }
}
