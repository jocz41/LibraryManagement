using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Practica4
{
    class FichaLibro : Ficha
    {
        private string autor, editorial;

        public FichaLibro (string referencia, string titulo, string autor, string editorial, byte nEjemplares) : base(referencia, titulo, nEjemplares)
        {
            this.autor = autor;
            this.editorial = editorial;
        }

        #region Propiedades
        public string Autor
        {
            get => autor;
        }

        public string Editorial
        {
            get => editorial;
        }
        #endregion 

        public override void imprimir()
        {
            Auxiliar.imprimirAzul("\nReferencia: ");
            Console.WriteLine(Referencia);
            Auxiliar.imprimirAzul("\nTítulo: ");
            Console.WriteLine(Titulo);
            Auxiliar.imprimirAzul("\nAutor: ");
            Console.WriteLine(Autor);
            Auxiliar.imprimirAzul("\nEditorial: ");
            Console.WriteLine(Editorial);
            Auxiliar.imprimirAzul("\nNº Ejemplares: ");
            Console.WriteLine(NEjemeplares);
        }
    }
}
