using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;


namespace LayawayGradedUnit
{
    public partial class LayawaySystem : Form
    {
        //Connection String to Database - NOTE IT IS LOCATED ON DRIVE F:
        System.Data.SqlClient.SqlConnection Conn =
        new SqlConnection("Data Source=(LocalDB)\\MSSQLLocalDB;AttachDbFilename=F:\\LayawayGradedUnit\\LayawayGradedUnit\\LayawayDB.mdf;Integrated Security=True;Connect Timeout=30");
        DataTable dt = new DataTable();
        System.Data.SqlClient.SqlCommand insert = new System.Data.SqlClient.SqlCommand();


        public LayawaySystem()
        {
            InitializeComponent();
        }

        
        
        ///////////////////////////////////////
        //-- Main Page - Program Interface --//
        ///////////////////////////////////////

        private void LayawaySystem_Load(object sender, EventArgs e)
        {   
            //Fills Data Grids with information from the appropriate database table
            
            this.stockTableAdapter1.Fill(this.layawayDBDataSet5.Stock);
         
            // this.stockTableAdapter.Fill(this.layawayDBDataSet4.Stock);

            this.customerTableAdapter2.Fill(this.layawayDBDataSet3.Customer);

            this.locationTableAdapter.Fill(this.layawayDBDataSet1.Location);

            UsernameBox.Focus();
        }

        private void AddCustomerButton_Click(object sender, EventArgs e)
        {
            //Changes to the stated tab
            LayawaySystemTabs.SelectedIndex = 2;
        }

        private void EditCustomerButton_Click(object sender, EventArgs e)
        {
            //Changes to the stated tab
            LayawaySystemTabs.SelectedIndex = 3;
        }

        private void ViewLocationButton_Click(object sender, EventArgs e)
        {
            //Changes to the stated tab
            LayawaySystemTabs.SelectedIndex = 4;
        }

        private void ViewStockButton_Click(object sender, EventArgs e)
        {
            //Changes to the stated tab
            LayawaySystemTabs.SelectedIndex = 5;
        }

        private void AddStockButton_Click(object sender, EventArgs e)
        {
            //Changes to the stated tab
            LayawaySystemTabs.SelectedIndex = 6;
        }

        private void RemoveStockButtonMP_Click(object sender, EventArgs e)
        {
            //Changes to the stated tab
            LayawaySystemTabs.SelectedIndex = 7;
        }

        private void CloseConnButton_Click(object sender, EventArgs e)
        { 
            //Closes open database connections
            Conn.Close();
        }

        private void LogOutButton_Click(object sender, EventArgs e)
        {
            //Exits applicaitons
            Application.Exit();
        }

        private void SearchText_TextChanged(object sender, EventArgs e)
        {
            //Searches through customers via firstname, surname, postcode,city,email, telephone or layaway number.
            string Query = "";

            if (MainPageComboBox.Text == "FirstName")
                Query = "Select  FirstName, Surname, HouseNo, StreetName, Postcode, City, Telephone, Email, LayawayNumber FROM Customer WHERE FirstName LIKE '" + SearchText.Text + "%'";

            if (MainPageComboBox.Text == "Surname")
                Query = "Select  FirstName, Surname, HouseNo, StreetName, Postcode, City, Telephone, Email, LayawayNumber FROM Customer WHERE Surname LIKE '" + SearchText.Text + "%'";

            if (MainPageComboBox.Text == "Postcode")
                Query = "Select  FirstName, Surname, HouseNo, StreetName, Postcode, City, Telephone, Email, LayawayNumber FROM Customer WHERE Postcode LIKE '" + SearchText.Text + "%'";

            if (MainPageComboBox.Text == "City")
                Query = "Select  FirstName, Surname, HouseNo, StreetName, Postcode, City, Telephone, Email, LayawayNumber FROM Customer WHERE City LIKE '" + SearchText.Text + "%'";

            if (MainPageComboBox.Text == "Email")
                Query = "Select  FirstName, Surname, HouseNo, StreetName, Postcode, City, Telephone, Email, LayawayNumber FROM Customer WHERE Email LIKE '" + SearchText.Text + "%'";

            if (MainPageComboBox.Text == "Telephone")
                Query = "Select  FirstName, Surname, HouseNo, StreetName, Postcode, City, Telephone, Email, LayawayNumber FROM Customer WHERE Telephone LIKE '" + SearchText.Text + "%'";

            if (MainPageComboBox.Text == "LayawayNumber")
                Query = "Select  FirstName, Surname, HouseNo, StreetName, Postcode, City, Telephone, Email, LayawayNumber FROM Customer WHERE LayawayNumber LIKE '" + SearchText.Text + "%'";

            SqlDataAdapter da = new SqlDataAdapter(Query, Conn);
            DataTable data = new DataTable();
            da.Fill(data);
            CustomerGrid.DataSource = data;
        }




