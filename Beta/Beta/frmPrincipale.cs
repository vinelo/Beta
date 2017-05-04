using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;
using System.Linq;

namespace Beta
{
    public partial class frmPrincipale : Form
    {
        private int[] _tableauCaracteresBannisAscii = { 1,2};
        
        private List<char> _listeCaracteresBannis;
        private int _indexSelectionne;
        private List<clsTravail> _listeTravaux;

        public frmPrincipale()
        {
            InitializeComponent();
            ListeTravaux = new List<clsTravail>();
            this.ListeCaracteresBannis = new List<char>();
            //Remplissage du tableau TableauCaractereBannis
            for (int i = 0; i < 31; i++)
            {
                this.ListeCaracteresBannis.Add((char)i);
            }
            this.ListeCaracteresBannis.Add('0');
            //_________________________________________

            CreerTravail("Vincent", "Vincent");
            MisAJourListeVue();
        }

        internal List<clsTravail> ListeTravaux
        {
            get
            {
                return _listeTravaux;
            }

            set
            {
                _listeTravaux = value;
            }
        }

        public int IndexSelectionne
        {
            get
            {
                return _indexSelectionne;
            }

            set
            {
                _indexSelectionne = value;
            }
        }

        public int[] TableauCaracteresBannisAscii
        {
            get
            {
                return _tableauCaracteresBannisAscii;
            }

            set
            {
                _tableauCaracteresBannisAscii = value;
            }
        }

        public List<char> ListeCaracteresBannis
        {
            get
            {
                return _listeCaracteresBannis;
            }

            set
            {
                _listeCaracteresBannis = value;
            }
        }


        /// <summary>
        /// Créer un nouveau travail et l'ajoute dans la liste
        /// </summary>
        /// <param name="paramTexte">Texte du travail</param>
        /// <param name="paramNom">Nom de l'élève</param>
        public void CreerTravail(string paramTexte, string paramNom)
        {
            paramTexte = this.FiltrerCaractere(paramTexte);
            clsTravail NouveauTravail = new clsTravail(paramTexte, paramNom);
            ListeTravaux.Add(NouveauTravail);
        }
        /// <summary>
        /// Mets à jours la liste coté vue
        /// </summary>
        public void MisAJourListeVue()
        {
            lsbListeTravaux.Items.Clear();
            foreach (clsTravail travail in this.ListeTravaux)
            {
                lsbListeTravaux.Items.Add(travail);
            }
        }
        /// <summary>
        /// Affiche le travail dans la page Travail
        /// </summary>
        /// <param name="index">index du travail que l'on veut afficher</param>
        private void SelectionnerTravail(int index)
        {
            IndexSelectionne = index;
            this.tbxExemple.Text = this.ListeTravaux[IndexSelectionne].TexteExemple;
            string TexteCopie = "";
            for (int i = 0; i < this.ListeTravaux[IndexSelectionne].Progression; i++)
            {
                TexteCopie += this.ListeTravaux[IndexSelectionne].TexteExemple[i];
            }
            this.tbxCopie.Text = TexteCopie;
            tbcPrincipale.SelectedIndex = 0;
        }
        /// <summary>
        /// Serialise la classe travail correspondant à l'index
        /// </summary>
        /// <param name="index">index du travail que l'on veut serialiser</param>
        /// <param name="paramChemin">Chemin ou l'on veut sauver son fichier</param>
        public void Serialiser(int index,string paramChemin)
        {
            string[] DonneeSerialisee = { ListeTravaux[index].NomEleve, ListeTravaux[index].TexteExemple, Convert.ToString(ListeTravaux[index].Progression) };
            FileStream stream = File.Create(paramChemin);
            var formatter = new BinaryFormatter();
            formatter.Serialize(stream, DonneeSerialisee);
            stream.Close();
        }
        /// <summary>
        /// Deserialise le fichier "Data.td" se trouvant à la racine de bin
        /// </summary>
        /// <param name="paramFichier">Fichier que l'on veut deserialiser</param>
        public void Deserialiser(string paramFichier)
        {
            var formatter = new BinaryFormatter();
            FileStream stream = File.OpenRead(paramFichier);
            string[] v = (string[])formatter.Deserialize(stream);
            string NomEleve = v[0];
            string Texte = v[1];
            int Progression = Convert.ToInt32(v[2]);
            AjouterTravail(Texte, NomEleve, Progression);

            MisAJourListeVue();
            stream.Close();
        }
        /// <summary>
        /// Ajoute un travail déjà existant
        /// </summary>
        /// <param name="paramTexte">Texte du travail existant</param>
        /// <param name="paramNom">Nom de l'élève</param>
        /// <param name="paramProgression">Progression du travail</param>
        public void AjouterTravail(string paramTexte, string paramNom, int paramProgression)
        {
            clsTravail TravailAjoute = new clsTravail(paramTexte, paramNom, paramProgression);
            ListeTravaux.Add(TravailAjoute);
        }
        /// <summary>
        /// Filtre les caractère du texte en paramètre
        /// </summary>
        /// <param name="paramTexte">Texte que l'on veut filtrer</param>
        /// <returns></returns>
        public string FiltrerCaractere(string paramTexte)
        {
            int[] TableauTexteEnAscii = paramTexte.Select(r => (int)r).ToArray();
            foreach (char c in this.ListeCaracteresBannis)
            {
                if(paramTexte.Contains(c) == true)
                {
                    paramTexte = paramTexte.Replace(c, ' ');
                }
            }
            return paramTexte;
        }

