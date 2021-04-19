using ClienteSocketApp.Comunicacion;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClienteSocketApp
{
    class Program
    {
        static void Main(string[] args)
        {
            string ip = ConfigurationManager.AppSettings["ip"];
            int puerto = Convert.ToInt32(ConfigurationManager.AppSettings["puerto"]);

            ClienteSocket clienteSocket = new ClienteSocket(ip, puerto);
            if (clienteSocket.Conectar())
            {
                //Comunicarme
                Console.WriteLine("Cliente Conectado...");

                //Hacer el protocolo de comunicacion
                string mensaje = "";
                while(mensaje.ToLower() != "chao")
                {
                    Console.WriteLine("Diga lo que quiere decir:");
                    mensaje = Console.ReadLine().Trim();
                    Console.WriteLine("C:{0}", mensaje);
                    clienteSocket.Escribir(mensaje);
                    if(mensaje.ToLower() != "chao")
                    {
                        mensaje = clienteSocket.Leer();
                        Console.WriteLine("S:{0}", mensaje);
                    }
                }
                clienteSocket.Desconectar();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error de conexion");
            }
        }
    }
}