        ///////////////////////////
        //-- Log-in to system -- //
        ///////////////////////////

        private void LogInButton_Click(object sender, EventArgs e)
        {
            //Method to log-in to the system
            string a = UsernameBox.Text;
            string b = PasswordBox.Text;

            if (a == "User1")   //Prototype for simple login
            {
                if (b == "Password")
                {
                    MessageBox.Show("Login Is Successful");
                    //Changes to the stated tab
                    LayawaySystemTabs.SelectedIndex = 1;
                }
                else
                    MessageBox.Show("Incorrect Username or Password, Try Again");
            }
            else
                MessageBox.Show("Incorrect Username or Password, Try Again");
        }


        private void CloseButton_Click(object sender, EventArgs e)
        { 
            // exits applications - Quit
            Application.Exit();
        }




        /////////////////////////////////////////
        // -- Add Customer record to system -- //
        /////////////////////////////////////////
        
        private void ProcessButton_Click(object sender, EventArgs e)
        {
            //This method adds the customer to the database customers table
            try
            {
                System.Data.SqlClient.SqlCommand insert = new System.Data.SqlClient.SqlCommand();
                insert.CommandType = System.Data.CommandType.Text;
                insert.CommandText = "INSERT INTO Customer VALUES('" + textBoxFirstName.Text + "','" + textBoxLastName.Text + "','" + textBoxHouseNumber.Text + "','" + textBoxStreetName.Text + "','" + textBoxPostCode.Text + "','" + textBoxCity.Text + "','" + textBoxTelephone.Text + "','" + textBoxEmail.Text + "','" + textBoxLayawayNumber.Text + "');";
                insert.Connection = Conn;
                Conn.Open();
                insert.ExecuteNonQuery();
                insert.CommandText = "SELECT * FROM Customer;";
                SqlDataAdapter da = new SqlDataAdapter(insert);
                da.Fill(dt);
                CustomerGrid.DataSource = dt;
                Conn.Close();

                lbl_msg.Text = "Record Created";
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }
        }


        private void BackButtonAddCust_Click(object sender, EventArgs e)
        {
            //Changes to the stated tab
            LayawaySystemTabs.SelectedIndex = 1;
        }


        private void ClearFielsButtonCust_Click(object sender, EventArgs e)
        {
            textBoxFirstName.Text = "";
            textBoxLastName.Text = "";
            textBoxHouseNumber.Text = "";
            textBoxStreetName.Text = "";
            textBoxPostCode.Text = "";
            textBoxCity.Text = "";
            textBoxTelephone.Text = "";
            textBoxEmail.Text = "";
            textBoxLayawayNumber.Text = "";
        }




        ///////////////////////////////
        //-- Edit Customer Details --//
        ///////////////////////////////

