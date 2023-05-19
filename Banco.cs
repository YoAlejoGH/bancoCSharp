//Banco

using System;
using System.Collections.Generic;
using System.Text;

namespace Banco
{
    internal class Banco
    {
        List<Cuenta> cuentas;

        public Banco()
        {
            cuentas = new List<Cuenta>(); //1. Creo el listado de cuentas
            Cliente cliente = new Cliente(1110100, "Alfonso"); //Clientes

            Cuenta c = new Cuenta(1606030, cliente, 30000000, 100); //Cuentas
            cuentas.Add(c); //Agrego todas las cuentas
        }
        public bool agregarCuenta(Cuenta cuenta)
        {
            cuentas.Add(cuenta);
            return true;
        }
        public int agregarCuenta(Cliente c, string clave, double saldo, int puntos)
        {
            int numero;

            while(true)
            {
                numero = generador();
                if(!cuentas.Exists(c => c.numero == numero))
                {
                    break;
                }
            }
            
            Cuenta cuenta = new Cuenta(numero, c, saldo, clave, puntos);
            cuentas.Add(cuenta);
            return numero;

            //Metodo interno
            int generador()
            {
                int numero = 0;
                Random r = new Random();
                numero = r.Next(1000000, 9999999);
                return numero;
            }
        }
        public bool existeCuenta(int numero)
        {
            return cuentas.Exists(c => c.numero == numero);
        }
        public Cuenta dameCuenta(int numero)
        {
            Cuenta c = cuentas.Find(c => c.numero == numero);
            return c;
        }
        public bool loguear(int numeroCuenta, string clave)
        {
            if(existeCuenta(numeroCuenta))
            {
                Cuenta c = dameCuenta(numeroCuenta);
                return c.loguear(numeroCuenta, clave);
            }
            else
            {
                return false;
            }
        }
        public bool retirar(int numero, double cantidad)
        {
            Cuenta c = dameCuenta(numero);
            int indice = cuentas.IndexOf(c);
            if(cuentas[indice].retirar(cantidad))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public double consultarSaldo(ref double saldo)
        {
            return saldo;
        }
    }
}