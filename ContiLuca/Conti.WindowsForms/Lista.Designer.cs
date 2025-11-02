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
            cmbEstadoFiltro = new ComboBox();
            BTN_Filtrar = new Button();
            BTN_Pagar = new Button();
            ((System.ComponentModel.ISupportInitialize)DGV_Multas).BeginInit();
            SuspendLayout();
            // 
            // DGV_Multas
            // 
            DGV_Multas.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGV_Multas.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DGV_Multas.Location = new Point(55, 26);
            DGV_Multas.Name = "DGV_Multas";
            DGV_Multas.RowHeadersWidth = 51;
            DGV_Multas.Size = new Size(675, 364);
            DGV_Multas.TabIndex = 0;
            DGV_Multas.SelectionChanged += DGV_Multas_SelectionChanged;
            // 
            // BTN_Agregar
            // 
            BTN_Agregar.Location = new Point(654, 402);
            BTN_Agregar.Name = "BTN_Agregar";
            BTN_Agregar.Size = new Size(75, 23);
            BTN_Agregar.TabIndex = 1;
            BTN_Agregar.Text = "Agregar";
            BTN_Agregar.UseVisualStyleBackColor = true;
            BTN_Agregar.Click += BTN_Agregar_Click;
            // 
            // BTN_Modificar
            // 
            BTN_Modificar.Location = new Point(563, 402);
            BTN_Modificar.Name = "BTN_Modificar";
            BTN_Modificar.Size = new Size(75, 23);
            BTN_Modificar.TabIndex = 2;
            BTN_Modificar.Text = "Modificar";
            BTN_Modificar.UseVisualStyleBackColor = true;
            BTN_Modificar.Click += BTN_Modificar_Click;
            // 
            // BTN_Eliminar
            // 
            BTN_Eliminar.Location = new Point(467, 402);
            BTN_Eliminar.Name = "BTN_Eliminar";
            BTN_Eliminar.Size = new Size(75, 23);
            BTN_Eliminar.TabIndex = 3;
            BTN_Eliminar.Text = "Eliminar";
            BTN_Eliminar.UseVisualStyleBackColor = true;
            BTN_Eliminar.Click += BTN_Eliminar_Click;
            // 
            // cmbEstadoFiltro
            // 
            cmbEstadoFiltro.FormattingEnabled = true;
            cmbEstadoFiltro.Location = new Point(55, 402);
            cmbEstadoFiltro.Name = "cmbEstadoFiltro";
            cmbEstadoFiltro.Size = new Size(121, 23);
            cmbEstadoFiltro.TabIndex = 4;
            // 
            // BTN_Filtrar
            // 
            BTN_Filtrar.Location = new Point(182, 402);
            BTN_Filtrar.Name = "BTN_Filtrar";
            BTN_Filtrar.Size = new Size(75, 23);
            BTN_Filtrar.TabIndex = 5;
            BTN_Filtrar.Text = "Filtrar";
            BTN_Filtrar.UseVisualStyleBackColor = true;
            BTN_Filtrar.Click += BTN_Filtrar_Click;
            // 
            // BTN_Pagar
            // 
            BTN_Pagar.Location = new Point(373, 402);
            BTN_Pagar.Name = "BTN_Pagar";
            BTN_Pagar.Size = new Size(75, 23);
            BTN_Pagar.TabIndex = 6;
            BTN_Pagar.Text = "Pagar";
            BTN_Pagar.UseVisualStyleBackColor = true;
            BTN_Pagar.Click += BTN_Pagar_Click;
            // 
            // Lista
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(785, 483);
            Controls.Add(BTN_Pagar);
            Controls.Add(BTN_Filtrar);
            Controls.Add(cmbEstadoFiltro);
            Controls.Add(BTN_Eliminar);
            Controls.Add(BTN_Modificar);
            Controls.Add(BTN_Agregar);
            Controls.Add(DGV_Multas);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
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
        private ComboBox cmbEstadoFiltro;
        private Button BTN_Filtrar;
        private Button BTN_Pagar;
    }
}