        private void UpdateButton_Click(object sender, EventArgs e)
        {
            //Gets the strings from the forms text boxes
            String firstName = textBoxFirstName.Text;
            String surname = textBoxLastName.Text;
            String houseNo = textBoxHouseNumber.Text;
            String streetName = textBoxStreetName.Text;
            String postcode = textBoxPostCode.Text;
            String city = textBoxCity.Text;
            String telephone = textBoxTelephone.Text;
            String email = textBoxEmail.Text;
            String layaway = textBoxLayawayNumber.Text;

            try
            { 
                //Edits required customer record
                //Console.WriteLine("shdgsujhf");

                System.Data.SqlClient.SqlCommand cmd = new System.Data.SqlClient.SqlCommand();
                cmd.CommandType = System.Data.CommandType.Text;
                cmd.CommandText = ("Update Customer set FirstName = @parameter1, Surname = @parameter2, HouseNo = @parameter3, StreetName = @parameter4, Postcode = @parameter5, City = @parameter6, Telephone = @parameter7, Email = @parameter8 where LayawayNumber = @parameter9");
                cmd.Connection = Conn;
                Conn.Open();
                cmd.Parameters.AddWithValue("@parameter1", firstName);
                cmd.Parameters.AddWithValue("@parameter2", surname);
                cmd.Parameters.AddWithValue("@parameter3", houseNo);
                cmd.Parameters.AddWithValue("@parameter4", streetName);
                cmd.Parameters.AddWithValue("@parameter5", postcode);
                cmd.Parameters.AddWithValue("@parameter6", city);
                cmd.Parameters.AddWithValue("@parameter7", telephone);
                cmd.Parameters.AddWithValue("@parameter8", email);
                cmd.Parameters.AddWithValue("@parameter9", layaway);

                cmd.ExecuteNonQuery();
                cmd.CommandText = "SELECT * FROM Customer;";
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                CustomerGrid.DataSource = dt;
                //CustomerGrid.Refresh();
                Conn.Close();

                lbl_msg2.Text = "Record Updated";
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }
        }


        private void BackButtonEditCust_Click(object sender, EventArgs e)
        {
            //Changes to the stated tab
            LayawaySystemTabs.SelectedIndex = 1;
        }


        private void ClearFeildsEditButton_Click(object sender, EventArgs e)
        {
            //Initialises all form text boxes
            textBoxFirstName.Text = "";
            textBoxLastName.Text = "";
            textBoxHouseNumber.Text = "";
            textBoxStreetName.Text = "";
            textBoxPostCode.Text = "";
            textBoxCity.Text = "";
            textBoxTelephone.Text = "";
            textBoxEmail.Text = "";
            textBoxLayawayNumber.Text = "";
        }




        ////////////////////////////////
        //-- View Location of Items --//
        ////////////////////////////////

        private void SearchLocTextBox_TextChanged(object sender, EventArgs e)
        {
            //Searches through locations and displays by location number or layaway number.
            string Query = "";

            if (SearchLocComboBox.Text == "LocationNumber")
                Query = "Select LocationNumber, LayawayNumber FROM Location WHERE LocationNumber LIKE '" + SearchLocTextBox.Text + "%'";

            if (SearchLocComboBox.Text == "LayawayNumber")
                Query = "Select  LocationNumber, LayawayNumber FROM Location WHERE LayawayNumber LIKE '" + SearchLocTextBox.Text + "%'";

            SqlDataAdapter da = new SqlDataAdapter(Query, Conn);
            DataTable data = new DataTable();
            da.Fill(data);
            LocationGrid.DataSource = data;
        }


        private void addLayawayNoButton_Click(object sender, EventArgs e)
        {
            //Changes to the stated tab
            LayawaySystemTabs.SelectedIndex = 8;
        }


        private void BackButtonLocations_Click(object sender, EventArgs e)
        {
            //Changes to the stated tab
            LayawaySystemTabs.SelectedIndex = 1;
        }




        //////////////////////////
        //-- View Stock Items --//
        //////////////////////////

        private void AddStockButton2_Click(object sender, EventArgs e)
        {
            //Changes to the stated tab
            LayawaySystemTabs.SelectedIndex = 6;
        }

        private void BackButtonStock_Click(object sender, EventArgs e)
        {
            LayawaySystemTabs.SelectedIndex = 1;
        }




