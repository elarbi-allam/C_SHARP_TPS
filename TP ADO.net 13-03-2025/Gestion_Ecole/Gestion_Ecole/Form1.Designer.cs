namespace Gestion_Ecole
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label4 = new System.Windows.Forms.Label();
            t_nom = new System.Windows.Forms.TextBox();
            t_prenom = new System.Windows.Forms.TextBox();
            t_ville = new System.Windows.Forms.TextBox();
            t_specialite = new System.Windows.Forms.TextBox();
            b_Ajouter = new System.Windows.Forms.Button();
            DataEleve = new System.Windows.Forms.DataGridView();
            b_Rechercher = new System.Windows.Forms.Button();
            b_Update = new System.Windows.Forms.Button();
            delete = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)DataEleve).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            label1.Location = new System.Drawing.Point(335, 66);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(94, 45);
            label1.TabIndex = 0;
            label1.Text = "Nom";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            label2.Location = new System.Drawing.Point(335, 140);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(138, 45);
            label2.TabIndex = 0;
            label2.Text = "Prénom";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            label3.Location = new System.Drawing.Point(335, 216);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(85, 45);
            label3.TabIndex = 0;
            label3.Text = "Ville";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            label4.Location = new System.Drawing.Point(335, 296);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(163, 45);
            label4.TabIndex = 0;
            label4.Text = "Spécialité";
            // 
            // t_nom
            // 
            t_nom.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            t_nom.Location = new System.Drawing.Point(584, 66);
            t_nom.Name = "t_nom";
            t_nom.Size = new System.Drawing.Size(615, 50);
            t_nom.TabIndex = 1;
            // 
            // t_prenom
            // 
            t_prenom.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            t_prenom.Location = new System.Drawing.Point(584, 140);
            t_prenom.Name = "t_prenom";
            t_prenom.Size = new System.Drawing.Size(615, 50);
            t_prenom.TabIndex = 2;
            // 
            // t_ville
            // 
            t_ville.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            t_ville.Location = new System.Drawing.Point(584, 216);
            t_ville.Name = "t_ville";
            t_ville.Size = new System.Drawing.Size(615, 50);
            t_ville.TabIndex = 3;
            // 
            // t_specialite
            // 
            t_specialite.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold);
            t_specialite.Location = new System.Drawing.Point(584, 296);
            t_specialite.Name = "t_specialite";
            t_specialite.Size = new System.Drawing.Size(615, 50);
            t_specialite.TabIndex = 4;
            // 
            // b_Ajouter
            // 
            b_Ajouter.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
            b_Ajouter.Location = new System.Drawing.Point(338, 435);
            b_Ajouter.Name = "b_Ajouter";
            b_Ajouter.Size = new System.Drawing.Size(188, 70);
            b_Ajouter.TabIndex = 5;
            b_Ajouter.Text = "Ajouter";
            b_Ajouter.UseVisualStyleBackColor = true;
            b_Ajouter.Click += b_Ajouter_Click;
            // 
            // DataEleve
            // 
            DataEleve.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DataEleve.GridColor = System.Drawing.SystemColors.WindowText;
            DataEleve.Location = new System.Drawing.Point(338, 589);
            DataEleve.Name = "DataEleve";
            DataEleve.RowHeadersWidth = 102;
            DataEleve.Size = new System.Drawing.Size(1114, 557);
            DataEleve.TabIndex = 6;
            // 
            // b_Rechercher
            // 
            b_Rechercher.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
            b_Rechercher.Location = new System.Drawing.Point(1185, 435);
            b_Rechercher.Name = "b_Rechercher";
            b_Rechercher.Size = new System.Drawing.Size(267, 70);
            b_Rechercher.TabIndex = 7;
            b_Rechercher.Text = "Rechercher";
            b_Rechercher.UseVisualStyleBackColor = true;
            b_Rechercher.Click += b_Rechercher_Click;
            // 
            // b_Update
            // 
            b_Update.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
            b_Update.Location = new System.Drawing.Point(619, 435);
            b_Update.Name = "b_Update";
            b_Update.Size = new System.Drawing.Size(188, 70);
            b_Update.TabIndex = 8;
            b_Update.Text = "Update";
            b_Update.UseVisualStyleBackColor = true;
            b_Update.Click += b_Update_Click;
            // 
            // delete
            // 
            delete.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)0));
            delete.Location = new System.Drawing.Point(903, 435);
            delete.Name = "delete";
            delete.Size = new System.Drawing.Size(188, 70);
            delete.TabIndex = 9;
            delete.Text = "Delete";
            delete.UseVisualStyleBackColor = true;
            delete.Click += b_Delete_Click;
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(2455, 1196);
            Controls.Add(delete);
            Controls.Add(b_Update);
            Controls.Add(b_Rechercher);
            Controls.Add(DataEleve);
            Controls.Add(b_Ajouter);
            Controls.Add(t_specialite);
            Controls.Add(t_ville);
            Controls.Add(t_prenom);
            Controls.Add(t_nom);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Margin = new System.Windows.Forms.Padding(2);
            Text = "Form1";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)DataEleve).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        private System.Windows.Forms.Button delete;

        private System.Windows.Forms.Button b_Update;

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox t_nom;
        private System.Windows.Forms.TextBox t_prenom;
        private System.Windows.Forms.TextBox t_ville;
        private System.Windows.Forms.TextBox t_specialite;
        private System.Windows.Forms.Button b_Ajouter;
        private System.Windows.Forms.DataGridView DataEleve;
        private System.Windows.Forms.Button b_Rechercher;
        
    }
}
