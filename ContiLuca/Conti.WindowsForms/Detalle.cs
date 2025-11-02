using System.Windows.Forms;
using Conti.API;
using Conti.DTOs;

namespace Conti.WindowsForms
{
    public partial class Detalle : Form
    {
        private MultaDTO multa;
        private FormMode mode;

        public enum FormMode
        {
            Add,
            Update
        }

        public MultaDTO Multa
        {
            get { return multa; }
            set
            {
                multa = value;
                this.SetMulta();
            }
        }

        public FormMode Mode
        {
            get
            {
                return mode;
            }
            set
            {
                SetFormMode(value);
            }
        }
        public Detalle()
        {
            InitializeComponent();
        }


        private void SetFormMode(FormMode value)
        {
            mode = value;
            if (Mode == FormMode.Add)
            {
                LBL_id.Visible = false;
                TXT_id.Visible = false;

            }

            if (Mode == FormMode.Update)
            {
                LBL_id.Visible = true;
                TXT_id.Visible = true;
            }
        }
        private void abrirPadre()
        {
            Lista lista = new Lista();
            var parent = this.MdiParent as ParentWindow;
            lista.MdiParent = parent;
            lista.Dock = DockStyle.None;
            lista.StartPosition = FormStartPosition.Manual;
            lista.Location = new Point(0, 0);
            parent.ClientSize = lista.Size;
            lista.Show();
            this.Close();
        }
        private void SetMulta()
        {
            this.TXT_id.Text = this.Multa.ID.ToString();
            this.TXT_Patente.Text = this.Multa.Patente;
            this.TXT_Monto.Text = this.Multa.Monto.ToString();
            this.TXT_Tipo.Text = this.Multa.Tipo;
        }

        private bool Validate()
        {
            bool isValid = true;
            decimal monto;
            errorProvider1.SetError(TXT_Patente, string.Empty);
            errorProvider1.SetError(TXT_Monto, string.Empty);
            errorProvider1.SetError(TXT_Tipo, string.Empty);
            if (string.IsNullOrWhiteSpace(TXT_Patente.Text))
            {
                errorProvider1.SetError(TXT_Patente, "La patente es obligatoria");
                isValid = false;
            }
            if (string.IsNullOrWhiteSpace(TXT_Monto.Text) || !decimal.TryParse(TXT_Monto.Text, out monto))
            {
                errorProvider1.SetError(TXT_Monto, "El monto es obligatorio y debe ser un número válido");
                isValid = false;
            }
            else if ((monto <= 0) || (monto >= 500000))
            {
                isValid = false;
                errorProvider1.SetError(TXT_Monto, "El monto no es valido");
            }

            if (string.IsNullOrWhiteSpace(TXT_Tipo.Text))
            {
                errorProvider1.SetError(TXT_Tipo, "El tipo es obligatorio");
                isValid = false;
            }

            return isValid;
        }

        private async void BTN_Finalizar_Click(object sender, EventArgs e)
        {
            if (this.Validate())
            {
                try
                {
                    this.Multa.Patente = this.TXT_Patente.Text;
                    this.Multa.Monto = decimal.Parse(this.TXT_Monto.Text);
                    this.Multa.Tipo = this.TXT_Tipo.Text;
                    DateOnly fecha;
                    DateOnly.TryParse(System.DateTime.Now.ToString("dd/MM/yyyy"), out fecha);
                    this.Multa.Fecha = fecha;
                    if (this.Mode == FormMode.Update)
                    {
                        await MultaAPI.UpdateAsync(this.Multa);
                    }
                    else
                    {
                        await MultaAPI.AddAsync(this.Multa);
                    }

                    MessageBox.Show("¡Registro exitoso!", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    abrirPadre();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }


            }
        }

        private void BTN_Cancelar_Click(object sender, EventArgs e)
        {
            abrirPadre();   
        }
    }
}
