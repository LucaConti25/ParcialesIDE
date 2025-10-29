using Conti.API;
using Conti.DTOs;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
namespace Conti.WindowsForms
{
    public partial class ParentWindow : Form
    {
        private MultaDTO _multa;

        private void InitializeComponent()
        {
            menuStrip1 = new MenuStrip();
            multaToolStripMenuItem = new ToolStripMenuItem();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // menuStrip1
            // 
            menuStrip1.BackColor = SystemColors.Control;
            menuStrip1.ImageScalingSize = new Size(20, 20);
            menuStrip1.Items.AddRange(new ToolStripItem[] { multaToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(867, 28);
            menuStrip1.TabIndex = 0;
            menuStrip1.Text = "menuStrip1";
            // 
            // multaToolStripMenuItem
            // 
            multaToolStripMenuItem.Name = "multaToolStripMenuItem";
            multaToolStripMenuItem.Size = new Size(67, 24);
            multaToolStripMenuItem.Text = "Multas";
            multaToolStripMenuItem.Click += multaToolStripMenuItem_Click;
            // 
            // ParentWindow
            // 
            BackColor = SystemColors.ControlDark;
            ClientSize = new Size(867, 451);
            Controls.Add(menuStrip1);
            MainMenuStrip = menuStrip1;
            Name = "ParentWindow";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();

        }

        public ParentWindow()
        {
            InitializeComponent();
        }
        private MenuStrip menuStrip1;
        private ToolStripMenuItem multaToolStripMenuItem;

        private void multaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (Form frm in this.MdiChildren)
            {
                frm.Close();
            }

            Lista listaForm = new Lista();
            listaForm.MdiParent = this;
            listaForm.Dock = DockStyle.None;
            listaForm.Location = new Point(0, 0);
            listaForm.StartPosition = FormStartPosition.Manual;
            listaForm.Show();
            this.ClientSize = listaForm.Size;
        }
    }
}