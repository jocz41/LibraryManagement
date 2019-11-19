using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Practica4
{
    class FichaRevista : Ficha
    {
        private uint numero, anio;

        public FichaRevista(string r, string t, uint numero, uint anio, byte nEjem) : base (r, t, nEjem)
        {
            this.numero = numero;
            this.anio = anio;
        }

        #region Propiedades
        public uint Numero
        {
            get => numero;
        }

        public uint Anio
        {
            get => anio;
        }
        #endregion

        public override void imprimir()
        {
            Auxiliar.imprimirAzul("\nReferencia: ");
            Console.WriteLine(Referencia);
            Auxiliar.imprimirAzul("\nTítulo: ");
            Console.WriteLine(Titulo);
            Auxiliar.imprimirAzul("\nNúmero: ");
            Console.WriteLine(Numero);
            Auxiliar.imprimirAzul("\nAño: ");
            Console.WriteLine(Anio);
            Auxiliar.imprimirAzul("\nNº Ejemplares: ");
            Console.WriteLine(NEjemeplares);
        }
    }
}
