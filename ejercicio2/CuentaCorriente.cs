using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace operacionesBancarias.dominio
{
    class CuentaCorriente : Cuenta
    {
        private double SIN_PROTECTION = -1.0;

        private double proteccionSobregiro;

        public CuentaCorriente(double bal, double proteccion): base(bal)
        {
            proteccionSobregiro = proteccion;
        }
        public CuentaCorriente(double bal):this(bal, -1.0)
        {
        }

        public override void Retira(double cantidad)
        {
            if (balance < cantidad)
            {
                double sobregiroNecesario = cantidad - balance;

                // No hay balance suficiente para cubrir la cantidad a retirar
                // Verificar si hay proteccion por sobregiro
                if (proteccionSobregiro == SIN_PROTECTION)
                {
                    // No hay proteccion por sobregiro o no llega a cubrir la cantidad
                    throw new ExcepcionSobregiro("No hay protección por sobregiro", sobregiroNecesario);
                }
                else
                {

                    if (proteccionSobregiro < sobregiroNecesario)
                    {
                        // Fondos insuficientes para cubrir el sobregiro
                        throw new ExcepcionSobregiro("Fondos insuficientes para proteger el sobregiro",
                                         sobregiroNecesario);
                    }
                    else
                    {
                        // Hay protección por sobregiro y es suficiente para cubrir la cantidad
                        balance = 0.0;
                        proteccionSobregiro = proteccionSobregiro - sobregiroNecesario;
                    }
                }
            }
            else
            {
                // Hay balance suficiente para cubrir la cantidad
                // Proceder normalmente
                balance = balance - cantidad;
            }
        }
    }
}
