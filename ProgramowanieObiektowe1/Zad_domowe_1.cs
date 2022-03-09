using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zad_domowe_1
{
   public class Ułamek
    {
        private readonly int  _licznik;
        private readonly int _mianownik;
        public int Licznik
        {
            get { return _licznik; }    
        }
        public int Mianownik
        {
            get { return _mianownik; }
        }
        public Ułamek(int licznik, int mianownik)
        {
            var _nwd = nwd(licznik, mianownik);
            _licznik = licznik/_nwd;
            _mianownik = mianownik/_nwd; 
        }
        public override string ToString()
        {
            return $"{Licznik}/{Mianownik}";
        }
        public static Ułamek operator+(Ułamek u1, Ułamek u2)
        {
            return new Ułamek(u1.Licznik * u2.Mianownik + u2.Licznik * u1.Mianownik, u1.Mianownik * u2.Mianownik);
        }
        public static Ułamek operator*(Ułamek u1, Ułamek u2)
        {
            return new Ułamek(u1.Licznik * u2.Licznik, u1.Mianownik * u2.Mianownik);
        }
        private static int nwd(int a, int b)
        {
            int x = a, y = b;
            while (x != y)
            {
                if (x > y)
                    x = x - y;
                else
                    y = y - x;
            }
            return x;
        }
    }
}
