using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace operacionesBancarias.dominio
{
    class ExcepcionSobregiro : Exception
    {
        private double deficit;

        public ExcepcionSobregiro(string mensaje, double deficit): base(mensaje)
        {
            this.deficit = deficit;
        }

        public double Deficit
        {
            get
            {
                return deficit;
            }
        }
    }
}
