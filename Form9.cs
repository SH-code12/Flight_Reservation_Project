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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
            button1.Click += button1_Click;
            button2.Click += button2_Click;


            dateTimePicker1.Format = DateTimePickerFormat.Custom;
            dateTimePicker1.CustomFormat = "yyyy-MM-dd HH:mm:ss";
            // Set initial value
            dateTimePicker1.Value = new DateTime(2024, 5, 15, 8, 0, 0);

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

                    string sqlQueryInsert1 = "INSERT INTO Reservaration (ReservarationNo,UserID,Flight_ID,FlightClassId,SeatNo , TicketNo,ISCancle , DateTime) " +
                        " VALUES (@ReservarationNo,@UserID,@Flight_ID,@FlightClassId,@SeatNo,@TicketNo,@ISCancle,@DateTime)";
                   
                    string sqlQueryInsert2 = "INSERT INTO FlightClass (FlightClassId, FirstClass, Business, Economy , Premium,TicketNo,SeatNo)" +
                        " VALUES (@FlightClassId, @FirstClass, @Business, @Economy,@Premium,@TicketNo,@SeatNo)";


                    SqlCommand command = new SqlCommand(sqlQueryInsert1, conn);
                    SqlCommand command2 = new SqlCommand(sqlQueryInsert2, conn);


                    command.Parameters.AddWithValue("@ReservarationNo", Convert.ToInt32(textBox3.Text));
                    command.Parameters.AddWithValue("@UserID", Convert.ToInt32(textBox4.Text));
                    command.Parameters.AddWithValue("@Flight_ID", Convert.ToInt32(textBox5.Text)); // Assuming textBox1 contains the flight ID
                    command.Parameters.AddWithValue("@FlightClassId", Convert.ToInt32(textBox9.Text));
                    command.Parameters.AddWithValue("@SeatNo", Convert.ToInt32(textBox6.Text));
                    command.Parameters.AddWithValue("@TicketNo", Convert.ToInt32(textBox7.Text));
                    command.Parameters.AddWithValue("@ISCancle",checkBox1.Checked ? "1" : "0");
                    command.Parameters.AddWithValue("@DateTime", dateTimePicker1.Value);

                    command2.Parameters.AddWithValue("@FlightClassId", Convert.ToInt32(textBox8.Text));
                    command2.Parameters.AddWithValue("@TicketNo", Convert.ToInt32(textBox7.Text));
                    command2.Parameters.AddWithValue("@SeatNo", Convert.ToInt32(textBox6.Text));
                    command2.Parameters.AddWithValue("@FirstClass", radioButton1.Checked ? "1" : "0");
                    command2.Parameters.AddWithValue("@Business", radioButton2.Checked ? "1" : "0");
                    command2.Parameters.AddWithValue("@Premium", radioButton3.Checked ? "1" : "0");
                    command2.Parameters.AddWithValue("@Economy", radioButton4.Checked ? "1" : "0");







                    MessageBox.Show("Executing Query...");
                    int rowsAffected = command.ExecuteNonQuery();
                    int rowAffected = command2.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("Reservation Successfully!");
                    }
                    else
                    {
                        MessageBox.Show("Not Book a Flight!");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form13 form13 = new Form13();
            form13.Show();
            this.Hide();
        }
    }
}
