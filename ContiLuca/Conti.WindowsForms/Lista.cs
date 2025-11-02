using System.Threading.Tasks;
using Conti.API;
using Conti.DTOs;
namespace Conti.WindowsForms
{
    public partial class Lista : Form
    {
        public Lista()
        {
            InitializeComponent();
            ConfigurarFiltroComboBox();

        }

        private async Task Lista_Load(object sender, EventArgs e)
        {
            await CargarTodo();
        }

        private void ConfigurarFiltroComboBox()
        {
            if (cmbEstadoFiltro != null)
            {
                cmbEstadoFiltro.Items.Clear();
                cmbEstadoFiltro.Items.Add("Todas");
                cmbEstadoFiltro.Items.Add("Pendiente");
                cmbEstadoFiltro.Items.Add("Pagada");
                cmbEstadoFiltro.SelectedIndex = 0;
                cmbEstadoFiltro.DropDownStyle = ComboBoxStyle.DropDownList;
            }
        }
        private async Task CargarTodo()
        {
            string estadoSeleccionado = cmbEstadoFiltro?.SelectedItem?.ToString() ?? "Todas";

            this.Cursor = Cursors.WaitCursor;
            try
            {
                var multas = await MultaAPI.GetAllAsync(estadoSeleccionado);
                this.DGV_Multas.DataSource = null;
                this.DGV_Multas.DataSource = multas;
                if (this.DGV_Multas.Rows.Count > 0)
                {
                    this.DGV_Multas.Rows[0].Selected = true;
                    this.BTN_Eliminar.Enabled = true;
                    this.BTN_Modificar.Enabled = true;
                }
                else
                {
                    this.BTN_Eliminar.Enabled = false;
                    this.BTN_Modificar.Enabled = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al cargar elementos: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.BTN_Eliminar.Enabled = false;
                this.BTN_Modificar.Enabled = false;
            }
            finally
            {
                this.Cursor = Cursors.Default;
            }
        }

        private async void BTN_Filtrar_Click(object sender, EventArgs e)
        {
            await CargarTodo();
        }

        private MultaDTO Seleccionado()
        {
            MultaDTO multa;
            multa = (MultaDTO)this.DGV_Multas.SelectedRows[0].DataBoundItem;
            return multa;
        }

        private async void BTN_Eliminar_Click(object sender, EventArgs e)
        {
            try
            {
                int id = this.Seleccionado().ID;
                var resultado = MessageBox.Show("¿Está seguro de que desea eliminar el elemento seleccionado?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    await MultaAPI.DeleteAsync(id);
                    this.CargarTodo();
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void BTN_Agregar_Click(object sender, EventArgs e)
        {
            Detalle detalle = new Detalle();
            MultaDTO multa = new MultaDTO();
            var parent = this.MdiParent as ParentWindow;
            detalle.Mode = Detalle.FormMode.Add;
            detalle.Multa = multa;
            detalle.MdiParent = parent;
            detalle.Dock = DockStyle.None;
            detalle.StartPosition = FormStartPosition.Manual;
            detalle.Location = new Point(0, 0);
            parent.ClientSize = detalle.Size;
            detalle.Show();
            this.Close();
        }

    }
}
