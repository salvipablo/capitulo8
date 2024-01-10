using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace operacionesBancarias.dominio
{
    class Cuenta
    {
        protected double balance;

        public Cuenta(double bal)
        {
            balance = bal;
        }

        public virtual bool Deposita(double cantidad)
        {
            balance = balance + cantidad;
            return true;
        }
        public virtual void Retira(double cantidad)
        {
            if (balance < cantidad)
            {
                throw new ExcepcionSobregiro("Fondos Insuficientes", cantidad - balance);
            }
            else
            {
                balance = balance - cantidad;
            }
        }

        public double Balance
        {
            get
            {
                return balance;
            }
        }
    }
}
