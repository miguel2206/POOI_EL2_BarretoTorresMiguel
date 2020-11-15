using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace lab01
{
    public class ASISTENTE
    {
        public string Codigo { get; set; }
        public string Nombre { get; set; }
        public string Categoria { get; set; }

        //Métodos
        public double CalcularImportePorEntrada()
        {
            double importe = 0.0;
            switch (Categoria)
            {
                case "Normal":
                    importe = 250.00;
                    break;
                case "VIP":
                    importe = 400.00;
                    break;
                case "Super VIP":
                    importe = 500.00;
                    break;
            }
            return importe;
        }
    }
}
