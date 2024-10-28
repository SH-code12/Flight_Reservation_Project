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
    public partial class Form10 : Form
    {
        string connString = "Server=Eng-SHAHD; Database=FlightReservation; Integrated Security=True;";

        public Form10()
        {
            InitializeComponent();
            button1.Click += button1_Click;
            button2.Click += button2_click;
            button3.Click += button3_click;
            button4.Click += button4_click;



        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form13 form13 = new Form13();
            form13.Show();
            this.Hide();
        }

        private void LoadDataIntoDataGridView()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();
                    // Construct SQL query with joins
                    string sqlQuerySelect = @"
                    SELECT 
                        R.ReservarationNo,
                        U.UserID,
                        U.Fname,
                        F.Source_Name,
                        F.Desctination_Name,
                        F.LeftTime,
                        F.ArriveTime,
                        FC.FlightClassId,
                        FC.FirstClass,
                        FC.Business,
                        FC.Economy,
                        FC.Premium,
                        S.SeatNo,
                        T.TicketNo,
                        T.Price,
                        R.ISCancle,
                        R.DateTime
                    FROM 
                        Reservaration R
                    INNER JOIN 
                        User_ U ON R.UserID = U.UserID
                    INNER JOIN 
                        Flight F ON R.Flight_ID = F.Flight_ID
                    INNER JOIN 
                        FlightClass FC ON R.FlightClassId = FC.FlightClassId
                    INNER JOIN 
                        Seat S ON R.SeatNo = S.SeatNo
                    INNER JOIN 
                        Tickets T ON R.TicketNo = T.TicketNo
                    WHERE 
                        R.ISCancle = 1 AND
                        U.UserID = @UserID AND
                        (FC.FirstClass = 1 OR FC.Business = 1 OR FC.Economy = 1 OR FC.Premium = 1)";  // Example filter

                    using (SqlCommand cmd = new SqlCommand(sqlQuerySelect, conn))
                    {
                        cmd.Parameters.AddWithValue("@UserID", Convert.ToInt32(textBox2.Text));

                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            if (dataTable.Rows.Count == 0)
                            {
                                MessageBox.Show("Sorry! There are no booked flights for you.", "No Reservations Found", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {

                                dataGridView1.DataSource = dataTable;


                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_click(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView();
        }

        private void button3_click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    string sqlQueryUpdate = "UPDATE FlightClass SET FirstClass = @FirstClass,Business = @Business,Economy = @Economy,Premium = @Premium WHERE FlightClassId = @FlightClassId";




                    using (SqlCommand cmd = new SqlCommand(sqlQueryUpdate, conn))
                    {
                        // Add parameters for update
                        cmd.Parameters.AddWithValue("@FirstClass", radioButton1.Checked ? "1" : "0");
                        cmd.Parameters.AddWithValue("@Business", radioButton2.Checked ? "1" : "0");
                        cmd.Parameters.AddWithValue("@Economy", radioButton3.Checked ? "1" : "0");
                        cmd.Parameters.AddWithValue("@Premium", radioButton4.Checked ? "1" : "0");
                        cmd.Parameters.AddWithValue("@FlightClassId", Convert.ToInt32(textBox4.Text));

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Flight class Changed successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No rows Changed. Please check the FlightClassId.", "No Class Changed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button4_click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connString))
                {
                    conn.Open();

                    string sqlQueryDelete = "DELETE FROM Reservaration  WHERE ReservarationNo = @ReservarationNo";




                    using (SqlCommand cmd = new SqlCommand(sqlQueryDelete, conn))
                    {
                        // Add parameters for update
                        cmd.Parameters.AddWithValue("@ReservarationNo", Convert.ToInt32(textBox6.Text));

                        int rowsAffected = cmd.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Reservation Cancelling successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("Fail To Cancelling . Please check the ReservationNo.", "No Class Changed", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
