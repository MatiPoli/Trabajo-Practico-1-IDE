using Trabajo_Práctico_1.Model;
using Trabajo_Práctico_1.Services;


namespace WindowsForms
{
    public partial class AlumnoDetalle : Form
    {
        private Alumno alumno;

        public Alumno Alumno
        {
            get { return alumno; }
            set 
            { 
                alumno = value;
                this.SetAlumno();
            }
        }
        public bool EditMode { get; set; } = false;

        public AlumnoDetalle()
        {
            InitializeComponent();
        }

        private void aceptarButton_Click(object sender, EventArgs e)
        {
            UniversidadService uniService = new UniversidadService();

            if (this.ValidateAlumno())
            {
                this.Alumno.Nombre = nombreTextBox.Text;
                this.Alumno.Apellido = apellidoTextBox.Text;
                this.Alumno.Legajo = legajoTextBox.Text;
                this.Alumno.Direccion = direccionTextBox.Text;

                if (this.EditMode)
                {
                    uniService.Update(this.Alumno);
                }
                else
                {
                    uniService.Add(this.Alumno);
                }

                this.Close();
            }
        }

        private void cancelarButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void SetAlumno()
        {
            this.apellidoTextBox.Text = this.Alumno.Apellido;
            this.nombreTextBox.Text = this.Alumno.Nombre;
            this.legajoTextBox.Text = this.Alumno.Legajo;
            this.direccionTextBox.Text = this.Alumno.Direccion;
        }

        private bool ValidateAlumno()
        {
            bool isValid = true;

            errorProvider.SetError(nombreTextBox, string.Empty);
            errorProvider.SetError(apellidoTextBox, string.Empty);
            errorProvider.SetError(legajoTextBox, string.Empty);
            errorProvider.SetError(direccionTextBox, string.Empty);

            if (this.nombreTextBox.Text == string.Empty)
            {
                isValid = false;
                errorProvider.SetError(nombreTextBox, "El Nombre es requerido");
            }

            if (this.apellidoTextBox.Text == string.Empty)
            {
                isValid = false;
                errorProvider.SetError(apellidoTextBox, "El Apellido es requerido");
            }

            if (this.legajoTextBox.Text.Length != 5)
            {
                isValid = false;
                errorProvider.SetError(legajoTextBox, "El Legajo tiene un largo incorrecto");
            }

            if (this.legajoTextBox.Text == string.Empty)
            {
                isValid = false;
                errorProvider.SetError(legajoTextBox, "El Legajo es requerido");
            }

            if (this.direccionTextBox.Text == string.Empty)
            {
                isValid = false;
                errorProvider.SetError(direccionTextBox, "La Direccion es requerida");
            }

            return isValid;
        }

 
    }
}
