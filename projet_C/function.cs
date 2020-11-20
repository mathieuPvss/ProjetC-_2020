using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace projet_C
{
    class function
    {
        public List<string> liste_sous_titres()//on recupere la list avec tous les lignes du fichier .srt
        {
            string mydocpath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            using (StreamReader outputFile = new StreamReader(mydocpath + @"\travis.srt"))
            {
                string s;
                List<string> texte = new List<string>();
                int i = 0;
                while ((s = outputFile.ReadLine()) != null)
                {

                    texte.Add(s);
                    //Console.WriteLine(texte[i]);
                    i++;
                }
                return texte;
            }
        }

        public void str_to_object()
        {
            List<string> sous_titres = liste_sous_titres();
            List<sous_titres> sous_titres_obj;
            sous_titres_obj = new List<sous_titres>();
            int i = 0;
            while (i == 0 && sous_titres.Count != 1)
            {



                string indice = sous_titres[i];
                string timing = sous_titres[i + 1];
                //parcourir la chaine de caractere timing et garder que les 12 premiers caracteres 
                string timing_debut = timing.Remove(12, 17);
                string timing_fin = timing.Remove(0, 17);
                string texte = sous_titres[i + 2];
                


                if (String.IsNullOrEmpty(sous_titres[i + 3]))
                {
                    sous_titres_obj.Add(new sous_titres(indice, timing_debut, timing_fin, texte));
                    
                    sous_titres.RemoveAt(i);
                    sous_titres.RemoveAt(i);
                    sous_titres.RemoveAt(i);
                    sous_titres.RemoveAt(i);                 
                }
                else
                {
                    texte += sous_titres[i + 3];
                    sous_titres_obj.Add(new sous_titres(indice, timing_debut, timing_fin, texte));
                    sous_titres.RemoveAt(i);
                    sous_titres.RemoveAt(i);
                    sous_titres.RemoveAt(i);
                    sous_titres.RemoveAt(i);
                    sous_titres.RemoveAt(i);
                }


                if (sous_titres.Count == 0)
                {
                    
                    int g = 0;
                    while (g <= sous_titres_obj.Count)
                    {
                        Console.WriteLine(sous_titres_obj[g].texte);
                        int duré = delay(sous_titres_obj[g].time_debut, sous_titres_obj[g+1].time_debut);
                        
                        System.Threading.Thread.Sleep(duré);
                        Console.Clear();
                        g++;
                        if (g == sous_titres_obj.Count)
                        {
                            break;
                        }

                    }
                    
                }
                
            }
            
           
        }
        public int delay(string a, string b)
        {
            string heure_a = a.Remove(2, 10);//a garder
            string minute_a_1 = a.Remove(0, 3);
            string minute_a = minute_a_1.Remove(2,7);//a garder
            string seconde_a_1 = a.Remove(0, 6);
            string seconde_a = seconde_a_1.Remove(2, 4);//a garder
            string milli_a = a.Remove(0, 9);//a garder

            int NBheure_a = Int32.Parse(heure_a);
            int NBminute_a = Int32.Parse(minute_a);
            int NBseconde_a = Int32.Parse(seconde_a);
            int NBmilli_a = Int32.Parse(milli_a);

            int result_heure_a = NBheure_a * 60; //resultat en min
            int result_minute_a = (NBminute_a + result_heure_a) * 60;//resultat en seconde
            int result_seconde_a = (NBseconde_a + result_minute_a) * 1000;//resultat en milliseconde
            int result_milli_a = NBmilli_a + result_seconde_a; //resultat en milliseconde


            string heure_b = b.Remove(2, 10);//a garder
            string minute_b_1 = b.Remove(0, 3);
            string minute_b = minute_b_1.Remove(2, 7);//a garder
            string seconde_b_1 = b.Remove(0, 6);
            string seconde_b = seconde_b_1.Remove(2, 4);//a garder
            string milli_b = b.Remove(0, 9);//a garder

            int NBheure_b = Int32.Parse(heure_b);
            int NBminute_b = Int32.Parse(minute_b);
            int NBseconde_b = Int32.Parse(seconde_b);
            int NBmilli_b = Int32.Parse(milli_b);

            int result_heure_b = NBheure_b * 60; //resultat en min
            int result_minute_b = (NBminute_b + result_heure_b) * 60;//resultat en seconde
            int result_seconde_b = (NBseconde_b + result_minute_b) * 1000;//resultat en milliseconde
            int result_milli_b = NBmilli_b + result_seconde_b; //resultat en milliseconde

            int delay = result_milli_b - result_milli_a;
            return delay;
        }
        
    }
}
