using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet1
{
    internal class Ville
    {

        private string nom;
        public Ville(string nom)
        {
            this.nom = nom;
        }   
        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }
    }
}
