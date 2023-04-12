using Connecte.DAL;
using Connecte.Modele;
using System;
using System.Collections.Generic;


namespace Connecte.Controleur
{
    public class Mgr
    {

        SecteurDAO lc = new SecteurDAO();

        List<Secteur> maListSecteur;

        LiaisonDAO ll = new LiaisonDAO();

        List<Liaison> maListLiaison;

        public Mgr()
        {

            maListSecteur = new List<Secteur>();

            maListLiaison = new List<Liaison>();

        }



        // Appel à la fonction qui récupère la liste des secteurs
        public List<Secteur> chargementSecteurBd()
        {

            maListSecteur = SecteurDAO.getSecteur();

            return (maListSecteur);
        }

        // Appel à la fonction qui recupère l'ID secteur
        public Secteur GetSecteurById(int SecId)
        {
            return lc.getSecteurById(SecId);
        }


        // Appel à la fonction qui met à jour une liaison
        public void updateLiaison(Liaison l)
        {

                LiaisonDAO.updateLiaison(l);

        }

        // Appel à la fonction qui insert une liaison
        public void insertLiaison(Liaison l)
        {
            LiaisonDAO.insertLiaison(l);
        }

        // Appel à la fonction qui supprime une liaison
        public void deleteLiaison(Liaison l)
        {
            LiaisonDAO.deleteLiaison(l);
        }

        // Appel à la fonction qui récupère la liste des liaisons
        public List<Liaison> chargementLiaisonBd(int SecId)
        {

            maListLiaison = LiaisonDAO.getLiaison(SecId);

            return (maListLiaison);
        }

    }
}
