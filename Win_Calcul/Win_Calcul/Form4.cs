using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using MetroFramework.Forms;

namespace Win_Calcul
{
    public partial class Form4 : MetroForm
    {

        int m = 0;
        int n = 0;
        double l = 1;
        double p = 1;
        double[,] x = null;

        public Form4()
        {
            InitializeComponent();

            Grid1.ColumnHeadersVisible = false;
            Grid1.RowHeadersVisible = false;
            Grid1.Visible = false;
            Grid2.ColumnHeadersVisible = false;
            Grid2.RowHeadersVisible = false;
            Grid2.Visible = false;
            Grid3.ColumnHeadersVisible = false;
            Grid3.RowHeadersVisible = false;
            Grid3.Visible = false;
        }

        int i, j, k;

        //---------------------------------------Определитель---------------------------------------------------------------------
        private void metroRadioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (m != n)
            {
                metroLink1.Text = "Невозможно найти опредлитель!Матрица должна быть квадратной";
                return;
            }

            //Прямой ход метода Гаусса
            for (j = 0; j < (n - 1); j++)
            {
                for (k = 1; k < n; k++)
                {
                    l = x[j, k] / x[j, j];

                    for (i = j; i < m; i++)
                    {
                        x[j, k] = x[j, k] - (x[j, i] * l);
                    }

                }
            }
            for (j = 0; j < n; j++)
            {
                for (i = 0; i < m; i++)
                {
                    p = p * x[i, i];

                }
            }
            double Determinant = p;
            metroLink1.Text = "Определитель равер:" + Determinant.ToString();

        }

        //----------------------Транспонирование----------------------------------------------------------------------
        private void metroRadioButton2_CheckedChanged(object sender, EventArgs e)
        {
            if (m != n)
            {
                metroLink1.Text = "Матрица должна быть квадратной!";
                return;
            }

            double[,] y = new double[m, n];
            for (i = 0; i < n; i++)
            {
                for (j = 0; j < m; j++)
                {
                    y[i, j] = x[j, i];
                }
            }

            for (i = 0; i < n; i++)
            {
                for (j = 0; j < m; j++)
                {
                    Grid2[i, j].Value = y[i, j];
                }
            }
            Grid1.Visible = false;
            Grid2.Visible = true;
            Grid3.Visible = false;
        }

        //----------------------------ОБРАТНАЯ МАТРИЦА------------------------------------------------------------------//
        private void metroRadioButton3_CheckedChanged(object sender, EventArgs e)
        {
            //единичная матрица того же порядка
            double[,] z = new double[m, n];

            for (i = 0; i < n; i++)
            {
                for (j = 0; j < m; j++)
                {
                    if (i == j)
                    {
                        z[i, j] = 1;
                    }
                    else
                    {
                        z[i, j] = 0;
                    }
                }
            }
            //Прямой ход метода Гаусса

            for (j = 0; j < (n - 1); j++)
            {
                for (k = 1; k < n; k++)
                {
                    l = x[j, k] / x[j, j];

                    for (i = j; i < m; i++)
                    {
                        z[j, k] = z[j, k] - (x[j, i] * l);
                    }

                }
            }

            //Приведение к диагональному виду исходной единичной матриц - получение на месте исходной матрицы единичную, а на месте единичной - обратную к исходной

            for (j = n - 1; j > 0; j--)
            {
                for (k = n - 2; k > 1; k--)
                {
                    l = x[j, k] / x[j, j];

                    for (i = j; i < m; i++)
                    {
                        x[j, k] = x[j, k] - (x[j, i] * l);
                    }
                }
            }

            for (i = 0; i < m; i++)
            {
                for (j = 0; j < n; j++)
                {
                    x[i, j] = x[i, j] / x[i, j];
                    z[i, j] = z[i, j] / x[i, j];
                }
            }

            for (i = 0; i < m; i++)
            {
                for (j = 0; j < n; j++)
                {
                    Grid3[i, j].Value = z[i, j];
                }
            }
            Grid3.Visible = true;
            Grid2.Visible = false;
            Grid1.Visible = false;
        }

        //---------------------Минимальное--------------------------------
        private void metroRadioButton4_CheckedChanged(object sender, EventArgs e)
        {
            
            double[,] z = new double[m, n];
            double min = 0;

            for (i = 0; i < m; i++)
            {
                for (j = 0; j < n; j++)
                {
                    if (min > x[i, j])
                    {
                        min = x[i, j];
                    }

                }
            }
            metroLink1.Text = min.ToString();

        }

        private void metroRadioButton5_CheckedChanged(object sender, EventArgs e)
        {
            double[,] z = new double[m, n];
            double max = 0;

            for (i = 0; i < m; i++)
            {
                for (j = 0; j < n; j++)
                {
                    if (max < x[i, j])
                    {
                        max = x[i, j];
                    }

                }
            }
            metroLink1.Text = max.ToString();

        }


        //----------------------------------------------------------------------------------------------------


        //--------------------------------Ввод элементов----------------------------------------------------------
        private void metroButton2_Click(object sender, EventArgs e)
        {
            x = new double[m, n];

            for (i = 0; i < m; i++)
            {
                for (j = 0; j < n; j++)
                {
                    x[i, j] = Convert.ToDouble(Grid1[i, j].Value);
                }
            }
        }
        //---------------------------------------------------------------------------------------------------------------------
        //----------------------Создание Размерности---------------------------------------------------------------------
        private void metroButton1_Click(object sender, EventArgs e)
        {
            //Задание размерности
            n = Convert.ToInt32(metroTextBox1.Text);
            m = Convert.ToInt32(metroTextBox2.Text);
            //Значение с TextBox равны размерности Столбцов и строк
            Grid1.RowCount = m;
            Grid1.ColumnCount = n;
            Grid2.RowCount = m;
            Grid2.ColumnCount = n;
            Grid3.RowCount = m;
            Grid3.ColumnCount = n;
            Grid1.Visible = true;

        }
        //--------------------------------------------------------------------------------------------------------------------
    }
}
