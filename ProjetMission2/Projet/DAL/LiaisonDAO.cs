using Connecte.Modele;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;

namespace Connecte.DAL
{
    public class LiaisonDAO
    {

        private static string provider = "localhost";
        private static string dataBase = "bd_sicily_lines";
        private static string uid = "root";
        private static string mdp = "";

        private static ConnexionSql sql;
        private static MySqlCommand com;


        public static List<Liaison> getLiaison(int SecId)
        {
            List<Liaison> ll = new List<Liaison>();

            try
            {
                sql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);
                sql.openConnection();

                com = sql.reqExec("SELECT * FROM liaison WHERE idSecteur = " + SecId );
                MySqlDataReader reader = com.ExecuteReader();

                Liaison l;

                while (reader.Read())
                {

                    int id = (int)reader.GetValue(0);

                    int idDepart = (int)reader.GetValue(2);

                    int idArrivee = (int)reader.GetValue(3);

                    String duree = (String)reader.GetValue(1);

                    int idSecteur = (int)reader.GetValue(4);

                    l = new Liaison(id, idDepart, idArrivee, duree, idSecteur);

                    ll.Add(l);
                }

                reader.Close();

                sql.closeConnection();

            }

            catch (Exception e)
            {

                throw (e);

            }

            return (ll);


        }

        // Mise à jour d'une liaison
        public static void updateLiaison(Liaison l)
        {

            try
            {


                sql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);


                sql.openConnection();


                com = sql.reqExec("UPDATE liaison set duree= '" + l.Duree + "' WHERE id_liaison = " + l.Id);


                int i = com.ExecuteNonQuery();



                sql.closeConnection();



            }

            catch (Exception emp)
            {

                throw (emp);
            }


        }


        // Insertion d'une liaison
        public static void insertLiaison(Liaison l)
        {

            try
            {


                sql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);


                sql.openConnection();


                com = sql.reqExec("INSERT INTO liaison(duree, port_depart, port_arrivee, idSecteur) VALUES('" + l.Duree + "'," + l.Depart + "," + l.Arrivee + "," + l.IdSecteur + ")");


                int i = com.ExecuteNonQuery();



                sql.closeConnection();


                
            }

            catch (Exception emp)
            {

                throw (emp);
            }


        }

    // Supprimer une liaison 
    public static void deleteLiaison(Liaison l)
        {

            try
            {


                sql = ConnexionSql.getInstance(provider, dataBase, uid, mdp);


                sql.openConnection();


                com = sql.reqExec("DELETE FROM liaison WHERE id_liaison = " + l.Id );


                int i = com.ExecuteNonQuery();



                sql.closeConnection();



            }

            catch (Exception emp)
            {

                throw (emp);
            }


        }


    }


}
