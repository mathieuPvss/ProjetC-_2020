using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace projet_C
{
    class sous_titres
    {
        public string indice;
        public string time_debut;
        public string time_fin;
        public string texte;


        public sous_titres(string numero, string temp_debut, string temp_fin, string textes)
        {
            indice = numero;
            time_debut = temp_debut;
            time_fin = temp_fin;
            texte = textes;

        }
    }
}
