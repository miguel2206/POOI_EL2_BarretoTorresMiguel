using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace lab03
{
    public partial class Form1 : Form
    {
        //Crear proveedor 
        DESCryptoServiceProvider des = new DESCryptoServiceProvider();
        byte[] key = new byte[] { 60, 61, 62, 63, 64, 65, 66, 67 };
        byte[] iv = new byte[] { 50, 51, 52, 53, 54, 55, 56, 57 };

        public Form1()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if(txtArea.Text == "" || txtArea.Text == null)
            {
                MessageBox.Show("Ingrese texto o algún caracter");
            }
            else
            {
                SaveFileDialog dialogo = new SaveFileDialog();
                dialogo.Filter = "Archivo de texto (*.txt)|*.txt";

                if (dialogo.ShowDialog() == DialogResult.OK)
                {

                    MemoryStream ms = new MemoryStream();
                    StreamWriter escritor = new StreamWriter(ms);
                    escritor.Write(txtArea.Text);
                    escritor.Flush();

                    FileStream fs = new FileStream(dialogo.FileName, FileMode.Create);

                    CryptoStream cs = new CryptoStream(fs, des.CreateEncryptor(key, iv), CryptoStreamMode.Write);

                    cs.Write(ms.ToArray(), 0, ms.ToArray().Length);

                    cs.Close();
                    fs.Close();

                    MessageBox.Show("Texto encriptado exitosamente!");
                }
            }
        }

        private void btnLimpiar_Click(object sender, EventArgs e)
        {
            if(txtArea.Text == "" || txtArea.Text == null)
            {
                MessageBox.Show("La caja está vacía");
            }
            else
            {
                txtArea.Text = "";
                MessageBox.Show("Limpieza exitosa");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(txtArea.Text == "" || txtArea.Text == null)
            {
                MessageBox.Show("Ingrese texto o algún caracter");
            }
            else
            {
                SaveFileDialog dialogo = new SaveFileDialog();
                dialogo.Filter = "Archivo binario (*.bin) | *.bin";
                if (dialogo.ShowDialog() == DialogResult.OK)
                {
                    FileStream fs = new FileStream(dialogo.FileName, FileMode.Create);
                    //Seriaizacion binaria
                    BinaryWriter escritor = new BinaryWriter(fs);
                    escritor.Write(txtArea.Text);
                    escritor.Close();
                    fs.Close();
                    MessageBox.Show("Archivo binario grabado satisfactoriamente");
                }
            }
            
        }

        private void btnDesencriptar_Click(object sender, EventArgs e)
        {
            OpenFileDialog dialogo = new OpenFileDialog();
            dialogo.Filter = "Archivo de texto (*.txt)|*.txt";

            if (dialogo.ShowDialog() == DialogResult.OK)
            {
                FileStream fs = new FileStream(dialogo.FileName, FileMode.Open);

                CryptoStream cs = new CryptoStream(fs, des.CreateDecryptor(key, iv), CryptoStreamMode.Read);

                txtArea.Text = new StreamReader(cs).ReadToEnd();

                cs.Close();
                fs.Close();

                MessageBox.Show("Texto decifrado satisfactoriamente!");
            }
        }
    }
}
