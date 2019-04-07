using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gra_Lista5_zad2
{
    class Gracz
    {
        private string _nazwaGracza;
        private int _liczbaDniDoZwyciestwa;
        private int _posiadanePieniadze;

        public Gracz(string nazwa, int liczbaDni, int pieniadze)
        {
            _nazwaGracza = nazwa;
            _liczbaDniDoZwyciestwa = liczbaDni;
            _posiadanePieniadze = pieniadze;
        }

        public string NazwaGracza
        {
            get { return _nazwaGracza; }
            set { _nazwaGracza = value; }
        }

        public int LiczbaDniDoZwyciestwa
        {
            get { return _liczbaDniDoZwyciestwa; }
            set { _liczbaDniDoZwyciestwa = value; }
        }

        public int PosiadanePieniadze
        {
            get { return _posiadanePieniadze; }
            set { _posiadanePieniadze = value; }
        }
    }
}
