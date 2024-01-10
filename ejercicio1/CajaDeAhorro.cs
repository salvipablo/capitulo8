using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace operacionesBancarias.dominio
{
    class CajaDeAhorro : Cuenta
    {
        private double porcentajeInteres;

        public CajaDeAhorro(double bal, double porcentaje): base(bal)
        {
            porcentajeInteres = porcentaje;
        }

        public double PorcentajeInteres
        {
            get
            {
                return porcentajeInteres;
            }
        }
    }
}
