using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Components;
using MetroFramework.Forms;

namespace Win_Calcul
{
    public partial class Form1 : MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        bool isOperator = false;
        Double resultValues = 0;
        String operatorvalues = "";
        //------------------------------ГЛОБАЛЬНАЯ ФУНКЦИЯ ДЛЯ ВСЕХ КНОПАК-------------------------------------------------------
        private void metroButton10_Click(object sender, EventArgs e)
        {
            //Если Ничего не введенно в textbox
            if ((metroTextBox1.Text == null) || (isOperator))

            {
                metroTextBox1.Clear();
            }
            isOperator = false;

            MetroFramework.Controls.MetroButton button = (MetroFramework.Controls.MetroButton)sender;
            //Если у объекта button  текст = ","
            if (button.Text == ".")
            {

                if (!metroTextBox1.Text.Contains("."))
                    metroTextBox1.Text = metroTextBox1.Text + button.Text;
            }
            else
            {
                metroTextBox1.Text = metroTextBox1.Text + button.Text;
            }
        }

        //---------------------Кнопка CE-------------------------------------------------------
        private void metroButton1_Click(object sender, EventArgs e)
        {
            metroTextBox1.Text = "";
            resultValues = 0;
        }
        //----------------------------------------Кнопка "="--------------------------------------------
        private void metroButton19_Click(object sender, EventArgs e)
        {
            try
            {
                //Объект класса Operator
                Operator oper = new Operator();

                switch (operatorvalues)
                {
                    case "+":
                        
                        metroTextBox1.Text =  oper.Plus(resultValues, Double.Parse(metroTextBox1.Text)).ToString();
                        break;

                    case "-":
                        metroTextBox1.Text = oper.Minus(resultValues, Double.Parse(metroTextBox1.Text)).ToString();
                        break;

                    case "*":
                        metroTextBox1.Text = oper.Umn(resultValues, Double.Parse(metroTextBox1.Text)).ToString();
                        break;

                    case "/":
                        metroTextBox1.Text = oper.Del(resultValues, Double.Parse(metroTextBox1.Text)).ToString();
                        break;
                    case "sin":
                       /* metroTextBox1.Text = oper.Sin(resultValues,Double.Parse(metroTextBox1.Text)).ToString();*/
                        break;

                    default:
                        break;
                }
                resultValues = Double.Parse(metroTextBox1.Text);
                metroLabel1.Text = "";
            }
            catch (Exception ex) { ex.Message.ToString(); }
        }

        //------------------------------ГЛОБАЛЬНАЯ ФУНКЦИЯ ДЛЯ ОПЕРАЦИЙ (КНОПОК) не ввода с клавиатуры... 
        private void metroButton13_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (resultValues != 0)
            {
                metroButton19.PerformClick();
                operatorvalues = button.Text;
                metroLabel1.Text = resultValues + " " + operatorvalues;
                isOperator = true;

            }
            else
            {
                operatorvalues = button.Text;
                resultValues = Double.Parse(metroTextBox1.Text);
                metroLabel1.Text = resultValues + " " + operatorvalues;
                isOperator = true;
            }

        }

        //----------------------Кнопка  "C"------------------------------------------------------------------------------------------
        private void metroButton2_Click(object sender, EventArgs e)
        {
            metroTextBox1.Text = "";
            resultValues = 0;

        }

        private void обычныйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Width = 265;
            this.Height = 404;
        }

        private void инженерныйToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Height = 425;
            this.Width = 553;
            metroRadioButton1.Checked = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.Width = 265;
            this.Height = 404;
        }


        //---------------------------Кнопка "Sin"-------------------------------------------------------------
        private void metroButton21_Click(object sender, EventArgs e)
        {
            Operator oper = new Operator();

            if (metroRadioButton1.Checked == true)
            {
                metroTextBox1.Text = oper.Sin(double.Parse(metroTextBox1.Text)).ToString();
            }

            if (metroRadioButton2.Checked == true)
            {
                metroTextBox1.Text = oper.Sin(double.Parse(metroTextBox1.Text)).ToString();
            }

            if (metroRadioButton2.Checked == true)
            {
                metroTextBox1.Text = oper.Sin(double.Parse(metroTextBox1.Text)).ToString();
            }

        }

        //---------------------Кнопка "COS" -----------------------------------------------------------
        private void metroButton22_Click(object sender, EventArgs e)
        {
            Operator oper = new Operator();

            if (metroRadioButton1.Checked == true)
            {
                metroTextBox1.Text = oper.Cos(double.Parse(metroTextBox1.Text)).ToString();
            }

            if (metroRadioButton2.Checked == true)
            {
                metroTextBox1.Text = oper.Cos(double.Parse(metroTextBox1.Text)).ToString();
            }

            if (metroRadioButton2.Checked == true)
            {
                metroTextBox1.Text = oper.Cos(double.Parse(metroTextBox1.Text)).ToString();
            }
            

        }
        //-------------------------TAN
        private void metroButton23_Click(object sender, EventArgs e)
        {
            Operator oper = new Operator();

            if (metroRadioButton1.Checked == true)
            {
                metroTextBox1.Text = oper.Tan(double.Parse(metroTextBox1.Text)).ToString();
            }

            if (metroRadioButton2.Checked == true)
            {
                metroTextBox1.Text = oper.Tan(double.Parse(metroTextBox1.Text)).ToString();
            }

            if (metroRadioButton2.Checked == true)
            {
                metroTextBox1.Text = oper.Tan(double.Parse(metroTextBox1.Text)).ToString();
            }


        }
        //------------------------LOG
        private void metroButton24_Click(object sender, EventArgs e)
        {
            Operator oper = new Operator();
            metroTextBox1.Text = oper.Log(double.Parse(metroTextBox1.Text)).ToString();

        }

        //----------------Pi
        private void metroButton20_Click(object sender, EventArgs e)
        {
            Operator oper = new Operator();
            metroTextBox1.Text = oper.Pi(double.Parse(metroTextBox1.Text)).ToString();
        }

        //--------------------Fact
        private void metroButton25_Click(object sender, EventArgs e)
        {
            Operator oper = new Operator();
            metroTextBox1.Text = oper.Fact(double.Parse(metroTextBox1.Text)).ToString();
        }

        private void metroButton28_Click(object sender, EventArgs e)
        {
            Operator oper = new Operator();
            metroTextBox1.Text = oper.SinH(double.Parse(metroTextBox1.Text)).ToString();

        }

        private void metroButton26_Click(object sender, EventArgs e)
        {
            Operator oper = new Operator();
            metroTextBox1.Text = oper.TanH(double.Parse(metroTextBox1.Text)).ToString();
        }

        private void metroButton27_Click(object sender, EventArgs e)
        {
            Operator oper = new Operator();
            metroTextBox1.Text = oper.CosH(double.Parse(metroTextBox1.Text)).ToString();
        }

        private void metroButton29_Click(object sender, EventArgs e)
        {
            Operator oper = new Operator();
            metroTextBox1.Text = oper.Ln(double.Parse(metroTextBox1.Text)).ToString();
        }

        private void нелинейныеУравToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form2().Show();
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Application.Exit();
        }

        private void графикФункцииToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form3().Show();
        }

        private void матрицывозможноToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Hide();
            new Form4().Show();
        }
        //---------------------------------------------------------------------------------------------------------------------------


    }
}
