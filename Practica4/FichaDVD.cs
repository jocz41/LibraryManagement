using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Practica4
{
    class FichaDVD : Ficha
    {
        #region Atributos
        private string director;
        private uint anio;
        private List<string> actores;
        #endregion

        public FichaDVD (string r, string t, string director, uint anio, List<string> actores, byte nEjem) : base(r, t, nEjem)
        {
            this.director = director;
            this.anio = anio;
            this.actores = actores.ToList();
        }

        #region Propiedades
        public string Director
        {
            get => director;
        }

        public uint Anio
        {
            get => anio;
        }

        public List<string> Actores
        {
            get => actores;
        }

        #endregion

        public override void imprimir()
        {
            Auxiliar.imprimirAzul("\nReferencia: ");
            Console.WriteLine(Referencia);
            Auxiliar.imprimirAzul("\nTítulo: ");
            Console.WriteLine(Titulo);
            Auxiliar.imprimirAzul("\nDirector: ");
            Console.WriteLine(Director);
            Auxiliar.imprimirAzul("\nAño: ");
            Console.WriteLine(Anio);
            Auxiliar.imprimirAzul("\nNº Ejemplares: ");
            Console.WriteLine(NEjemeplares);

            if (Actores.Count > 0)
            {
                Auxiliar.imprimirAzul("\nActores: ");
                foreach (string s in Actores)
                    Console.WriteLine(s + ", ");
            }
        }
    }
}
