//Cuentas

using System;
using System.Collections.Generic;
using System.Text;

namespace Banco
{
    internal class Cuenta
    {
        private double cantidadAcumulada; //Me ayuda a controlar los retiros diarios, si este llega a dos millones no deja retirar mas.
        public int numero{ get; set;}
        public string clave{ get; set;}
        public Cliente cliente{ get; set;}
        public double saldo{ get; set;}
        public int puntos{ get; set;}

        //Metodos...........

        public Cuenta(int numero, Cliente c, double saldo, int puntos)
        {
            cantidadAcumulada = 0;
            this.numero = numero;
            this.cliente = c;
            this.saldo = saldo;
            this.puntos = puntos;
        }
        public Cuenta(int numero, Cliente c, double saldo, string clave, int puntos)
        {
            cantidadAcumulada = 0;
            this.numero = numero;
            this.clave = clave;
            this.cliente = c;
            this.saldo = saldo;
            this.puntos = puntos;
        }
        public double consultarSaldo()
        {
            return this.saldo;
        }
        public bool retirar(double cantidad)
        {
            if(cantidad <= saldo && (cantidadAcumulada + cantidad) <= 2000000)
            {
                saldo -= cantidad;
                return true;
            }
            else
            {
                return false;
            }
            
            
        }
        public int consultarPuntos()
        {
            return puntos;
        }
        public bool loguear(int numero, string clave)
        {
            return this.numero == numero && this.clave == clave;
        }
    }
}