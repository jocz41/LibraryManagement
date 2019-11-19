using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Practica4
{
    abstract class Ficha
    {
        #region Atributos
        private static int numOrden = 1;
        private string referencia, titulo;
        private byte nEjemeplares;
        #endregion

        public Ficha (string referencia, string titulo, byte nEjemplares)
        {
            this.referencia = referencia + "/" + (numOrden++);
            this.titulo = titulo;
            this.nEjemeplares = nEjemplares;
        }

        #region Propiedades
        public string Referencia
        {
            get => referencia;
        }

        public string Titulo
        {
            get => titulo;
        }

        public byte NEjemeplares
        {
            get => nEjemeplares;
        }
        #endregion

        public abstract void imprimir();

    }
}
