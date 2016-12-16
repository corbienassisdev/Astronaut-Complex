namespace AstronautComplexBasicPack.ExerciceCalculus
{
    partial class ExerciceCalculus
    {
        /// <summary> 
        /// Variable nécessaire au concepteur.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Nettoyage des ressources utilisées.
        /// </summary>
        /// <param name="disposing">true si les ressources managées doivent être supprimées ; sinon, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Code généré par le Concepteur de composants

        /// <summary> 
        /// Méthode requise pour la prise en charge du concepteur - ne modifiez pas 
        /// le contenu de cette méthode avec l'éditeur de code.
        /// </summary>
        private void InitializeComponent()
        {
            this.labelTitle = new System.Windows.Forms.Label();
            this.tableLayoutPanelSelection = new System.Windows.Forms.TableLayoutPanel();
            this.buttonSelectionDivision = new System.Windows.Forms.Button();
            this.buttonSelectionMultiplication = new System.Windows.Forms.Button();
            this.buttonSelectionSubtraction = new System.Windows.Forms.Button();
            this.buttonSelectionAddition = new System.Windows.Forms.Button();
            this.tableLayoutPanelSelection.SuspendLayout();
            this.SuspendLayout();
            // 
            // labelTitle
            // 
            this.labelTitle.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelTitle.Location = new System.Drawing.Point(0, 0);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Padding = new System.Windows.Forms.Padding(20, 20, 0, 0);
            this.labelTitle.Size = new System.Drawing.Size(1212, 70);
            this.labelTitle.TabIndex = 2;
            this.labelTitle.Text = "labelTitle";
            // 
            // tableLayoutPanelSelection
            // 
            this.tableLayoutPanelSelection.ColumnCount = 1;
            this.tableLayoutPanelSelection.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanelSelection.Controls.Add(this.buttonSelectionDivision, 0, 3);
            this.tableLayoutPanelSelection.Controls.Add(this.buttonSelectionMultiplication, 0, 2);
            this.tableLayoutPanelSelection.Controls.Add(this.buttonSelectionSubtraction, 0, 1);
            this.tableLayoutPanelSelection.Controls.Add(this.buttonSelectionAddition, 0, 0);
            this.tableLayoutPanelSelection.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tableLayoutPanelSelection.Location = new System.Drawing.Point(0, 70);
            this.tableLayoutPanelSelection.Name = "tableLayoutPanelSelection";
            this.tableLayoutPanelSelection.Padding = new System.Windows.Forms.Padding(0, 0, 0, 70);
            this.tableLayoutPanelSelection.RowCount = 4;
            this.tableLayoutPanelSelection.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelSelection.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelSelection.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelSelection.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 25F));
            this.tableLayoutPanelSelection.Size = new System.Drawing.Size(1212, 646);
            this.tableLayoutPanelSelection.TabIndex = 3;
            // 
            // buttonSelectionDivision
            // 
            this.buttonSelectionDivision.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonSelectionDivision.Location = new System.Drawing.Point(456, 474);
            this.buttonSelectionDivision.Name = "buttonSelectionDivision";
            this.buttonSelectionDivision.Size = new System.Drawing.Size(300, 60);
            this.buttonSelectionDivision.TabIndex = 3;
            this.buttonSelectionDivision.Text = "Division";
            this.buttonSelectionDivision.UseVisualStyleBackColor = true;
            this.buttonSelectionDivision.Click += new System.EventHandler(this.buttonSelection_Click);
            // 
            // buttonSelectionMultiplication
            // 
            this.buttonSelectionMultiplication.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonSelectionMultiplication.Location = new System.Drawing.Point(456, 330);
            this.buttonSelectionMultiplication.Name = "buttonSelectionMultiplication";
            this.buttonSelectionMultiplication.Size = new System.Drawing.Size(300, 60);
            this.buttonSelectionMultiplication.TabIndex = 2;
            this.buttonSelectionMultiplication.Text = "Multiplication";
            this.buttonSelectionMultiplication.UseVisualStyleBackColor = true;
            this.buttonSelectionMultiplication.Click += new System.EventHandler(this.buttonSelection_Click);
            // 
            // buttonSelectionSubtraction
            // 
            this.buttonSelectionSubtraction.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonSelectionSubtraction.Location = new System.Drawing.Point(456, 186);
            this.buttonSelectionSubtraction.Name = "buttonSelectionSubtraction";
            this.buttonSelectionSubtraction.Size = new System.Drawing.Size(300, 60);
            this.buttonSelectionSubtraction.TabIndex = 1;
            this.buttonSelectionSubtraction.Text = "Soustraction";
            this.buttonSelectionSubtraction.UseVisualStyleBackColor = true;
            this.buttonSelectionSubtraction.Click += new System.EventHandler(this.buttonSelection_Click);
            // 
            // buttonSelectionAddition
            // 
            this.buttonSelectionAddition.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonSelectionAddition.Location = new System.Drawing.Point(456, 42);
            this.buttonSelectionAddition.Name = "buttonSelectionAddition";
            this.buttonSelectionAddition.Size = new System.Drawing.Size(300, 60);
            this.buttonSelectionAddition.TabIndex = 0;
            this.buttonSelectionAddition.Text = "Addition";
            this.buttonSelectionAddition.UseVisualStyleBackColor = true;
            this.buttonSelectionAddition.Click += new System.EventHandler(this.buttonSelection_Click);
            // 
            // ExerciceCalculus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tableLayoutPanelSelection);
            this.Controls.Add(this.labelTitle);
            this.Name = "ExerciceCalculus";
            this.Size = new System.Drawing.Size(1212, 716);
            this.tableLayoutPanelSelection.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        protected System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanelSelection;
        private System.Windows.Forms.Button buttonSelectionDivision;
        private System.Windows.Forms.Button buttonSelectionMultiplication;
        private System.Windows.Forms.Button buttonSelectionSubtraction;
        private System.Windows.Forms.Button buttonSelectionAddition;
    }
}
