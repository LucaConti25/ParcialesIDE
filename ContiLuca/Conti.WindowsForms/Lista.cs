using Conti.API;
using Conti.DTOs;
namespace Conti.WindowsForms
{
    public partial class Lista : Form
    {
        public Lista()
        {
            InitializeComponent();
            this.CargarTodo();
        }

        private async void CargarTodo()
        {
            try
            {
                this.DGV_Multas.DataSource = null;
                this.DGV_Multas.DataSource = await MultaAPI.GetAllAsync();
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
        }
    }
}
