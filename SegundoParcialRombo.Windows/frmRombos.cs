using SegundoParcialRombo.Datos;
using SegundoParcialRombo.Entidades;

namespace SegundoParcialRombo.Windows
{
    public partial class frmRombos : Form
    {
        
        private repositoriodeRombos? _repo;
        private List<Rombo> listaderombos;
        private int cantidaderombos;

        public frmRombos()
        {
            InitializeComponent();
            _repo = new repositoriodeRombos();
        }


        private void tsbNuevo_Click(object sender, EventArgs e)
        {
            frmRomboAE frm = new frmRomboAE(_repo!) { Text = "nuevo rombo" };
            DialogResult dr = frm.ShowDialog(this);
            if (dr == DialogResult.Cancel) return;
            Rombo? romboingresada = frm.GetRombo();
            if (romboingresada is null)
            {
                return;
            }
            _repo!.agregar(romboingresada);
            var r = contruirfila(dgvDatos);
            setearfilla(r, romboingresada);
            agregarfila(r, dgvDatos);
            cantidaderombos = _repo!.getcantidad();
            mostrartotales();
            MessageBox.Show("rombo ingresado!!!!", "mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void mostrartotales()
        {
            txtCantidad.Text = cantidaderombos.ToString();
        }

        private void agregarfila(DataGridViewRow r, DataGridView dgvDatos)
        {
            dgvDatos.Rows.Add(r);
        }

        private void setearfilla(DataGridViewRow r, Rombo romboingresada)
        {
            r.Cells[colMayor.Index].Value = romboingresada.diagonalmayor;
            r.Cells[colMenor.Index].Value = romboingresada.diagonalmenor;
            r.Cells[colBorde.Index].Value = romboingresada.contornodelrombo.ToString();
            r.Cells[colLado.Index].Value = romboingresada.getlado().ToString("N2");
            r.Cells[colPerimetro.Index].Value = romboingresada.getperimetro().ToString("N2");
            r.Cells[colArea.Index].Value = romboingresada.getarea().ToString("N2");

            r.Tag = romboingresada;
        }

        private DataGridViewRow contruirfila(DataGridView dgvDatos)
        {
            DataGridViewRow r = new DataGridViewRow();
            r.CreateCells(dgvDatos);
            return r;
        }

        private void tsbBorrar_Click(object sender, EventArgs e)
        {
            if (dgvDatos.SelectedRows.Count == 0) 
            {
                return;
            }
            var seletcrombo = dgvDatos.SelectedRows[0];
            Rombo rombossaborrar = (Rombo)seletcrombo.Tag;
            DialogResult dr = MessageBox.Show($"quieres borrar esta {rombossaborrar!}?", "confirmar para borrar", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1);
            if (dr == DialogResult.No) return;
            _repo!.Borrar(rombossaborrar);
            quitarfilla(seletcrombo, dgvDatos);
            cantidaderombos = _repo!.getcantidad();
            mostrartotales();
            MessageBox.Show("rombo eliminada!!", "mensaje", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void quitarfilla(DataGridViewRow seletc, DataGridView dgvDatos)
        {
            dgvDatos.Rows.Remove(seletc);
        }

        private void tsbEditar_Click(object sender, EventArgs e)
        {
        }


        private void CargarComboContornos(ref ToolStripComboBox tsCboBordes)
        {
            var listaBordes = Enum.GetValues(typeof(contorno));
            foreach (var item in listaBordes)
            {
                tsCboBordes.Items.Add(item);
            }
            tsCboBordes.DropDownStyle = ComboBoxStyle.DropDownList;
            tsCboBordes.SelectedIndex = 0;

        }


        private void lado09ToolStripMenuItem_Click(object sender, EventArgs e)
        {
        }

        private void lado90ToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void tsbActualizar_Click(object sender, EventArgs e)
        {
            cantidaderombos = _repo.getcantidad();

        }

        private void tsbSalir_Click(object sender, EventArgs e)
        {
            _repo.guardardatos();
            Application.Exit();
        }

        private void frmElipses_Load(object sender, EventArgs e)
        {
            CargarComboContornos(ref tsCboContornos);
            cantidaderombos = _repo!.getcantidad();
            mostrardatosengrilla();
            mostrartotales();
        }

        private void mostrardatosengrilla()
        {
            dgvDatos.Rows.Clear();
            foreach(var romboss in listaderombos) 
            {
                DataGridViewRow r = contruirfila(dgvDatos);
                setearfilla(r, romboss);
                agregarfila(r, dgvDatos);
            }
        }
    }
}
