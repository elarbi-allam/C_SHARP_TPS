using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace Gestion_Ecole
{
    public partial class Form1 : Form
    {
        // Instance de DAOEleve pour gérer les interactions avec la base de données
        private DAOEleve daoEleve;

        /// <summary>
        /// Constructeur de la fenêtre principale du formulaire.
        /// Initialise les composants et applique le style personnalisé.
        /// </summary>
        public Form1()
        {
            InitializeComponent();
            daoEleve = new DAOEleve();
            ApplyStyles(); // Applique les styles visuels
        }

        /// <summary>
        /// Événement appelé lors du chargement du formulaire.
        /// Charge les données des élèves dans le DataGridView.
        /// </summary>
        private void Form1_Load(object sender, EventArgs e)
        {
            RefreshDataGrid();
        }

        /// <summary>
        /// Applique un style visuel amélioré à l'interface utilisateur.
        /// </summary>
        private void ApplyStyles()
        {
            // Couleur de fond du formulaire
            this.BackColor = Color.FromArgb(245, 245, 255);

            // Style des labels
            Label[] labels = { label1, label2, label3, label4 };
            foreach (var lbl in labels)
            {
                lbl.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                lbl.ForeColor = Color.FromArgb(80, 80, 80);
            }

            // Style des champs de texte
            TextBox[] textBoxes = { t_nom, t_prenom, t_ville, t_specialite };
            foreach (var txt in textBoxes)
            {
                txt.Font = new Font("Segoe UI", 12, FontStyle.Regular);
                txt.ForeColor = Color.FromArgb(0, 0, 128);
                txt.BackColor = Color.FromArgb(240, 248, 255);
                txt.BorderStyle = BorderStyle.FixedSingle;
            }

            // Style des boutons
            Button[] buttons = { b_Ajouter, b_Update, b_Rechercher, delete };
            foreach (var btn in buttons)
            {
                btn.Font = new Font("Segoe UI", 12, FontStyle.Bold);
                btn.ForeColor = Color.White;
                btn.BackColor = Color.FromArgb(100, 149, 237); // Nouveau bleu
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.Cursor = Cursors.Hand;
            }

            delete.BackColor = Color.FromArgb(178, 34, 34); // Rouge revisité pour suppression
            b_Rechercher.BackColor = Color.FromArgb(60, 179, 113); // Vert revisité pour recherche

            // Style du DataGridView
            DataEleve.BackgroundColor = Color.FromArgb(255, 250, 240);
            DataEleve.GridColor = Color.FromArgb(200, 200, 200);
            DataEleve.DefaultCellStyle.BackColor = Color.FromArgb(250, 240, 230);
            DataEleve.DefaultCellStyle.ForeColor = Color.FromArgb(64, 64, 64);
            DataEleve.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(100, 149, 237);
            DataEleve.ColumnHeadersDefaultCellStyle.ForeColor = Color.FromArgb(255, 255, 255);
            DataEleve.EnableHeadersVisualStyles = false;
            DataEleve.Font = new Font("Segoe UI", 11);
            DataEleve.BorderStyle = BorderStyle.Fixed3D;
        }

        /// <summary>
        /// Rafraîchit les données du DataGridView en récupérant tous les élèves.
        /// </summary>
        private void RefreshDataGrid()
        {
            try
            {
                DataEleve.DataSource = daoEleve.findAll();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors du chargement des données : " + ex.Message);
            }
        }

        /// <summary>
        /// Ajoute un nouvel élève à la base de données.
        /// </summary>
        private void b_Ajouter_Click(object sender, EventArgs e)
        {
            try
            {
                Eleve newEleve = new Eleve(0, t_nom.Text, t_prenom.Text, t_ville.Text, t_specialite.Text);
                daoEleve.insert(newEleve);
                MessageBox.Show("Élève ajouté avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                RefreshDataGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de l'ajout de l'élève : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Met à jour les informations d'un élève sélectionné.
        /// </summary>
        private void b_Update_Click(object sender, EventArgs e)
        {
            if (DataEleve.SelectedRows.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner un élève à mettre à jour.", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DataGridViewRow selectedRow = DataEleve.SelectedRows[0];
                int studentId = Convert.ToInt32(selectedRow.Cells["id"].Value);

                // Conserve les valeurs existantes si les champs de texte sont vides
                Eleve updatedEleve = new Eleve(
                    studentId,
                    string.IsNullOrEmpty(t_nom.Text) ? selectedRow.Cells["Nom"].Value.ToString() : t_nom.Text,
                    string.IsNullOrEmpty(t_prenom.Text) ? selectedRow.Cells["Prenom"].Value.ToString() : t_prenom.Text,
                    string.IsNullOrEmpty(t_ville.Text) ? selectedRow.Cells["Ville"].Value.ToString() : t_ville.Text,
                    string.IsNullOrEmpty(t_specialite.Text) ? selectedRow.Cells["Specialite"].Value.ToString() : t_specialite.Text
                );

                int rowsAffected = daoEleve.update(updatedEleve);

                if (rowsAffected > 0)
                    MessageBox.Show("Élève mis à jour avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                else
                    MessageBox.Show("Échec de la mise à jour de l'élève.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);

                RefreshDataGrid();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la mise à jour : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Recherche les élèves en fonction des critères saisis.
        /// </summary>
        private void b_Rechercher_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(t_nom.Text) && string.IsNullOrWhiteSpace(t_prenom.Text) &&
                    string.IsNullOrWhiteSpace(t_ville.Text) && string.IsNullOrWhiteSpace(t_specialite.Text))
                {
                    RefreshDataGrid();
                }
                else
                {
                    Eleve searchEleve = new Eleve(0, t_nom.Text.Trim(), t_prenom.Text.Trim(), t_ville.Text.Trim(), t_specialite.Text.Trim());
                    DataEleve.DataSource = daoEleve.find(searchEleve);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la recherche : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        /// <summary>
        /// Supprime un élève sélectionné.
        /// </summary>
        private void b_Delete_Click(object sender, EventArgs e)
        {
            if (DataEleve.SelectedRows.Count == 0)
            {
                MessageBox.Show("Veuillez sélectionner un élève à supprimer.", "Avertissement", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                DataGridViewRow selectedRow = DataEleve.SelectedRows[0];
                int studentId = Convert.ToInt32(selectedRow.Cells["id"].Value);

                DialogResult confirmResult = MessageBox.Show(
                    "Êtes-vous sûr de vouloir supprimer cet élève ?",
                    "Confirmation de suppression",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Warning
                );

                if (confirmResult == DialogResult.Yes)
                {
                    int rowsAffected = daoEleve.delete(studentId);
                    if (rowsAffected > 0)
                        MessageBox.Show("Élève supprimé avec succès !", "Succès", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    else
                        MessageBox.Show("Échec de la suppression.", "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);

                    RefreshDataGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erreur lors de la suppression : " + ex.Message, "Erreur", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
