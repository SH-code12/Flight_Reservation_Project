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

namespace FlightReservation
{
    public partial class Form11 : Form
    {
        public Form11()
        {
            InitializeComponent();
            button1.Click += button1_Click;
            button2.Click += button2_Click;


        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form13 form13 = new Form13();
            form13.Show();
            this.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string connString = "Server=Eng-SHAHD; Database=FlightReservation; Integrated Security=True;";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    Console.WriteLine("Connected");

                    MessageBox.Show("Connection Successful...");

                    string sqlQueryInsert = "UPDATE User_ SET UserID = @UserID, Fname = @Fname,Lname =@Lname,PassportNum=@PassportNum,phone=@phone WHERE UserID = @UserID";


                    SqlCommand command = new SqlCommand(sqlQueryInsert, conn);


                    command.Parameters.AddWithValue("@UserID", Convert.ToInt32(textBox2.Text));
                    command.Parameters.AddWithValue("@Fname", textBox3.Text);
                    command.Parameters.AddWithValue("@Lname", textBox4.Text);
                    command.Parameters.AddWithValue("@PassportNum", textBox5.Text);
                    command.Parameters.AddWithValue("@phone", textBox6.Text);

                


                    MessageBox.Show("Executing Query...");
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Update Details Successfully!");
                    }
                    else
                    {
                        MessageBox.Show("No Details updated!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

        }
    }
}
