using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

/*
Zad.2. Napisz grę edukacyjną dedykowaną dla dzieci w wieku ok. 8-10 lat, która ma
stymulować ich zapamiętywanie, umiejętność odczytywania/gromadzenia danych z
wykresów oraz umiejętność wykonywania prostych obliczeń arytmetycznych.
a) Gra rozpoczyna się kredytem w wysokości 10 tys. zł (-10 000 złotych na rozpoczęcie
działalności gospodarczej), i ma polegać na kupowaniu/sprzedawaniu 4 rodzajów zwierząt
(koszatniczki, króliki, świnki (morskie), chomiki).
b) Gra może prowadzić do zwycięstwa (o ile gracz będzie sprzedawał drożej niż kupił) w
przypadku osiągnięcia kwoty 100 tys. zł. na koncie gry.
c) Gra może kończy się w momencie przekroczenia zadłużenia na poziomie 100 tyś zł.
d) Zwierzęta można zastąpić kursami walut o wartościach w porządku malejącym: funt, euro,
dolar, korona (w tym przypadku nie będzie to już gra dla tak małych dzieci). W takim
wariancie, gra będzie polegała na kupnie/sprzedaży walut.
e) Koszt jednostkowy, wyjściowy walut powinien kształtować się mniej więcej na poziomie
średniego kursu wymienionych wyżej walut. Ceny wyjściowe zwierząt: 20, 15, 10, 3 zł.
odpowiednio.
f) Logika gry powinna zapewniać zarówno powolne wzrosty, spadki cen/kursu zwierząt/walut,
ale również rzadkie „krachy na giełdzie”. „Krachy” powinny być sygnalizowane
komunikatem np. „…dzikie hordy kotów przepędziły większość chomików – cena tych
zwierząt (podobnie jak masło), poszybowała w górę do niebotycznej wartości ...” (proszę
wymyślić własne scenariusze).
g) Podstawowym elementem interfejsu graficznego gry powinien zostać wykres
wspomnianych wcześniej walorów (ceny jednostkowe zwierząt, walut), zawierający historię
cen z ostatnich dziesięciu dni. Od jego przejrzystości będą zależały przyszłe wyniki małych
(dużych) graczy oraz zapewniać odpowiednio wysoką grywalność.
h) Ponadto gracz powinien dysponować wiedzą o aktualnych cenach kupna/sprzedaży
dostępnych walorów, posiadanych stanach magazynowych oraz bieżącym stanie konta i
aktualnym dniu rozgrywki.
i) Ilość kupowanego/sprzedawanego waloru powinna być określana przy pomocy np.
trackBar-ów a nie textBox-ów.
j) Gra powinna toczyć się turowo (1 tura = 1 dzień).
k) Gra powinna tworzyć/zapamiętywać listę najlepszych wyników: nr na liście -> gracz (nik
w grze) → liczba dni potrzebnych do zwycięstwa (w porządku rosnącym). Lista
zwycięzców powinna kończyć grę.
 */

namespace Gra_Lista5_zad2
{
    public partial class Form1 : Form
    {
        Zwierze _koszatniczka = new Zwierze(25, 0, "Koszatniczka");
        Zwierze _krolik = new Zwierze(15, 0, "Krolik");
        Zwierze _swinka = new Zwierze(10, 0, "Swinka morska");
        Zwierze _chomik = new Zwierze(3, 0, "Chomik");
        Gracz _gracz = new Gracz("Gracz", 0, -10000);
        Rozgrywka _rozgrywka = new Rozgrywka(1, false, 0);
        Random _losowanieLiczb = new Random();

        List<Zwierze> _listaZwierzat = new List<Zwierze>();
        bool[] _czySpadkiCenZwierzat = new bool[4];

        
        
        

        public Form1()
        {
            InitializeComponent();
            label1CenaKoszatniczka.Text = Convert.ToString(_koszatniczka.CenaJednostkowa);
            label2CenaKrolika.Text = Convert.ToString(_krolik.CenaJednostkowa);
            label3CenaSwinki.Text = Convert.ToString(_swinka.CenaJednostkowa);
            label4CenaChomika.Text = Convert.ToString(_chomik.CenaJednostkowa);
            label6IloscKoszatniczka.Text = Convert.ToString(_koszatniczka.PosiadanaIlosc);
            label7IloscKrolika.Text = Convert.ToString(_krolik.PosiadanaIlosc);
            label8IloscSwinki.Text = Convert.ToString(_swinka.PosiadanaIlosc);
            label9IloscChomika.Text = Convert.ToString(_chomik.PosiadanaIlosc);
            label4IloscPosiadanejKasy.Text = Convert.ToString(_gracz.PosiadanePieniadze);
            label5.Text = Convert.ToString(_rozgrywka.TuraRozgrywki);
            _listaZwierzat.Add(_koszatniczka);
            _listaZwierzat.Add(_krolik);
            _listaZwierzat.Add(_swinka);
            _listaZwierzat.Add(_chomik);
            //chart1.Series["Seria1"].Points.AddXY(x[i], y[i]);

            foreach (var zwierze in _listaZwierzat)
            {
                chart1.Series[zwierze.NazwaZwierzecia].Points.AddXY(_rozgrywka.TuraRozgrywki, zwierze.CenaJednostkowa);
            }
        }

