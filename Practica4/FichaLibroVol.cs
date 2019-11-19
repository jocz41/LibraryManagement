using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Practica4
{
    class FichaLibroVol : FichaLibro
    {
        private byte numeroVol;

        public FichaLibroVol(string r, string t, string autor, string edit, byte nVol, byte nEjem) : base(r, t, autor, edit, nEjem)
        {
            this.numeroVol = nVol;
        }

        public byte NumeroVol
        {
            get => numeroVol;
        }

        public override void imprimir ()
        {
            base.imprimir();
            Auxiliar.imprimirAzul("\nNº Volumen: ");
            Console.WriteLine(NumeroVol);
        }
    }
}
