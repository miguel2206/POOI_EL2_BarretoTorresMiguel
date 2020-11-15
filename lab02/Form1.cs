using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Runtime.Serialization.Json;

namespace lab02
{
    public partial class Form1 : Form
    {
        List<Serie> ARREGLOSERIE = new List<Serie>();
        Serie s = new Serie();
        int numero = 1;
        public Form1()
        {
            InitializeComponent();
            s.Codigo = numero.ToString();
            txtCodigo.Text = s.GenerarCod(Convert.ToInt32(s.Codigo));
        }

        private void btnObtenerFecha_Click(object sender, EventArgs e)
        {
            txtFecha.Text = monthCalendar1.SelectionStart.Day.ToString() + "/" +
                            monthCalendar1.SelectionStart.Month.ToString() + "/" +
                            monthCalendar1.SelectionStart.Year.ToString();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCodigo.Text == "" || txtCodigo == null || txtNombre.Text == "" || txtNombre.Text == null || cboCategoria.Text == "" || txtDuracion.Text == ""|| txtDuracion.Text == null || txtFecha.Text.ToString() == "" || txtFecha.Text == null || txtImporte.Text == "" || txtImporte.Text == null)
                {
                    MessageBox.Show("Ingrese datos completos", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
                else
                {
                    Serie s1 = ARREGLOSERIE.Find(x => x.Codigo == txtCodigo.Text);
                    if (s1 == null)
                    {
                        Serie s_nuevo = new Serie();

                        s_nuevo.Codigo = txtCodigo.Text.ToString();
                        s_nuevo.Nombre = txtNombre.Text.ToString();
                        s_nuevo.Categoria = cboCategoria.Text;
                        s_nuevo.Fecha = txtFecha.Text.ToString();
                        s_nuevo.Duracion = Convert.ToInt32(txtDuracion.Text);
                        s_nuevo.ImporteProduccion = Convert.ToDouble(txtImporte.Text);

                        ARREGLOSERIE.Add(s_nuevo);
                        dgvLista.DataSource = null;
                        dgvLista.DataSource = ARREGLOSERIE;
                        Listar();
                        limpiarCajas();
                        

                        numero += 1;
                        s.Codigo = numero.ToString();
                        txtCodigo.Text = s.GenerarCod(Convert.ToInt32(s.Codigo));
                    }
                    else
                    {
                        MessageBox.Show("El Código ya se encuentra registrado!", "Verifique", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                        limpiarCajas();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Fue mano", ex.Message);
            }
            
        }

        void Listar()
        {
            //DataGridView
            dgvLista.DataSource = null;//Limpiar la lista
            dgvLista.DataSource = ARREGLOSERIE;

            lwLista.Items.Clear();
            foreach (Serie s1 in ARREGLOSERIE)
            {
                ListViewItem item = new ListViewItem(s1.Codigo);
                item.SubItems.Add(s1.Nombre);
                item.SubItems.Add(s1.Categoria.ToString());
                item.SubItems.Add(s1.Fecha.ToString());
                item.SubItems.Add(s1.Duracion.ToString());
                item.SubItems.Add(s1.ImporteProduccion.ToString());

                lwLista.Items.Add(item);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        

        void limpiarCajas()
        {
            txtCodigo.Text = "";
            txtNombre.Text = "";
            cboCategoria.Text = "";
            txtDuracion.Text = "";
            txtFecha.Text = "";
            txtImporte.Text = "";
            
        }
        
        
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog dialogo = new SaveFileDialog();
                dialogo.Filter = "Archivo Json(*.json)|*.json";
                if (dialogo.ShowDialog() == DialogResult.OK)
                {
                    FileStream fs = new FileStream(dialogo.FileName, FileMode.Create);
                    DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(List<Serie>));
                    js.WriteObject(fs, ARREGLOSERIE);
                    fs.Close();
                    MessageBox.Show("Guardado satisfactoriamente");
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("ERROR", ex.Message);
            }
            
        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void btnDeserializar_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialogo = new OpenFileDialog();
            dialogo.Filter = "Archivo Json(*.json)|*.json";
            if (dialogo.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(dialogo.FileName, FileMode.Open);
                DataContractJsonSerializer js = new DataContractJsonSerializer(typeof(List<Serie>));
                ARREGLOSERIE = (List<Serie>)js.ReadObject(fs);
                dgvLista.DataSource = ARREGLOSERIE;
                fs.Close();
            }
        }
    }
}
