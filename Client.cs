using System.ComponentModel.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using System.Collections;
using System.Windows.Input;
namespace projet1
{
    class Client : Personne, IComparable<Client>
    {
        private string ville;
        private double sommeachat;
        public string Ville
        {
            get { return ville; }
            set { ville = value; }
        }
        public Client(string ss, string nom, string prenom, DateTime datenaissance, string addresspost, string email, string tel, string ville, double sommeachat = 0) : base(ss, nom, prenom, datenaissance, addresspost, email, tel)
        {
            this.ville = ville;
            this.sommeachat = sommeachat;
        }

        public double Sommeachat
        {
            get { return sommeachat; }
            set { sommeachat = value; }
        }


        public override string ToString()
        {
            return Ss + "," + Nom + "," + Prenom + "," + Datenaissance.ToString() + "," + Addresspost + "," + Email + "," + Tel + "," + Ville + "," + Sommeachat + ";";
        }

        // Méthode pour sauvegarder au format CSV
        public string ToCSV()
        {
            return $"{Ss};{Nom};{Prenom};{Datenaissance:yyyy-MM-dd};{Addresspost};{Email};{Tel};{Ville};{Sommeachat}";
        }

        public int myCompare(Client a)
        {
            return (this.Nom).CompareTo(a.Nom);
        }

        public int CompareTo(Client? other)
        {
            throw new NotImplementedException();
        }
    }
}