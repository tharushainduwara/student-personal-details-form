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

namespace Student_Personal_Details
{
    public partial class Form1 : Form
    {
        //connect to database
        SqlConnection con = new SqlConnection(@"Data Source=ACER\SQLEXPRESS;Initial Catalog=student_info;Integrated Security=True");
        public Form1()
        {
            InitializeComponent();
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string registrationNo, firstName, lastName, street, city, district, nicNo, mobileNo, email;

            try
            {
                //Get details 
                registrationNo = regNoText.Text;
                firstName = firstNameText.Text;
                lastName = lastNameText.Text;
                street = streetText.Text;
                city = cityText.Text;
                district = districtComboBox.SelectedItem != null ? districtComboBox.SelectedItem.ToString() : "Not Selected";
                nicNo = nicText.Text;
                mobileNo = mobileText.Text;
                email = emailText.Text;

                con.Open();
                
                //Insert data
                string query = "INSERT INTO student_info (Reg_No, First_Name, Last_Name, Street, City, District, NIC_No, Mobile_Phone, Email)" + "VALUES(@r,@f,@l,@s,@c,@d,@n,@m,@e)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@r", registrationNo);
                cmd.Parameters.AddWithValue("@f", firstName);
                cmd.Parameters.AddWithValue("@l", lastName);
                cmd.Parameters.AddWithValue("@s", street);
                cmd.Parameters.AddWithValue("@c", city);
                cmd.Parameters.AddWithValue("@d", district);
                cmd.Parameters.AddWithValue("@n", nicNo);
                cmd.Parameters.AddWithValue("@m", mobileNo);
                cmd.Parameters.AddWithValue("@e", email);

                //Execute command
                cmd.ExecuteNonQuery();

                MessageBox.Show("Student details recorded successfully!", "Success", MessageBoxButtons.OKCancel, MessageBoxIcon.Information);
                
                con.Close();
                
                // refresh grid
                viewButton_Click(sender, e);
                
                //Clear all fields
                reloadGridAndClearFields();


            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
                if (con.State == ConnectionState.Open) 
                    con.Close();
            }
        }

        void reloadGridAndClearFields()
        {
            regNoText.Clear();
            firstNameText.Clear();
            lastNameText.Clear();
            streetText.Clear();
            cityText.Clear();
            districtComboBox.Text = "";
            nicText.Clear();
            mobileText.Clear();
            emailText.Clear();
            regNoText.Focus();
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            string registrationNo, firstName, lastName, street, city, district, nicNo, mobileNo, email;

            try
            {
                //Get details 
                registrationNo = regNoText.Text;
                firstName = firstNameText.Text;
                lastName = lastNameText.Text;
                street = streetText.Text;
                city = cityText.Text;
                district = districtComboBox.SelectedItem != null ? districtComboBox.SelectedItem.ToString() : "Not Selected";
                nicNo = nicText.Text;
                mobileNo = mobileText.Text;
                email = emailText.Text;

                con.Open();

                //Insert data
                string query = "INSERT INTO student_info (Reg_No, First_Name, Last_Name, Street, City, District, NIC_No, Mobile_Phone, Email)" + "VALUES(@r,@f,@l,@s,@c,@d,@n,@m,@e)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@r", registrationNo);
                cmd.Parameters.AddWithValue("@f", firstName);
                cmd.Parameters.AddWithValue("@l", lastName);
                cmd.Parameters.AddWithValue("@s", street);
                cmd.Parameters.AddWithValue("@c", city);
                cmd.Parameters.AddWithValue("@d", district);
                cmd.Parameters.AddWithValue("@n", nicNo);
                cmd.Parameters.AddWithValue("@m", mobileNo);
                cmd.Parameters.AddWithValue("@e", email);

                //Execute command
                cmd.ExecuteNonQuery();

                MessageBox.Show("Student details recorded successfully!","Success",MessageBoxButtons.OKCancel,MessageBoxIcon.Information);
              
                con.Close();

                // refresh grid
                viewButton_Click(sender, e);

                //Clear all fields
                reloadGridAndClearFields();

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex.Message);
                if (con.State == ConnectionState.Open)
                    con.Close();
            }

        }


        private void deleteButton_Click(object sender, EventArgs e)
        {
            con.Open();

            string sql = "DELETE from student_info WHERE Reg_No = @r";

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue ("@r",regNoText.Text);
           
            cmd.ExecuteNonQuery(); 

            MessageBox.Show("Delete Data Successfully!","Success",MessageBoxButtons.OKCancel, MessageBoxIcon.Information);

            con.Close();

            //Clear all fields
            reloadGridAndClearFields();


        }

        private void viewButton_Click(object sender, EventArgs e)
        {
            //open connection
            con.Open();

            //refresh datgrid
            dataGridView1.Rows.Clear();

            string sql = "SELECT * FROM student_info";
            SqlCommand cmd = new SqlCommand(sql, con);

            //execute query
            var reader = cmd.ExecuteReader();
               
            //display result in GridView
                while (reader.Read())
                {
                    dataGridView1.Rows.Add(reader["Reg_No"], reader["First_Name"], reader["Last_Name"],
                        reader["Street"], reader["City"], reader["District"], reader["NIC_No"], reader["Mobile_Phone"],
                        reader["Email"]);

                }
            // connection close
            con.Close(); 
        
        }

        private void updateButton_Click(object sender, EventArgs e)
        {
            if (con.State == ConnectionState.Open)
                con.Close();

            con.Open();

            string sql = "UPDATE student_info SET Reg_No = @r, First_Name = @f, Last_Name = @l, Street = @s, " +
                   "City = @c, District = @d, NIC_No = @n,  Mobile_Phone = @m, Email = @e WHERE Reg_No = @r";

            SqlCommand cmd = new SqlCommand(sql, con);
            cmd.Parameters.AddWithValue("@r", regNoText.Text);
            cmd.Parameters.AddWithValue("@f", firstNameText.Text);
            cmd.Parameters.AddWithValue("@l", lastNameText.Text);
            cmd.Parameters.AddWithValue("@s", streetText.Text);
            cmd.Parameters.AddWithValue("@c", cityText.Text);
            cmd.Parameters.AddWithValue("@d", districtComboBox.Text);
            cmd.Parameters.AddWithValue("@m", mobileText.Text);
            cmd.Parameters.AddWithValue("@n", nicText.Text);
            cmd.Parameters.AddWithValue("@e", emailText.Text);

            cmd.ExecuteNonQuery();

            MessageBox.Show("Update Success","Success",MessageBoxButtons.OKCancel,MessageBoxIcon.Information);
            
            con.Close();


            // refresh grid       
            viewButton_Click(sender, e);
            
            //Clear all fields
            reloadGridAndClearFields();

        }

        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            regNoText.Text = row.Cells[0].Value.ToString();
            firstNameText.Text = row.Cells[1].Value.ToString();
            lastNameText.Text = row.Cells[2].Value.ToString();
            streetText.Text = row.Cells[3].Value.ToString();
            cityText.Text = row.Cells[4].Value.ToString();
            districtComboBox.Text = row.Cells[5].Value.ToString();
            nicText.Text = row.Cells[6].Value.ToString();
            mobileText.Text = row.Cells[7].Value.ToString();
            emailText.Text = row.Cells[8].Value.ToString();
        }
    }
}
