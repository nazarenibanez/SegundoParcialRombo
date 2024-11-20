using SegundoParcialRombo.Datos;
using SegundoParcialRombo.Entidades;

namespace SegundoParcialRombo.Windows
{
    public partial class frmRomboAE : Form
    {
        public Rombo? _rombo;
        public readonly repositoriodeRombos repo;

        public frmRomboAE(repositoriodeRombos _repo)
        {
            InitializeComponent();
            repo = _repo;
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if(_rombo != null) 
            {
                txtDiagonalMayor.Text = _rombo.diagonalmayor.ToString();
                txtDiagonalMenor.Text = _rombo.diagonalmenor.ToString();
                switch (_rombo.contornodelrombo) 
                {
                    case contorno.Solido:
                        rbtSolido.Checked = true;
                        break;
                    case contorno.Punteado:
                        rbtPunteado.Checked = true;
                        break;
                    case contorno.Rayado:
                        rbtRayado.Checked = true;
                        break;
                    case contorno.Doble:
                        rbtDoble.Checked = true;
                        break;

                }
            }
        }


        private void btnCancelar_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if(_rombo is null) 
            {
                _rombo = new Rombo();
            }
            _rombo.diagonalmayor = int.Parse(txtDiagonalMayor.Text);
            _rombo.diagonalmenor = int.Parse(txtDiagonalMenor.Text);
            if (rbtSolido.Checked) _rombo.contornodelrombo = contorno.Solido;
            else if (rbtPunteado.Checked) _rombo.contornodelrombo = contorno.Punteado;
            else if (rbtRayado.Checked) _rombo.contornodelrombo = contorno.Rayado;
            else _rombo.contornodelrombo = contorno.Doble;
            DialogResult = DialogResult.OK;

        }
        public Rombo? GetRombo() 
        {
            return _rombo;
        }


    }
}
