private void userInsert(String fName, String lName, String password, String role)
        {
            SqlConnection con = new SqlConnection(@"Data Source = (LocalDB)\MSSQLLocalDB; AttachDbFilename =" + dbConnection + "; Integrated Security = True; Connect Timeout = 30");

            try
            {
                con.Open();
            } catch (Exception err) {
                MessageBox.Show(err.Message);
            }

            string sql = "INSERT INTO Staff (firstName, lastName, password, role) VALUES (@fName, @lName, @password, @role)";
            using (var cmd = new SqlCommand(sql, con)) {
				//This lets you put values in without directly adding them. 
                cmd.Parameters.AddWithValue("@fName", fName);
                cmd.Parameters.AddWithValue("@lName", lName);
                cmd.Parameters.AddWithValue("@password", password);
                cmd.Parameters.AddWithValue("@role", role);
                try{
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("The user was Added Successfully");
                } catch (Exception err) {
                    MessageBox.Show(err.Message);
                }

                try{
                    con.Close();
                }catch (Exception err){
                    MessageBox.Show(err.Message);
                }
            }
        }
		

private void emptyCheck(String fName, String lName, String password, String insertRole)
        {
            String role = "";

            if (string.IsNullOrWhiteSpace(fName))
                MessageBox.Show("Enter the users First Name");
            else if (string.IsNullOrWhiteSpace(lName))
                MessageBox.Show("Enter the users Last Name");
            else if (string.IsNullOrWhiteSpace(password))
                MessageBox.Show("Enter a Password");
            else if (insertRole == null)
                MessageBox.Show("Please select a Role");
            else
            {
                if (insertRole == "Customer Service")
                {
                    role = "custServ";
                }
                else if (insertRole == "Administrator")
                {
                    role = "admin";
                }
                else if (insertRole == "Maintenance")
                {
                    role = "maint";
                }
            }

            userInsert(fName, lName, password, role);
        }