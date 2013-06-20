namespace PSC2013.ES.GUI.Miscellaneous
{
    partial class TwoButtonStartContainer
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
            this.Btn_Simulation = new System.Windows.Forms.Button();
            this.Btn_Review = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Btn_Simulation
            // 
            this.Btn_Simulation.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Simulation.Dock = System.Windows.Forms.DockStyle.Top;
            this.Btn_Simulation.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Btn_Simulation.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Simulation.Location = new System.Drawing.Point(0, 0);
            this.Btn_Simulation.Name = "Btn_Simulation";
            this.Btn_Simulation.Size = new System.Drawing.Size(391, 128);
            this.Btn_Simulation.TabIndex = 0;
            this.Btn_Simulation.Text = "New Simulation";
            this.Btn_Simulation.UseVisualStyleBackColor = true;
            // 
            // Btn_Review
            // 
            this.Btn_Review.Cursor = System.Windows.Forms.Cursors.Hand;
            this.Btn_Review.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.Btn_Review.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.Btn_Review.Font = new System.Drawing.Font("Microsoft Sans Serif", 35F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Btn_Review.Location = new System.Drawing.Point(0, 134);
            this.Btn_Review.Name = "Btn_Review";
            this.Btn_Review.Size = new System.Drawing.Size(391, 143);
            this.Btn_Review.TabIndex = 1;
            this.Btn_Review.Text = "New Review";
            this.Btn_Review.UseVisualStyleBackColor = true;
            // 
            // TwoButtonStartContainer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.Btn_Review);
            this.Controls.Add(this.Btn_Simulation);
            this.Name = "TwoButtonStartContainer";
            this.Size = new System.Drawing.Size(391, 277);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button Btn_Simulation;
        private System.Windows.Forms.Button Btn_Review;
    }
}
