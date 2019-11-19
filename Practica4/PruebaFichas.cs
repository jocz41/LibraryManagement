using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Practica4
{
    class PruebaFichas
    {
        #region Atributos
        private List<string> datos;
        public List<Ficha> fichas;
        public List<FichaLibro> fichasLibro;
        public List<FichaLibroVol> fichasLibroVol;
        public List<FichaRevista> fichasRevista;
        public List<FichaDVD> fichasDVD;
        #endregion

        static void Main(string[] args)
        {
            PruebaFichas p = new PruebaFichas();
            p.fichas = new List<Ficha>();
            p.fichasLibro = new List<FichaLibro>();
            p.fichasLibroVol = new List<FichaLibroVol>();
            p.fichasRevista = new List<FichaRevista>();
            p.fichasDVD = new List<FichaDVD>();
            byte opcion;

            do
            {
                p.Menu();
                Auxiliar.imprimirMagenta("\nTeclee opción: ");
                opcion = Auxiliar.leerByte(Console.ReadLine());

                if (opcion != 0)
                    p.seleccionFicha(opcion);
            } while (opcion != 7);
        }

        #region Menú
        private void Menu()
        {
            Console.Clear();
            Console.WriteLine("┌─────────── GESTIÓN BIBLIOTECA ──────────┐");
            Console.WriteLine("|                                         |");
            Console.WriteLine("|    Elija el tipo de Ficha a crear:      |");
            Console.WriteLine("|                                         |");
            Console.WriteLine("| 1.     Libro                            |");
            Console.WriteLine("| 2.     Libro Volumen                    |");
            Console.WriteLine("| 3.     Revista                          |");
            Console.WriteLine("| 4.     Película en DVD                  |");
            Console.WriteLine("| 5.     Consultar Biblioteca             |");
            Console.WriteLine("| 6.     Salir                            |");
            Console.WriteLine("└─────────────────────────────────────────┘");
        }

        private void seleccionFicha (byte n)
        {
            switch(n)
            {
                case 1:
                    creaLibro();
                    break;
                case 2:
                    creaLibroVolumen();
                    break;
                case 3:
                    creaRevista();
                    break;
                case 4:
                    creaDVD();
                    break;
                case 5:
                    consultarBiblioteca();
                    break;
                case 6:
                    Environment.Exit(0);
                    break;
                default:
                    Auxiliar.imprimirError("\nERROR. Opción no válida.\n");
                    Auxiliar.esperaCorta();
                    break;
            }
        }
        #endregion

        #region Métodos

        #region Creación de elementos
        private void creaLibro()
        {
            byte nEjem = pedirDatos("libro");
            FichaLibro f = new FichaLibro(datos[0], datos[1], datos[2], datos[3], nEjem);

            fichasLibro.Add(f);
            fichas.Add(f);

            Console.Clear();
            Console.WriteLine("Datos introducidos:");
            f.imprimir();
            Auxiliar.pulsarContinuar();
        }

        private void creaLibroVolumen()
        {
            byte nEjem = pedirDatos("volumen");
            byte nVol = Auxiliar.leerByte (datos [datos.Count() - 1]);
            FichaLibroVol f = new FichaLibroVol(datos[0], datos[1], datos[2], datos[3], nVol, nEjem);

            fichasLibroVol.Add(f);
            fichas.Add(f);

            Console.Clear();
            Console.WriteLine("Datos introducidos:");
            f.imprimir();
            Auxiliar.pulsarContinuar();
        }

        private void creaRevista()
        {
            byte nEjem;
            uint numero, anio;

            nEjem = pedirDatos("revista");
            numero = Auxiliar.leerInt (datos[2]);
            anio = Auxiliar.leerInt(datos[datos.Count() - 1]);

            FichaRevista f = new FichaRevista(datos[0], datos[1], numero, anio, nEjem);

            fichasRevista.Add(f);
            fichas.Add(f);

            Console.Clear();
            Console.WriteLine("Datos introducidos:");
            f.imprimir();
            Auxiliar.pulsarContinuar();
        }

        private void creaDVD()
        {
            byte nEjem = pedirDatos("dvd");
            uint anio = Auxiliar.leerInt(datos[datos.Count() - 1]);
            List<string> actores = pedirActores();
            actores.RemoveAt(actores.Count-1);

            FichaDVD f = new FichaDVD(datos[0], datos[1], datos[2], anio, actores, nEjem);

            fichasDVD.Add(f);
            fichas.Add(f);

            Console.Clear();
            Console.WriteLine("Datos introducidos:");
            f.imprimir();
            Auxiliar.pulsarContinuar();
        }
        #endregion

        #region Consultas

        #region Biblioteca
        private void consultarBiblioteca()
        {
            byte opcion;

            do
            {
                menuConsulta();
                Auxiliar.imprimirMagenta("\nTeclee opción: ");
                opcion = Auxiliar.leerByte(Console.ReadLine());

                if (opcion != 0)
                    seleccionConsulta(opcion);
            } while (opcion != 5);
        }

        private void menuConsulta()
        {
            Console.Clear();
            Console.WriteLine("┌────────── CONSULTA BIBLIOTECA ──────────┐");
            Console.WriteLine("|                                         |");
            Console.WriteLine("|    Elija qué quiere buscar:             |");
            Console.WriteLine("|                                         |");
            Console.WriteLine("| 1.     Libro                            |");
            Console.WriteLine("| 2.     Libro Volumen                    |");
            Console.WriteLine("| 3.     Revista                          |");
            Console.WriteLine("| 4.     Película en DVD                  |");
            Console.WriteLine("| 5.     Atrás                            |");
            Console.WriteLine("└─────────────────────────────────────────┘");
        }

        private void seleccionConsulta(byte opcion)
        {
            switch (opcion)
            {
                case 1:
                    consultarLibro("");
                    break;
                case 2:
                    consultarLibro("volumen");
                    break;
                case 3:
                    consultarRevista();
                    break;
                case 4:
                    consultarDVD();
                    break;
                case 5:
                    break;
                default:
                    Auxiliar.imprimirError("\nERROR. Opción no válida.\n");
                    Auxiliar.esperaCorta();
                    break;
            }
        }
        #endregion

        #region Libro
        private void consultarLibro(string s)
        {
            byte opcion, lim;

            do
            {
                lim = menuLibro(s);
                Auxiliar.imprimirMagenta("\nTeclee opción: ");
                opcion = Auxiliar.leerByte(Console.ReadLine());

                if (opcion != 0)
                    seleccionaLibro(opcion, lim);
            } while (opcion !=lim);
        }

        private byte menuLibro(string s)
        {
            int c = 5;

            Console.Clear();
            Console.WriteLine("┌───────────── CONSULTA LIBRO ────────────┐");
            Console.WriteLine("|                                         |");
            Console.WriteLine("|    Elija qué quiere buscar:             |");
            Console.WriteLine("|                                         |");
            Console.WriteLine("| 1.     Referencia                       |");
            Console.WriteLine("| 2.     Título                           |");
            Console.WriteLine("| 3.     Autor                            |");
            Console.WriteLine("| 4.     Editorial                        |");

            if (s.Equals("volumen"))
            {
                Console.WriteLine("| " + c + ".     Volumen                          |");
                c++;
            }

            //Console.WriteLine("| " + c++ + ".     Nº Ejemplares                    |");
            Console.WriteLine("| " + c + ".     Atrás                            |");
            Console.WriteLine("└─────────────────────────────────────────┘");

            return Convert.ToByte(c);
        }

        private void seleccionaLibro(byte opcion, byte lim)
        {
            Console.Clear();
            Type t = (lim == 7) ? typeof(FichaLibroVol) : typeof(FichaLibro);

            switch (opcion)
            {
                case 1:
                    buscarReferencia(t);
                    break;
                case 2:
                    buscarTitulo(t);
                    break;
                case 3:
                    buscarAutor(t);
                    break;
                case 4:
                    buscarEditorial(t);
                    break;
                case 5:
                    if (lim == 7)
                        buscarVolumen();
                    //else
                    //    buscarNEjemplar();
                    break;
                case 6:
                    //if (lim == 7)
                    //    buscarNEjemplar();
                    break;
                case 7:
                    if (lim != 7)
                    {
                        Auxiliar.imprimirError("\nERROR. Opción no válida.\n");
                        Auxiliar.esperaCorta();
                    }
                    break;
                default:
                    Auxiliar.imprimirError("\nERROR. Opción no válida.\n");
                    Auxiliar.esperaCorta();
                    break;
            }
        }
        #endregion
        
        #region Revista

        private void consultarRevista()
        {
            byte opcion;
            
            do
            {
                menuRevista();
                Auxiliar.imprimirMagenta("\nTeclee opción: ");
                opcion = Auxiliar.leerByte(Console.ReadLine());
            
                if (opcion != 0)
                    seleccionaRevista(opcion);
            } while (opcion != 6);
        }

        private void menuRevista()
        {
            Console.Clear();
            Console.WriteLine("┌─────────── CONSULTA REVISTA ────────────┐");
            Console.WriteLine("|                                         |");
            Console.WriteLine("|    Elija qué quiere buscar:             |");
            Console.WriteLine("|                                         |");
            Console.WriteLine("| 1.     Referencia                       |");
            Console.WriteLine("| 2.     Título                           |");
            //Console.WriteLine("| 3.     Número                           |");
            //Console.WriteLine("| 4.     Año                              |");
            //Console.WriteLine("| 5.     Nº Ejemplares                    |");
            Console.WriteLine("| 6.     Atrás                            |");
            Console.WriteLine("└─────────────────────────────────────────┘");
        }

        private void seleccionaRevista(byte opcion)
        {
            Console.Clear();
            Type t = typeof(FichaRevista);

            switch (opcion)
            {
                case 1:
                    buscarReferencia(t);
                    break;
                case 2:
                    buscarTitulo(t);
                    break;
                //case 3:
                //    //buscarNumero();
                //    break;
                //case 4:
                //    //buscarAnio(t);
                //    break;
                //case 5:
                //    buscarNEjemplar();
                //    break;
                case 6:
                    break;
                default:
                    Auxiliar.imprimirError("\nERROR. Opción no válida.\n");
                    Auxiliar.esperaCorta();
                    break;
            }
        }

        #endregion

        #region DVD

        private void consultarDVD()
        {
            byte opcion;

            do
            {
                menuDVD();
                Auxiliar.imprimirMagenta("\nTeclee opción: ");
                opcion = Auxiliar.leerByte(Console.ReadLine());

                if (opcion != 0)
                    seleccionaDVD(opcion);
            } while (opcion != 7);
        }

        private void menuDVD()
        {
            Console.Clear();
            Console.WriteLine("┌───────────── CONSULTA DVD ──────────────┐");
            Console.WriteLine("|                                         |");
            Console.WriteLine("|    Elija qué quiere buscar:             |");
            Console.WriteLine("|                                         |");
            Console.WriteLine("| 1.     Referencia                       |");
            Console.WriteLine("| 2.     Título                           |");
            //Console.WriteLine("| 3.     Director                         |");
            //Console.WriteLine("| 4.     Año                              |");
            //Console.WriteLine("| 5.     Actores                          |");
            //Console.WriteLine("| 6.     Nº Ejemplares                    |");
            Console.WriteLine("| 7.     Atrás                            |");
            Console.WriteLine("└─────────────────────────────────────────┘");
        }

        private void seleccionaDVD(byte opcion)
        {
            Console.Clear();
            Type t = typeof(FichaDVD);

            switch (opcion)
            {
                case 1:
                    buscarReferencia(t);
                    break;
                case 2:
                    buscarTitulo(t);
                    break;
                //case 3:
                //    //buscarDirector();
                //    break;
                //case 4:
                //    //buscarAnio(t);
                //    break;
                //case 5:
                //    //buscarActores()
                //    break;
                //case 6:
                //    buscarNEjemplar();
                //    break;
                case 7:
                    break;
                default:
                    Auxiliar.imprimirError("\nERROR. Opción no válida.\n");
                    Auxiliar.esperaCorta();
                    break;
            }
        }

        #endregion

        #endregion

        #region Pedir Datos
        private byte pedirDatos(string tipo)
        {
            Console.Clear();
            Console.WriteLine("Introduzca los datos del/la " + tipo + ": ");
            byte aux;
            uint auxInt;

            datos = new List<string>();
            tipo = tipo.ToLower();
            
            datos.Add(pedirString("\nReferencia: "));
            datos.Add(pedirString("\nTítulo: "));

            switch (tipo)
            {
                case "libro":
                case "volumen":
                    datos.Add(pedirNombre("\nAutor: "));
                    datos.Add(pedirString("\nEditorial: "));

                    if (tipo.Equals("volumen"))
                    {
                        aux = pedirByte("\nNº Volumen: ");
                        datos.Add("" + aux);
                    }
                    break;

                case "revista":
                    auxInt = pedirInt("\nNúmero: ");
                    datos.Add("" + auxInt);
                    auxInt = pedirAnio("\nAño: ");
                    datos.Add("" + auxInt);
                    break;

                case "dvd":
                    datos.Add(pedirNombre("\nDirector: "));
                    auxInt = pedirAnio("\nAño: ");
                    datos.Add("" + auxInt);
                    break;
            }

            byte nEjem = pedirByte("\nNº Ejemplares: ");

            return nEjem;
        }

        private byte pedirByte (string s)
        {
            byte n = 0;

            while (n == 0)
            {
                Auxiliar.imprimirMagenta(s);
                n = Auxiliar.leerByte(Console.ReadLine());
            }

            return n;
        }

        private uint pedirInt(string s)
        {
            uint n = 0;

            while (n == 0)
            {
                Auxiliar.imprimirMagenta(s);
                n = Auxiliar.leerInt(Console.ReadLine());
            }

            return n;
        }

        private uint pedirAnio(string s)
        {
            uint n = 0;

            while (n < 1895 || n > DateTime.Now.Year)
            {
                if (n != 0)
                {
                    Auxiliar.imprimirError("\nERROR. Fecha no válida (1895-).\n");
                }
                n = pedirInt(s);                
            }

            return n;
        }

        private string pedirString (string s)
        {
            string nombre = "";

            while (nombre.Length == 0)
            {
                Auxiliar.imprimirMagenta(s);
                nombre = Auxiliar.leerCadena(Console.ReadLine());
            }

            return nombre;
        }

        private string pedirNombre(string s)
        {
            string nombre = "";

            while (nombre.Length == 0)
            {
                Auxiliar.imprimirMagenta(s);
                nombre = Auxiliar.leerNombre(Console.ReadLine());
            }

            return nombre;
        }

        private string pedirActor (string s)
        {
            string nombre = "", teclado = "";

            do
            {
                Auxiliar.imprimirMagenta(s);
                teclado = Console.ReadLine();
                nombre = Auxiliar.leerActor(teclado);
            } while (nombre.Length == 0 && teclado.Length != 0);

            return nombre;
        }

        private List<string> pedirActores()
        {
            List<string> nombres = new List<string>();
            byte c = 0;

            do
            {
                nombres.Add(pedirActor("\nActor " + c + ": "));
                c++;
            } while (nombres[c-1].Length > 0);

            return nombres;
        }
        #endregion

        #region Buscar

        private void buscarReferencia(Type t)
        {
            int c = 0;
            Ficha f = null;
            bool encontrada = false;
            string rf = pedirString("\nReferencia: ");

            if (!rf.Equals("/"))
            {
                while (c < fichas.Count && !encontrada)
                {
                    f = fichas[c];
                    f = f.GetType().Equals(t) ? f : null;
                    encontrada = (f != null) ? f.Referencia.Contains(rf) : false;
                    c++;
                }
            }

            if (!encontrada)
                Auxiliar.imprimirError("\nReferencia errónea o no existente.");
            else
                f.imprimir();

            Auxiliar.pulsarContinuar();
        }

        private void buscarTitulo(Type t)
        {
            int c = 0;
            Ficha f = null;
            bool encontrada = false;
            string rf = pedirString("\nTítulo: ");

            while (c < fichas.Count && !encontrada)
            {
                f = fichas[c];
                f = f.GetType().Equals(t) ? f : null;
                encontrada = (f != null) ? f.Titulo.Contains(rf) : false;
                c++;
            }

            if (!encontrada)
                Auxiliar.imprimirError("\nTítulo erróneo o no existente.");
            else
                f.imprimir();

            Auxiliar.pulsarContinuar();
        }

        private void buscarAutor(Type t)
        {
            int c = 0;
            bool encontrada = false;
            string rf = pedirString("\nAutor: ");

            if (t.GetType().Equals(typeof(FichaLibro)))
            {
                FichaLibro f = null;

                while (c < fichasLibro.Count && !encontrada)
                {
                    f = fichasLibro[c];
                    encontrada = (f != null) ? f.Autor.Contains(rf) : false;
                    c++;
                }

                if (!encontrada)
                    Auxiliar.imprimirError("\nAutor erróneo o no existente.");
                else
                    f.imprimir();

            }
            else
            {
                FichaLibroVol f = null;

                while (c < fichasLibroVol.Count && !encontrada)
                {
                    f = fichasLibroVol[c];
                    encontrada = (f != null) ? f.Autor.Contains(rf) : false;
                    c++;
                }
                
                if (!encontrada)
                    Auxiliar.imprimirError("\nAutor erróneo o no existente.");
                else
                    f.imprimir();
            }

            Auxiliar.pulsarContinuar();
        }

        private void buscarEditorial(Type t)
        {
            int c = 0;
            bool encontrada = false;
            string rf = pedirString("\nEditorial: ");

            if (t.GetType().Equals(typeof(FichaLibro)))
            {
                FichaLibro f = null;

                while (c < fichasLibro.Count && !encontrada)
                {
                    f = fichasLibro[c];
                    encontrada = (f != null) ? f.Editorial.Contains(rf) : false;
                    c++;
                }

                if (!encontrada)
                    Auxiliar.imprimirError("\nEditorial erróneo o no existente.");
                else
                    f.imprimir();

            }
            else
            {
                FichaLibroVol f = null;

                while (c < fichasLibroVol.Count && !encontrada)
                {
                    f = fichasLibroVol[c];
                    encontrada = (f != null) ? f.Editorial.Contains(rf) : false;
                    c++;
                }

                if (!encontrada)
                    Auxiliar.imprimirError("\nEditorial erróneo o no existente.");
                else
                    f.imprimir();
            }

            Auxiliar.pulsarContinuar();
        }

        private void buscarVolumen()
        {
            int c = 0;
            FichaLibroVol f = null;
            bool encontrada = false;
            int rf = pedirByte("\nNº Volumen: ");

            while (c < fichasLibroVol.Count && !encontrada)
            {
                f = fichasLibroVol[c];
                encontrada = (f.NumeroVol == rf);
                c++;
            }

            if (!encontrada)
                Auxiliar.imprimirError("\nVolumen erróneo o no existente.");
            else
                f.imprimir();

            Auxiliar.pulsarContinuar();
        }
                
        #endregion
        
        #endregion
    }
}
