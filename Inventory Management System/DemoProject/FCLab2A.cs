﻿using System;
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
    public partial class FCLab2A : Form
    {
        SqlConnection con = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\AniMuS\Documents\Data.mdf;Integrated Security=True;Connect Timeout=30");
        public FCLab2A()
        {
            InitializeComponent();
            disp_data();
            textBox6.Hide();
        }
        public int A;
        public int B;
        public int C;
        public void disp_data()
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from FCLab2";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();

        }
        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from FCLab2 where ProductName= '" + textBox1.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;

            clear();
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            disp_data();
        }

    

        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from FCLab2 where ProductName='" + textBox1.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            disp_data();
            clear();
            MessageBox.Show("Record deleted succesfully");
        }

        private void button5_Click(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "insert into FCLab2 values('" + textBox1.Text + "','" + textBox2.Text + "','" + textBox3.Text + "')";
            cmd.ExecuteNonQuery();
            con.Close();
            disp_data();
            clear();
            MessageBox.Show("Record added succesfully");
        }



        private void PLab2A_Load(object sender, EventArgs e)
        {
            disp_data();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Form1 ss = new Form1();
            ss.Show();
        }

       
        private void clear()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";

        }

        private void linkLabel1_LinkClicked_1(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Form1 ss = new Form1();
            ss.Show();
        }

        private void FCLab2A_Load(object sender, EventArgs e)
        {
            con.Open();
            string str = "FCLab2A";
            SqlCommand cmd = new SqlCommand("select * from Data where Role='" + str + "'", con);
            SqlDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
            {

                label7.Text = "Welcome," + (dr["Fullname"].ToString());
            }
            con.Close();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "delete from FCLab2 where ProductName='" + textBox1.Text + "'";
            cmd.ExecuteNonQuery();
            con.Close();
            disp_data();
            clear();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;

            int a = Convert.ToInt32(textBox2.Text);


            if (textBox3.Text != "")
            {
                cmd.CommandText = "update FCLab2 set ExistingQuantity= '" + textBox2.Text + "',InStock='" + textBox3.Text + "' where ProductName='" + textBox1.Text + "'";
                cmd.ExecuteNonQuery();
                con.Close();
                disp_data();
                clear();

                MessageBox.Show("record updated succesfully");
            }
            else if (a < B)
            {

                int b = B - a;
                int c = A + a;

                cmd.CommandText = "update FCLab2 set ExistingQuantity= '" + c + "',InStock='" + b + "' where ProductName='" + textBox1.Text + "'";
                cmd.ExecuteNonQuery();
                con.Close();
                disp_data();
                clear();

                MessageBox.Show("record updated succesfully");
            }

            else
            {
                MessageBox.Show("Not enough products in STOCK");
                con.Close();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            disp_data();
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = con.CreateCommand();
            cmd.CommandType = CommandType.Text;
            cmd.CommandText = "select * from Inventory where ProductName= '" + textBox1.Text + "'";
            cmd.ExecuteNonQuery();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            da.Fill(dt);
            dataGridView1.DataSource = dt;
            con.Close();
            clear();
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
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex >= 0)
                {
                    DataGridViewRow row = this.dataGridView1.Rows[e.RowIndex];

                    textBox1.Text = row.Cells["ProductName"].Value.ToString();
                    A = Convert.ToInt32(row.Cells["ExistingQuantity"].Value.ToString());
                    B = Convert.ToInt32(row.Cells["InStock"].Value.ToString());



                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button6_Click_1(object sender, EventArgs e)
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
    }
}
