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
    internal class Program
    {

        #region Ajouter client
        static void AjouterClient(List<Client> clients)
        {
            Console.WriteLine("Veuillez entrer le nombre de clients à insérer :");
            int x = Convert.ToInt32(Console.ReadLine());
    
            for (int ii = 0; ii < x; ii++)
            {
                int s3 = ii + 1;
                Console.WriteLine($"=== Client {s3} ===");
                Console.WriteLine("Numéro de sécurité sociale :");
                string a = Console.ReadLine();
                Console.WriteLine("Nom :");
                string b = Console.ReadLine();
                Console.WriteLine("Prénom :");
                string c = Console.ReadLine();
                Console.WriteLine("Année de naissance :");
                int d = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Mois de naissance :");
                int e = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Jour de naissance :");
                int f = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Adresse postale :");
                string g = Console.ReadLine();
                Console.WriteLine("Email :");
                string h = Console.ReadLine();
                Console.WriteLine("Téléphone :");
                string i = Console.ReadLine();
                Console.WriteLine("Ville :");
                string j = Console.ReadLine();

                clients.Add(new Client(a, b, c, new DateTime(d, e, f), g, h, i, j));
            }
            
            
            SauvegarderClients(clients);
            Console.WriteLine("Clients ajoutés et sauvegardés !");
        }
        #endregion

        #region Ejecter client
        static void EjecterClient(List<Client> clients)
        {
            Console.WriteLine("Nombre de clients à supprimer :");
            int y = Convert.ToInt32(Console.ReadLine());

            for (int nn = 0; nn < y; nn++)
            {
                int pp = nn + 1;
                Console.WriteLine($"Numéro de sécurité sociale du client {pp} à supprimer :");
                string k = Console.ReadLine();

                Client clientASupprimer = clients.Find(x => x.Ss == k);
                if (clientASupprimer != null)
                {
                    clients.Remove(clientASupprimer);
                    Console.WriteLine($"Client {clientASupprimer.Nom} supprimé.");
                }
                else
                {
                    Console.WriteLine($"Aucun client trouvé avec le SS : {k}");
                }
            }

            
            SauvegarderClients(clients);
            Console.WriteLine("Modifications sauvegardées !");
        }
        #endregion


        #region Modifier Client 

        static void ModifierClient(List<Client> clients)
        {
            Console.WriteLine("Numéro de sécurité sociale du client à modifier :");
            string ss = Console.ReadLine();

            Client client = clients.Find(x => x.Ss == ss);

            if (client == null)
            {
                Console.WriteLine("Client non trouvé !");
                return;
            }

            Console.WriteLine($"Client trouvé : {client.Nom} {client.Prenom}");
            Console.WriteLine("\nQue voulez-vous modifier ?");
            Console.WriteLine("1. Nom");
            Console.WriteLine("2. Email");
            Console.WriteLine("3. Téléphone");
            Console.WriteLine("4. Adresse");

            string choix = Console.ReadLine();

            switch (choix)
            {
                case "1":
                    Console.WriteLine("Nouveau nom :");
                    client.Nom = Console.ReadLine();
                    break;
                case "2":
                    Console.WriteLine("Nouvel email :");
                    client.Email = Console.ReadLine();
                    break;
                case "3":
                    Console.WriteLine("Nouveau téléphone :");
                    client.Tel = Console.ReadLine();
                    break;
                case "4":
                    Console.WriteLine("Nouvelle adresse :");
                    client.Addresspost = Console.ReadLine();
                    break;
                default:
                    Console.WriteLine("Choix invalide !");
                    return;
            }

            
            SauvegarderClients(clients);
            Console.WriteLine("Client modifié et sauvegardé !");
        }

        #endregion

        static void Statistiquechauffeur(List<Commande> comands,List<Chauffeur> chauffeurs)
        {
            Console.WriteLine("La liste des chauffeurs est la suivantes :\n");
            for (int i = 0; i < chauffeurs.Count(); i++)
            {
                Console.WriteLine(chauffeurs[i]);
            }
            Console.WriteLine("Veuillez choisir  le nom du chaufeur dont vous voullez avoir les statistiques sur ces livraisons");
            string pio = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("la liste des commandes livre par ce chauffeur est la suivantes \n ");
            for (int i = 0; i < comands.Count(); i++)
            {
                if (pio == comands[i].Chauffeur)
                {
                    Console.WriteLine(comands[i]);

                }
            }
            
        }
         

            static void TrieNomAffiche(List<Client> clients)
        {

            List<Client> annexe = clients;
            annexe.Sort((x, y) => x.myCompare(y));
            annexe.ForEach(a => Console.WriteLine(a));
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();

        }



        static void VilleAffiche(List<Client> clients, string ville)
        {
            List<Client> annexe = clients.FindAll(a => a.Ville == ville);
            annexe.ForEach((a) => Console.WriteLine(a));
            Console.WriteLine();
            Console.WriteLine();
            Console.WriteLine();
        }



        static void MoyPrixCommande(List<Commande> comands, List<Chauffeur> chauff, int[,] graph, int source, int arrivee, List<Ville> villes)
        {
            double a = 0;
            foreach (Commande b in comands)
            {
                a += PrixCommande2(comands, b, chauff, graph, villes);

            }
            Console.WriteLine("La moyenne de prix de toutes les commandes est " + (double)(a / comands.Count()));
        }

        static void ListeCommandeClient(List<Commande> comands,Client client)
        {

            List<Commande> liste = comands.FindAll(x => x.Client == client);
            Console.WriteLine("Voici la suite des commandes de " + client.Nom + " " + client.Prenom);
            liste.ForEach(a => Console.WriteLine(a));
        }
        
        
        
        static void NbLivChauffeur(List<Commande> commandes,List<Chauffeur> chauff)
        {

            Console.WriteLine("Veuillez entrer le nom et prenom du chauffeur demandé separés d'un espace");
            string a=Console.ReadLine();
 
            int s = 0;
            commandes.FindAll(x => x.Chauffeur == a);
            Console.WriteLine(commandes.Count());
        }
        static void AdPrixtot(List<Commande> commandes, Client a,List<Chauffeur> chauffeurs, int[,] graph,List<Ville> villes)
        {
            double s = 0;

            foreach (Commande commande in commandes)
            {
                if (commande.Client == a)
                {
                    s += PrixCommande(commandes,commande,chauffeurs, graph,villes);
                }
            }
            a.Sommeachat = s;
        }


        static void AffichagePeriodeTemps(List<Commande> comand,DateTime T1,DateTime T2)
        {
            List<Commande> annexe=new List<Commande> { };
            if(T1<T2)
            {
                foreach(Commande b in comand)
                {
                    if(b.Datelivraison>=T1 && b.Datelivraison<=T2)
                    {
                        annexe.Add(b);
                    }
                }
            }
            if(T2<T1)
            {
                foreach (Commande b in comand)
                {
                    if (b.Datelivraison <= T1 && b.Datelivraison >= T2)
                    {
                        annexe.Add(b);
                    }
                }
            }
            Console.WriteLine("Voici les commandes entre" + T1 + " et " + T2);
            annexe.ForEach(a => Console.WriteLine(a));

        }
        static double MoyenneCompteClient(List<Commande> commandes,List<Client> clients, Client a, List<Chauffeur> chauffeurs, int[,] graph, List<Ville> villes)
        {
            int h = 0;
            double f = 0;
            double k = 0;
            for(int i=0;i<clients.Count(); i++)
            {
                f += AdPrixtot2(commandes,clients[i],chauffeurs,graph,villes);
                h = h + 1;
            }
            k = (f / h);
            return k;
        }

        static double  AdPrixtot2(List<Commande> commandes, Client a, List<Chauffeur> chauffeurs, int[,] graph, List<Ville> villes)
        {
            double s = 0;

            foreach (Commande commande in commandes)
            {
                if (commande.Client == a)
                {
                    

                    s += PrixCommande2(commandes, commande, chauffeurs, graph, villes);
                }
            }
            return s;
        }
        static void AfficheTriePrix(List<Commande> commandes, List<Client> clients, List<Chauffeur> chauffeurs, int[,] graph, List<Ville> villes)
        {
            
            foreach(Client c in clients)
            {
                c.Sommeachat = AdPrixtot2(commandes, c, chauffeurs, graph, villes);
            }
         
            clients.Sort((x, y) => y.Sommeachat.CompareTo(x.Sommeachat));


            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("listes des clients classee par ordre decroissant de somme total des achats effectue dans l'entreprise ");
            foreach (Client z in clients)
            {
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine(z);
                Console.WriteLine();
                Console.WriteLine();
            }
        }

        static double PrixCommande(List<Commande> comands,Commande com, List<Chauffeur> chauff, int[,] graph,List<Ville> villes)
        {
            Chauffeur z = chauff.Find(x => x.Nom + " " + x.Prenom == com.Chauffeur);
            


            int dist1 = DistanceChemin(graph, 0, com.LivraisonAB, graph.GetLength(0)) ;
            Console.WriteLine("Le prix de la commande "+comands.IndexOf(com)+" est " +z.TaxeH() * dist1*0.1);
            return z.TaxeH() * dist1 * 0.1;

        }
        static double PrixCommande2(List<Commande> comands, Commande com, List<Chauffeur> chauff, int[,] graph, List<Ville> villes)
        {
            Chauffeur z = chauff.Find(x => x.Nom + " " + x.Prenom == com.Chauffeur);
            

            int dist1 = DistanceChemin(graph, 0, com.LivraisonAB, graph.GetLength(0));
            return dist1 * 0.1;

        }


        static void ChoixChauffeurDispo(List<Chauffeur> chauffeurs)
        {
            List<Chauffeur> resul = chauffeurs.FindAll(x => x.Disponible == true);
            resul.ForEach(a => Console.Write(" " + a.Nom + " " + a.Prenom + "  "));
        }

        #region Ajouter commande

        static void AjouterCommande(List<Commande> comands, List<Client> clients, List<Chauffeur> chauffeurs, List<Vehicule> vehicules)
        {
            Console.WriteLine("Veuillez entre le nombre de commande a inserer dans le fichier commande");
            int p = Convert.ToInt32(Console.ReadLine());
            for (int ii = 0; ii < p; ii++)
            {
                int m = ii + 1;
                Console.WriteLine("Veuillez entrer la ss du client " + m);
                string a = Console.ReadLine();
                Client l2 = clients.Find(x => x.Ss == a);
                if (l2 == null)
                {
                    Console.WriteLine("Le client demandé n'est pas dans le dossier client veuillez l'ajouter");

                    AjouterClient(clients);
                    AjouterCommande(comands, clients, chauffeurs, vehicules);
                }
                else
                {
                    Console.WriteLine("veuillez entrer l'arrivée de la commande " + m);
                    int gg = Convert.ToInt32( Console.ReadLine());



                    Console.WriteLine("veuillez choisir un chauffeur du disponible parmis la liste suivante: " + m);
                    Console.WriteLine();
                    ChoixChauffeurDispo(chauffeurs);
                    string j6 = Console.ReadLine();


                    Console.WriteLine();
                    
                    Console.WriteLine("veuillez entrer l'annee de la date de livraison du client " + m);
                    int d2 = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("veuillez entrer le mois de la date de livraison du client " + m);
                    int e2 = Convert.ToInt32(Console.ReadLine());

                    Console.WriteLine("veuillez entrer le jour de la date de livraison du client " + m);
                    int f2 = Convert.ToInt32(Console.ReadLine());
                    DateTime dateliv = new DateTime(d2, e2, f2);

                    Console.WriteLine("veuillez choisir le vehicule du chauffeur pour la commande  " + m);
                    Console.Write("Camionnette,Poids Lourd ou Voiture");
                    string m6 = Console.ReadLine();
                    if(m6=="Voiture")
                    {
                        Console.WriteLine("Precisez le nombre de passager");
                        m6 =m6+" pour transporter " +Convert.ToInt32(Console.ReadLine())+" personnes";


                    }
                    if(m6=="Camionnette")
                    {
                        Console.WriteLine("Precisez l'usage");
                        m6=m6+" pour "+Console.ReadLine();
                    }
                    if (m6 == "Poids Lourd")
                    {
                        Console.WriteLine("Precisez le type de marchandise transporté");
                        Console.Write("Liquide,Sableux ou Perrisable");
                        string m7 = Console.ReadLine();
                        if(m7=="Liquide")
                        {
                            m6 = "Camion-Citerne";
                        }
                        if(m7=="Sableux")
                        {
                            m6 = "Camion benne";
                        }
                        if(m7=="Perrisable")
                        {
                            m6 = "Camion frigorifique";
                        }
                    }

                    
                    comands.Add(new Commande(l2, gg, m6, j6, dateliv));

                    try
                    {
                        //Pass the filepath and filename to the StreamWriter Constructor
                        StreamWriter sw = new StreamWriter("/Users/engenouadje/Desktop/Bureau/Projets Scolaires/MonProjet/Data/Commande.csv");
                        //Write a line of text

                        comands.ForEach(a => sw.WriteLine(a));
                        //Write a second line of text

                        //Close the file
                        sw.Close();
                    }
                    catch (Exception e)
                    {
                        Console.WriteLine("Exception: " + e.Message);
                    }
                    finally
                    {
                        Console.WriteLine("Executing finally block.");
                    }
                    Console.WriteLine();
                    Console.WriteLine();
                    Console.WriteLine(" la liste des clients est mis a jour ");
                    Console.WriteLine();

                    Console.WriteLine();
                    Console.WriteLine();

                }
            }
        }
        #endregion

        #region Modifier commande

        static void ModifierCommande(Commande comand, List<Client> clients, List<Chauffeur> chauffeurs, List<Vehicule> vehicules,List<Commande> comands)
        {
            Console.WriteLine("Veuillez entre le nombre de commande a modifier dans le fichier commande");
            int p = Convert.ToInt32(Console.ReadLine());
            for (int ii = 0; ii < p; ii++)
            {
                    Console.WriteLine("Modification " + ii + 1 + "\n");
                    Console.WriteLine();
                    int m = ii + 1;


                Console.WriteLine("veuillez entrer l'arrivée de la commande " + m);
                int gg = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("veuillez choisir le vehicule du chauffeur pour la commande  " + m);
                Console.Write("Camionnette,Poids Lourd ou Voiture");
                string m6 = Console.ReadLine();
                if (m6 == "Voiture")
                {
                    Console.WriteLine("Precisez le nombre de passager");
                    m6 = m6 + " pour transporter " + Convert.ToInt32(Console.ReadLine()) + " personnes";


                }
                if (m6 == "Camionnette")
                {
                    Console.WriteLine("Precisez l'usage");
                    m6 = m6 + " pour " + Console.ReadLine();
                }
                if (m6 == "Poids Lourd")
                {
                    Console.WriteLine("Precisez le type de marchandise transporté");
                    Console.Write("Liquide,Sableux ou Perrisable");
                    string m7 = Console.ReadLine();
                    if (m7 == "Liquide")
                    {
                        m6 = "Camion-Citerne";
                    }
                    if (m7 == "Sableux")
                    {
                        m6 = "Camion benne";
                    }
                    if (m7 == "Perrisable")
                    {
                        m6 = "Camion frigorifique";
                    }
                }



                Console.WriteLine("veuillez entrer l'annee de la date de livraison du client " + m);
                int d2 = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("veuillez entrer le mois de la date de livraison du client " + m);
                int e2 = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("veuillez entrer le jour de la date de livraison du client " + m);
                int f2 = Convert.ToInt32(Console.ReadLine());
                DateTime dateliv = new DateTime(d2, e2, f2);
                
                Console.WriteLine("veuillez choisir un chauffeur du disponible parmis la liste suivante: " + m);
                Console.WriteLine();
                ChoixChauffeurDispo(chauffeurs);
                string j6 = Console.ReadLine();

                comand = new Commande(comand.Client, gg, m6, j6, dateliv);

                try
                {
                    //Pass the filepath and filename to the StreamWriter Constructor
                    StreamWriter sw = new StreamWriter("/Users/engenouadje/Desktop/Bureau/Projets Scolaires/MonProjet/Data/Client.csv");
                    //Write a line of text

                    comands.ForEach(a => sw.WriteLine(a));
                    //Write a second line of text

                    //Close the file
                    sw.Close();
                }
                catch (Exception e)
                {
                    Console.WriteLine("Exception: " + e.Message);
                }
                finally
                {
                    Console.WriteLine("Executing finally block.");
                }
                Console.WriteLine();
                Console.WriteLine();
                Console.WriteLine(" la liste des clients est mis a jour ");
                Console.WriteLine();

                Console.WriteLine();
                Console.WriteLine();

                Console.WriteLine();
                Console.WriteLine();

            }
        }
        
        #endregion



        #region Dijskra
        private static int MinimumDistance2(int[] distance)
        {
            int min = int.MaxValue;
            int minIndex = 0;

            for(int i=0; i<distance.Length;i++)
            {
                if (distance[i] <= min && distance[i]!=null)
                {
                    min = distance[i];
                    minIndex = i;
                }
            }

            return minIndex;
        }
        private static int MinimumDistance(int[] distance, bool[] shortestPathTreeSet, int verticesCount)
        {
            int min = int.MaxValue;
            int minIndex = 0;

            for (int v = 0; v < verticesCount; ++v)
            {
                if (shortestPathTreeSet[v] == false && distance[v] <= min)
                {
                    min = distance[v];
                    minIndex = v;
                }
            }

            return minIndex;
        }

        private static void Print(int[] distance, int verticesCount)
        {
            Console.WriteLine("Vertex    Distance from source");

            for (int i = 0; i < verticesCount; ++i)
                Console.WriteLine("{0}\t  {1}", i, distance[i]);
        }

        public static void Dijkstra(int[,] graph, int source, int verticesCount)
        {
            int[] distance = new int[verticesCount];
            bool[] shortestPathTreeSet = new bool[verticesCount];

            for (int i = 0; i < verticesCount; ++i)
            {
                distance[i] = int.MaxValue;
                shortestPathTreeSet[i] = false;
            }

            distance[source] = 0;

            int[] tabstock = new int[] { };
            for (int count = 0; count < verticesCount - 1; ++count)
            {
                int u = MinimumDistance(distance, shortestPathTreeSet, verticesCount);
                shortestPathTreeSet[u] = true;

                for (int v = 0; v < verticesCount; ++v)
                    if (!shortestPathTreeSet[v] && Convert.ToBoolean(graph[u, v]) && distance[u] != int.MaxValue && distance[u] + graph[u, v] < distance[v])
                    { distance[v] = distance[u] + graph[u, v]; 
                    }
                         
            }

            Print(distance, verticesCount);
        }
        public static int DistanceChemin(int[,] graph, int source, int arrivee, int verticesCount)
        {
            int[] distance = new int[verticesCount];
            bool[] shortestPathTreeSet = new bool[verticesCount];

            for (int i = 0; i < verticesCount; ++i)
            {
                distance[i] = int.MaxValue;
                shortestPathTreeSet[i] = false;
            }

            distance[source] = 0;

            int[] tabstock = new int[] { };
            for (int count = 0; count < verticesCount - 1; ++count)
            {
                int u = MinimumDistance(distance, shortestPathTreeSet, verticesCount);
                shortestPathTreeSet[u] = true;

                for (int v = 0; v < verticesCount; ++v)
                    if (!shortestPathTreeSet[v] && Convert.ToBoolean(graph[u, v]) && distance[u] != int.MaxValue && distance[u] + graph[u, v] < distance[v])
                    {
                        distance[v] = distance[u] + graph[u, v];
                    }

            }

            return distance[arrivee];
            
        }



        private static void Print2(List<int> chemin, List<Ville> villes,int source,int arrivee)
        {
            Console.WriteLine("Parcours pour aller à "+villes[arrivee].Nom+" en partant de " + villes[source].Nom);
            Console.WriteLine();
            foreach(int i in chemin)
            { 
                Console.WriteLine(" ↓ \n{0} ", villes[i].Nom);
            }
        }

        public static void CheminCommande(int[,] graph, int source, int arrivee, int verticesCount, List<Ville> villes)
        {
            
            bool[] shortestPathTreeSet = new bool[verticesCount];
            
            
            for (int i = 0; i < verticesCount; ++i)
            {
                
                shortestPathTreeSet[i] = false;
            }
          


            int current = source;
            List<int> chcourt = new List<int> {source};
            while (!chcourt.Contains(arrivee))
            {
                
                int[] tabstock = new int[verticesCount];
                for (int i = 0; i < verticesCount; ++i)
                {

                    tabstock[i] = int.MaxValue;
                }
                
                for (int v = 0; v < verticesCount; ++v)
                {
                    

                    if (!shortestPathTreeSet[v] && Convert.ToBoolean(graph[current, v]))
                    {
                        
                        tabstock[v]=DistanceChemin(graph, v, arrivee, verticesCount);
                        shortestPathTreeSet[v] = true;
                    }
                    
                }
                current = MinimumDistance2(tabstock);
                chcourt.Add(current);


                

            }
            Print2(chcourt, villes, source, arrivee);
            
        }










        #endregion

        static void TrieNom(List<Client> clients)

        {
            Console.WriteLine(" liste des clients en ordre alphabetique ");
            Console.WriteLine();

            clients.Sort((x, y) => (x.Nom + x.Prenom).CompareTo(y.Nom + y.Prenom));
            clients.ForEach(aa => Console.WriteLine(aa));
        }


        static void AfficheClientville(List<Client> clients)
        {
            
            Console.WriteLine("Veuillez entrer le nom de la ville que vous recherchez :");
            Console.WriteLine();
            string jj = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine();
            List<Client> listerecherche = clients.FindAll(x => x.Ville == jj);
            foreach (Client z in listerecherche)
            {
                Console.WriteLine(z);
                Console.WriteLine();
            }
        }
        

        #region Gestion fichier CSV


static readonly string cheminCSV = "/Users/engenouadje/Desktop/Bureau/Projets Scolaires/MonProjet/Data/Client.csv";


static List<Client> ChargerClients()
{
    List<Client> clients = new List<Client>();
    
    
    Directory.CreateDirectory(Path.GetDirectoryName(cheminCSV));
    
    
    if (!File.Exists(cheminCSV))
    {
        Console.WriteLine("Aucun fichier client trouvé. Démarrage avec une liste vide.");
        return clients;
    }
    
    try
    {
        using (StreamReader sr = new StreamReader(cheminCSV))
        {
            string ligne;
            while ((ligne = sr.ReadLine()) != null)
            {
                
                string[] donnees = ligne.Split(';');
                
                if (donnees.Length >= 8)
                {
                    string ss = donnees[0];
                    string nom = donnees[1];
                    string prenom = donnees[2];
                    DateTime dateNaissance = DateTime.Parse(donnees[3]);
                    string adresse = donnees[4];
                    string email = donnees[5];
                    string tel = donnees[6];
                    string ville = donnees[7];
                    double sommeAchat = donnees.Length > 8 ? double.Parse(donnees[8]) : 0;
                    
                    clients.Add(new Client(ss, nom, prenom, dateNaissance, adresse, email, tel, ville, sommeAchat));
                }
            }
        }
        Console.WriteLine($"✓ {clients.Count} clients chargés depuis le fichier.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erreur lors du chargement : {ex.Message}");
    }
    
    return clients;
}


static void SauvegarderClients(List<Client> clients)
{
    try
    {
        // Créer le dossier s'il n'existe pas
        Directory.CreateDirectory(Path.GetDirectoryName(cheminCSV));
        
        using (StreamWriter sw = new StreamWriter(cheminCSV, false)) 
        {
            foreach (Client client in clients)
            {
                sw.WriteLine(client.ToCSV()); 
            }
        }
        Console.WriteLine($"✓ {clients.Count} clients sauvegardés dans le fichier.");
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Erreur lors de la sauvegarde : {ex.Message}");
    }
}

#endregion

    static void Main(string[] args)
        {


            #region base de donnee(client)


            Client c1 = new Client("0976", "Martin", "okdz", new DateTime(2002, 09, 24), "76 rue particuliere", "okdz@gmail.com", "0937352725", "Nancy");

            Client c2 = new Client("9776", "Paul", "Sylvain", new DateTime(2002, 09, 24), "76 rue particuliere", "okdz@gmail.com", "0937352725", "Nancy");

            Client c3 = new Client("02935383", "ludovic", "papi", new DateTime(2002, 09, 24), "76 rue canton", "ludovic@gmail.com", "0937352725", "Rouen");

            Client c4 = new Client("943892", "Leonard", "carlos", new DateTime(2002, 09, 24), "76 rue particuliere", "carlos@gmail.com", "0937352725", "Paris");

            Client c5 = new Client("296293'", "Fabrice", "Dupont", new DateTime(2002, 09, 24), "76 rue particuliere", "okdz@gmail.com", "0937352725", "Marseille");

            Client c6 = new Client("46382", "Arnold", "Tony", new DateTime(2002, 09, 24), "76 rue particuliere", "okdz@gmail.com", "0937352725", "Pau");

            Client c7 = new Client("24723", "Brice", "Jeff", new DateTime(2002, 09, 24), "76 rue particuliere", "okdz@gmail.com", "0937352725", "Paris");

            Client c8 = new Client("23529", "Pogba", "Giroud", new DateTime(2002, 09, 24), "76 rue particuliere", "okdz@gmail.com", "0937352725", "Toulon");


            List<Client> clients = new List<Client>() { c1, c2, c3, c4, c5, c6, c7, c8 };

            try
            {
                //Pass the filepath and filename to the StreamWriter Constructor
                StreamWriter sw = new StreamWriter("/Users/engenouadje/Desktop/Bureau/Projets Scolaires/MonProjet/Data/Client.csv");
                //Write a line of text
                clients.ForEach(a => sw.WriteLine(a));
                //Write a second line of text

                //Close the file
                sw.Close();
            }
            catch (Exception y)
            {
                Console.WriteLine("Exception: " + y.Message);
            }
            finally
            {
                Console.WriteLine("Executing finally block.");
            }



            #endregion


            #region base de donnee (commande)



            List<Vehicule> vehicules = new List<Vehicule>() { };
            Voiture v1 = new Voiture(3, "dzzd");

            Ville Lyon = new Ville("Lyon");
            Ville Paris = new Ville("Paris");
            Ville Angers = new Ville("Angers");
            Ville Rouen = new Ville("Rouen");
            Ville LaRochelle = new Ville("La Rochelle");
            Ville Bordeaux = new Ville("Bordeaux");
            Ville Biarritz = new Ville("Biarritz");
            Ville Toulouse = new Ville("Toulouse");
            Ville Pau = new Ville("Pau");
            Ville Montpellier = new Ville("Montpellier");
            Ville Nimes = new Ville("Nimes");
            Ville Marseille = new Ville("Marseille");
            Ville Avignon = new Ville("Avignon");
            Ville Monaco = new Ville("Monaco");
            Ville Toulon = new Ville("Toulon");


            List<Ville> villes = new List<Ville> { Lyon, Paris, Angers, Rouen, LaRochelle, Bordeaux, Biarritz, Toulouse, Pau, Montpellier, Nimes, Marseille, Avignon, Monaco, Toulon };




            List<Commande> comands = new List<Commande>() { };
            Commande dd1 = new Commande(c1, 1, "v1", "conducteur1", new DateTime(2018, 06, 29)); //Lyon, Paris, Angers, Rouen, LaRochelle, Bordeaux, Biarritz, Toulouse, Pau, Montpellier, Nimes, Marseille, Avignon, Monaco, Toulon
            Commande dd2 = new Commande(c1, 2, "v1", "conducteur1", new DateTime(2018, 11, 29));
            Commande dd3 = new Commande(c2, 3, "v1", "conducteur2", new DateTime(2018, 09, 29));
            Commande dd4 = new Commande(c3, 4, "v1", "conducteur2", new DateTime(2018, 11, 05));
            Commande dd5 = new Commande(c2, 5, "v1", "conducteur1", new DateTime(2018, 11, 29));
            Commande dd6 = new Commande(c3, 6, "v1", "conducteur3", new DateTime(2018, 11, 30));
            Commande dd7 = new Commande(c3, 7, "v1", "conducteur1", new DateTime(2019, 11, 25));
            Commande dd8 = new Commande(c3, 8, "v1", "conducteur2", new DateTime(2021, 03, 29));
            Commande dd9 = new Commande(c3, 9, "v1", "conducteur3", new DateTime(2021, 03, 15));
            Commande dd10 = new Commande(c3, 10, "v1", "conducteur3", new DateTime(2021, 04, 07));
            comands = new List<Commande>() { dd1, dd2, dd3, dd4, dd4, dd5, dd6, dd7, dd8, dd9, dd10 };
            Console.WriteLine();

            Console.WriteLine();
            Console.WriteLine();




            Chauffeur conducteur1 = new Chauffeur("0987", "Lejeune", "Patrick", new DateTime(1994, 11, 24), "5 rue de la fansanderie", "patrick@gmail.fr", "0965272537", new DateTime(2014, 11, 29), "Chauffeur", 1200, true);
            Chauffeur conducteur2 = new Chauffeur("0945", "camile", "jule", new DateTime(1990, 05, 22), " 6 avenue luca", "camile@gmail.com", "45635654", new DateTime(2017, 06, 22), "Chauffeur", 1100, false);
            Chauffeur conducteur3 = new Chauffeur("876043", "Lewis", " capadi", new DateTime(1980, 03, 08), "10 avenue du 8 mai 1945 courbevoie", "lewis@gmail.com", "0675432187", new DateTime(2018, 01, 17), "Chauffeur", 1300, true);
            List<Chauffeur> chauffeurs = new List<Chauffeur>() { conducteur1, conducteur2, conducteur3 };

            int[,] graphT = {
    { 0, 295, 0, 0, 0, 0, 0, 0, 0 ,0,0,0,0,0,0},
    { 295, 0, 191, 105, 0, 0, 0, 0, 0 ,0,0,0,0,0,0},
    { 0, 191, 0, 0, 140, 0, 0, 0, 0 ,0,0,0,0,0,0},
    { 0, 105, 0, 0, 0, 0, 0, 0, 0,0,0,0,0,0,0 },
    { 0, 0, 140, 0, 0, 98, 0, 0, 0 ,0,0,0,0,0,0},
    { 0, 0, 0, 0, 98, 0, 107, 0, 0 ,0,0,0,0,0,0},
    { 0, 0, 0, 0, 0, 107, 0, 159, 0 ,0,0,0,0,0,0},
    { 0, 0, 0, 0, 0, 0, 159, 0, 101 ,0,146,0,0,0,0},
    { 0, 0, 0, 0, 0, 0, 0, 101, 0 ,0,0,0,0,0,0},
    { 0, 0, 0, 0, 0, 0, 0, 0, 0 ,0,35,0,0,0,0},
    { 0, 0, 0, 0, 0, 0, 0, 146, 0 ,35,0,73,0,0,0},
    { 0, 0, 0, 0, 0, 0, 0, 0, 0 ,0,73,0,60,123,0},
    { 0, 0, 0, 0, 0, 0, 0, 0, 0 ,0,0,60,0,0,0},
    { 0, 0, 0, 0, 0, 0, 0, 0, 0 ,0,0,123,0,0,95},
    { 0, 0, 0, 0, 0, 0, 0, 0, 0 ,0,0,0,0,95,0}
     };
            int[,] graphD = {
    { 0, 464, 0, 0, 0, 0, 0, 0, 0 ,0,0,0,0,0,0},
    { 464, 0, 294, 133, 0, 0, 0, 0, 0 ,0,0,0,0,0,0},
    { 0, 294, 0, 0, 187, 0, 0, 0, 0 ,0,0,0,0,0,0},
    { 0, 133, 0, 0, 0, 0, 0, 0, 0,0,0,0,0,0,0 },
    { 0, 0, 187, 0, 0, 183, 0, 0, 0 ,0,0,0,0,0,0},
    { 0, 0, 0, 0, 183, 0, 202, 0, 0 ,0,0,0,0,0,0},
    { 0, 0, 0, 0, 0, 202, 0, 309, 0 ,0,0,0,0,0,0},
    { 0, 0, 0, 0, 0, 0, 309, 0, 193 ,0,289,0,0,0,0},
    { 0, 0, 0, 0, 0, 0, 0, 193, 0 ,0,0,0,0,0,0},
    { 0, 0, 0, 0, 0, 0, 0, 0, 0 ,0,52,0,0,0,0},
    { 0, 0, 0, 0, 0, 0, 0, 289, 0 ,52,0,126,0,0,0},
    { 0, 0, 0, 0, 0, 0, 0, 0, 0 ,0,126,0,99,224,0},
    { 0, 0, 0, 0, 0, 0, 0, 0, 0 ,0,0,99,0,0,0},
    { 0, 0, 0, 0, 0, 0, 0, 0, 0 ,0,0,224,0,0,169},
    { 0, 0, 0, 0, 0, 0, 0, 0, 0 ,0,0,0,0,169,0}
     };

            #endregion




            #region base de donnee(organigramme)
            Employe Dco2 = new Employe("Comptable", "Mme Gautier");
            Employe Dco1 = new Employe("Comptable", "Mme Fournier", Dco2);
            Employe CG = new Employe("Controleur de Gestion", "Mr Gropsous");
            Employe Dco = new Employe("Direction Comptable", "Mr Piscou", CG, Dco1);
            Employe CON = new Employe("Contrat", "Mme ToutleMonde");
            Employe FOR = new Employe("Formation", "Mme Couleur", CON);
            Employe CH5 = new Employe("Chauffeur", "Mme Romou");
            Employe CH4 = new Employe("Chauffeur", "Mme Rome", CH5);
            Employe CH3 = new Employe("Chauffeur", "Mme Roma");
            Employe CH2 = new Employe("Chauffeur", "Mme Romi", CH3);
            Employe CH1 = new Employe("Chauffeur", "Mr Romu", CH2);
            Employe CE2 = new Employe("Chef d'equipe 2", "Mr Prince", null, CH4);
            Employe CE1 = new Employe("Chef d'equipe 1", "Mr Royal", CE2, CH1);
            Employe C2 = new Employe("Commercial", "Mme Fermi");
            Employe C1 = new Employe("Commercial", "Mr Forge", C2);
            Employe DF = new Employe("Diecteur Financier", "Mr Gripsous", null, Dco);
            Employe DH = new Employe("Directrice des RH", "Mme Joyeuses", DF, FOR);
            Employe DO = new Employe("Directeur des operations", "Mr Fetard", DH, CE1);
            Employe DC = new Employe("Directrice commerciale", "Mme Fiesta", DO, C1);


            Employe Krg = new Employe("Directeur General", "Mr Dupont\n", null, DC);
            List<Employe> employes = new List<Employe>() { DC, DO, DH, DF, C1, C2, CE1, CE2, CH1, CH2, CH3, CH4, CH5, FOR, CON, Dco, CG, Dco1, Dco2 };
            Transconnect transconnect = new Transconnect(Krg);
            // Console.WriteLine(" l'organigramme de l'entreprise Transconnect est :");


            #endregion


            Console.WriteLine("Debut du Main : " + DateTime.Now);


            #region Module Client


            // AjouterClient(clients);
            // Console.WriteLine();
            // Console.WriteLine("La nouvelles liste de clients est la suivante :");
            // Console.WriteLine();
            // Console.WriteLine();


            // foreach (Client z in clients)
            // {
            //     Console.WriteLine(z);
            //     Console.WriteLine();
            //     Console.WriteLine();
            // }



            //EjecterClient(clients);
            //Console.WriteLine();
            //Console.WriteLine("La nouvelles liste de clients es la suivantes ");
            //Console.WriteLine();


            // foreach (Client z in clients)
            // {
            //    Console.WriteLine(z);
            //    Console.WriteLine();
            //    Console.WriteLine();
            // }

            //ModifierClient(clients);
            //Console.WriteLine();
            //Console.WriteLine("La nouvelles liste de clients est la suivante ");
            //Console.WriteLine();
            //foreach (Client z in clients)
            //{
            //    Console.WriteLine(z);
            //    Console.WriteLine();
            //    Console.WriteLine();
            //}

            //TrieNom(clients);

            //Console.WriteLine("La liste des clients est la suivante ");
            //Console.WriteLine();
            //foreach (Client z in clients)
            //{
            //    Console.WriteLine(z);
            //    Console.WriteLine();
            //    Console.WriteLine();
            //}

            //Console.WriteLine();
            //Console.WriteLine();
            // Console.WriteLine("Liste des clients par ville :\n");
            // AfficheClientville(clients);
            // Console.WriteLine();
            // Console.WriteLine();

            // AfficheTriePrix(comands, clients, chauffeurs, graphD, villes);




            #endregion



            //                TriePrix(comands, clients,chauffeurs);

            //                Console.WriteLine();
            //                Console.WriteLine();
            //                Console.WriteLine("Liste des clients classé par ordre de prix");
            //                clients.ForEach(a => Console.WriteLine(a));



            #region Module Commande


            // Dijkstra(graphT, 0, 15);

            //Dijkstra(graphD, 0, 15);


            // CheminCommande(graphD, 1, 11, 15, villes);

            //AjouterCommande(comands, clients, chauffeurs, vehicules);

            #endregion



            #region Organigramme 
            // transconnect.Affichage(Krg);
            ////transconnect.Creerunemploye(employes,Krg);
            //transconnect.Effaceemmploye(employes, Krg);

            #endregion



            Console.WriteLine("press key to EXIT!!!!!");
            Console.ReadKey();

        }


    } 
}

