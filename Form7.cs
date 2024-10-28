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
    public partial class Form7 : Form
    {
        string connectionString = "Server=Eng-SHAHD;Database=FlightReservation;Integrated Security=True;";

        public Form7()
        {
            InitializeComponent();
            button1.Click += back_button_click; 
            button2.Click += source_show_button_click;
        }
        private void back_button_click(object sender, EventArgs e)
        {
            // Open Form10 when the date_button is clicked
            Form6 form6 = new Form6();
            form6.Show();
            this.Hide();
        }



        private void LoadDataIntoDataGridView()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    //string source = textBox2.Text;


                    // Construct SQL query with parameters
                    string sqlQuerySelect = @"SELECT * FROM Flight WHERE Source_Name = @Source_Name";
                    

                    using (SqlCommand cmd = new SqlCommand(sqlQuerySelect, conn))
                    {
                        // Add parameters to the SqlCommand
                        cmd.Parameters.AddWithValue("@Source_Name", textBox2.Text);
                        using (SqlDataAdapter adapter = new SqlDataAdapter(cmd))
                        {
                            DataTable dataTable = new DataTable();
                            adapter.Fill(dataTable);
                            dataGridView1.DataSource = dataTable;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("An error occurred: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void source_show_button_click(object sender, EventArgs e)
        {
            LoadDataIntoDataGridView();
        }

        private void Form7_Load(object sender, EventArgs e)
        {
            // This is the Load event handler for the form
        }
    }
}
