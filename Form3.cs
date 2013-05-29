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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //加载目录树
            gettreeview();
        }

        private void gettreeview()
        {
            string constr = " Data Source = 222.16.85.162; DataSource =实习单位; User ID =sa; PWD =123";
            SqlConnection con = new SqlConnection(constr);
            con.Open();
            string sqlstr = " select * from 实习单位（公司）";
            SqlDataAdapter sqldataadapter = new SqlDataAdapter(sqlstr, con);
            DataSet ds = new DataSet();
            sqldataadapter.Fill(ds, "实习单位（公司）");
            con.Close();

            // 加载根结点
            TreeNode tn = new TreeNode();
            tn.Text = "实习单位";
            tn.Name = "0";
            tn.Tag = "0";
            treeView1.Nodes.Add(tn);
            treeView1.SelectedNode = tn;

            // 加载子结点
            if (ds != null)
            {
                foreach (DataRow dr in ds.Tables[0].Rows)
                {
                    tn = new TreeNode();
                    tn.Text = dr["公司名"].ToString();
                    tn.Name = dr["地址"].ToString();
                    tn.Tag = dr["nd_parent"].ToString();
                    if (treeView1.SelectedNode != tn.Tag)
                    {
                        TreeNode[] tn_temp = treeView1.Nodes.Find(dr["nd_parent"].ToString(), true);
                        if (tn_temp.Length > 0)
                        {
                            treeView1.SelectedNode = tn_temp[0];
                        }
                    }
                    treeView1.SelectedNode.Nodes.Add(tn);
                }
            }
            //展开所有结点并且光标返回根结点
            treeView1.ExpandAll();
            treeView1.SelectedNode = treeView1.TopNode;
        }



        }
}