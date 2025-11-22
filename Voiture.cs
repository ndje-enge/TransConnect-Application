using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet1
{
    internal class Voiture : Vehicule
    {
        private int nmbrepersonne;

        private string idvehicule;
        public int Nmbrepersonne
        {
            get { return nmbrepersonne; }
        }
        public string Idvehicule
        {
            get { return idvehicule; }
        }

        public Voiture(int nmbrepersonne,string idvehicule)
        {
            this.nmbrepersonne = nmbrepersonne;
        }
    }
}