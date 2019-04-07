using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Gra_Lista5_zad2
{
    class Zwierze
    {
        private int _cenaJednostkowa;
        private int _posiadanaIlosc;
        private string _nazwaZwierzecia;

        private Queue<int> _cenyZwierzecia = new Queue<int>();

        public Zwierze(int cena, int ilosc, string nazwa)
        {
            _cenaJednostkowa = cena;
            _posiadanaIlosc = ilosc;
            _nazwaZwierzecia = nazwa;
            _cenyZwierzecia.Enqueue(cena);
        }

        public int CenaJednostkowa
        {
            get { return _cenaJednostkowa; }
            set { _cenaJednostkowa = value; }
        }

        public int PosiadanaIlosc
        {
            get { return _posiadanaIlosc; }
            set { _posiadanaIlosc = value; }
        }
        
        public string NazwaZwierzecia
        {
            get { return _nazwaZwierzecia; }
            set { _nazwaZwierzecia = value; }
        } 
        
        public Queue<int> PobierzListeCenZwierzat
        {
            get { return _cenyZwierzecia; }
        }       

        public int DodajCeneZwierzeciaDoListy
        {
            set
            {
                if (_cenyZwierzecia.Count>9)
                {
                    _cenyZwierzecia.Dequeue();
                }
                _cenyZwierzecia.Enqueue(value);
            }
        }
    }
}
