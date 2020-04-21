﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComiqueriaLogic;

namespace ComiqueriaApp
{
    public partial class ModificarProductoForm : Form
    {
        private Producto productoSeleccionado;

        public ModificarProductoForm(Producto productoSeleccionado)
        {
            InitializeComponent();
            this.productoSeleccionado = productoSeleccionado;
        }

        private void VentasForm_Load(object sender, EventArgs e)
        {
            this.lblDescripcion.Text = this.productoSeleccionado.Descripcion;
            this.txtPrecioActual.Text = String.Format("{0:0.00}", this.productoSeleccionado.Precio);
        }

        private void OnModificarClick(object sender, EventArgs e)
        {
            double nuevoPrecio;
            if (Double.TryParse(this.txtNuevoPrecio.Text, out nuevoPrecio))
            {
                DialogResult result = MessageBox.Show("¿Seguro desea modificar el producto?", "Modificar Producto", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    this.productoSeleccionado.Precio = nuevoPrecio;
                    this.Close();
                }
            }
            else
            {
                this.lblError.Text = "Error. Debe ingresar un precio válido.";
            }   
        }

        /// <summary>
        /// Manejador del evento click del botón cancelar.
        /// Cierra el formulario.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnCancelarClick(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNuevoPrecio_TextChanged(object sender, EventArgs e)
        {
            this.lblError.Text = String.Empty;
        }
    }
}
