using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace operacionesBancarias.dominio
{
    class Cliente : IComparable<Cliente>
    {
        // Atributos para datos
        private String primerNombre;
        private String apellido;
        // Atributos para la agregación
        private List<Cuenta> cuentas;
        private int numeroDeCuentas = 0;

        public Cliente(String p, String a)
        {
            primerNombre = p;
            apellido = a;
            cuentas = new List<Cuenta>();
        }

        public void AgregaCuenta(Cuenta cta)
        {
            cuentas.Add(cta);
            numeroDeCuentas = cuentas.Count;
        }
        public Cuenta GetCuenta(int indiceCuenta)
        {
            return cuentas[indiceCuenta];
        }

        public int CompareTo( Cliente? obj )
        {
            if( obj == null ) return 1;
            Cliente elOtro = obj;

            if (elOtro != null)
            {
                int aux = apellido.CompareTo(elOtro.apellido);
                if (aux != 0) return aux;
                aux = primerNombre.CompareTo(elOtro.primerNombre);
                if (aux != 0) return aux;
                return 0;
            }
            else throw new ArgumentException("El objeto no es un cliente");
        }

        public String PrimerNombre
        {
            get
            {
                return primerNombre;
            }
        }
        public String Apellido
        {
            get
            {
                return apellido;
            }
        }
        public int NumeroDeCuentas
        {
            get
            {
                return numeroDeCuentas;
            }
        }
    }
}
