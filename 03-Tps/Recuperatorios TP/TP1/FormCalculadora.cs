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

namespace TP1
{
    public partial class FormCalculadora : Form
    {
        public FormCalculadora()
        {
            InitializeComponent();

            this.cmbOperador.Items.Add("+");
            this.cmbOperador.Items.Add("-");
            this.cmbOperador.Items.Add("*");
            this.cmbOperador.Items.Add("/");

            this.cmbOperador.SelectedItem = "+";
            this.cmbOperador.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        /// <summary>
        /// Genera la operacion entre dos numeros y un operador
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            double resultado;
            Numero numero1 = new Numero(txtNumero1.Text);
            Numero numero2 = new Numero(txtNumero2.Text);

            resultado = Entidades.Calculadora.Operar(numero1, numero2, (string)this.cmbOperador.SelectedItem);

            this.lblResultado.Text = resultado.ToString();
        }

        private void lblResultado_Click(object sender, EventArgs e)
        {

        }

        private void txtNumero1_TextChanged(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Cierra el Formulario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        
        private void btnCerrar_Click(object sender, EventArgs e)
        {
            Close();
        }

        /// <summary>
        /// Establece pasaje de Decimal a Binario
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnConervirABinario_Click(object sender, EventArgs e)
        {
            string num = lblResultado.Text;
            this.lblResultado.Text = Numero.DecimalBinario(num);
        }

        /// <summary>
        /// Establece pasaje de Binario a Decimal
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnConvertirADecimal_Click(object sender, EventArgs e)
        {
            string bin = lblResultado.Text;
            this.lblResultado.Text = Numero.BinarioDecimal(bin);
        }

        /// <summary>
        /// Limpia los valores que se encuentren en la pantalla de texto
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = "";
            this.txtNumero1.Text = "";
            this.txtNumero2.Text = "";
            this.cmbOperador.SelectedItem = "+";
        }

        private void cmbOperador_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
