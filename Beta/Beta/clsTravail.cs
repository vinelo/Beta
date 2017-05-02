using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Beta
{
    class clsTravail
    {
        private string _texteExemple;
        private string _nomEleve;
        private int _totalCaractere;
        private int _progression;

        public string TexteExemple
        {
            get
            {
                return _texteExemple;
            }

            set
            {
                _texteExemple = value;
            }
        }

        public string NomEleve
        {
            get
            {
                return _nomEleve;
            }

            set
            {
                _nomEleve = value;
            }
        }

        public int TotalCaractere
        {
            get
            {
                return _totalCaractere;
            }

            set
            {
                _totalCaractere = value;
            }
        }

        public int Progression
        {
            get
            {
                return _progression;
            }

            set
            {
                _progression = value;
            }
        }
        public clsTravail() : this("Texte aléatoire n'est-ce pas ?", "Dupont") { }
        public clsTravail(string paramTexte, string paramNom)
        {
            this.TexteExemple = paramTexte;
            this.NomEleve = paramNom;
            this.Progression = 0;
            this.TotalCaractere = TexteExemple.Count();
        }
    }
}