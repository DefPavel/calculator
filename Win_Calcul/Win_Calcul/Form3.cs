using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading.Tasks;
using System.Drawing.Drawing2D;
using MetroFramework.Forms;

namespace Win_Calcul
{
    public partial class Form3 : MetroForm
    {
        public Form3()
        {
            InitializeComponent();
        }

        

        private void panel1_Paint(object sender, System.Windows.Forms.PaintEventArgs e)
        {
            /*
            float W = panel1.Width, H = panel1.Height;
            float halfW = W / 2, halfH = H / 2;
            // оси координат
            e.Graphics.DrawLine(Pens.Black, halfW, 0, halfW, H);
            e.Graphics.DrawLine(Pens.Black, 0, halfH, W, halfH);
            // координаты предыдущей точки
            int ixPrev = -1, iyPrev = (int)halfH;
            // тангенс на интервале x=[-Pi..Pi]
            // проходим по всем точкам на форме, вычисляем x и y
            for (int ix = 0; ix < W; ix++)
            {
                // переводим x в диапазон -1..1
                float x = (ix - halfW) / halfW;
                // переводим x в -pi..pi
                x *= (float)Math.PI;
                //-----------------------------------------------//
                // Задание уравление y=
                float y = (float)3*x*x + 4*x - 2;
                //----------------------------------------------//
                // переводим y из -1..1 в пикселы на форме
                int iy = (int)(halfH - y * halfH);
             
                e.Graphics.DrawLine(Pens.Red, ixPrev, iyPrev, ix, iy);
                ixPrev = ix;
                iyPrev = iy;
            }
            */
        }

        private void Form3_FormClosing(object sender, System.Windows.Forms.FormClosingEventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
        }

        private void metroButton1_Click(object sender, EventArgs e)
        {
            // Считываем с формы требуемые значения

            double Xmin = double.Parse(metroTextBox1.Text);

            double Xmax = double.Parse(metroTextBox2.Text);

            double Step = double.Parse(metroTextBox3.Text);

            // Количество точек графика

            int count = (int)Math.Ceiling((Xmax - Xmin) / Step)

            + 1;

            // Массив значений X – общий для обоих графиков

            double[] x = new double[count];

            // Два массива Y – по одному для каждого графика

            double[] y1 = new double[count];

            double[] y2 = new double[count];

            
            // Расчитываем точки для графиков функции

            for (int i = 0; i < count; i++)

            {

                // Вычисляем значение X

                x[i] = Xmin + Step * i;
                //ПРОБЛЕМА ВЫТЯНУТЬ ЗНАЧЕНИЕ ИЗ TEXTBOX и подставить их в выражение...
                // Вычисляем значение функций в точке X
                //Первый график y=
                y1[i] = /*3*x[i]*x[i] + 4*x[i] - 2;*/Math.Sin(x[i]);
                //Второй график y=
                y2[i] = Math.Cos(x[i]);

            }



            // Настраиваем оси графика

            chart1.ChartAreas[0].AxisX.Minimum = Xmin;

            chart1.ChartAreas[0].AxisX.Maximum = Xmax;



            // Определяем шаг сетки

            chart1.ChartAreas[0].AxisX.MajorGrid.Interval = Step;



            // Добавляем вычисленные значения в графики

            chart1.Series[0].Points.DataBindXY(x, y1);

            chart1.Series[1].Points.DataBindXY(x, y2);
            chart1.Series[0].Name = "Sin";
            chart1.Series[1].Name = "Cos";
        }

      
    }
}
