//Interfaz

using System;
using System.Collections.Generic;
using System.Text;

namespace Banco
{
    internal class interfaz
    {
        string menu = "1. Crear cuenta\n2. Retirar\n3. Consultar saldo\n4. Transferir\n5. Salir";
        Banco banco;

        public interfaz()
        {
            banco = new Banco();
        }
        public void Menu()
        {
            while(true) //Ciclo 
            {
                Cliente c;
                string opc;
                string nombre, clave;
                int id, puntos, numeroCuenta, cuentaTransferencia;
                double saldoInicial, cantidad;
                double saldoUsuario = 0;
                Console.WriteLine(menu);
                opc = Console.ReadLine();

                
                    switch(opc)
                    {
                        case "1": //Crear cuenta
                            //Datos cliente
                            Console.Write("Nombre: ");
                            nombre = Console.ReadLine();
                            Console.Write("ID: ");
                            int.TryParse(Console.ReadLine(), out id);
                            c = new Cliente(id, nombre);

                            //Saldo
                            Console.Write("Digite su saldo: ");
                            double.TryParse(Console.ReadLine(), out saldoInicial);
                            saldoInicial = saldoUsuario;

                            //Puntos

                            Console.WriteLine("Digite unos puntos iniciales para su cuenta: ");
                            int.TryParse(Console.ReadLine(), out puntos);

                            //Clave

                            Console.WriteLine("Ingrese una clave: ");
                            clave = Console.ReadLine();

                            numeroCuenta = banco.agregarCuenta(c,clave, saldoInicial, puntos);
                            Console.WriteLine("La cuenta fue creada exitosa mente :)");
                            Console.WriteLine("Los datos de su cuenta son: ");
                            Console.WriteLine($"Numero de cuenta: {numeroCuenta}");
                            Console.WriteLine($"Clave: {clave}");
                            
                        break;
                        
                        case "2": //Retirar
                            //Pido numero de cuenta

                            Console.WriteLine("Numero de cuenta: ");
                            int.TryParse(Console.ReadLine(), out numeroCuenta);

                            //Pido clave

                            Console.WriteLine("Clave: ");
                            clave = Console.ReadLine();

                            if(banco.loguear(numeroCuenta, clave))
                            {
                                Console.WriteLine("Digita la cantidad a retirar: ");
                                double.TryParse(Console.ReadLine(), out cantidad);
                                if(banco.retirar(numeroCuenta, cantidad))
                                {
                                    Console.WriteLine("Retiro exitoso....");
                                }
                                else
                                {
                                    Console.WriteLine("Error. Verifica cantidad a retirar. Maximo $2.000.000 al dia");
                                }
                            }
                            else
                            {
                                Console.WriteLine("La clave y cuenta no coinciden....");
                            }
                        break;

                        case "3": //Consultar saldo

                            //Pido la cuenta
                            Console.WriteLine("Numero de cuenta: ");
                            int.TryParse(Console.ReadLine(), out numeroCuenta);

                            //Pido clave

                            Console.WriteLine("Clave: ");
                            clave = Console.ReadLine();

                            if(banco.loguear(numeroCuenta, clave))
                            {
                                Console.WriteLine("Su saldo es: " + banco.consultarSaldo);
                            }
                            else
                            {
                                Console.WriteLine("La clave y cuenta no coinciden....");
                            }
                        break;

                        case "4": //Transferir

                            //Pido la cuenta
                            Console.WriteLine("Numero de cuenta: ");
                            int.TryParse(Console.ReadLine(), out numeroCuenta);

                            //Pido clave

                            Console.WriteLine("Clave: ");
                            clave = Console.ReadLine();

                            if(banco.loguear(numeroCuenta, clave))
                            {
                                Console.WriteLine("Ingrese el numero de cuenta al que va transferir: ");
                                int.TryParse(Console.ReadLine(), out cuentaTransferencia);
                                Console.WriteLine("Ingrese el monto a transferir: ");
                                double.TryParse(Console.ReadLine(), out cantidad);

                                if(cantidad > saldoUsuario && cantidad < 2000000)
                                {
                                    if(banco.existeCuenta(cuentaTransferencia))
                                    {
                                        Console.WriteLine("Transferencia completa.... :)");
                                    }
                                    else
                                    {
                                        Console.WriteLine("La cuenta  a la que desea trasnferir no existe....");
                                    }
                                }
                                else
                                {
                                    Console.WriteLine("El monto supera tu saldo actual o los $2.000.000");
                                }
                            }

                        break;

                        case "5":
                            Console.WriteLine("Vuelva pronto...");
                            Environment.Exit(0);
                        break;
                    }
            }
        }
    }
}