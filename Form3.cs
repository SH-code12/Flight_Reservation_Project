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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace FlightReservation
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
            button1.Click += button1_Click;
            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            // Set initial value
            dateTimePicker1.Value = new DateTime(2024, 5, 15, 8, 0, 0);

            dateTimePicker2.Format = DateTimePickerFormat.Custom;
            dateTimePicker2.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            // Set initial value
            dateTimePicker2.Value = new DateTime(2024, 5, 15, 8, 0, 0);
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

                    string sqlQueryUpdate = "UPDATE Flight SET Source_Name = @Source_Name, Desctination_Name = @Desctination_Name, LeftTime = @LeftTime, ArriveTime = @ArriveTime ,FlightClassId = @FlightClassId, AirLine_Name = @AirLine_Name WHERE Flight_ID = @Flight_ID";
                    SqlCommand command = new SqlCommand(sqlQueryUpdate, conn);

                    command.Parameters.AddWithValue("@Flight_ID", Convert.ToInt32(textBox1.Text)); // Assuming textBox1 contains the flight ID
                    command.Parameters.AddWithValue("@Source_Name", textBox2.Text);
                    command.Parameters.AddWithValue("@Desctination_Name", textBox3.Text);
                    command.Parameters.AddWithValue("@LeftTime", dateTimePicker1.Value);
                    command.Parameters.AddWithValue("@ArriveTime", dateTimePicker2.Value);
                    command.Parameters.AddWithValue("@FlightClassId", Convert.ToInt32(textBox4.Text)); // Assuming textBox1 contains the flight ID
                    command.Parameters.AddWithValue("@AirLine_Name", textBox5.Text); // Assuming textBox1 contains the flight ID



                    MessageBox.Show("Executing Query...");
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Update Successfully!");
                    }
                    else
                    {
                        MessageBox.Show("No rows Updates!");
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
