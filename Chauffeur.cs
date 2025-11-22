using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet1
{
    internal class Chauffeur : Salarie
    {
        private bool disponible;
        private double anciennete;


        public Chauffeur(string ss, string nom, string prenom, DateTime datenaissance, string addresspost, string email, string tel, DateTime entresoc, string poste, double salaire, bool disponible) : base(ss, nom, prenom, datenaissance, addresspost, email, tel, entresoc, poste, salaire)
        {
            this.disponible = disponible;

        }
        public bool Disponible
        { get { return disponible; } set { disponible = value; } }

        public double Anciennete
        {
            get { return anciennete; } set { anciennete = value; } 
        }

        public double TaxeH()
        {
            return Anciennete;
        }

    }
}

