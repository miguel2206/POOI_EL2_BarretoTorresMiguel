using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab02
{
    public class Serie
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Categoria { get; set; }
        public string Fecha { get; set; }
        public int Duracion { get; set; }
        public double ImporteProduccion { get; set; }

        public String GenerarCod(int numero)
        {

            string correlativo = "SE";
            string codCorrelativo = "";
            if (numero < 10)
            {
                codCorrelativo = correlativo + "0" + "0" + "0" +  numero.ToString();
            }
            else if (numero < 100)
            {
                codCorrelativo = correlativo + "0" + "0" + numero.ToString();
            }
            else
            {
                codCorrelativo = correlativo + "0" + numero;
            }


            return codCorrelativo;
        }
    }
}