        private void tsiNouveau_Click(object sender, EventArgs e)
        {
            frmCreation Creation = new frmCreation();
            DialogResult DR = Creation.ShowDialog();
            if (DR == DialogResult.OK)
            {
                string Nom = Creation.retournerNom();
                string Texte = Creation.retournerTexte();
                this.CreerTravail(Texte, Nom);
                this.MisAJourListeVue();
            }
        }

        private void lsbListeTravaux_DrawItem(object sender, DrawItemEventArgs e)
        {
            // Draw the background of the ListBox control for each item.
            e.DrawBackground();
            Brush FontBrush = Brushes.Black;
            Brush BackgroundBrush = Brushes.Black;
            switch (e.Index % 2)
            {
                case 0:
                    BackgroundBrush = Brushes.WhiteSmoke;
                    break;
                case 1:
                    BackgroundBrush = Brushes.White;
                    break;
            }
            e.Graphics.FillRectangle(BackgroundBrush, e.Bounds);
            // Define the default color of the brush as black.


            // Determine the color of the brush to draw each item based 
            // on the index of the item to draw.


            // Draw the current item text based on the current Font 
            // and the custom brush settings.
            e.Graphics.DrawString(ListeTravaux[e.Index].NomEleve,
                e.Font, FontBrush, 0, e.Bounds.Y + 2);
            e.Graphics.DrawString(ListeTravaux[e.Index].TexteExemple,
               e.Font, FontBrush, 250, e.Bounds.Y + 2);
            // If the ListBox has focus, draw a focus rectangle around the selected item.
            e.DrawFocusRectangle();
        }

        private void lsbListeTravaux_DoubleClick(object sender, EventArgs e)
        {
            int index = this.lsbListeTravaux.SelectedIndex;
            this.SelectionnerTravail(index);
        }

        private void tbxCopie_KeyPress(object sender, KeyPressEventArgs e)
        {
            int progression = this.ListeTravaux[this.IndexSelectionne].Progression;
            if (e.KeyChar != this.ListeTravaux[this.IndexSelectionne].TexteExemple[progression])
            {
                e.Handled = true;
            }
            else
            {
                this.ListeTravaux[this.IndexSelectionne].Progression += 1;
            }

            if (this.ListeTravaux[this.IndexSelectionne].Progression == this.ListeTravaux[this.IndexSelectionne].TotalCaractere)
            {
                MessageBox.Show("Félicitation vous avez fini ! ");
            }
        }

        private void btnSerialiser_Click(object sender, EventArgs e)
        {
            
            if (sfdSauvegarder.ShowDialog() == DialogResult.OK)
            {
                string sourceFile = sfdSauvegarder.FileName;
                Serialiser(IndexSelectionne, sourceFile);
            }
            
        }

        private void btnDeserialiser_Click(object sender, EventArgs e)
        {
            //Deserialiser();
        }

        private void tsiOuvrir_Click(object sender, EventArgs e)
        {
            string sourceFile;
            if (ofdDeserialisation.ShowDialog() == DialogResult.OK)
            {
                sourceFile = ofdDeserialisation.FileName;
                Deserialiser(sourceFile);
            }
            
        }
    }
}
