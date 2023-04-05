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
    public partial class Chairman : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\AniMuS\Documents\Data.mdf;Integrated Security=True;Connect Timeout=30");
        public Chairman()
        {
            InitializeComponent();
                 SidePanel.Height = button1.Height;
            SidePanel.Top = button1.Top;
            pLab1Load1.BringToFront();
            button5.Hide();
            button7.Hide();
            addRemove1.Hide();
         

        }

        private void Chairman_Load(object sender, EventArgs e)
        {
            con.Open();
            string str = "Chairman";
            SqlCommand cmd = new SqlCommand("select * from Data where Role='" + str + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                label1.Text = "Welcome," + (dr["Fullname"].ToString());
            }
            con.Close();
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

      



        private void button1_Click(object sender, EventArgs e)
        {
            SidePanel.Height = button1.Height;
            SidePanel.Top = button1.Top;
            button5.Hide();
            button7.Hide();
        
            button3.Show();
            button4.Show();
            pLab1Load1.BringToFront();


        }

      
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Form1 ss = new Form1();
            ss.Show();
        }

        private void pLab2Load1_Load(object sender, EventArgs e)
        {

        }

        private void pLab1Load1_Load(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update Data set Password='" + textBox5.Text + "' where Password='" + textBox4.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);

            con.Close();
            MessageBox.Show("Password changed successfully");
        }

        private void button2_Click(object sender, EventArgs e)
        {

            SidePanel.Top = button2.Top;
            SidePanel.Height = button2.Height;
            fcLab1Load1.BringToFront();
            button3.Hide();
            button4.Hide();
            button7.Show();
            button5.Show();
            
        
    }

        private void pLab2Load2_Load(object sender, EventArgs e)
        {

        }

        private void button3_Click_1(object sender, EventArgs e)
        {

      

            pLab1Load1.BringToFront();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {


            pLab2Load1.BringToFront();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            fcLab1Load1.BringToFront();

  
        }

        private void button7_Click(object sender, EventArgs e)
        {
            fcLab2Load1.BringToFront();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            
            SidePanel.Top = button8.Top;
            SidePanel.Height = button8.Height;
            SidePanel.BringToFront();
            addRemove1.Show();
            fcLab2Load1.SendToBack();
            fcLab1Load1.SendToBack();
            pLab2Load1.SendToBack();
            pLab1Load1.SendToBack();
            button3.Hide();
            button4.Hide();
            button7.Hide();
            button5.Hide();
        

        }
    }
}
