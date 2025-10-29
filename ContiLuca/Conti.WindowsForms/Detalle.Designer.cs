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
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            LBL_Tipo = new Label();
            LBL_Monto = new Label();
            textBox3 = new TextBox();
            BTN_Finalizar = new Button();
            BTN_Cancelar = new Button();
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
            LBL_Patente.Location = new Point(171, 130);
            LBL_Patente.Name = "LBL_Patente";
            LBL_Patente.Size = new Size(58, 20);
            LBL_Patente.TabIndex = 0;
            LBL_Patente.Text = "Patente";
            // 
            // textBox1
            // 
            textBox1.Location = new Point(260, 127);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(402, 27);
            textBox1.TabIndex = 1;
            // 
            // textBox2
            // 
            textBox2.Location = new Point(260, 179);
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(402, 27);
            textBox2.TabIndex = 2;
            // 
            // LBL_Tipo
            // 
            LBL_Tipo.AutoSize = true;
            LBL_Tipo.Location = new Point(171, 182);
            LBL_Tipo.Name = "LBL_Tipo";
            LBL_Tipo.Size = new Size(39, 20);
            LBL_Tipo.TabIndex = 3;
            LBL_Tipo.Text = "Tipo";
            // 
            // LBL_Monto
            // 
            LBL_Monto.AutoSize = true;
            LBL_Monto.Location = new Point(171, 231);
            LBL_Monto.Name = "LBL_Monto";
            LBL_Monto.Size = new Size(53, 20);
            LBL_Monto.TabIndex = 4;
            LBL_Monto.Text = "Monto";
            // 
            // textBox3
            // 
            textBox3.Location = new Point(260, 228);
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(402, 27);
            textBox3.TabIndex = 5;
            // 
            // BTN_Finalizar
            // 
            BTN_Finalizar.Location = new Point(502, 328);
            BTN_Finalizar.Name = "BTN_Finalizar";
            BTN_Finalizar.Size = new Size(160, 66);
            BTN_Finalizar.TabIndex = 7;
            BTN_Finalizar.Text = "Finalizar";
            BTN_Finalizar.UseVisualStyleBackColor = true;
            // 
            // BTN_Cancelar
            // 
            BTN_Cancelar.Location = new Point(260, 328);
            BTN_Cancelar.Name = "BTN_Cancelar";
            BTN_Cancelar.Size = new Size(160, 66);
            BTN_Cancelar.TabIndex = 8;
            BTN_Cancelar.Text = "Cancelar";
            BTN_Cancelar.UseVisualStyleBackColor = true;
            // 
            // Detalle
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(879, 597);
            Controls.Add(BTN_Cancelar);
            Controls.Add(BTN_Finalizar);
            Controls.Add(textBox3);
            Controls.Add(LBL_Monto);
            Controls.Add(LBL_Tipo);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(LBL_Patente);
            Name = "Detalle";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)errorProvider1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ErrorProvider errorProvider1;
        private TextBox textBox1;
        private Label LBL_Patente;
        private Label LBL_Tipo;
        private TextBox textBox2;
        private TextBox textBox3;
        private Label LBL_Monto;
        private Button BTN_Cancelar;
        private Button BTN_Finalizar;
    }
}