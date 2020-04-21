using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Entidades;

namespace MiCalculadora
{
    public partial class LaCalculadora : Form
    {
        /// <summary>
        /// Constructor por defecto del formulario contenedor de la calculadora.
        /// </summary>
        public LaCalculadora()
        {
            InitializeComponent();

            this.cmbOperacion.Items.Add("+");
            this.cmbOperacion.Items.Add("-");
            this.cmbOperacion.Items.Add("*");
            this.cmbOperacion.Items.Add("/");

            this.cmbOperacion.SelectedItem = "+";
            this.cmbOperacion.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Cierra la ventana
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnClose_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Toma los valores de los campos de texto, los mete en objetos de tipo Numero, opera con ellos y escribe el resultado en el Label.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnOperar_Click(object sender, EventArgs e)
        {
            double resultado;
            Numero numero1 = new Numero(txtNumero1.Text);
            Numero numero2 = new Numero(txtNumero2.Text);

            resultado = Entidades.Calculadora.Operar(numero1, numero2, (string)this.cmbOperacion.SelectedItem);

            this.TxtResult.Text = resultado.ToString();
        }

        /// <summary>
        /// Establece los valores por defecto en el label, en los campos de texto y en el combo box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void BtnLimpiar_Click(object sender, EventArgs e)
        {
            this.TxtResult.Text = "";
            this.txtNumero1.Text = "";
            this.txtNumero2.Text = "";
            this.cmbOperacion.SelectedItem = "+";
        }

        /// <summary>
        /// Establece pasaje de Decimal a Binario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button1_Click(object sender, EventArgs e)
        {
            string num = TxtResult.Text;
            this.TxtResult.Text = Numero.DecimalBinario(num);
        }

        /// <summary>
        /// Establece pasaje de Binario a Decimal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Button2_Click(object sender, EventArgs e)
        {
            string bin = TxtResult.Text;
            this.TxtResult.Text = Numero.BinarioDecimal(bin);
        }

        private void TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNumero1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
