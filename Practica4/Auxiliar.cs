using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Practica4
{
    class Auxiliar
    {
        #region Lectura
        public static string leerCadena(string mensaje)
        {
            if (mensaje.Length == 0)
            {
                imprimirError("\nERROR. Campo vacío.\n");
                esperaCorta();
            }

            return mensaje;
        }

        public static string leerNombre(string mensaje)
        {
            if (mensaje.Length == 0)
            {
                imprimirError("\nERROR. Campo vacío.\n");
                esperaCorta();
            }
            else
            {
                Regex letras = new Regex("^[a-zA-z ñÑÀ-ÿ]+$");

                if (!letras.Match(mensaje).Success)
                {
                    mensaje = "";
                    imprimirError("\nERROR. Un nombre no debe tener números.\n");
                    esperaCorta();
                }
            }

            return mensaje;
        }

        public static string leerActor(string nombre)
        {
            if (nombre.Length != 0)
                nombre = leerNombre(nombre);

            return nombre;
        }

        public static byte leerByte(string mensaje)
        {
            byte n = 0;

            try
            {
                n = byte.Parse(mensaje);

                if (n == 0)
                {
                    throw new OverflowException();
                }
            }
            catch (ArgumentNullException)
            {
                imprimirError("\nERROR. Campo vacío.\n");
                esperaCorta();
            }
            catch (FormatException)
            {
                if (mensaje.Length == 0)
                    imprimirError("\nERROR. Campo vacío.\n");
                else
                    imprimirError("\nERROR. Valor no númerico.\n");
                esperaCorta();
            }
            catch (OverflowException)
            {
                imprimirError("\nERROR. Fuera de rango (1 - 255).\n");
                esperaCorta();
            }

            return n;
        }

        public static uint leerInt(string mensaje)
        {
            uint n = 0;

            try
            {
                if (mensaje.Length == 0)
                {
                    throw new ArgumentNullException();
                }

                n = UInt16.Parse(mensaje);

                if (n == 0)
                {
                    throw new OverflowException();
                }
            }
            catch (ArgumentNullException)
            {
                imprimirError("\nERROR. Campo vacío.\n");
                esperaCorta();
            }
            catch (FormatException)
            {
                imprimirError("\nERROR. Valor no númerico.\n");
                esperaCorta();
            }
            catch (OverflowException)
            {
                imprimirError("\nERROR. Fuera de rango (1 - 65.535).\n");
                esperaCorta();
            }

            return n;
        }
        #endregion

        #region Imprimir
        public static void imprimirError(string s)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write(s);
            Console.ResetColor();
        }

        public static void imprimirAzul(string s)
        {
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.Write(s);
            Console.ResetColor();
        }

        public static void imprimirMagenta(string s)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.Write(s);
            Console.ResetColor();
        }
        #endregion

        public static void esperaCorta()
        {
            System.Threading.Thread.Sleep(800);
        }

        public static void pulsarContinuar()
        {
            Console.Write("\n\nPulse cualquier tecla para continuar.");
            Console.ReadKey();
        }
    }
}
