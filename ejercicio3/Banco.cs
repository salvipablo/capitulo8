using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace operacionesBancarias.dominio
{
    /*
    * La clase Banco implementa el patrón de diseño Singleton
    * porque sólo puede haber un objeto del tipo Banco
    */
    class Banco
    {
        /*
        * La variable de referencia qua almacena la instancia de Banco.
        */
        private static Banco instanciaBanco = new Banco();
        public static Banco getBanco()
        {
            return instanciaBanco;
        }

        private const double PORCENTAJE_CAJA_AHORRO = 3.5;
        private List<Cliente> clientes;
        private int numeroDeClientes;

        private Banco()
        {
            clientes = new List<Cliente>();
            numeroDeClientes = 0;
        }

        public void ordenarClientes()
        {
            clientes.Sort();
        }   

        public void AgregaCliente(String p, String a)
        {
            clientes.Add(new Cliente(p, a));
            numeroDeClientes = clientes.Count;
        }
        public Cliente GetCliente(int indiceCliente)
        {
            return clientes[indiceCliente];
        }
        public int NumeroDeClientes
        {
            get
            {
                return numeroDeClientes;
            }
        }
    }
}
