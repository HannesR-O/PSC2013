namespace PSC2013.ES.GUI.Components
{
    partial class DiseaseComponent
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
            this.Btn_export = new System.Windows.Forms.Button();
            this.Btn_import = new System.Windows.Forms.Button();
            this.openDisFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.saveDisFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.SuspendLayout();
            // 
            // Btn_export
            // 
            this.Btn_export.Location = new System.Drawing.Point(3, 3);
            this.Btn_export.Name = "Btn_export";
            this.Btn_export.Size = new System.Drawing.Size(100, 23);
            this.Btn_export.TabIndex = 0;
            this.Btn_export.Text = "Export disease...";
            this.Btn_export.UseVisualStyleBackColor = true;
            // 
            // Btn_import
            // 
            this.Btn_import.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.Btn_import.Location = new System.Drawing.Point(183, 3);
            this.Btn_import.Name = "Btn_import";
            this.Btn_import.Size = new System.Drawing.Size(100, 23);
            this.Btn_import.TabIndex = 1;
            this.Btn_import.Text = "Import disease...";
            this.Btn_import.UseVisualStyleBackColor = true;
            // 
            // openDisFileDialog
            // 
            this.openDisFileDialog.Title = "Import disease (.dis)";
            // 
            // saveDisFileDialog
            // 
            this.saveDisFileDialog.Title = "Export disease (.dis)";
            // 
            // DiseaseComponent
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.Transparent;
            this.Controls.Add(this.Btn_import);
            this.Controls.Add(this.Btn_export);
            this.Name = "DiseaseComponent";
            this.Size = new System.Drawing.Size(286, 29);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Btn_export;
        private System.Windows.Forms.Button Btn_import;
        private System.Windows.Forms.OpenFileDialog openDisFileDialog;
        private System.Windows.Forms.SaveFileDialog saveDisFileDialog;
    }
}
