namespace PSC2013.ES.GUI
{
    partial class FactorContainerForm
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.MainPanel = new System.Windows.Forms.Panel();
            this.MainPanel_bottom = new System.Windows.Forms.GroupBox();
            this.MainPanel_male = new System.Windows.Forms.GroupBox();
            this.MainPanel_female = new System.Windows.Forms.GroupBox();
            this.lbl_male_baby = new System.Windows.Forms.Label();
            this.numField_male_baby = new System.Windows.Forms.NumericUpDown();
            this.numField_male_child = new System.Windows.Forms.NumericUpDown();
            this.lbl_male_child = new System.Windows.Forms.Label();
            this.numField_male_senior = new System.Windows.Forms.NumericUpDown();
            this.lbl_male_senior = new System.Windows.Forms.Label();
            this.numField_male_adult = new System.Windows.Forms.NumericUpDown();
            this.labl_male_adult = new System.Windows.Forms.Label();
            this.numField_female_senior = new System.Windows.Forms.NumericUpDown();
            this.lbl_female_senior = new System.Windows.Forms.Label();
            this.numField_female_adult = new System.Windows.Forms.NumericUpDown();
            this.lbl_female_adult = new System.Windows.Forms.Label();
            this.numField_female_child = new System.Windows.Forms.NumericUpDown();
            this.lbl_female_child = new System.Windows.Forms.Label();
            this.numField_female_baby = new System.Windows.Forms.NumericUpDown();
            this.lbl_female_baby = new System.Windows.Forms.Label();
            this.btn_confirm = new System.Windows.Forms.Button();
            this.btn_cancel = new System.Windows.Forms.Button();
            this.MainPanel.SuspendLayout();
            this.MainPanel_bottom.SuspendLayout();
            this.MainPanel_male.SuspendLayout();
            this.MainPanel_female.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numField_male_baby)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numField_male_child)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numField_male_senior)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numField_male_adult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numField_female_senior)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numField_female_adult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numField_female_child)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numField_female_baby)).BeginInit();
            this.SuspendLayout();
            // 
            // MainPanel
            // 
            this.MainPanel.Controls.Add(this.MainPanel_female);
            this.MainPanel.Controls.Add(this.MainPanel_male);
            this.MainPanel.Controls.Add(this.MainPanel_bottom);
            this.MainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.MainPanel.Location = new System.Drawing.Point(0, 0);
            this.MainPanel.Name = "MainPanel";
            this.MainPanel.Padding = new System.Windows.Forms.Padding(5);
            this.MainPanel.Size = new System.Drawing.Size(391, 197);
            this.MainPanel.TabIndex = 0;
            // 
            // MainPanel_bottom
            // 
            this.MainPanel_bottom.Controls.Add(this.btn_cancel);
            this.MainPanel_bottom.Controls.Add(this.btn_confirm);
            this.MainPanel_bottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.MainPanel_bottom.Location = new System.Drawing.Point(5, 142);
            this.MainPanel_bottom.Name = "MainPanel_bottom";
            this.MainPanel_bottom.Size = new System.Drawing.Size(381, 50);
            this.MainPanel_bottom.TabIndex = 0;
            this.MainPanel_bottom.TabStop = false;
            // 
            // MainPanel_male
            // 
            this.MainPanel_male.Controls.Add(this.numField_male_senior);
            this.MainPanel_male.Controls.Add(this.lbl_male_senior);
            this.MainPanel_male.Controls.Add(this.numField_male_adult);
            this.MainPanel_male.Controls.Add(this.labl_male_adult);
            this.MainPanel_male.Controls.Add(this.numField_male_child);
            this.MainPanel_male.Controls.Add(this.lbl_male_child);
            this.MainPanel_male.Controls.Add(this.numField_male_baby);
            this.MainPanel_male.Controls.Add(this.lbl_male_baby);
            this.MainPanel_male.Dock = System.Windows.Forms.DockStyle.Left;
            this.MainPanel_male.Location = new System.Drawing.Point(5, 5);
            this.MainPanel_male.Name = "MainPanel_male";
            this.MainPanel_male.Size = new System.Drawing.Size(190, 137);
            this.MainPanel_male.TabIndex = 1;
            this.MainPanel_male.TabStop = false;
            this.MainPanel_male.Text = "Male";
            // 
            // MainPanel_female
            // 
            this.MainPanel_female.Controls.Add(this.numField_female_senior);
            this.MainPanel_female.Controls.Add(this.lbl_female_senior);
            this.MainPanel_female.Controls.Add(this.lbl_female_baby);
            this.MainPanel_female.Controls.Add(this.numField_female_adult);
            this.MainPanel_female.Controls.Add(this.numField_female_baby);
            this.MainPanel_female.Controls.Add(this.lbl_female_adult);
            this.MainPanel_female.Controls.Add(this.lbl_female_child);
            this.MainPanel_female.Controls.Add(this.numField_female_child);
            this.MainPanel_female.Dock = System.Windows.Forms.DockStyle.Right;
            this.MainPanel_female.Location = new System.Drawing.Point(196, 5);
            this.MainPanel_female.Name = "MainPanel_female";
            this.MainPanel_female.Size = new System.Drawing.Size(190, 137);
            this.MainPanel_female.TabIndex = 2;
            this.MainPanel_female.TabStop = false;
            this.MainPanel_female.Text = "Female";
            // 
            // lbl_male_baby
            // 
            this.lbl_male_baby.AutoSize = true;
            this.lbl_male_baby.Location = new System.Drawing.Point(7, 25);
            this.lbl_male_baby.Name = "lbl_male_baby";
            this.lbl_male_baby.Size = new System.Drawing.Size(34, 13);
            this.lbl_male_baby.TabIndex = 1;
            this.lbl_male_baby.Text = "Baby:";
            // 
            // numField_male_baby
            // 
            this.numField_male_baby.Location = new System.Drawing.Point(84, 23);
            this.numField_male_baby.Maximum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            0});
            this.numField_male_baby.Name = "numField_male_baby";
            this.numField_male_baby.Size = new System.Drawing.Size(100, 20);
            this.numField_male_baby.TabIndex = 2;
            // 
            // numField_male_child
            // 
            this.numField_male_child.Location = new System.Drawing.Point(84, 49);
            this.numField_male_child.Maximum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            0});
            this.numField_male_child.Name = "numField_male_child";
            this.numField_male_child.Size = new System.Drawing.Size(100, 20);
            this.numField_male_child.TabIndex = 4;
            // 
            // lbl_male_child
            // 
            this.lbl_male_child.AutoSize = true;
            this.lbl_male_child.Location = new System.Drawing.Point(7, 51);
            this.lbl_male_child.Name = "lbl_male_child";
            this.lbl_male_child.Size = new System.Drawing.Size(33, 13);
            this.lbl_male_child.TabIndex = 3;
            this.lbl_male_child.Text = "Child:";
            // 
            // numField_male_senior
            // 
            this.numField_male_senior.Location = new System.Drawing.Point(84, 101);
            this.numField_male_senior.Maximum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            0});
            this.numField_male_senior.Name = "numField_male_senior";
            this.numField_male_senior.Size = new System.Drawing.Size(100, 20);
            this.numField_male_senior.TabIndex = 8;
            // 
            // lbl_male_senior
            // 
            this.lbl_male_senior.AutoSize = true;
            this.lbl_male_senior.Location = new System.Drawing.Point(7, 103);
            this.lbl_male_senior.Name = "lbl_male_senior";
            this.lbl_male_senior.Size = new System.Drawing.Size(40, 13);
            this.lbl_male_senior.TabIndex = 7;
            this.lbl_male_senior.Text = "Senior:";
            // 
            // numField_male_adult
            // 
            this.numField_male_adult.Location = new System.Drawing.Point(84, 75);
            this.numField_male_adult.Maximum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            0});
            this.numField_male_adult.Name = "numField_male_adult";
            this.numField_male_adult.Size = new System.Drawing.Size(100, 20);
            this.numField_male_adult.TabIndex = 6;
            // 
            // labl_male_adult
            // 
            this.labl_male_adult.AutoSize = true;
            this.labl_male_adult.Location = new System.Drawing.Point(7, 77);
            this.labl_male_adult.Name = "labl_male_adult";
            this.labl_male_adult.Size = new System.Drawing.Size(34, 13);
            this.labl_male_adult.TabIndex = 5;
            this.labl_male_adult.Text = "Adult:";
            // 
            // numField_female_senior
            // 
            this.numField_female_senior.Location = new System.Drawing.Point(83, 101);
            this.numField_female_senior.Maximum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            0});
            this.numField_female_senior.Name = "numField_female_senior";
            this.numField_female_senior.Size = new System.Drawing.Size(100, 20);
            this.numField_female_senior.TabIndex = 16;
            // 
            // lbl_female_senior
            // 
            this.lbl_female_senior.AutoSize = true;
            this.lbl_female_senior.Location = new System.Drawing.Point(6, 103);
            this.lbl_female_senior.Name = "lbl_female_senior";
            this.lbl_female_senior.Size = new System.Drawing.Size(40, 13);
            this.lbl_female_senior.TabIndex = 15;
            this.lbl_female_senior.Text = "Senior:";
            // 
            // numField_female_adult
            // 
            this.numField_female_adult.Location = new System.Drawing.Point(83, 75);
            this.numField_female_adult.Maximum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            0});
            this.numField_female_adult.Name = "numField_female_adult";
            this.numField_female_adult.Size = new System.Drawing.Size(100, 20);
            this.numField_female_adult.TabIndex = 14;
            // 
            // lbl_female_adult
            // 
            this.lbl_female_adult.AutoSize = true;
            this.lbl_female_adult.Location = new System.Drawing.Point(6, 77);
            this.lbl_female_adult.Name = "lbl_female_adult";
            this.lbl_female_adult.Size = new System.Drawing.Size(34, 13);
            this.lbl_female_adult.TabIndex = 13;
            this.lbl_female_adult.Text = "Adult:";
            // 
            // numField_female_child
            // 
            this.numField_female_child.Location = new System.Drawing.Point(83, 49);
            this.numField_female_child.Maximum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            0});
            this.numField_female_child.Name = "numField_female_child";
            this.numField_female_child.Size = new System.Drawing.Size(100, 20);
            this.numField_female_child.TabIndex = 12;
            // 
            // lbl_female_child
            // 
            this.lbl_female_child.AutoSize = true;
            this.lbl_female_child.Location = new System.Drawing.Point(6, 51);
            this.lbl_female_child.Name = "lbl_female_child";
            this.lbl_female_child.Size = new System.Drawing.Size(33, 13);
            this.lbl_female_child.TabIndex = 11;
            this.lbl_female_child.Text = "Child:";
            // 
            // numField_female_baby
            // 
            this.numField_female_baby.Location = new System.Drawing.Point(83, 23);
            this.numField_female_baby.Maximum = new decimal(new int[] {
            -2147483648,
            0,
            0,
            0});
            this.numField_female_baby.Name = "numField_female_baby";
            this.numField_female_baby.Size = new System.Drawing.Size(100, 20);
            this.numField_female_baby.TabIndex = 10;
            // 
            // lbl_female_baby
            // 
            this.lbl_female_baby.AutoSize = true;
            this.lbl_female_baby.Location = new System.Drawing.Point(6, 25);
            this.lbl_female_baby.Name = "lbl_female_baby";
            this.lbl_female_baby.Size = new System.Drawing.Size(34, 13);
            this.lbl_female_baby.TabIndex = 9;
            this.lbl_female_baby.Text = "Baby:";
            // 
            // btn_confirm
            // 
            this.btn_confirm.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.btn_confirm.Location = new System.Drawing.Point(200, 17);
            this.btn_confirm.Name = "btn_confirm";
            this.btn_confirm.Size = new System.Drawing.Size(174, 23);
            this.btn_confirm.TabIndex = 0;
            this.btn_confirm.Text = "Confirm";
            this.btn_confirm.UseVisualStyleBackColor = true;
            this.btn_confirm.Click += new System.EventHandler(this.btn_confirm_Click);
            // 
            // btn_cancel
            // 
            this.btn_cancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btn_cancel.Location = new System.Drawing.Point(10, 17);
            this.btn_cancel.Name = "btn_cancel";
            this.btn_cancel.Size = new System.Drawing.Size(174, 23);
            this.btn_cancel.TabIndex = 1;
            this.btn_cancel.Text = "Cancel";
            this.btn_cancel.UseVisualStyleBackColor = true;
            this.btn_cancel.Click += new System.EventHandler(this.btn_cancel_Click);
            // 
            // FactorContainerForm
            // 
            this.AcceptButton = this.btn_confirm;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btn_cancel;
            this.ClientSize = new System.Drawing.Size(391, 197);
            this.Controls.Add(this.MainPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FactorContainerForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "-Factor input";
            this.MainPanel.ResumeLayout(false);
            this.MainPanel_bottom.ResumeLayout(false);
            this.MainPanel_male.ResumeLayout(false);
            this.MainPanel_male.PerformLayout();
            this.MainPanel_female.ResumeLayout(false);
            this.MainPanel_female.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numField_male_baby)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numField_male_child)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numField_male_senior)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numField_male_adult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numField_female_senior)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numField_female_adult)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numField_female_child)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numField_female_baby)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel MainPanel;
        private System.Windows.Forms.GroupBox MainPanel_bottom;
        private System.Windows.Forms.GroupBox MainPanel_female;
        private System.Windows.Forms.GroupBox MainPanel_male;
        private System.Windows.Forms.Label lbl_male_baby;
        private System.Windows.Forms.NumericUpDown numField_male_baby;
        private System.Windows.Forms.NumericUpDown numField_male_child;
        private System.Windows.Forms.Label lbl_male_child;
        private System.Windows.Forms.NumericUpDown numField_male_senior;
        private System.Windows.Forms.Label lbl_male_senior;
        private System.Windows.Forms.NumericUpDown numField_male_adult;
        private System.Windows.Forms.Label labl_male_adult;
        private System.Windows.Forms.NumericUpDown numField_female_senior;
        private System.Windows.Forms.Label lbl_female_senior;
        private System.Windows.Forms.Label lbl_female_baby;
        private System.Windows.Forms.NumericUpDown numField_female_adult;
        private System.Windows.Forms.NumericUpDown numField_female_baby;
        private System.Windows.Forms.Label lbl_female_adult;
        private System.Windows.Forms.Label lbl_female_child;
        private System.Windows.Forms.NumericUpDown numField_female_child;
        private System.Windows.Forms.Button btn_cancel;
        private System.Windows.Forms.Button btn_confirm;

    }
}