namespace PSC2013.ES.GUI.Simulation.Panels
{
    partial class SimulationDiseasePanel
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.GrpBox_Main = new System.Windows.Forms.GroupBox();
            this.Comp_Transferability = new PSC2013.ES.GUI.Components.IntComponent();
            this.Comp_SpreadingTime = new PSC2013.ES.GUI.Components.IntComponent();
            this.Comp_IdleTime = new PSC2013.ES.GUI.Components.IntComponent();
            this.Comp_IncubationPeriod = new PSC2013.ES.GUI.Components.IntComponent();
            this.Comp_DiseaseName = new PSC2013.ES.GUI.Components.TextComponent();
            this.Comp_HealingFactors = new PSC2013.ES.GUI.Components.FactorComponent();
            this.Comp_MortalityRates = new PSC2013.ES.GUI.Components.FactorComponent();
            this.Comp_ResistanceFactors = new PSC2013.ES.GUI.Components.FactorComponent();
            this.GrpBox_Main.SuspendLayout();
            this.SuspendLayout();
            // 
            // GrpBox_Main
            // 
            this.GrpBox_Main.BackColor = System.Drawing.SystemColors.Control;
            this.GrpBox_Main.Controls.Add(this.Comp_ResistanceFactors);
            this.GrpBox_Main.Controls.Add(this.Comp_MortalityRates);
            this.GrpBox_Main.Controls.Add(this.Comp_HealingFactors);
            this.GrpBox_Main.Controls.Add(this.Comp_Transferability);
            this.GrpBox_Main.Controls.Add(this.Comp_SpreadingTime);
            this.GrpBox_Main.Controls.Add(this.Comp_IdleTime);
            this.GrpBox_Main.Controls.Add(this.Comp_IncubationPeriod);
            this.GrpBox_Main.Controls.Add(this.Comp_DiseaseName);
            this.GrpBox_Main.Dock = System.Windows.Forms.DockStyle.Fill;
            this.GrpBox_Main.Location = new System.Drawing.Point(0, 0);
            this.GrpBox_Main.Name = "GrpBox_Main";
            this.GrpBox_Main.Size = new System.Drawing.Size(273, 445);
            this.GrpBox_Main.TabIndex = 0;
            this.GrpBox_Main.TabStop = false;
            this.GrpBox_Main.Text = "Disease";
            // 
            // Comp_Transferability
            // 
            this.Comp_Transferability.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Comp_Transferability.BackColor = System.Drawing.Color.Transparent;
            this.Comp_Transferability.ComponentTag = PSC2013.ES.GUI.Components.EComponentTag.Transferability;
            this.Comp_Transferability.LabelText = "Transferability:";
            this.Comp_Transferability.Location = new System.Drawing.Point(6, 139);
            this.Comp_Transferability.Name = "Comp_Transferability";
            this.Comp_Transferability.Padding = new System.Windows.Forms.Padding(2);
            this.Comp_Transferability.Size = new System.Drawing.Size(261, 24);
            this.Comp_Transferability.TabIndex = 4;
            this.Comp_Transferability.ToolTip = "The chance for a subject to get infected.";
            // 
            // Comp_SpreadingTime
            // 
            this.Comp_SpreadingTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Comp_SpreadingTime.BackColor = System.Drawing.Color.Transparent;
            this.Comp_SpreadingTime.ComponentTag = PSC2013.ES.GUI.Components.EComponentTag.SpreadingTime;
            this.Comp_SpreadingTime.LabelText = "Spreading time:";
            this.Comp_SpreadingTime.Location = new System.Drawing.Point(6, 109);
            this.Comp_SpreadingTime.Name = "Comp_SpreadingTime";
            this.Comp_SpreadingTime.Padding = new System.Windows.Forms.Padding(2);
            this.Comp_SpreadingTime.Size = new System.Drawing.Size(261, 24);
            this.Comp_SpreadingTime.TabIndex = 3;
            this.Comp_SpreadingTime.ToolTip = "The hours a subject is spreading the disease.";
            // 
            // Comp_IdleTime
            // 
            this.Comp_IdleTime.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Comp_IdleTime.BackColor = System.Drawing.Color.Transparent;
            this.Comp_IdleTime.ComponentTag = PSC2013.ES.GUI.Components.EComponentTag.IdleTime;
            this.Comp_IdleTime.LabelText = "Idle time:";
            this.Comp_IdleTime.Location = new System.Drawing.Point(6, 79);
            this.Comp_IdleTime.Name = "Comp_IdleTime";
            this.Comp_IdleTime.Padding = new System.Windows.Forms.Padding(2);
            this.Comp_IdleTime.Size = new System.Drawing.Size(261, 24);
            this.Comp_IdleTime.TabIndex = 2;
            this.Comp_IdleTime.ToolTip = "The hours until a subject spreads the disease after being infected.";
            // 
            // Comp_IncubationPeriod
            // 
            this.Comp_IncubationPeriod.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Comp_IncubationPeriod.BackColor = System.Drawing.Color.Transparent;
            this.Comp_IncubationPeriod.ComponentTag = PSC2013.ES.GUI.Components.EComponentTag.FemaleChild;
            this.Comp_IncubationPeriod.LabelText = "Incubation period:";
            this.Comp_IncubationPeriod.Location = new System.Drawing.Point(6, 49);
            this.Comp_IncubationPeriod.Name = "Comp_IncubationPeriod";
            this.Comp_IncubationPeriod.Padding = new System.Windows.Forms.Padding(2);
            this.Comp_IncubationPeriod.Size = new System.Drawing.Size(261, 24);
            this.Comp_IncubationPeriod.TabIndex = 1;
            this.Comp_IncubationPeriod.ToolTip = "The incubation time of the disease in hours.";
            // 
            // Comp_DiseaseName
            // 
            this.Comp_DiseaseName.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Comp_DiseaseName.BackColor = System.Drawing.Color.Transparent;
            this.Comp_DiseaseName.ComponentTag = PSC2013.ES.GUI.Components.EComponentTag.FemaleBaby;
            this.Comp_DiseaseName.LabelText = "Disease name:";
            this.Comp_DiseaseName.Location = new System.Drawing.Point(6, 19);
            this.Comp_DiseaseName.Name = "Comp_DiseaseName";
            this.Comp_DiseaseName.Padding = new System.Windows.Forms.Padding(2);
            this.Comp_DiseaseName.Size = new System.Drawing.Size(261, 24);
            this.Comp_DiseaseName.TabIndex = 0;
            this.Comp_DiseaseName.ToolTip = "The name of the disease.";
            // 
            // Comp_HealingFactors
            // 
            this.Comp_HealingFactors.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Comp_HealingFactors.BackColor = System.Drawing.Color.Transparent;
            this.Comp_HealingFactors.ComponentTag = PSC2013.ES.GUI.Components.EComponentTag.HealingFactors;
            this.Comp_HealingFactors.LabelText = "Healingfactors:";
            this.Comp_HealingFactors.Location = new System.Drawing.Point(6, 169);
            this.Comp_HealingFactors.Name = "Comp_HealingFactors";
            this.Comp_HealingFactors.Padding = new System.Windows.Forms.Padding(2);
            this.Comp_HealingFactors.Size = new System.Drawing.Size(261, 27);
            this.Comp_HealingFactors.TabIndex = 5;
            this.Comp_HealingFactors.ToolTip = "Specifies the chances for each agegroup being healed over time.";
            // 
            // Comp_MortalityRates
            // 
            this.Comp_MortalityRates.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Comp_MortalityRates.BackColor = System.Drawing.Color.Transparent;
            this.Comp_MortalityRates.ComponentTag = PSC2013.ES.GUI.Components.EComponentTag.MortalityFactors;
            this.Comp_MortalityRates.LabelText = "Mortalityrates:";
            this.Comp_MortalityRates.Location = new System.Drawing.Point(6, 202);
            this.Comp_MortalityRates.Name = "Comp_MortalityRates";
            this.Comp_MortalityRates.Padding = new System.Windows.Forms.Padding(2);
            this.Comp_MortalityRates.Size = new System.Drawing.Size(261, 27);
            this.Comp_MortalityRates.TabIndex = 6;
            this.Comp_MortalityRates.ToolTip = "Specifies the chances for each agegroup dieing as a result of the disease.";
            // 
            // Comp_ResistanceFactors
            // 
            this.Comp_ResistanceFactors.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.Comp_ResistanceFactors.BackColor = System.Drawing.Color.Transparent;
            this.Comp_ResistanceFactors.ComponentTag = PSC2013.ES.GUI.Components.EComponentTag.Resistance;
            this.Comp_ResistanceFactors.LabelText = "Resistancefactors";
            this.Comp_ResistanceFactors.Location = new System.Drawing.Point(6, 235);
            this.Comp_ResistanceFactors.Name = "Comp_ResistanceFactors";
            this.Comp_ResistanceFactors.Padding = new System.Windows.Forms.Padding(2);
            this.Comp_ResistanceFactors.Size = new System.Drawing.Size(261, 27);
            this.Comp_ResistanceFactors.TabIndex = 7;
            this.Comp_ResistanceFactors.ToolTip = "Specifies the chances for each agegroup not to be infected.";
            // 
            // SimulationDiseasePanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.GrpBox_Main);
            this.Name = "SimulationDiseasePanel";
            this.Size = new System.Drawing.Size(273, 445);
            this.GrpBox_Main.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox GrpBox_Main;
        private Components.TextComponent Comp_DiseaseName;
        private Components.IntComponent Comp_IdleTime;
        private Components.IntComponent Comp_IncubationPeriod;
        private Components.IntComponent Comp_SpreadingTime;
        private Components.IntComponent Comp_Transferability;
        private Components.FactorComponent Comp_HealingFactors;
        private Components.FactorComponent Comp_MortalityRates;
        private Components.FactorComponent Comp_ResistanceFactors;
    }
}
