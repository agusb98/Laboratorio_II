using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Biblioteca;

namespace TP_01
{
    public partial class Calculadora : Form
    {
        /// <summary>
        /// Constructor por defecto del formulario contenedor de la calculadora.
        /// </summary>
        public Calculadora()
        {
            InitializeComponent();

            this.cmbOperacion.Items.Add("+");
            this.cmbOperacion.Items.Add("-");
            this.cmbOperacion.Items.Add("*");
            this.cmbOperacion.Items.Add("/");

            this.cmbOperacion.SelectedItem = "+";
            this.cmbOperacion.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        /// <summary>
        /// Establece los valores por defecto en el label, en los campos de texto y en el combo box.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            this.lblResultado.Text = "Ingrese operandos";
            this.txtNumero1.Text = "";
            this.txtNumero2.Text = "";
            this.cmbOperacion.SelectedItem = "+";
        }

        /// <summary>
        /// Toma los valores de los campos de texto, los mete en objetos de tipo Numero, opera con ellos y escribe el resultado en el Label.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnOperar_Click(object sender, EventArgs e)
        {
            double resultado;
            Numero numero1 = new Numero(txtNumero1.Text);
            Numero numero2 = new Numero(txtNumero2.Text);

            resultado = Biblioteca.Calculadora.Operar(numero1, numero2, (string)this.cmbOperacion.SelectedItem);

            this.lblResultado.Text = resultado.ToString();
        }
    }
}
