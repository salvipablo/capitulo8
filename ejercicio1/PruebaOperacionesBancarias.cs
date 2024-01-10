using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using operacionesBancarias.dominio;
using operacionesBancarias.reportes;

namespace operacionesBancarias.verificaciones
{
    class PruebaOperacionesBancarias
    {
        static void Main(string[] args)
        {
            Banco banco = Banco.getBanco();
            Cliente cliente;
            Cuenta cuenta;

            banco.AgregaCliente("Juan", "Perez");
            cliente = banco.GetCliente(0);
            cliente.AgregaCuenta(new CuentaCorriente(200.00, 500.00));
            cliente.AgregaCuenta(new CajaDeAhorro(500.00, 0.05));

            banco.AgregaCliente("Oscar", "Toma");
            cliente = banco.GetCliente(1);
            cliente.AgregaCuenta(new CuentaCorriente(200.00));
            cliente.AgregaCuenta(new CajaDeAhorro(700.00, 0.05));

            banco.AgregaCliente("Pedro", "García");
            cliente = banco.GetCliente(2);
            cliente.AgregaCuenta(new CuentaCorriente(500.00));
            cliente.AgregaCuenta(new CajaDeAhorro(900.00, 0.05));

            banco.AgregaCliente("Maria", "Soley");
            cliente = banco.GetCliente(3);
            // Maria y Oscar tienen una caja de ahorros en común
            cliente.AgregaCuenta(banco.GetCliente(1).GetCuenta(1));


            cliente = banco.GetCliente(0);
            cuenta = cliente.GetCuenta(1);
            Console.WriteLine("El Cliente [" + cliente.Apellido + ", "
                    + cliente.PrimerNombre + "]"
                    + " tiene un balance en cuenta corriente de "
                    + cuenta.Balance
                    + " con una protección por sobregiro de 500.00.");
            try
            {
                Console.WriteLine("Cuenta Corriente [Juan Perez]: retira 150.00");
                cuenta.Retira(150.00);
                Console.WriteLine("Cuenta Corriente [Juan Perez]: deposita 22.50");
                cuenta.Deposita(22.50);
                Console.WriteLine("Cuenta Corriente [Juan Perez]: retira 147.62");
                cuenta.Retira(147.62);
                Console.WriteLine("Cuenta Corriente [Juan Perez]: retira 470.00");
                cuenta.Retira(470.00);
            }
            catch (ExcepcionSobregiro e1)
            {
                Console.WriteLine("Excepción: " + e1.Message + "   Deficit: "
                        + e1.Deficit);
            }
            finally
            {
                Console.WriteLine("El Cliente [" + cliente.Apellido + ", "
                        + cliente.PrimerNombre + "]"
                        + " tiene un balance en cuenta corriente de "
                        + cuenta.Balance);
            }

            Console.WriteLine();

            cliente = banco.GetCliente(1);
            cuenta = cliente.GetCuenta(0);
            Console.WriteLine("El Cliente [" + cliente.Apellido + ", "
                    + cliente.PrimerNombre + "]"
                    + " tiene un balance en cuenta corriente de "
                    + cuenta.Balance);
            try
            {
                Console.WriteLine("Cuenta Corriente [Oscar Toma]: retira 100.00");
                cuenta.Retira(100.00);
                Console.WriteLine("Cuenta Corriente [Oscar Toma]: deposita 25.00");
                cuenta.Deposita(25.00);
                Console.WriteLine("Cuenta Corriente [Oscar Toma]: retira 175.00");
                cuenta.Retira(175.00);
            }
            catch (ExcepcionSobregiro e1)
            {
                Console.WriteLine("Excepción: " + e1.Message + "   Deficit: "
                        + e1.Deficit);
            }
            finally
            {
                Console.WriteLine("El Cliente [" + cliente.Apellido + ", "
                        + cliente.PrimerNombre + "]"
                        + " tiene un balance en cuenta corriente de "
                        + cuenta.Balance);
            }

            Console.WriteLine();

            cliente = banco.GetCliente(2);
            cuenta = cliente.GetCuenta(0);
            Console.WriteLine("El Cliente [" + cliente.Apellido + ", "
                    + cliente.PrimerNombre + "]"
                    + " tiene un balance en cuenta corriente de "
                    + cuenta.Balance);
            try
            {
                Console.WriteLine("Cuenta Corriente [Pedro García]: retira 50.00");
                cuenta.Retira(50.00);
                Console.WriteLine("Cuenta Corriente [Pedro García]: deposita 250.00");
                cuenta.Deposita(250.00);
                Console.WriteLine("Cuenta Corriente [Pedro García]: retira 400.00");
                cuenta.Retira(400.00);
            }
            catch (ExcepcionSobregiro e1)
            {
                Console.WriteLine("Excepción: " + e1.Message + "   Deficit: "
                        + e1.Deficit);
            }
            finally
            {
                Console.WriteLine("El Cliente [" + cliente.Apellido + ", "
                        + cliente.PrimerNombre + "]"
                        + " tiene un balance en cuenta corriente de "
                        + cuenta.Balance);
            }

            ReporteCliente.generarReporte();
            Console.ReadKey();
        }
    }
}
