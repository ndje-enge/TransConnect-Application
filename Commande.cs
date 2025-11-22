using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet1
{
    internal class Commande
    {
        private Client client;
        private int livraisonAB;

        private string vehicule;
        private string chauffeur;
        private DateTime datelivraison;
        public Commande(Client client, int livraisonAB, string vehicule, string chauffeur, DateTime datelivraison)
        {
            this.client = client;
            this.livraisonAB = livraisonAB;
            this.vehicule = vehicule;
            this.chauffeur = chauffeur;
            this.datelivraison = datelivraison;
        }
        public Client Client
        {
            get { return client; }
            set { client = value; }
        }
        public int LivraisonAB
        {
            get { return livraisonAB; }
        }





        public string Vehicule
        {
            get { return vehicule; }
            set { vehicule = value; }
        }
        public string Chauffeur
        {
            get { return chauffeur; }
            set { Chauffeur = value; }
        }
        public DateTime Datelivraison
        {
            get { return datelivraison; }
        }
        public override string ToString()
        {
            return "Client : " + Client + ",LivraisonAB :" + LivraisonAB  + ",Vehicule : " + Vehicule + ",Chauffeur : " + Chauffeur + ",Datedelivraison : " + Datelivraison;
        }
    }
}