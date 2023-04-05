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



namespace DemoProject
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\AniMuS\Documents\Data.mdf;Integrated Security=True;Connect Timeout=30");
            SqlDataAdapter sda = new SqlDataAdapter("Select Role From Data where UserId='"+textBox1.Text+"' and Password='"+textBox2.Text+"'",con);
            DataTable dt = new System.Data.DataTable();
            sda.Fill(dt);
            int i = dt.Rows.Count;

            if (i > 0)
            {
                if (dt.Rows[0][0].ToString() == "PLab1A")
                {

                    this.Hide();
                    PLab1A ss = new PLab1A();

                    ss.Show();



                }
                else if (dt.Rows[0][0].ToString() == "PLab2A")
                {

                    this.Hide();
                    PLab2A ss = new PLab2A();
                    ss.Show();



                }
                else if (dt.Rows[0][0].ToString() == "Chairman")
                {

                    this.Hide();
                    Chairman ss = new Chairman();
                    ss.Show();



                }

                else if (dt.Rows[0][0].ToString() == "FCLab1A")
                {

                    this.Hide();
                    FCLab1A ss = new FCLab1A();

                    ss.Show();



                }
                else if (dt.Rows[0][0].ToString() == "FCLab2A")
                {

                    this.Hide();
                    FCLab2A ss = new FCLab2A();
                    ss.Show();



                }
                else if (dt.Rows[0][0].ToString() == "FCLab1I")
                {

                    this.Hide();
                    FCLab1Incharge ss = new FCLab1Incharge();

                    ss.Show();



                }
                else if (dt.Rows[0][0].ToString() == "FCLab2I")
                {

                    this.Hide();
                    FCLab2Incharge ss = new FCLab2Incharge();
                    ss.Show();



                }
                else if (dt.Rows[0][0].ToString() == "PLab1I")
                {

                    this.Hide();
                    PLab1Incharge ss = new PLab1Incharge();

                    ss.Show();



                }
                else if (dt.Rows[0][0].ToString() == "PLab2I")
                {

                    this.Hide();
                    PLab2Incharge ss = new PLab2Incharge();
                    ss.Show();



                }
                else if (dt.Rows[0][0].ToString() == "Coordinator1")
                {

                    this.Hide();
                    Coordinator1 ss = new Coordinator1();

                    ss.Show();



                }
                else if (dt.Rows[0][0].ToString() == "Coordinator2")
                {

                    this.Hide();
                    Coordinator2 ss = new Coordinator2();
                    ss.Show();



                }
                else
                {
                    MessageBox.Show("Wrong UserId or Password");
                }
            }
            else
            {
                MessageBox.Show("Wrong Username or Password");
            }
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

      
        private void pictureBox4_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_KeyPress(object sender, KeyPressEventArgs e)
        {
            
        }
    }
}
