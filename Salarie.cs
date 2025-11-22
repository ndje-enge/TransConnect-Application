using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet1
{
    internal class Salarie : Personne
    {
        private DateTime entresoc;
        private string poste;
        private double salaire;

        public Salarie(string ss, string nom, string prenom, DateTime datenaissance, string addresspost, string email, string tel, DateTime entresoc, string poste, double salaire) : base(ss, nom, prenom, datenaissance, addresspost, email, tel)
        {
            this.entresoc = entresoc;
            this.poste = poste;
            this.salaire = salaire;
        }
        public DateTime Entresoc { get { return entresoc; } }
        public string Poste { get { return poste; } set { poste = value; } }
        public double Salaire { get { return salaire; } set { salaire = value; } }
    }
}