using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab01
{
    public partial class CargarBarra : Form
    {
        public CargarBarra()
        {
            InitializeComponent();
        }

        delegate void CambiarProgresoDelegado(String texto, int valor);


        void EjecutarProceso()
        {
            // Invocar a un método
            CambiarProgreso("Iniciando Proceso", 0);

            for (int i = 1; i <= 100; i++)
            {
                Thread.Sleep(15);
                //Notificamos el avance
                CambiarProgreso(string.Format("Completado: {0}%", i), i);
            }

            CambiarProgreso("Completado!!!", 100);
            MessageBox.Show("Guardado satisfactoriamente en un txt");
            
            
        }
        private void pgbBarra_Click(object sender, EventArgs e)
        {

        }

        void CambiarProgreso(string texto, int valor)
        {
            // verificar si la invocación desde un hilo
            if (this.InvokeRequired)
            {
                // Invocamos al delegado
                CambiarProgresoDelegado delegado = new CambiarProgresoDelegado(CambiarProgreso);
                // Indicamos los parámetros 
                Object[] parametros = new object[] { texto, valor };
                // Invocamos al método a través del delegado
                this.Invoke(delegado, parametros);
            }
            else
            {
                lblProgreso.Text = texto;
                pgbBarra.Value = valor;
            }
        }

        private void CargarBarra_Load(object sender, EventArgs e)
        {
            // Crear el delegado
            ThreadStart delegado = new ThreadStart(EjecutarProceso);
            // Creamos un hilo
            Thread hilo = new Thread(delegado);
            // Iniciamos el hilo
            hilo.Start();
        }

        private void bwSerie_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            
        }
    }
}
