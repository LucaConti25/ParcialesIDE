namespace Conti.WindowsForms
{
    partial class Lista
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            DGV_Multas = new DataGridView();
            BTN_Agregar = new Button();
            BTN_Modificar = new Button();
            BTN_Eliminar = new Button();
            ((System.ComponentModel.ISupportInitialize)DGV_Multas).BeginInit();
            SuspendLayout();
            // 
            // DGV_Multas
            // 
            DGV_Multas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGV_Multas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGV_Multas.Location = new Point(63, 35);
            DGV_Multas.Margin = new Padding(3, 4, 3, 4);
            DGV_Multas.Name = "DGV_Multas";
            DGV_Multas.RowHeadersWidth = 51;
            DGV_Multas.Size = new Size(771, 485);
            DGV_Multas.TabIndex = 0;
            // 
            // BTN_Agregar
            // 
            BTN_Agregar.Location = new Point(748, 536);
            BTN_Agregar.Margin = new Padding(3, 4, 3, 4);
            BTN_Agregar.Name = "BTN_Agregar";
            BTN_Agregar.Size = new Size(86, 31);
            BTN_Agregar.TabIndex = 1;
            BTN_Agregar.Text = "Agregar";
            BTN_Agregar.UseVisualStyleBackColor = true;
            BTN_Agregar.Click += BTN_Agregar_Click;
            // 
            // BTN_Modificar
            // 
            BTN_Modificar.Location = new Point(643, 536);
            BTN_Modificar.Margin = new Padding(3, 4, 3, 4);
            BTN_Modificar.Name = "BTN_Modificar";
            BTN_Modificar.Size = new Size(86, 31);
            BTN_Modificar.TabIndex = 2;
            BTN_Modificar.Text = "Modificar";
            BTN_Modificar.UseVisualStyleBackColor = true;
            // 
            // BTN_Eliminar
            // 
            BTN_Eliminar.Location = new Point(534, 536);
            BTN_Eliminar.Margin = new Padding(3, 4, 3, 4);
            BTN_Eliminar.Name = "BTN_Eliminar";
            BTN_Eliminar.Size = new Size(86, 31);
            BTN_Eliminar.TabIndex = 3;
            BTN_Eliminar.Text = "Eliminar";
            BTN_Eliminar.UseVisualStyleBackColor = true;
            BTN_Eliminar.Click += BTN_Eliminar_Click;
            // 
            // Lista
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(879, 597);
            Controls.Add(BTN_Eliminar);
            Controls.Add(BTN_Modificar);
            Controls.Add(BTN_Agregar);
            Controls.Add(DGV_Multas);
            Name = "Lista";
            Text = "MultaLista";
            ((System.ComponentModel.ISupportInitialize)DGV_Multas).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView DGV_Multas;
        private Button BTN_Agregar;
        private Button BTN_Modificar;
        private Button BTN_Eliminar;
    }
}
