using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows.Forms;
using MetroFramework.Components;
using MetroFramework.Forms;
using Expressions;

namespace Win_Calcul
{
    public partial class Form2 : MetroForm
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_FormClosed(object sender, FormClosedEventArgs e)
        {
            
        }

        private void Form2_FormClosing(object sender, FormClosingEventArgs e)
        {
            Form1 form = new Form1();
            form.Show();
        }
       

        private void metroButton1_Click(object sender, EventArgs e)
        {
            Operator oper = new Operator();

            
                        double x = Double.Parse(metroTextBox1.Text);
           
                       double eps = Double.Parse(metroTextBox3.Text);

            /*  string resul = metroTextBox2.Text;
               resul = resul.Replace("x", "{0}");
               resul = String.Format(resul, x);

               MSScriptControl.ScriptControl sc = new MSScriptControl.ScriptControl();
               sc.Language = "VBScript";
               object result = sc.Eval(resul);

    */


               // richTextBox1.Text = resul + "=" + result;
               // double r = Convert.ToDouble(result);
               //  richTextBox1.Text = resul + "=" + result + r;

               richTextBox1.Text = oper.Neton_Metod(x, eps).ToString();
             
           //  string s = "2 * x + 2";
            //  richTextBox1.Text = oper.Newton(metroTextBox2.Text, s, x,eps).ToString();
          
          //  richTextBox1.Text = oper.func(metroTextBox2.Text, s, x,eps).ToString();
        }

        private void metroLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
