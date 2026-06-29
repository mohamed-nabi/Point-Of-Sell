namespace NewPOS
{
    partial class frmTest
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
            this.ucListFindProduct1 = new NewPOS.User_Controlls.ucListFindProduct();
            this.SuspendLayout();
            // 
            // ucListFindProduct1
            // 
            this.ucListFindProduct1.Location = new System.Drawing.Point(142, 37);
            this.ucListFindProduct1.Name = "ucListFindProduct1";
            this.ucListFindProduct1.Size = new System.Drawing.Size(388, 238);
            this.ucListFindProduct1.TabIndex = 0;
            // 
            // frmTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ucListFindProduct1);
            this.Name = "frmTest";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.frmTest_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private User_Controlls.ucListFindProduct ucListFindProduct1;
    }
}