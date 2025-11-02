namespace Conti.WindowsForms
{
    partial class Detalle
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
            components = new System.ComponentModel.Container();
            errorProvider1 = new ErrorProvider(components);
            LBL_Patente = new Label();
            TXT_Patente = new TextBox();
            TXT_Tipo = new TextBox();
            LBL_Tipo = new Label();
            LBL_Monto = new Label();
            TXT_Monto = new TextBox();
            BTN_Finalizar = new Button();
            BTN_Cancelar = new Button();
            LBL_id = new Label();
            TXT_id = new TextBox();
            ((System.ComponentModel.ISupportInitialize)errorProvider1).BeginInit();
            SuspendLayout();
            // 
            // errorProvider1
            // 
            errorProvider1.ContainerControl = this;
            // 
            // LBL_Patente
            // 
            LBL_Patente.AutoSize = true;
            LBL_Patente.Location = new Point(138, 138);
            LBL_Patente.Name = "LBL_Patente";
            LBL_Patente.Size = new Size(47, 15);
            LBL_Patente.TabIndex = 0;
            LBL_Patente.Text = "Patente";
            // 
            // TXT_Patente
            // 
            TXT_Patente.Location = new Point(216, 135);
            TXT_Patente.Margin = new Padding(3, 2, 3, 2);
            TXT_Patente.Name = "TXT_Patente";
            TXT_Patente.Size = new Size(352, 23);
            TXT_Patente.TabIndex = 1;
            // 
            // TXT_Tipo
            // 
            TXT_Tipo.Location = new Point(216, 174);
            TXT_Tipo.Margin = new Padding(3, 2, 3, 2);
            TXT_Tipo.Name = "TXT_Tipo";
            TXT_Tipo.Size = new Size(352, 23);
            TXT_Tipo.TabIndex = 2;
            // 
            // LBL_Tipo
            // 
            LBL_Tipo.AutoSize = true;
            LBL_Tipo.Location = new Point(138, 176);
            LBL_Tipo.Name = "LBL_Tipo";
            LBL_Tipo.Size = new Size(30, 15);
            LBL_Tipo.TabIndex = 3;
            LBL_Tipo.Text = "Tipo";
            // 
            // LBL_Monto
            // 
            LBL_Monto.AutoSize = true;
            LBL_Monto.Location = new Point(138, 213);
            LBL_Monto.Name = "LBL_Monto";
            LBL_Monto.Size = new Size(43, 15);
            LBL_Monto.TabIndex = 4;
            LBL_Monto.Text = "Monto";
            // 
            // TXT_Monto
            // 
            TXT_Monto.Location = new Point(216, 211);
            TXT_Monto.Margin = new Padding(3, 2, 3, 2);
            TXT_Monto.Name = "TXT_Monto";
            TXT_Monto.Size = new Size(352, 23);
            TXT_Monto.TabIndex = 5;
            // 
            // BTN_Finalizar
            // 
            BTN_Finalizar.Location = new Point(428, 280);
            BTN_Finalizar.Margin = new Padding(3, 2, 3, 2);
            BTN_Finalizar.Name = "BTN_Finalizar";
            BTN_Finalizar.Size = new Size(140, 50);
            BTN_Finalizar.TabIndex = 7;
            BTN_Finalizar.Text = "Finalizar";
            BTN_Finalizar.UseVisualStyleBackColor = true;
            BTN_Finalizar.Click += BTN_Finalizar_Click;
            // 
            // BTN_Cancelar
            // 
            BTN_Cancelar.Location = new Point(217, 280);
            BTN_Cancelar.Margin = new Padding(3, 2, 3, 2);
            BTN_Cancelar.Name = "BTN_Cancelar";
            BTN_Cancelar.Size = new Size(140, 50);
            BTN_Cancelar.TabIndex = 8;
            BTN_Cancelar.Text = "Cancelar";
            BTN_Cancelar.UseVisualStyleBackColor = true;
            BTN_Cancelar.Click += BTN_Cancelar_Click;
            // 
            // LBL_id
            // 
            LBL_id.AutoSize = true;
            LBL_id.Location = new Point(138, 99);
            LBL_id.Name = "LBL_id";
            LBL_id.Size = new Size(18, 15);
            LBL_id.TabIndex = 9;
            LBL_id.Text = "ID";
            // 
            // TXT_id
            // 
            TXT_id.Location = new Point(216, 96);
            TXT_id.Name = "TXT_id";
            TXT_id.Size = new Size(352, 23);
            TXT_id.TabIndex = 10;
            // 
            // Detalle
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(769, 448);
            Controls.Add(TXT_id);
            Controls.Add(LBL_id);
            Controls.Add(BTN_Cancelar);
            Controls.Add(BTN_Finalizar);
            Controls.Add(TXT_Monto);
            Controls.Add(LBL_Monto);
            Controls.Add(LBL_Tipo);
            Controls.Add(TXT_Tipo);
            Controls.Add(TXT_Patente);
            Controls.Add(LBL_Patente);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "Detalle";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ErrorProvider errorProvider1;
        private TextBox TXT_Patente;
        private Label LBL_Patente;
        private Label LBL_Tipo;
        private TextBox TXT_Tipo;
        private TextBox TXT_Monto;
        private Label LBL_Monto;
        private Button BTN_Cancelar;
        private Button BTN_Finalizar;
        private TextBox TXT_id;
        private Label LBL_id;
    }
}