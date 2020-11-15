using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace lab01
{
    public partial class Form1 : Form
    {
        //Declarar la colección de platos
        List<ASISTENTE> ARREGLOASISTENTE = new List<ASISTENTE>();
        ASISTENTE a = new ASISTENTE();
        public Form1()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {

            if(txtCodigo.Text == "" || txtCodigo == null || txtNombre.Text == "" || txtNombre.Text == null || cboCategoria.Text == "")
            {
                MessageBox.Show("Ingrese datos completos", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            else
            {
                ASISTENTE a1 = ARREGLOASISTENTE.Find(x => x.Codigo == txtCodigo.Text);
                if (a1 == null)
                {
                    ASISTENTE a = new ASISTENTE()
                    {
                        Codigo = txtCodigo.Text,
                        Nombre = txtNombre.Text,
                        Categoria = cboCategoria.Text,
                    };
                    CargarBarra c = new CargarBarra();
                    c.Show();
                    bwSerie.RunWorkerAsync();
                    ARREGLOASISTENTE.Add(a);
                    Listar();
                    btnAgregar.Enabled = false;
                }
                else
                {
                    MessageBox.Show("El Código ya se encuentra registrado!", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    limpiarCajas();
                }
            }
        }



        void Listar()
        {
            lvAsistentes.Items.Clear();
            foreach (ASISTENTE a in ARREGLOASISTENTE)
            {
                ListViewItem item = new ListViewItem(a.Codigo);
                item.SubItems.Add(a.Nombre);
                item.SubItems.Add(a.Categoria.ToString());
                item.SubItems.Add(a.CalcularImportePorEntrada().ToString());

                lvAsistentes.Items.Add(item);
            }
            CalcularTotal();
        }

        void CalcularTotal()
        {
            txtTotal.Text = ARREGLOASISTENTE.Sum(x => x.CalcularImportePorEntrada()).ToString();
        }

       
        private void Form1_Load(object sender, EventArgs e)
        {
            
            btnAgregar.Enabled = false;
        }

        void ActivarCajas()
        {
            txtCodigo.Enabled = true;
            txtCodigo.ReadOnly = false;
            txtNombre.Enabled = true;
            txtNombre.ReadOnly = false;
            cboCategoria.Enabled = true;
        }

        private void btnNuevo_Click(object sender, EventArgs e)
        {
            ActivarCajas();
            limpiarCajas();
            btnAgregar.Enabled = true;
        }

        private void cboCategoria_SelectedIndexChanged(object sender, EventArgs e)
        {
            a.Categoria = cboCategoria.Text;
            txtTotal.Text = a.CalcularImportePorEntrada().ToString();
        }

       

        void limpiarCajas()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            cboCategoria.Text = "";
            txtTotal.Text = "";
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Obtener el contenido a guardar
            StringBuilder sb = new StringBuilder();
            foreach (ASISTENTE a in ARREGLOASISTENTE)
            {
                sb.AppendLine(a.Codigo + "|" + a.Nombre + "|" + a.Categoria);
            }

            if (ARREGLOASISTENTE.Count > 0)
            {
                string fecha = DateTime.Now.ToString("yyyyMMdd");
                string ruta = "G:\\ASISTENTES_" + fecha;

                //Archivo txt
                StreamWriter escritor = new StreamWriter(ruta + ".txt");
                escritor.Write(sb.ToString());
                escritor.Close();
                MessageBox.Show("Lista guardada exitosamente en : " + ruta);
            }
        }
    }
}
