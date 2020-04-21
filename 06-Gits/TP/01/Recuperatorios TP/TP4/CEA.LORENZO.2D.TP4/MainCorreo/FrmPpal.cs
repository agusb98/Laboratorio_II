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

namespace MainCorreo
{
    public partial class FrmPpal : Form
    {
        Correo correo;

        public FrmPpal()
        {
            InitializeComponent();

            correo = new Correo();
            lstEstadoEntregado.ContextMenuStrip = cmsListas;
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            Paquete paq = new Paquete(txtDireccion.Text, mtxtTrackingID.Text);

            paq.InformaEstado += paq_InformaEstado;
            try
            {
                correo += paq;
            }
            catch (TrackingIdRepetidoException ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                ActualizarEstados();
            }
        }

        #region Metodos
        /// <summary>
        /// Manejador del evento InformaEstado de los paquetes.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void paq_InformaEstado(object sender, EventArgs e)
        {
            if (this.InvokeRequired)
            {
                Paquete.DelegadoEstado d = new Paquete.DelegadoEstado(paq_InformaEstado);
                this.Invoke(d, new object[] { sender, e });
            }
            else
            {
                ActualizarEstados();
            }
        }

        /// <summary>
        /// Limpia y reasigna los paquetes a su correspondiente ListBox
        /// </summary>
        private void ActualizarEstados()
        {
            lstEstadoIngresado.Items.Clear();
            lstEstadoEnViaje.Items.Clear();
            lstEstadoEntregado.Items.Clear();

            foreach (Paquete paq in correo.Paquetes)
            {
                switch (paq.Estado)
                {
                    case EEstado.Ingresado:
                        lstEstadoIngresado.Items.Add(paq);
                        break;
                    case EEstado.EnViaje:
                        lstEstadoEnViaje.Items.Add(paq);
                        break;
                    case EEstado.Entregado:
                        lstEstadoEntregado.Items.Add(paq);
                        break;
                }
            }
        }

        /// <summary>
        /// Muestra la informacion de los paquetes en el RichTextBox del formulario
        /// y los guarda en un archivo de texto
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="elemento"></param>
        private void MostrarInformacion<T>(IMostrar<T> elemento)
        {
            if (elemento != null)
            {
                rtbMostrar.Text = elemento.MostrarDatos(elemento);
                rtbMostrar.Text.Guardar("salida.txt");
            }
        }
        #endregion

        private void FrmPpal_FormClosing(object sender, FormClosingEventArgs e)
        {
            correo.FinEntregas();
        }

        private void btnMostrarTodos_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<List<Paquete>>((IMostrar<List<Paquete>>)correo);
        }

        private void mostrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.MostrarInformacion<Paquete>((IMostrar<Paquete>)lstEstadoEntregado.SelectedItem);
        }
    }
}
