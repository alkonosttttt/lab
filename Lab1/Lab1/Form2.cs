using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing.Drawing2D;

namespace Lab1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();

        }
        private int x1, x2, y1, y2, z, firstx, firstY;

        private void Form2_MouseDown(object sender, MouseEventArgs e) //нажата кнопка
        {
            if (e.Button == MouseButtons.Left) //устанвка флага рисования и нажатой мыши
            {
                x1 = e.X;
                x2 = e.X;
                y1 = e.Y;
                y2 = e.Y;
                firstx = e.X;
                firstY = e.Y;
            }
        }

        private void Form2_MouseMove(object sender, MouseEventArgs e) //передвигается
        {
            Graphics g = CreateGraphics();//объект типа Graphics для рисования
            if (e.Button == MouseButtons.Left)//проверка флага рисования. если зажата
                //значит рисовать будет
            {
                Pen clear = new Pen(Color.White, 2); //объект перо для рисоватия контуров ,белыми линиями (стираем наши контуры) 
                
                Rectangle r = Rectangle.FromLTRB(x1, y1, x2, y2); //FromLTRB - метод класса Rectangle  для создания
                //прямоугольника, с параметрами верхнего и правого нижнего углов прямоугольника
                
                g.DrawRectangle(clear, r);// рисования прямоугольника методом DrawRectangle, которому передаются значения
                // 2 параметра (pen, Rectangle)

                //переворачиваем при необходимости координаты
                x1 = firstx;
                y1 = firstY;
                x2 = e.X;
                y2 = e.Y;
                if (x1 > x2)
                {
                    z = x1;
                    x1 = x2;
                    x2 = z;
                }
                if (y1 > y2)
                {
                    z = y1;
                    y1 = y2;
                    y2 = z;
                }
                //рисование пунктирного контура 

                Pen pen = new Pen(Color.Red, 1);
                pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash;//рисуем пунктиром
                Rectangle rdash = Rectangle.FromLTRB(x1, y1, x2, y2); 
                g.DrawRectangle(pen, rdash);
                g.Dispose(); //метод позавершении использования объекта Graphics pen.DashStyle = System.Drawing.Drawing2D.DashStyle.Dash

            }
        }

        private void Form2_MouseUp(object sender, MouseEventArgs e) //для отпущенной кнопки мыши
        {
            Graphics g = CreateGraphics();
            if (e.Button == MouseButtons.Left) //if в качестве проверки флага рисования
            {
                //прорисовка последнего пунктира невидимым
                Pen pen1 = new Pen(Color.White, 2); 
                Rectangle rend = Rectangle.FromLTRB(x1, y1, x2, y2);
                g.DrawRectangle(pen1, rend);

                //окончательная прорисовка спошным контуром, где координаты берутся из последнего пунктира rend
                Pen pen = new Pen(Color.Red, 2);
                g.DrawRectangle(pen, rend);
                g.Dispose();
            }
        }

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        
    }
}

