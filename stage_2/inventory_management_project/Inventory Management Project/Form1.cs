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
            //Connection string - note change the drive letter depending on the letter of the USB!
            //Unsure where the connection string settup for the DataSets created using Visual Studio is stored in code form, but it can be changed via "Project > Project Properties > Settings"
            
            //System.Data.SqlClient.SqlConnection Connect = new SqlConnection("Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename="E:\SQL Database\graded_unit.mdf";Integrated Security=True;Connect Timeout=30");
            //DataTable dt = new DataTable();
            //.Data.SqlClient.SqlCommand insert = new System.Data.SqlClient.SqlCommand();

            //DataSets created to read data from the database into DataGridViews
            this.gu_batchTableAdapter.Fill(this.graded_unitDataSet6.gu_batch);
            this.packagingDutyRecordsViewTableAdapter.Fill(this.graded_unitDataSet5.packagingDutyRecordsView);
            this.salesSoldViewTableAdapter.Fill(this.graded_unitDataSet4.salesSoldView);
            this.salesAvailableViewTableAdapter.Fill(this.graded_unitDataSet3.salesAvailableView);
            this.packagingViewTableAdapter.Fill(this.graded_unitDataSet2.packagingView);
            this.productionViewTableAdapter.Fill(this.graded_unitDataSet1.productionView);

        }
    }
}
