using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Dll;
using examenSeleccionBansi.Models;

namespace examenSeleccionBansi
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void UpdateDatagrid()
        {
            using (BdiExamenEntities db = new BdiExamenEntities())
            {
                var lst = from d in db.tblExamen
                          select d;

                dataGridView1.DataSource = lst.ToList();
            }
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            // Solamente inclui EntityFramework aqui para poder tener una vista
            // de lo que hay en la db y como se va actualizando
            dataGridView1.CellFormatting += dataGridView1_CellFormatting;
            UpdateDatagrid();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtBoxId.Text.ToString());
            string nombre = txtBoxNombre.Text.ToString();
            string descripcion = txtBoxDescripcion.Text.ToString();
            bool resultado;
            string resDescripcion;

            Dll.clsExamen examen = new clsExamen(checkBoxWS.Checked);
            examen.AgregarExamen(id, nombre, descripcion, out resultado, out resDescripcion);

            txtBoxResultado.Text = resDescripcion;

            UpdateDatagrid();
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtBoxId.Text.ToString());
            string nombre = txtBoxNombre.Text.ToString();
            string descripcion = txtBoxDescripcion.Text.ToString();
            bool resultado;
            string resDescripcion;

            Dll.clsExamen examen = new clsExamen(checkBoxWS.Checked);
            examen.ActualizarExamen(id, nombre, descripcion, out resultado, out resDescripcion);

            txtBoxResultado.Text = resDescripcion;

            UpdateDatagrid();
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            int id = Convert.ToInt32(txtBoxId.Text.ToString());
            bool resultado;
            string resDescripcion;

            Dll.clsExamen examen = new clsExamen(checkBoxWS.Checked);
            examen.EliminarExamen(id, out resultado, out resDescripcion);

            txtBoxResultado.Text = resDescripcion;

            UpdateDatagrid();
        }

        private void btnConsultar_Click(object sender, EventArgs e)
        {
            string nombre = txtBoxNombre.Text.ToString();
            string descripcion = txtBoxDescripcion.Text.ToString();

            Dll.clsExamen examen = new clsExamen(checkBoxWS.Checked);
            List<Dll.tblExaman> examenes = examen.consultarExamenes(0, nombre, descripcion);

            dataGridView1.DataSource = examenes;
            txtBoxResultado.Text = examenes.Count.ToString();
        }

        private void dataGridView1_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.RowIndex >= 0 && dataGridView1.Rows[e.RowIndex].DataBoundItem != null)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];

                if (e.RowIndex % 2 == 0)
                {
                    // Estilo para las filas pares
                    row.DefaultCellStyle.BackColor = Color.LightGray;
                }
                else
                {
                    // Estilo para las filas impares
                    row.DefaultCellStyle.BackColor = Color.White;
                }
            }
        }
    }
}
