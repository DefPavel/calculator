using System;

namespace Win_Calcul
{
    public class Operator
    {
        //-----------------------------------------ОБЫЧНЫЕ ОПЕРАЦИИ------------------------------------------
        public double Plus(double a , double b)
        {
            return a + b;
        }
        public double Minus(double a , double b)
        {
            return a - b;
        }
        public double Del(double a, double b)
        {
            return a / b;
        }
        public double Umn(double a, double b)
        {
            return a * b;
        }
        //---------------------Синус-------------------------------------------------------------------------------
         public double Sin(double a)
        {
            a = a * Math.PI / 180.0;
            return Math.Sin(a);
        }
        //-------------Косинус
        public double Cos(double a)
        {
            if (a == 90) return 1;
            else
            {
                a = a * Math.PI / 180.0;
                return Math.Cos(a);
            }
        }
        //---------Тангенс
        public double Tan(double a)
        {
            a = a * Math.PI / 180.0;
            return Math.Tan(a);
        }
        //--------Лог
        public double Log(double a)
        {
            return Math.Log10(a);
        }
        //-------------Число Пи
        public double Pi(double a)
        {
            return Math.PI;
        }
        //------------Факториал
        public double Fact(double a)
        {
            if (a <= 0) return 1;
            else
            {
                a = a * Fact(a - 1);
                return (a);
            }
        }

        public double SinH(double a)
        {
            a = a * Math.PI / 180;
            return Math.Sinh(a);
            
        }
        public double CosH(double a)
        {
            a = a * Math.PI / 180;
            return Math.Cosh(a);

        }
        public double TanH(double a)
        {
            a = a * Math.PI / 180;
            return Math.Tanh(a);

        }

        public double Ln(double a)
        {
            return Math.Log(a);
        }


        //---------------------------НЕЛИНЕЙНЫЕ УРАВНЕНИЕ---------------------------------------------------------

        //---------------------------МЕТОД НЬЮТОНА ---------------------------------------------------------------

        //Функция
        public MSScriptControl.ScriptControl sc = new MSScriptControl.ScriptControl();

        public double func(string ex ,double x)
          {
            ex = ex.Replace("x", "{0}");
            ex = String.Format(ex, x);
            sc.Language = "VBScript";
            object result = sc.Eval(ex);
            x = Convert.ToDouble(result);
            /*
            double x1 =  Convert.ToDouble(result2);
            double y = x;
            x = x - x / x1;
            if (Math.Abs(y - x) >= eps) return func(ex, proiz, x, eps);
            else */
            return x;
          }

        public static double function(double x)
        {
            return x * x + 2 * x - 3;
        }

        //Производная функции
        public static double proizvod(double x)
        {
            return 2 * x + 2;
        }

       
        public double Neton_Metod(double x, double eps)
        {
            //double funct = Double.Parse(fun);
           //double funt = Double.Parse(fun);
            double y = x;
            x = x -  function(x)/ proizvod(x);
            //Если |y-x| > 0,001 ,то начать заново и до тех пор пока y-x максимально не приблизится к 0,001 
            if (Math.Abs(y - x) >= eps)
                return Neton_Metod( x , eps);
            else
                return x;
        }
        //--------------------------------------------------------------------------------------------------------------------------------------------------
        //Функция
        public static double Purs(string ex, double x)
        {
           
            ex = ex.Replace("x", "{0}");
            ex = String.Format(ex, x);

            MSScriptControl.ScriptControl sc = new MSScriptControl.ScriptControl();
            sc.Language = "VBScript";
            object result = sc.Eval(ex);

            x = Convert.ToDouble(result);

            return x;
        }
        //Производная 
        public static double proiz(string ex, double x)
        {
            ex = ex.Replace("x", "{0}");
            ex = String.Format(ex, x);

            MSScriptControl.ScriptControl sc = new MSScriptControl.ScriptControl();
            sc.Language = "VBScript";
            object result = sc.Eval(ex);

            x = Convert.ToDouble(result);
            return x;
        }
        //Ньютон версия 2
        public object Newton(string expression, string derivativeExpression, double x, double epsilon)
        {
            double y = x;
            x = x - Purs(expression,x)/ proiz(derivativeExpression,x);
            //Если |y-x| > 0,001 ,то начать заново и до тех пор пока y-x максимально не приблизится к 0,001 
            if (Math.Abs(y - x) >= epsilon)
                return Newton(expression, derivativeExpression,x, epsilon);
            else
                return x;
        }

    }

   
}
