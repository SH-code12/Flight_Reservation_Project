using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FlightReservation
{
    public partial class Form2 : Form
    {
        public Form2()
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

                    string sqlQueryInsert = "INSERT INTO Flight (Flight_ID,Source_Name, Desctination_Name,LeftTime,ArriveTime,FlightClassId,AirLine_Name) VALUES (@Flight_ID,@Source_Name, @Desctination_Name,@LeftTime,@ArriveTime,@FlightClassId,@AirLine_Name)";

                    SqlCommand command = new SqlCommand(sqlQueryInsert, conn);

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
