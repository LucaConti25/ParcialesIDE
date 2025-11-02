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
                var multas = (await MultaAPI.GetAllAsync(estadoSeleccionado)).ToList();
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
                ActualizarEstadoBotonPagar();
            }
        }

        private async void BTN_Filtrar_Click(object sender, EventArgs e)
        {
            await CargarTodo();
        }

        private MultaDTO Seleccionado()
        {
            MultaDTO multa;
            if (this.DGV_Multas.SelectedRows.Count == 0)
            {
                return null;
            }
            multa = (MultaDTO)this.DGV_Multas.SelectedRows[0].DataBoundItem;
            return multa;
        }

        private async void BTN_Eliminar_Click(object sender, EventArgs e)
        {
            var seleccionado = Seleccionado();
            if (seleccionado == null) return;

            try
            {
                int id = seleccionado.ID;
                var resultado = MessageBox.Show("¿Está seguro de que desea eliminar el elemento seleccionado?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (resultado == DialogResult.Yes)
                {
                    await MultaAPI.DeleteAsync(id);
                    await CargarTodo();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al eliminar: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private async void BTN_Agregar_Click(object sender, EventArgs e)
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

        private async void BTN_Pagar_Click(object sender, EventArgs e)
        {
            var seleccionado = Seleccionado();
            if (seleccionado == null) return;

            if (seleccionado.Estado.ToLower() != "pendiente")
            {
                MessageBox.Show("Solo se pueden pagar multas que están 'Pendiente'.", "Acción no válida", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var resultado = MessageBox.Show($"¿Está seguro que desea marcar como 'Pagada' la multa {seleccionado.ID} (Patente: {seleccionado.Patente})?",
                                            "Confirmar Pago", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (resultado == DialogResult.No) return;

            try
            {
                await MultaAPI.PagarAsync(seleccionado.ID);
                MessageBox.Show("Multa pagada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                await CargarTodo();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al pagar la multa: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void DGV_Multas_SelectionChanged(object sender, EventArgs e)
        {
            ActualizarEstadoBotonPagar();
        }

        private void ActualizarEstadoBotonPagar()
        {
            var seleccionado = Seleccionado();
            if (seleccionado != null && seleccionado.Estado.ToLower() == "pendiente")
            {
                BTN_Pagar.Enabled = true;
            }
            else
            {
                BTN_Pagar.Enabled = false;
            }
        }

        private async void BTN_Modificar_Click(object sender, EventArgs e)
        {
            var seleccionado = Seleccionado();
            if (seleccionado == null) return;

            try
            {
                MultaDTO multaAModificar = await MultaAPI.GetAsync(seleccionado.ID);
                if (multaAModificar == null)
                {
                    MessageBox.Show("No se encontró la multa (quizás fue eliminada).", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    await CargarTodo();
                    return;
                }

                Detalle detalle = new Detalle();
                int id = seleccionado.ID;
                var parent = this.MdiParent as ParentWindow;
                detalle.Mode = Detalle.FormMode.Update;
                detalle.Multa = multaAModificar;
                detalle.MdiParent = parent;
                detalle.Dock = DockStyle.None;
                detalle.StartPosition = FormStartPosition.Manual;
                detalle.Location = new Point(0, 0);
                parent.ClientSize = detalle.Size;
                detalle.Show();
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar multa para modificar: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
