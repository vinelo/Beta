using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;
using System.Collections;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;
using System.IO;

namespace Beta
{
    public partial class frmPrincipale : Form
    {
        private int _indexSelectionne;
        private List<clsTravail> _listeTravaux;

        public frmPrincipale()
        {
            InitializeComponent();
            ListeTravaux = new List<clsTravail>();
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


        /// <summary>
        /// Créer un nouveau travail et l'ajoute dans la liste
        /// </summary>
        /// <param name="paramTexte">Texte du travail</param>
        /// <param name="paramNom">Nom de l'élève</param>
        public void CreerTravail(string paramTexte, string paramNom)
        {
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
        public void Serialiser(int index)
        {
            string[] DonneeSerialisee = { ListeTravaux[index].NomEleve, ListeTravaux[index].TexteExemple, Convert.ToString(ListeTravaux[index].Progression) };
            FileStream stream = File.Create("Data.td");
            var formatter = new BinaryFormatter();
            formatter.Serialize(stream, DonneeSerialisee);
            stream.Close();
        }
        public void Deserialiser()
        {
            var formatter = new BinaryFormatter();
            FileStream stream = File.OpenRead("Data.td");
            string[] v = (string[])formatter.Deserialize(stream);
            string NomEleve = v[0];
            string Texte = v[1];
            int Progression = Convert.ToInt32(v[2]);
            AjouterTravail(Texte, NomEleve, Progression);

            MisAJourListeVue();
            stream.Close();
        }
        public void AjouterTravail(string paramTexte, string paramNom, int paramProgression)
        {
            clsTravail TravailAjoute = new clsTravail(paramTexte, paramNom, paramProgression);
            ListeTravaux.Add(TravailAjoute);
        }
        //public void Serialiser(int index)
        //{
        //    Hashtable zer = new Hashtable();
        //    zer.Add("jeff", "Lebo");
        //    // To serialize the hashtable and its key/value pairs,  
        //    // you must first open a stream for writing. 
        //    // In this case, use a file stream.
        //    FileStream fs = new FileStream("DataFile.dat", FileMode.Create);

        //    // Construct a BinaryFormatter and use it to serialize the data to the stream.
        //    BinaryFormatter formatter = new BinaryFormatter();
        //    try
        //    {
        //        formatter.Serialize(fs, zer);
        //    }
        //    catch (SerializationException e)
        //    {
        //        Console.WriteLine("Failed to serialize. Reason: " + e.Message);
        //        throw;
        //    }
        //    finally
        //    {
        //        fs.Close();
        //    }
        //}
        //public void Deserialise()
        //{
        //    // Declare the hashtable reference.
        //    Hashtable addresses = null;

        //    // Open the file containing the data that you want to deserialize.
        //    FileStream fs = new FileStream("DataFile.dat", FileMode.Open);
        //    try
        //    {
        //        BinaryFormatter formatter = new BinaryFormatter();

        //        // Deserialize the hashtable from the file and 
        //        // assign the reference to the local variable.
        //        addresses = (Hashtable)formatter.Deserialize(fs);
        //    }
        //    catch (SerializationException e)
        //    {
        //        Console.WriteLine("Failed to deserialize. Reason: " + e.Message);
        //        throw;
        //    }
        //    finally
        //    {
        //        fs.Close();
        //    }

        //    // To prove that the table deserialized correctly, 
        //    // display the key/value pairs.
        //    tbxCopie.Text = addresses[0]
        //    //addresses[0]
        //}


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
            Serialiser(IndexSelectionne);
        }

        private void btnDeserialiser_Click(object sender, EventArgs e)
        {
            Deserialiser();
        }
    }
}