        private void buttonWprowadzNick_Click(object sender, EventArgs e)
        {
            _gracz.NazwaGracza = textBoxNickGracza.Text;
        }

        private void trackBar1_Scroll(object sender, EventArgs e)
        {
            labelIloscDoKupienia.Text = Convert.ToString(trackBar1.Value);
            label3CenaZaZwierzaki.Text = Convert.ToString(trackBar1.Value * _koszatniczka.CenaJednostkowa);
        }

        private void trackBar2_Scroll(object sender, EventArgs e)
        {
            labelIloscDoKupienia.Text = Convert.ToString(trackBar2.Value);
            label3CenaZaZwierzaki.Text = Convert.ToString(trackBar2.Value * _krolik.CenaJednostkowa);
        }

        private void trackBar3_Scroll(object sender, EventArgs e)
        {
            labelIloscDoKupienia.Text = Convert.ToString(trackBar3.Value);
            label3CenaZaZwierzaki.Text = Convert.ToString(trackBar3.Value * _swinka.CenaJednostkowa);
        }

        private void trackBar4_Scroll(object sender, EventArgs e)
        {
            labelIloscDoKupienia.Text = Convert.ToString(trackBar4.Value);
            label3CenaZaZwierzaki.Text = Convert.ToString(trackBar4.Value * _chomik.CenaJednostkowa);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                _gracz.PosiadanePieniadze -= _koszatniczka.CenaJednostkowa * trackBar1.Value;
                label4IloscPosiadanejKasy.Text = Convert.ToString(_gracz.PosiadanePieniadze);
                _koszatniczka.PosiadanaIlosc += trackBar1.Value;
                label6IloscKoszatniczka.Text = Convert.ToString(_koszatniczka.PosiadanaIlosc);
                MessageBox.Show("Brawo! Kupiłeś " + trackBar1.Value + " koszatniczków.");
            }
            else if (radioButton2.Checked)
            {
                if (_koszatniczka.PosiadanaIlosc > 0 && trackBar1.Value <= _koszatniczka.PosiadanaIlosc)
                {
                    _gracz.PosiadanePieniadze += _koszatniczka.CenaJednostkowa * trackBar1.Value;
                    label4IloscPosiadanejKasy.Text = Convert.ToString(_gracz.PosiadanePieniadze);
                    _koszatniczka.PosiadanaIlosc -= trackBar1.Value;
                    label6IloscKoszatniczka.Text = Convert.ToString(_koszatniczka.PosiadanaIlosc);
                    MessageBox.Show("Brawo! Sprzedałeś " + trackBar1.Value + " koszatniczków.");
                }

                else
                {
                    MessageBox.Show("nie posiadasz tylu Koszatniczków! \nNic nie sprzedałeś.");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                _gracz.PosiadanePieniadze -= _krolik.CenaJednostkowa * trackBar2.Value;
                label4IloscPosiadanejKasy.Text = Convert.ToString(_gracz.PosiadanePieniadze);
                _krolik.PosiadanaIlosc += trackBar2.Value;
                label7IloscKrolika.Text = Convert.ToString(_krolik.PosiadanaIlosc);
                MessageBox.Show("Brawo! Kupiłeś " + trackBar2.Value + " królików.");
            }
            else if (radioButton2.Checked)
            {
                if (_krolik.PosiadanaIlosc > 0 && trackBar2.Value <= _krolik.PosiadanaIlosc)
                {
                    _gracz.PosiadanePieniadze += _krolik.CenaJednostkowa * trackBar2.Value;
                    label4IloscPosiadanejKasy.Text = Convert.ToString(_gracz.PosiadanePieniadze);
                    _krolik.PosiadanaIlosc -= trackBar2.Value;
                    label7IloscKrolika.Text = Convert.ToString(_krolik.PosiadanaIlosc);
                    MessageBox.Show("Brawo! Sprzedałeś " + trackBar2.Value + " królików.");
                }
                else
                {
                    MessageBox.Show("nie posiadasz tyle Królików! \nNic nie sprzedałeś.");
                }
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                _gracz.PosiadanePieniadze -= _swinka.CenaJednostkowa * trackBar3.Value;
                label4IloscPosiadanejKasy.Text = Convert.ToString(_gracz.PosiadanePieniadze);
                _swinka.PosiadanaIlosc += trackBar3.Value;
                label8IloscSwinki.Text = Convert.ToString(_swinka.PosiadanaIlosc);
                MessageBox.Show("Brawo! Kupiłeś " + trackBar3.Value + " świnek morskich.");
            }
            else if (radioButton2.Checked)
            {
                if (_swinka.PosiadanaIlosc > 0 && trackBar3.Value <= _swinka.PosiadanaIlosc)
                {
                    _gracz.PosiadanePieniadze += _swinka.CenaJednostkowa * trackBar3.Value;
                    label4IloscPosiadanejKasy.Text = Convert.ToString(_gracz.PosiadanePieniadze);
                    _swinka.PosiadanaIlosc -= trackBar3.Value;
                    label8IloscSwinki.Text = Convert.ToString(_swinka.PosiadanaIlosc);
                    MessageBox.Show("Brawo! Sprzedałeś " + trackBar3.Value + " świnek morskich.");
                }
                else
                {
                    MessageBox.Show("nie posiadasz tyle Świnek morskich! \nNic nie sprzedałeś.");
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                _gracz.PosiadanePieniadze -= _chomik.CenaJednostkowa * trackBar4.Value;
                label4IloscPosiadanejKasy.Text = Convert.ToString(_gracz.PosiadanePieniadze);
                _chomik.PosiadanaIlosc += trackBar4.Value;
                label9IloscChomika.Text = Convert.ToString(_chomik.PosiadanaIlosc);
                MessageBox.Show("Brawo! Kupiłeś " + trackBar4.Value + " chomików.");
            }
            else if (radioButton2.Checked)
            {
                if (_chomik.PosiadanaIlosc > 0 && trackBar4.Value <= _chomik.PosiadanaIlosc)
                {
                    _gracz.PosiadanePieniadze += _chomik.CenaJednostkowa * trackBar4.Value;
                    label4IloscPosiadanejKasy.Text = Convert.ToString(_gracz.PosiadanePieniadze);
                    _chomik.PosiadanaIlosc -= trackBar4.Value;
                    label9IloscChomika.Text = Convert.ToString(_chomik.PosiadanaIlosc);
                    MessageBox.Show("Brawo! Sprzedałeś " + trackBar4.Value + " chomików.");
                }
                else
                {
                    MessageBox.Show("nie posiadasz tylu Chomików! \nNic nie sprzedałeś.");
                }
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Kolejna tura!");
            _rozgrywka.TuraRozgrywki++;
            label5.Text = Convert.ToString(_rozgrywka.TuraRozgrywki);
            //if (_rozgrywka.TuraRozgrywki%7==1)
            {
                foreach (var zwierze in _listaZwierzat)
                {
                    int wylosowanaLiczbaPomocnicza = _losowanieLiczb.Next(0, 100);
                    if (wylosowanaLiczbaPomocnicza <= 50) _rozgrywka.SpadkiCen = true; // jeżeli mniejsze rowne od 50, to nastepuja spadki cen
                    else if (wylosowanaLiczbaPomocnicza > 50) _rozgrywka.SpadkiCen = false; //jeżeli większe, są wzrosty cen;

                    wylosowanaLiczbaPomocnicza = _losowanieLiczb.Next(0, 5);
                    if (_rozgrywka.SpadkiCen == true && (zwierze.CenaJednostkowa-wylosowanaLiczbaPomocnicza)>0)
                    {
                        zwierze.CenaJednostkowa -= wylosowanaLiczbaPomocnicza;
                    }
                    else if (_rozgrywka.SpadkiCen == false)
                    {
                        zwierze.CenaJednostkowa += wylosowanaLiczbaPomocnicza;
                    }

                    label1CenaKoszatniczka.Text = Convert.ToString(_koszatniczka.CenaJednostkowa);
                    label2CenaKrolika.Text = Convert.ToString(_krolik.CenaJednostkowa);
                    label3CenaSwinki.Text = Convert.ToString(_swinka.CenaJednostkowa);
                    label4CenaChomika.Text = Convert.ToString(_chomik.CenaJednostkowa);

                    zwierze.DodajCeneZwierzeciaDoListy = zwierze.CenaJednostkowa;

                    chart1.Series[zwierze.NazwaZwierzecia].Points.Clear();
                    foreach (var punkt in zwierze.PobierzListeCenZwierzat)
                    {
                        chart1.Series[zwierze.NazwaZwierzecia].Points.AddXY(_rozgrywka.TuraRozgrywki, punkt);
                    }
                    

                    //chart1.Series[zwierze.NazwaZwierzecia].Points.AddXY(_rozgrywka.TuraRozgrywki, zwierze.CenaJednostkowa);

                }
            }
        }
    }
}
