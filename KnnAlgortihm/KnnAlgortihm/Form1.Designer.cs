namespace KnnAlgortihm
{
    partial class Form1
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            this.ofd = new System.Windows.Forms.OpenFileDialog();
            this.loadData = new System.Windows.Forms.Button();
            this.confirm = new System.Windows.Forms.Button();
            this.attrBox = new System.Windows.Forms.RichTextBox();
            this.kBox = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // ofd
            // 
            this.ofd.FileName = "openFileDialog1";
            // 
            // loadData
            // 
            this.loadData.Location = new System.Drawing.Point(401, 12);
            this.loadData.Name = "loadData";
            this.loadData.Size = new System.Drawing.Size(150, 106);
            this.loadData.TabIndex = 0;
            this.loadData.Text = "Load Data";
            this.loadData.UseVisualStyleBackColor = true;
            this.loadData.Click += new System.EventHandler(this.loadData_Click);
            // 
            // confirm
            // 
            this.confirm.Location = new System.Drawing.Point(366, 164);
            this.confirm.Name = "confirm";
            this.confirm.Size = new System.Drawing.Size(219, 36);
            this.confirm.TabIndex = 2;
            this.confirm.Text = "Confirm";
            this.confirm.UseVisualStyleBackColor = true;
            this.confirm.Visible = false;
            this.confirm.Click += new System.EventHandler(this.confirm_Click);
            // 
            // attrBox
            // 
            this.attrBox.Location = new System.Drawing.Point(46, 164);
            this.attrBox.Name = "attrBox";
            this.attrBox.Size = new System.Drawing.Size(251, 36);
            this.attrBox.TabIndex = 3;
            this.attrBox.Text = "";
            this.attrBox.Visible = false;
            // 
            // kBox
            // 
            this.kBox.Location = new System.Drawing.Point(46, 246);
            this.kBox.Name = "kBox";
            this.kBox.Size = new System.Drawing.Size(251, 40);
            this.kBox.TabIndex = 4;
            this.kBox.Text = "";
            this.kBox.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(116, 110);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(103, 25);
            this.label1.TabIndex = 5;
            this.label1.Text = "Attributes";
            this.label1.Visible = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(151, 203);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 25);
            this.label2.TabIndex = 6;
            this.label2.Text = "K";
            this.label2.Visible = false;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(132, 289);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(82, 25);
            this.label3.TabIndex = 7;
            this.label3.Text = "Metrics";
            this.label3.Visible = false;
            // 
            // comboBox
            // 
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Location = new System.Drawing.Point(46, 331);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(251, 33);
            this.comboBox.TabIndex = 8;
            this.comboBox.Visible = false;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(907, 552);
            this.Controls.Add(this.comboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.kBox);
            this.Controls.Add(this.attrBox);
            this.Controls.Add(this.confirm);
            this.Controls.Add(this.loadData);
            this.Name = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.OpenFileDialog ofd;
        private System.Windows.Forms.Button loadData;
        private System.Windows.Forms.Button confirm;
        private System.Windows.Forms.RichTextBox attrBox;
        private System.Windows.Forms.RichTextBox kBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox comboBox;
    }
}

