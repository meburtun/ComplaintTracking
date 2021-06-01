using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace quiz4
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void toolStripButtons_Click(object sender, EventArgs e)
        {
            var menubutton = sender as ToolStripButton;
            ComplaintRepository cr = new ComplaintRepository();
            var liste=cr.getData(menubutton.Text);
            foreach (var item in liste)
            {
                labelmonthname.Text = item.monthname;
                c1txtbox.Text = item.c1.ToString();
                c2txtbox.Text = item.c2.ToString();
                c3txtbox.Text = item.c3.ToString();
                c4txtbox.Text = item.c4.ToString();
                c5txtbox.Text = item.c5.ToString();
            }
            calculate();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            var menubutton = sender as ToolStripButton;
            ComplaintRepository cr = new ComplaintRepository();
            var liste=cr.getData(labelmonthname.Text);
            foreach (var item in liste)
            {
                labelmonthname.Text = item.monthname;
                c1txtbox.Text = item.c1.ToString();
                c2txtbox.Text = item.c2.ToString();
                c3txtbox.Text = item.c3.ToString();
                c4txtbox.Text = item.c4.ToString();
                c5txtbox.Text = item.c5.ToString();
            }


        }
        public void calculate()
        {
            int total = 0, c1, c2, c3, c4, c5;
            double    cc1,cc2,cc3,cc4,cc5;
            c1 =Convert.ToInt32(c1txtbox.Text);
            c2 =Convert.ToInt32(c2txtbox.Text);
            c3 =Convert.ToInt32(c3txtbox.Text);
            c4 =Convert.ToInt32(c4txtbox.Text);
            c5 =Convert.ToInt32(c5txtbox.Text);
            total = c1 + c2 + c3 + c4 + c5;
            totaltxtbox.Text = total.ToString();
            cc1 = (double)(int)c1 / total * 100;
            textBox6.Text = cc1.ToString();
            cc2 = (double)(int)c2 / total * 100;
            textBox7.Text = cc2.ToString();
            cc3 = (double)(int)c3 / total * 100;
            textBox8.Text = cc3.ToString();
            cc4 = (double)(int)c4 / total * 100;
            textBox9.Text = cc4.ToString();
            cc5 = (double)(int)c5 / total * 100;
            textBox10.Text = cc5.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            c1txtbox.Clear();
            c2txtbox.Clear();
            c3txtbox.Clear();
            c4txtbox.Clear();
            c5txtbox.Clear();
            textBox6.Clear();
            textBox7.Clear();
            textBox8.Clear();
            textBox9.Clear();
            textBox10.Clear();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            List<Complaint> list = new List<Complaint>();
            ComplaintRepository cr = new ComplaintRepository();
            Complaint cmp = new Complaint()
            {
                monthname = labelmonthname.Text,
                c1 = Convert.ToInt32(c1txtbox.Text),
                c2 = Convert.ToInt32(c2txtbox.Text),
                c3 = Convert.ToInt32(c3txtbox.Text),
                c4 = Convert.ToInt32(c4txtbox.Text),
                c5 = Convert.ToInt32(c5txtbox.Text),
            };
            list.Add(cmp);
            cr.saveData(cmp.monthname,list);
        }
    }
}
