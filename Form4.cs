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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
            button1.Click += button1_Click;
            button2.Click += button2_Click;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string connString = "Server=Eng-SHAHD; Database=FlightReservation; Integrated Security=True;";

            using (SqlConnection conn = new SqlConnection(connString))
            {
                try
                {
                    conn.Open();
                    Console.WriteLine("Connected");

                    MessageBox.Show("Connection Successful...");

                    string sqlQueryInsert1 = "INSERT INTO AirPlane (PlanCode,PlanName) VALUES (@PlanCode,@PlanName)";
                    string sqlQueryInsert2 = "INSERT INTO AirPlaneType (MaxSeats, MadeIn, CompanyName, PlanCode) VALUES (@MaxSeats, @MadeIn, @CompanyName, @PlanCode)";


                    SqlCommand command = new SqlCommand(sqlQueryInsert1, conn);
                    SqlCommand command2 = new SqlCommand(sqlQueryInsert2, conn);


                    command.Parameters.AddWithValue("@PlanCode", textBox1.Text);
                    command.Parameters.AddWithValue("@PlanName", textBox2.Text);
                    command2.Parameters.AddWithValue("@MaxSeats", Convert.ToInt32(textBox3.Text)); // Assuming textBox1 contains the flight ID
                    command2.Parameters.AddWithValue("@MadeIn", textBox4.Text);
                    command2.Parameters.AddWithValue("@CompanyName", textBox5.Text);
                    command2.Parameters.AddWithValue("@PlanCode", textBox6.Text);


                    MessageBox.Show("Executing Query...");
                    int rowsAffected = command.ExecuteNonQuery();
                    int rowAffected = command2.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Inserted Successfully!");
                    }
                    else
                    {
                        MessageBox.Show("No rows inserted!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form12 form12 = new Form12();
            form12.Show();
            this.Hide();
        }
    }
}
