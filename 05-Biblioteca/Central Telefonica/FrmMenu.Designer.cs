namespace Central_Telefonica
{
    partial class FrmMenu
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnExit = new System.Windows.Forms.Button();
            this.btnFacturacionProvincial = new System.Windows.Forms.Button();
            this.btnFacturacionTotal = new System.Windows.Forms.Button();
            this.btnFacturacionLocal = new System.Windows.Forms.Button();
            this.btnAgregarLlamada = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.SystemColors.MenuBar;
            this.btnExit.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnExit.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.Location = new System.Drawing.Point(27, 304);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(398, 67);
            this.btnExit.TabIndex = 4;
            this.btnExit.Text = "Salir";
            this.btnExit.UseVisualStyleBackColor = false;
            // 
            // btnFacturacionProvincial
            // 
            this.btnFacturacionProvincial.BackColor = System.Drawing.SystemColors.MenuBar;
            this.btnFacturacionProvincial.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFacturacionProvincial.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFacturacionProvincial.Location = new System.Drawing.Point(27, 231);
            this.btnFacturacionProvincial.Name = "btnFacturacionProvincial";
            this.btnFacturacionProvincial.Size = new System.Drawing.Size(398, 67);
            this.btnFacturacionProvincial.TabIndex = 8;
            this.btnFacturacionProvincial.Text = "Facturacion Provincial";
            this.btnFacturacionProvincial.UseVisualStyleBackColor = false;
            // 
            // btnFacturacionTotal
            // 
            this.btnFacturacionTotal.BackColor = System.Drawing.SystemColors.MenuBar;
            this.btnFacturacionTotal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFacturacionTotal.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFacturacionTotal.Location = new System.Drawing.Point(27, 85);
            this.btnFacturacionTotal.Name = "btnFacturacionTotal";
            this.btnFacturacionTotal.Size = new System.Drawing.Size(398, 67);
            this.btnFacturacionTotal.TabIndex = 10;
            this.btnFacturacionTotal.Text = "Facturacion Total";
            this.btnFacturacionTotal.UseVisualStyleBackColor = false;
            // 
            // btnFacturacionLocal
            // 
            this.btnFacturacionLocal.BackColor = System.Drawing.SystemColors.MenuBar;
            this.btnFacturacionLocal.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnFacturacionLocal.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFacturacionLocal.Location = new System.Drawing.Point(27, 158);
            this.btnFacturacionLocal.Name = "btnFacturacionLocal";
            this.btnFacturacionLocal.Size = new System.Drawing.Size(398, 67);
            this.btnFacturacionLocal.TabIndex = 9;
            this.btnFacturacionLocal.Text = "Facturacion Local";
            this.btnFacturacionLocal.UseVisualStyleBackColor = false;
            // 
            // btnAgregarLlamada
            // 
            this.btnAgregarLlamada.BackColor = System.Drawing.SystemColors.MenuBar;
            this.btnAgregarLlamada.Cursor = System.Windows.Forms.Cursors.Hand;
            this.btnAgregarLlamada.Font = new System.Drawing.Font("Palatino Linotype", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAgregarLlamada.Location = new System.Drawing.Point(27, 12);
            this.btnAgregarLlamada.Name = "btnAgregarLlamada";
            this.btnAgregarLlamada.Size = new System.Drawing.Size(398, 67);
            this.btnAgregarLlamada.TabIndex = 11;
            this.btnAgregarLlamada.Text = "Generar Llamada";
            this.btnAgregarLlamada.UseVisualStyleBackColor = false;
            this.btnAgregarLlamada.Click += new System.EventHandler(this.btnAgregarLlamada_Click);
            // 
            // FrmMenu
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(455, 382);
            this.Controls.Add(this.btnAgregarLlamada);
            this.Controls.Add(this.btnFacturacionTotal);
            this.Controls.Add(this.btnFacturacionLocal);
            this.Controls.Add(this.btnFacturacionProvincial);
            this.Controls.Add(this.btnExit);
            this.Name = "FrmMenu";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FrmMenu_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnExit;
        private System.Windows.Forms.Button btnFacturacionProvincial;
        private System.Windows.Forms.Button btnFacturacionTotal;
        private System.Windows.Forms.Button btnFacturacionLocal;
        private System.Windows.Forms.Button btnAgregarLlamada;
    }
}

