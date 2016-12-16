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
            this.components = new System.ComponentModel.Container();
            this.componentFocusPanel = new System.Windows.Forms.Panel();
            this.tlpButtons = new System.Windows.Forms.TableLayoutPanel();
            this.tlpGlobal = new System.Windows.Forms.TableLayoutPanel();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.tlpGlobal.SuspendLayout();
            this.SuspendLayout();
            // 
            // componentFocusPanel
            // 
            this.componentFocusPanel.BackColor = System.Drawing.SystemColors.ActiveBorder;
            this.componentFocusPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.componentFocusPanel.Location = new System.Drawing.Point(3, 3);
            this.componentFocusPanel.Name = "componentFocusPanel";
            this.componentFocusPanel.Size = new System.Drawing.Size(842, 627);
            this.componentFocusPanel.TabIndex = 0;
            // 
            // tlpButtons
            // 
            this.tlpButtons.ColumnCount = 1;
            this.tlpButtons.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tlpButtons.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tlpButtons.Location = new System.Drawing.Point(851, 3);
            this.tlpButtons.Name = "tlpButtons";
            this.tlpButtons.RowCount = 3;
            this.tlpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpButtons.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tlpButtons.Size = new System.Drawing.Size(358, 627);
            this.tlpButtons.TabIndex = 1;
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
            this.tlpGlobal.Size = new System.Drawing.Size(1212, 633);
            this.tlpGlobal.TabIndex = 2;
            // 
            // timer
            // 
            this.timer.Interval = 3000;
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // ExerciceFocus
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.tlpGlobal);
            this.Name = "ExerciceFocus";
            this.Size = new System.Drawing.Size(1212, 633);
            this.tlpGlobal.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel componentFocusPanel;
        private System.Windows.Forms.TableLayoutPanel tlpButtons;
        private System.Windows.Forms.TableLayoutPanel tlpGlobal;
        private System.Windows.Forms.Timer timer;
    }
}
