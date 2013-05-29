using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace 毕业实习分配系统
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
           // ConnectSql();
        }

        public void ConnectSql()
        {
            SqlConnection con = new SqlConnection(SQL.conStr);
            try
            {
                con.Open();
            }
            catch (Exception ex)
            {
                MessageBox.Show("打开失败：" + ex.Message);
            }

        }
    }
}
