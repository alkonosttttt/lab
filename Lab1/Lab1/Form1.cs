using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Lab1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Graphics g = CreateGraphics();
                string x = e.X.ToString();
                string y = e.Y.ToString();
                string m = x + ";" + y;
                
                g.DrawString(m, new Font("Times New Roman", 8),
                new SolidBrush(Color.Black), new Point(e.X, e.Y));

            }
            else 
            {
                MessageBox.Show("Нажата пкм", "Результат");
                Graphics w = CreateGraphics();
                w.Clear(Color.White);
            }
        }

        private void menuStrip1_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }

        private void newToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Form f = new Form2();
            f.MdiParent = this;
            f.Text = "Рисунок" + this.MdiChildren.Length.ToString();
            f.Show();
        }
    }
}
