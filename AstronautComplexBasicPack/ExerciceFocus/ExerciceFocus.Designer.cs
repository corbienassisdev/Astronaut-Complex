namespace AstronautComplexBasicPack.ExerciceFocus
{
    partial class ExerciceFocus
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
            this.componentFocusPanel = new System.Windows.Forms.Panel();
            this.tlpButtons = new System.Windows.Forms.TableLayoutPanel();
            this.buttonSameColor = new System.Windows.Forms.Button();
            this.buttonSameDotNumber = new System.Windows.Forms.Button();
            this.buttonOther = new System.Windows.Forms.Button();
            this.tlpGlobal = new System.Windows.Forms.TableLayoutPanel();
            this.tlpButtons.SuspendLayout();
            this.tlpGlobal.SuspendLayout();
            this.SuspendLayout();
            // 
            // componentFocusPanel
            // 
            this.componentFocusPanel.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.componentFocusPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.componentFocusPanel.Location = new System.Drawing.Point(3, 3);
            this.componentFocusPanel.Name = "componentFocusPanel";
            this.componentFocusPanel.Size = new System.Drawing.Size(817, 710);
            this.componentFocusPanel.TabIndex = 0;
            // 
            // tlpButtons
            // 
            this.tlpButtons.ColumnCount = 1;
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpButtons.Controls.Add(this.buttonSameColor, 0, 0);
            this.tlpButtons.Controls.Add(this.buttonSameDotNumber, 0, 1);
            this.tlpButtons.Controls.Add(this.buttonOther, 0, 2);
            this.tlpButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpButtons.Location = new System.Drawing.Point(826, 3);
            this.tlpButtons.Name = "tlpButtons";
            this.tlpButtons.RowCount = 3;
            this.tlpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpButtons.Size = new System.Drawing.Size(347, 710);
            this.tlpButtons.TabIndex = 1;
            // 
            // buttonSameColor
            // 
            this.buttonSameColor.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonSameColor.Location = new System.Drawing.Point(118, 98);
            this.buttonSameColor.Name = "buttonSameColor";
            this.buttonSameColor.Size = new System.Drawing.Size(110, 40);
            this.buttonSameColor.TabIndex = 0;
            this.buttonSameColor.Text = "Bouton 1";
            this.buttonSameColor.UseVisualStyleBackColor = true;
            this.buttonSameColor.Click += new System.EventHandler(this.buttonSameColor_Click);
            // 
            // buttonSameDotNumber
            // 
            this.buttonSameDotNumber.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonSameDotNumber.Location = new System.Drawing.Point(118, 334);
            this.buttonSameDotNumber.Name = "buttonSameDotNumber";
            this.buttonSameDotNumber.Size = new System.Drawing.Size(110, 40);
            this.buttonSameDotNumber.TabIndex = 1;
            this.buttonSameDotNumber.Text = "Bouton 2";
            this.buttonSameDotNumber.UseVisualStyleBackColor = true;
            this.buttonSameDotNumber.Click += new System.EventHandler(this.buttonSameDotNumber_Click);
            // 
            // buttonOther
            // 
            this.buttonOther.Anchor = System.Windows.Forms.AnchorStyles.None;
            this.buttonOther.Location = new System.Drawing.Point(118, 571);
            this.buttonOther.Name = "buttonOther";
            this.buttonOther.Size = new System.Drawing.Size(110, 40);
            this.buttonOther.TabIndex = 2;
            this.buttonOther.Text = "Bouton 3";
            this.buttonOther.UseVisualStyleBackColor = true;
            this.buttonOther.Click += new System.EventHandler(this.buttonOther_Click);
            // 
            // tlpGlobal
            // 
            this.tlpGlobal.ColumnCount = 2;
            this.tlpGlobal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 70F));
            this.tlpGlobal.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 30F));
            this.tlpGlobal.Controls.Add(this.componentFocusPanel, 0, 0);
            this.tlpGlobal.Controls.Add(this.tlpButtons, 1, 0);
            this.tlpGlobal.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpGlobal.Location = new System.Drawing.Point(0, 0);
            this.tlpGlobal.Name = "tlpGlobal";
            this.tlpGlobal.RowCount = 1;
            this.tlpGlobal.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpGlobal.Size = new System.Drawing.Size(1176, 716);
            this.tlpGlobal.TabIndex = 2;
            // 
            // ExerciceFocus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpGlobal);
            this.Name = "ExerciceFocus";
            this.Size = new System.Drawing.Size(1176, 716);
            this.tlpButtons.ResumeLayout(false);
            this.tlpGlobal.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel componentFocusPanel;
        private System.Windows.Forms.TableLayoutPanel tlpButtons;
        private System.Windows.Forms.Button buttonSameColor;
        private System.Windows.Forms.Button buttonSameDotNumber;
        private System.Windows.Forms.Button buttonOther;
        private System.Windows.Forms.TableLayoutPanel tlpGlobal;
    }
}
