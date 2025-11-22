using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet1
{
    internal class PoidsLourd : Vehicule
    {
        private double volume;
        private string matiere;
        private string typecamions;

        public double Volume { get { return volume; } set { volume = value; } }
        public string Matiere { get { return matiere; } set { matiere = value; } }
        public string Typecamions
        {
            get { return typecamions; }
            set { typecamions = value; }
        }

        public PoidsLourd(double volume, string matiere, string typecamions)
        {
            this.volume = volume;
            this.matiere = matiere;
            this.typecamions = typecamions;

        }

    }
}
