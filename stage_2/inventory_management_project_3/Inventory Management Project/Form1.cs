using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

//Change connection string drive letter in Properties > Settings.settings > Settings.Designer.cs

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
			loadData();
		}

		public void loadData()
		{
			//This code loads the data into the ComboBoxes
			this.gu_dutyTableAdapter.Fill(this.gu_tables.gu_duty);
			this.gu_staffTableAdapter.Fill(this.gu_tables.gu_staff);
			this.gu_batchTableAdapter.Fill(this.gu_tables.gu_batch);
			this.gu_locationTableAdapter.Fill(this.gu_tables.gu_location);
			this.gu_storageTableAdapter.Fill(this.gu_tables.gu_storage);
			this.gu_alcaholTableAdapter.Fill(this.gu_tables.gu_alcahol);

			//This code loads the data into the DataGridViews
			this.productionViewTableAdapter.Fill(this.gu_views.productionView);
			this.salesAvailableViewTableAdapter.Fill(this.gu_views.salesAvailableView);
			this.packagingDutyRecordsViewTableAdapter.Fill(this.gu_views.packagingDutyRecordsView);
			this.packagingStockViewTableAdapter.Fill(this.gu_views.packagingStockView);
		}

		//Updates the updateDate picker to use correct date format for the date datatype in SQL
		public void SetMyCustomFormat()
		{
			//TODO: Check if this is working later as it isn't displayed as such
			updateDate.Format = DateTimePickerFormat.Custom;
			updateDate.CustomFormat = "yyyy MMM dd";
		}

		//Button onclick for Production > Insert
		private void submitRecordsInsert_Click(object sender, EventArgs e)
		{
			//Variable to check insertion or convert datatype
			int alcoholConverter;
			String gyleCheck;
			int containerConverter;
			int quantityConverter;
			int locationConverter;

			//Converting datatypes
			Int32.TryParse(insertAlcohol.SelectedValue.ToString(), out alcoholConverter);

			//Check text has been entered
			if (String.IsNullOrEmpty(insertGyle.Text))
			{
				MessageBox.Show("Please enter the gyle");
				return;
			}
			else
			{
				gyleCheck = insertGyle.Text;
			}

			//Converting datatypes
			Int32.TryParse(insertContainer.SelectedValue.ToString(), out containerConverter);

			//Check only integers have been entered
			if (!Int32.TryParse(insertNumberContainers.Text, out quantityConverter))
			{
				MessageBox.Show("Please enter an integer");
				return;
			}

			//Converting datatypes
			Int32.TryParse(insertLocation.SelectedValue.ToString(), out locationConverter);

			//Pass the parsed values into the insert method
			productionInsertRecords(alcoholConverter, gyleCheck, containerConverter, quantityConverter, locationConverter);

			//Reloads data into relevant fields
			loadData();
		}

		//Insertion code for Production > Insert
		private void productionInsertRecords(int drink_id, String gyle, int container_id, int number_of_items, int location_id)
		{
			//Connection string
			SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\SQL Database\graded_unit.mdf;Integrated Security=False;Connect Timeout=30");

			//Test the connection open
			try
			{
				con.Open();
			}
			catch (Exception err)
			{
				MessageBox.Show(err.Message);
			}

			//Insert records
			string sql = "INSERT INTO gu_batch (drink_id, gyle, container_id, number_of_items, location_id) VALUES (@drink_id, @gyle, @container_id, @number_of_items, @location_id); ";
			using (var cmd = new SqlCommand(sql, con))
			{
				cmd.Parameters.AddWithValue("@drink_id", drink_id);
				cmd.Parameters.AddWithValue("@gyle", gyle);
				cmd.Parameters.AddWithValue("@container_id", container_id);
				cmd.Parameters.AddWithValue("@number_of_items", number_of_items);
				cmd.Parameters.AddWithValue("@location_id", location_id);

				//Test the insertion
				try
				{
					cmd.ExecuteNonQuery();
					MessageBox.Show("The record was entered successfully");
				}
				catch (Exception err)
				{
					MessageBox.Show(err.Message);
				}

				//Test connection close
				try
				{
					con.Close();
				}
				catch (Exception err)
				{
					MessageBox.Show(err.Message);
				}

			}
		}

		//Button onclick for Packaging > Bottle
		private void submitRecordsBottle_Click(object sender, EventArgs e)
		{
			//Variable to check insertion or convert datatype
			int containerConverter;
			int quantityConverter;
			int locationConverter;

			//Converting datatypes
			Int32.TryParse(updateContainer.SelectedValue.ToString(), out containerConverter);

			//Check only integers have been entered
			if (!Int32.TryParse(updateNumberContainers.Text, out quantityConverter))
			{
				MessageBox.Show("Please enter an integer");
				return;
			}

			//Converting datatypes
			Int32.TryParse(updateLocationBottle.SelectedValue.ToString(), out locationConverter);

			//Pass the parsed values into the update method
			packagingBottlingRecords(selectGyleBottle.Text, containerConverter, quantityConverter, updateDate.Text, locationConverter);

			//Reloads data into relevant fields
			loadData();
		}

		//Update code for Packaging > Bottle
		private void packagingBottlingRecords(String gyle, int container_id, int number_of_items, String date_filled, int location_id)
		{
			//Connection string
			SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\SQL Database\graded_unit.mdf;Integrated Security=False;Connect Timeout=30");

			//Test the connection open
			try
			{
				con.Open();
			}
			catch (Exception err)
			{
				MessageBox.Show(err.Message);
			}

			//Insert records
			//string sql = "INSERT INTO gu_batch (gyle, container_id, number_of_items, date_filled, location_id) VALUES (@gyle, @container_id, @number_of_items, @date_filled, @location_id); ";
			string sql = "UPDATE gu_batch SET container_id = @container_id, number_of_items = @number_of_items, date_filled = @date_filled, location_id = @location_id, filled = 'Y' WHERE gyle = @gyle; ";
			using (var cmd = new SqlCommand(sql, con))
			{
				cmd.Parameters.AddWithValue("@gyle", gyle);
				cmd.Parameters.AddWithValue("@container_id", container_id);
				cmd.Parameters.AddWithValue("@number_of_items", number_of_items);
				cmd.Parameters.AddWithValue("@date_filled", date_filled);
				cmd.Parameters.AddWithValue("@location_id", location_id);

				//Test the insertion
				try
				{
					cmd.ExecuteNonQuery();
					MessageBox.Show("The record was entered successfully");
				}
				catch (Exception err)
				{
					MessageBox.Show(err.Message);
				}

				//Test connection close
				try
				{
					con.Close();
				}
				catch (Exception err)
				{
					MessageBox.Show(err.Message);
				}

			}
		}

		//Button onclick for Packaging > Label
		private void submitRecordsLabel_Click(object sender, EventArgs e)
		{
			//Variable to check insertion or convert datatype
			int staffIDConverter;
			int locationConverter;
			String dutyStartNumberCheck;
			String dutyEndNumberCheck;

			//Converting datatypes
			Int32.TryParse(setStaffID.SelectedValue.ToString(), out staffIDConverter);

			//Check text has been entered
			if (String.IsNullOrEmpty(setStartNumber.Text))
			{
				MessageBox.Show("Please enter the duty start number");
				return;
			}
			else
			{
				dutyStartNumberCheck = setStartNumber.Text;
			}

			//Check text has been entered
			if (String.IsNullOrEmpty(setEndNumber.Text))
			{
				MessageBox.Show("Please enter the duty end number");
				return;
			}
			else
			{
				dutyEndNumberCheck = setEndNumber.Text;
			}

			//Converting datatypes
			Int32.TryParse(updateLocationLabel.SelectedValue.ToString(), out locationConverter);

			//Pass the parsed values into the update method
			packagingLabelingRecords(selectGyleLabel.Text, staffIDConverter, dutyStartNumberCheck, dutyEndNumberCheck, setDutyStatus.Text, locationConverter);

			//Reloads data into relevant fields
			loadData();
		}

		//Insertion code for Packaging > Label
		private void packagingLabelingRecords(String gyle, int staff_id, String stamp_start_number, String stamp_end_number, String duty_status, int location_id)
		{
			//Connection string
			SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=F:\SQL Database\graded_unit.mdf;Integrated Security=False;Connect Timeout=30");

			//Test the connection open
			try
			{
				con.Open();
			}
			catch (Exception err)
			{
				MessageBox.Show(err.Message);
			}

			//Insert records
			string sql = "INSERT INTO gu_duty (gyle, staff_id, stamp_start_number, stamp_end_number, duty_status) VALUES (@gyle, @staff_id, @stamp_start_number, @stamp_end_number, @duty_status); UPDATE gu_batch SET packaged = 'Y', location_id = @location_id WHERE gyle = @gyle; ";


			using (var cmd = new SqlCommand(sql, con))
			{
				cmd.Parameters.AddWithValue("@gyle", gyle);
				cmd.Parameters.AddWithValue("@staff_id", staff_id);
				cmd.Parameters.AddWithValue("@stamp_start_number", stamp_start_number);
				cmd.Parameters.AddWithValue("@stamp_end_number", stamp_end_number);
				cmd.Parameters.AddWithValue("@duty_status", duty_status);
				cmd.Parameters.AddWithValue("@location_id", location_id);

				//Test the insertion
				try
				{
					cmd.ExecuteNonQuery();
					MessageBox.Show("The record was entered successfully");
				}
				catch (Exception err)
				{
					MessageBox.Show(err.Message);
				}

				//Test connection close
				try
				{
					con.Close();
				}
				catch (Exception err)
				{
					MessageBox.Show(err.Message);
				}

			}



















			//Set packaged to Y in code
			//Location is changed in batch, requires seperate SQL statement
		}
	}
}