        /////////////////////////////
        // -- Add Item to Stock -- //         
        /////////////////////////////

        private void AddStockToDBButton_Click(object sender, EventArgs e)
        { 
            //Method adds the stock to the Stock database table
            try
            {
                System.Data.SqlClient.SqlCommand insert = new System.Data.SqlClient.SqlCommand();
                insert.CommandType = System.Data.CommandType.Text;
                insert.CommandText = "INSERT INTO Stock VALUES('" + textBoxSKN.Text + "','" + textBoxItemName.Text + "','" + textBoxItemDesc.Text + "','" + textBoxPrice.Text + "','" + textBoxQTY.Text + "');";
                insert.Connection = Conn;
                Conn.Open();
                insert.ExecuteNonQuery();
                insert.CommandText = "SELECT * FROM Stock;";
                SqlDataAdapter da = new SqlDataAdapter(insert);
                da.Fill(dt);
                StockGrid.DataSource = dt;
                Conn.Close();
                
                lbl_msg3.Text = "Stock Created";
            }
            catch (Exception E)
            {
                MessageBox.Show(E.Message);
            }
        }
        
        private void BackButtonAddStock_Click(object sender, EventArgs e)
        {
            //Changes to the stated tab
            LayawaySystemTabs.SelectedIndex = 5;
        }

        private void ClearFeildStockButton_Click(object sender, EventArgs e)
        { 
            //Initialises all text boxes on Stock form
            textBoxSKN.Text = "";
            textBoxItemName.Text = "";
            textBoxItemDesc.Text = "";
            textBoxPrice.Text = "";
            textBoxQTY.Text = "";
        }




        //////////////////////////////////
        // -- Remove Item from Stock -- //
        //////////////////////////////////

        private void removeStockButton_Click(object sender, EventArgs e)
        {
            //Removes stock from the database table based on the SKN number
            try
            {
                System.Data.SqlClient.SqlCommand insert = new System.Data.SqlClient.SqlCommand();
                insert.CommandType = System.Data.CommandType.Text;
                insert.CommandText = "DELETE FROM Stock WHERE SKN =" + textBoxRemoveSKN.Text;
                insert.Connection = Conn;
                Conn.Open();
                insert.ExecuteNonQuery();
                insert.CommandText = "SELECT * FROM Stock;";
                SqlDataAdapter da = new SqlDataAdapter(insert);
                da.Fill(dt);
                StockGrid.DataSource = dt;
                Conn.Close();
                MessageBox.Show("Delete Successful");

            }
            catch (SqlException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void backButtonRemoveStock_Click(object sender, EventArgs e)
        {
            //Changes to the stated tab
            LayawaySystemTabs.SelectedIndex = 1;
        }



        ///////////////////////////////
        // -- Layaway to Location -- //
        ///////////////////////////////

        private void addToLocationButton_Click(object sender, EventArgs e)
        {
            //Add like cutomers
            System.Data.SqlClient.SqlCommand insert = new System.Data.SqlClient.SqlCommand();
            insert.CommandType = System.Data.CommandType.Text;
            insert.CommandText = "INSERT INTO Location VALUES('" + textBoxLocationNumber.Text + "','" + textBoxLayawayNo.Text + "');";
            insert.Connection = Conn;

            Conn.Open();
            insert.ExecuteNonQuery();
            insert.CommandText = "SELECT * FROM Location;";
            SqlDataAdapter da = new SqlDataAdapter(insert);
            da.Fill(dt);
            LocationGrid.DataSource = dt;
            Conn.Close();

            lbl_msg4.Text = "Layaway Added to Location";
        }



        private void backButtonLL_Click(object sender, EventArgs e)
        {
            //Changes to the stated tab
            LayawaySystemTabs.SelectedIndex = 1;
        }

        private void ClearFeildsLLButton_Click(object sender, EventArgs e)
        { 
            //Initialises text boxes on form
            textBoxLocationNumber.Text = "";
            textBoxLayawayNo.Text = "";
        }
        
    }//End of class

}//End of namespace



