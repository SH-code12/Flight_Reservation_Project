using System.Data.SqlClient;

namespace FlightReservation
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            button1.Click += button1_Click;
            button2.Click += button2_Click;
            button3.Click += button3_Click;



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

                    string sqlQueryInsert = "INSERT INTO User_ (UserID , Fname , Lname ,PassportNum,phone,Passenger,Admin_) " +
                        " VALUES (@UserID, @Fname,@Lname,@PassportNum,@phone,@Passenger,@Admin_ )";


                    SqlCommand command = new SqlCommand(sqlQueryInsert, conn);


                    command.Parameters.AddWithValue("@UserID", Convert.ToInt32(textBox2.Text));
                    command.Parameters.AddWithValue("@Fname", textBox3.Text);
                    command.Parameters.AddWithValue("@Lname", textBox4.Text);
                    command.Parameters.AddWithValue("@PassportNum", textBox5.Text);
                    command.Parameters.AddWithValue("@phone", textBox6.Text);
                    command.Parameters.AddWithValue("@Passenger", radioButton2.Checked ? "1" : "0");
                    command.Parameters.AddWithValue("@Admin_", radioButton1.Checked ? "1" : "0");


                    MessageBox.Show("Executing Query...");
                    int rowsAffected = command.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        MessageBox.Show("SignUp Successfully!");
                    }
                    
                    else
                    {
                        MessageBox.Show("Fail To SignUp!");
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
            if (radioButton2.Checked) {
                Form13 form13 = new Form13();
                form13.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Sorry! Not Allow For You!");
            }
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                Form12 form12 = new Form12();
                form12.Show();
                this.Hide();
            }
            
            else
            {
                MessageBox.Show("Sorry! Not Allow For You!");
            }
        }


    }
}
