namespace WinFormsReportingSample
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Text = "Form1";
            
            // 
            // generateReportButton
            // 
            this.generateReportButton = new System.Windows.Forms.Button();
            this.generateReportButton.Location = new System.Drawing.Point(20, 20);
            this.generateReportButton.Name = "generateReportButton";
            this.generateReportButton.Size = new System.Drawing.Size(150, 25);
            this.generateReportButton.TabIndex = 0;
            this.generateReportButton.Text = "Generate Report";
            this.generateReportButton.UseVisualStyleBackColor = true;
            // this.generateReportButton.Click += new System.EventHandler(this.generateReportButton_Click); // Event handler will be attached in Form1.cs

            this.Controls.Add(this.generateReportButton);
        }

        #endregion

        private System.Windows.Forms.Button generateReportButton;
    }
}
