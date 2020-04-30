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

namespace Central_Telefonica
{
    public partial class FrmMenu : Form
    {
        private Centralita miEmpresa;

        public FrmMenu()
        {
            InitializeComponent();

            this.IsMdiContainer = true;
            this.WindowState = FormWindowState.Maximized;
        }

        private void FrmPrincipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult rta = MessageBox.Show("¿Está seguro de salir?", "ATENCION", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (rta == DialogResult.OK)
            {
                MessageBox.Show("¡Quedate en casa!");
                e.Cancel = false;
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void btnAgregarLlamada_Click(object sender, EventArgs e)
        {
            FrmLlamador frm = new FrmLlamador();

            frm.MdiParent = this;

            frm.Show();
        }

        private void FrmMenu_Load(object sender, EventArgs e)
        {

        }
    }
}
