namespace Sistema_para_restaurante.Modulos.Punto_de_venta
{
    partial class Visor_de_mesas
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.panel3 = new System.Windows.Forms.Panel();
            this.btnUnirMesas = new System.Windows.Forms.Button();
            this.PanelMesas = new System.Windows.Forms.FlowLayoutPanel();
            this.PanelBienvenida = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.BtnParaLLevar = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.PanelBienvenida.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.PanelBienvenida);
            this.panel1.Controls.Add(this.PanelMesas);
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1137, 799);
            this.panel1.TabIndex = 0;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.panel3);
            this.panel2.Controls.Add(this.flowLayoutPanel1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(392, 799);
            this.panel2.TabIndex = 0;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(392, 799);
            this.flowLayoutPanel1.TabIndex = 0;
            // 
            // panel3
            // 
            this.panel3.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(31)))), ((int)(((byte)(31)))), ((int)(((byte)(31)))));
            this.panel3.Controls.Add(this.btnUnirMesas);
            this.panel3.Controls.Add(this.BtnParaLLevar);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 575);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(392, 224);
            this.panel3.TabIndex = 1;
            // 
            // btnUnirMesas
            // 
            this.btnUnirMesas.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(43)))), ((int)(((byte)(43)))), ((int)(((byte)(43)))));
            this.btnUnirMesas.FlatAppearance.BorderSize = 0;
            this.btnUnirMesas.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnUnirMesas.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUnirMesas.ForeColor = System.Drawing.Color.White;
            this.btnUnirMesas.Location = new System.Drawing.Point(12, 114);
            this.btnUnirMesas.Name = "btnUnirMesas";
            this.btnUnirMesas.Size = new System.Drawing.Size(359, 107);
            this.btnUnirMesas.TabIndex = 1;
            this.btnUnirMesas.Text = "Cambiar de mesa";
            this.btnUnirMesas.UseVisualStyleBackColor = false;
            // 
            // PanelMesas
            // 
            this.PanelMesas.BackColor = System.Drawing.Color.Black;
            this.PanelMesas.Location = new System.Drawing.Point(454, 255);
            this.PanelMesas.Name = "PanelMesas";
            this.PanelMesas.Size = new System.Drawing.Size(545, 180);
            this.PanelMesas.TabIndex = 1;
            // 
            // PanelBienvenida
            // 
            this.PanelBienvenida.BackColor = System.Drawing.Color.Black;
            this.PanelBienvenida.Controls.Add(this.label1);
            this.PanelBienvenida.Location = new System.Drawing.Point(454, 29);
            this.PanelBienvenida.Name = "PanelBienvenida";
            this.PanelBienvenida.Size = new System.Drawing.Size(545, 200);
            this.PanelBienvenida.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.DimGray;
            this.label1.Location = new System.Drawing.Point(0, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(545, 200);
            this.label1.TabIndex = 0;
            this.label1.Text = "Elija un salon para iniciar";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // BtnParaLLevar
            // 
            this.BtnParaLLevar.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(42)))), ((int)(((byte)(42)))));
            this.BtnParaLLevar.FlatAppearance.BorderSize = 0;
            this.BtnParaLLevar.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnParaLLevar.Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.BtnParaLLevar.ForeColor = System.Drawing.Color.White;
            this.BtnParaLLevar.Location = new System.Drawing.Point(12, 4);
            this.BtnParaLLevar.Name = "BtnParaLLevar";
            this.BtnParaLLevar.Size = new System.Drawing.Size(359, 107);
            this.BtnParaLLevar.TabIndex = 0;
            this.BtnParaLLevar.Text = "Para llevar";
            this.BtnParaLLevar.UseVisualStyleBackColor = false;
            // 
            // Visor_de_mesas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1137, 799);
            this.Controls.Add(this.panel1);
            this.Name = "Visor_de_mesas";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Visor_de_mesas";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.Visor_de_mesas_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel3.ResumeLayout(false);
            this.PanelBienvenida.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.FlowLayoutPanel PanelMesas;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button btnUnirMesas;
        private System.Windows.Forms.Button BtnParaLLevar;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Panel PanelBienvenida;
        private System.Windows.Forms.Label label1;
    }
}