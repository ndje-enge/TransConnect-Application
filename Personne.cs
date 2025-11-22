using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet1
{
    abstract internal class Personne
    {
        private string ss;
        private string nom;
        private string prenom;
        private DateTime datenaissance;
        private string addresspost;
        private string email;
        private string tel;

        public Personne(string ss, string nom, string prenom, DateTime datenaissance, string addresspost, string email, string tel)
        {
            this.ss = ss;
            this.nom = nom;
            this.prenom = prenom;
            this.datenaissance = datenaissance;
            this.addresspost = addresspost;
            this.email = email;
            this.tel = tel;

        }
        public string Ss
        {
            get { return this.ss; }
            set { this.ss = value; }
        }
        public string Nom
        {
            get { return this.nom; }
            set { this.nom = value; }
        }
        public string Prenom
        {
            get { return this.prenom; }
            set
            {
                this.prenom = value;
            }
        }
        public DateTime Datenaissance
        {
            get { return this.datenaissance; }
            set
            {
                this.datenaissance = value;
            }
        }
        public string Addresspost
        {
            get { return this.addresspost; }
            set
            {
                this.addresspost = value;
            }
        }
        public string Email
        {
            get { return this.email; }
            set
            {
                this.email = value;
            }
        }
        public string Tel
        {
            get { return this.tel; }
            set
            {
                this.tel = value;
            }
        }
    }
}