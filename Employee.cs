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
    internal class Employe
    {
        private string poste;
        private string nom;
        private Employe collegue;
        private Employe successeur;
        private List<Employe> employes = new List<Employe>();
        public string Poste
        {
            get { return poste; }
            set { poste = value; }
        }
        public string Nom
        {
            get { return nom; }
            set { nom = value; }
        }
        public Employe Collegue
        {   
            get { return collegue; } 
            set { collegue = value; }
        }
        public Employe Successeur
        {
            get { return successeur; }
            set { successeur = value; }
        }
        public List<Employe> Employes
        {
            get { return employes; }
            set { employes = value; }
        }


        public Employe(string poste, string nom,Employe collegue=null,Employe successeur=null)
        {
            this.poste = poste;
            this.nom = nom;
            this.collegue = collegue;
            this.successeur=successeur;
            this.Employes = new List<Employe>();

        }
        public override string ToString()
        {
            return poste + " " + nom;
        }
    }
}