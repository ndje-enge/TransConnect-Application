using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet1
{
    internal class Transconnect
    {
        private Employe org;
        public Employe Org
        {
            get { return org; }
            set { org = value; }
        }


        public void Creerunemploye(List<Employe> employes,Employe patron)
        {
            Console.WriteLine("Veuillez entrer le nom de l'employe ");
            string rr = Console.ReadLine();
            Console.WriteLine("veuillez entrer le poste de l'employe");
            string rr1 = Console.ReadLine();
            Console.WriteLine("entrer le nom du collegue de l'employe; entrer null si n'en possede pas");
            string rr2 = Console.ReadLine();
            Console.WriteLine("entrer le nom du successeur de l'employe; entrez null si il n'en possede pas ");
            string rr3 = Console.ReadLine();
            Employe kik = employes.Find(x => x.Nom == rr3);
            Employe det = employes.Find(x => x.Nom == rr2);
            Employe XS1 = new Employe(rr1, rr, null, kik);
            employes.Add(XS1);
            AjouterunCollegue(det, XS1);
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine("Voici le nouvel organigramme");
            Affichage(patron);
           
        }

        public bool AjouterunCollegue(Employe det, Employe XS1)
        {

            if (det == null) return false;
            if (det.Collegue == null)
            {
                det.Collegue = XS1;
                return true;
            }
            return AjouterunCollegue(det.Collegue, XS1);
        }
        public void Effaceemmploye(List<Employe> employes,Employe patron)
        {
            Console.WriteLine("Veuillez entrer le nom de l'employee que vous souhaitez supprimer");
            string uy = Console.ReadLine();
            Employe tobi= employes.Find(x => x.Nom == uy);
            
            Supprimer(patron,tobi);
            //Supprimeruncollegue(patron, tobi);
            Console.WriteLine("Voici le nouvel organigramme\n");
            Affichage(patron);

        }
        public bool Supprimer(Employe start,Employe sup)
        {
            if (start == null) return false;
               
            if(start.Successeur==sup )
            {
                
                    AjouterunCollegue(start.Successeur, start.Successeur.Successeur);
                    start.Successeur = start.Successeur.Collegue;
                    
                    return true;
                
                start.Successeur = start.Successeur.Successeur;
   
            }
            if (start.Collegue == sup)
            {
                if (start.Collegue.Successeur != null)
                {
                    AjouterunCollegue(start, start.Collegue.Successeur);
                    start.Collegue = start.Collegue.Collegue;

                    return true;
                }
                start.Collegue = start.Collegue.Collegue;

            }

            Supprimer(start.Successeur, sup);
            Supprimer(start.Collegue, sup);
            
            return false;
               
        }
        public bool Supprimeruncollegue(Employe emp,Employe collegueasuprimer)
        {
            if (emp == null) return false;
            if(emp==collegueasuprimer)
            {
                emp= emp.Successeur;
                
                return true;
            }
            return Supprimeruncollegue(emp.Collegue, collegueasuprimer);
        }
        public Transconnect(Employe org=null)
        {
            this.org=org;
            

        }
        public void Affichage(Employe start)
        {
            if(start!=null)
            {
                Console.WriteLine(start + " ");
                Affichage(start.Successeur);
                Affichage(start.Collegue);

            }
        }


    }
}
