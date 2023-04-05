using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace DemoProject
{
    public partial class AddRemove : UserControl
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\AniMuS\Documents\Data.mdf;Integrated Security=True;Connect Timeout=30");
        public AddRemove()
        {
            InitializeComponent();
            FillCombo();
            
        }
        private void FillCombo()
        {
            comboBox1.Items.Add("PLab1A");
            comboBox1.Items.Add("PLab2A");
            comboBox1.Items.Add("PLab1I");
            comboBox1.Items.Add("PLab2I");
            comboBox1.Items.Add("FCLab1A");
            comboBox1.Items.Add("FCLab2A");
            comboBox1.Items.Add("FCLab1I");
            comboBox1.Items.Add("FCLab2I");
            comboBox1.Items.Add("Chairman");
            comboBox1.Items.Add("Coordinator1");
            comboBox1.Items.Add("Coordinator2");


        }
        private void clear()
        {
            textBox1.Text = "";
            comboBox1.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";

        }
        private void LOAD()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select  * from Data";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            dataGridView1.Columns[1].Visible = false;

            con.Close();
        }
        private void AddRemove_Load(object sender, EventArgs e)
        {
            LOAD();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "update Data set UserId='"+textBox1.Text+"',Role='"+ comboBox1.Text+ "',Fullname='"+textBox3.Text+"' where UserId='"+textBox4.Text+"'";
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Information updated successfully");
            LOAD();
            clear();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];
                   
                    textBox1.Text = row.Cells["UserId"].Value.ToString();
                    comboBox1.Text = row.Cells["Role"].Value.ToString();
              
                    textBox3.Text = row.Cells["Fullname"].Value.ToString();
                    textBox4.Text = row.Cells["UserId"].Value.ToString();

                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into Data values('"+textBox1.Text+"','"+textBox1.Text+"','"+comboBox1.Text+ "','"+textBox3.Text+"')";
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Information added successfully");
            LOAD();
            clear();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from Data where UserId='"+textBox1.Text+"'and Role='"+comboBox1.Text+"'";
            cmd.ExecuteNonQuery();
            con.Close();
            MessageBox.Show("Information deleted successfully");
            LOAD();
            clear();
        }
    }
}
