using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Calculadora
{
    public partial class Form1 : Form
    {

        private Numero num1 = new Numero();
        private Numero num2 = new Numero();
        private string operador;

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button16_Click(object sender, EventArgs e)
        {

        }

        private void btn0_Click(object sender, EventArgs e)
        {
            this.txtResult.Text += "0";
        }

        private void btnComa_Click(object sender, EventArgs e)
        {
            this.txtResult.Text += ",";
        }

        private void btnResult_Click(object sender, EventArgs e)
        {
            string str = this.txtResult.Text;
            str = str.Replace((string) num1 + " " + operador, "");

            num2 = str;

            if (num2 == 0 && operador == "/")
            {
                MessageBox.Show("No se puede dividir por cero", "ERROR", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                this.txtResult.Text = Calculadora.CalculateToString(num1, num2, operador);
            }
        }

        private void btn1_Click(object sender, EventArgs e)
        {
            this.txtResult.Text += "1";
        }

        private void btn2_Click(object sender, EventArgs e)
        {
            this.txtResult.Text += "2";
        }

        private void btn3_Click(object sender, EventArgs e)
        {
            this.txtResult.Text += "3";
        }

        private void btn6_Click(object sender, EventArgs e)
        {
            this.txtResult.Text += "6";
        }

        private void btn5_Click(object sender, EventArgs e)
        {
            this.txtResult.Text += "5";
        }

        private void btn4_Click(object sender, EventArgs e)
        {
            this.txtResult.Text += "4";
        }

        private void btn7_Click(object sender, EventArgs e)
        {
            this.txtResult.Text += "7";
        }

        private void btn8_Click(object sender, EventArgs e)
        {
            this.txtResult.Text += "8";
        }

        private void btn9_Click(object sender, EventArgs e)
        {
            this.txtResult.Text += "9";
        }

        private void btnSuma_Click(object sender, EventArgs e)
        {
            operador = "+";
            num1 = this.txtResult.Text;
            this.txtResult.Text += " " + operador + " ";
        }

        private void btnResta_Click(object sender, EventArgs e)
        {
            operador = "-";
            num1 = this.txtResult.Text;
            this.txtResult.Text += " " + operador + " ";
        }

        private void btnMultiplicacion_Click(object sender, EventArgs e)
        {
            operador = "*";
            num1 = this.txtResult.Text;
            this.txtResult.Text += " " + operador + " ";
        }

        private void btnDivision_Click(object sender, EventArgs e)
        {
            operador = "/";
            num1 = this.txtResult.Text;
            this.txtResult.Text += " " + operador + " ";
        }

        private void btnPorcentaje_Click(object sender, EventArgs e)
        {

        }

        private void btnConver_Click(object sender, EventArgs e)
        {
            double.TryParse(txtResult.Text, out double num);
            num *= -1;

            this.txtResult.Text = num.ToString();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            this.txtResult.Text = " ";
        }
    }
}
