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
            // TODO: This line of code loads data into the 'graded_unitDataSet5.packagingDutyRecordsView' table. You can move, or remove it, as needed.
            this.packagingDutyRecordsViewTableAdapter.Fill(this.graded_unitDataSet5.packagingDutyRecordsView);
            // TODO: This line of code loads data into the 'graded_unitDataSet4.salesSoldView' table. You can move, or remove it, as needed.
            this.salesSoldViewTableAdapter.Fill(this.graded_unitDataSet4.salesSoldView);
            // TODO: This line of code loads data into the 'graded_unitDataSet3.salesAvailableView' table. You can move, or remove it, as needed.
            this.salesAvailableViewTableAdapter.Fill(this.graded_unitDataSet3.salesAvailableView);
            // TODO: This line of code loads data into the 'graded_unitDataSet2.packagingView' table. You can move, or remove it, as needed.
            this.packagingViewTableAdapter.Fill(this.graded_unitDataSet2.packagingView);
            // TODO: This line of code loads data into the 'graded_unitDataSet1.productionView' table. You can move, or remove it, as needed.
            this.productionViewTableAdapter.Fill(this.graded_unitDataSet1.productionView);
            // TODO: This line of code loads data into the 'testView._testView' table. You can move, or remove it, as needed.
            this.testViewTableAdapter.Fill(this.testView._testView);

        }
    }
}
