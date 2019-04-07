using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gra_Lista5_zad2
{
    class Rozgrywka
    {
        private int _turaRozgrywki;
        private bool _spadkiCen; // jeżeli wartość TRUE - ceny będą spadać, jeżeli FALSE, będą rosnąć
        private int _wartoscSpadkuCeny;

        public Rozgrywka(int tura, bool spadki, int wartosc)
        {
            _turaRozgrywki = tura;
            _spadkiCen = spadki;
            _wartoscSpadkuCeny = wartosc;
        }
        
        public int TuraRozgrywki
        {
            get { return _turaRozgrywki; }
            set { _turaRozgrywki = value; }
        }

        public bool SpadkiCen
        {
            get { return _spadkiCen; }
            set { _spadkiCen = value; }
        }

        public int WartoscSpadkuCeny
        {
            get { return _wartoscSpadkuCeny; }
            set { _wartoscSpadkuCeny = value; }
        }
    }
}
