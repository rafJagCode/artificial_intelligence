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
            this.attributesInfo = new System.Windows.Forms.Label();
            this.kInfo = new System.Windows.Forms.Label();
            this.metricsInfo = new System.Windows.Forms.Label();
            this.comboBox = new System.Windows.Forms.ComboBox();
            this.dataInfo = new System.Windows.Forms.Label();
            this.resultsTextBox = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.clearBtn = new System.Windows.Forms.Button();
            this.searchKtextBox = new System.Windows.Forms.RichTextBox();
            this.clearKbtn = new System.Windows.Forms.Button();
            this.searchBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.bgw = new System.ComponentModel.BackgroundWorker();
            this.resultLabel = new System.Windows.Forms.Label();
            this.progBar = new System.Windows.Forms.ProgressBar();
            this.pLabel = new System.Windows.Forms.Label();
            this.pBox = new System.Windows.Forms.RichTextBox();
            this.SuspendLayout();
            // 
            // ofd
            // 
            this.ofd.FileName = "openFileDialog1";
            // 
            // loadData
            // 
            this.loadData.Location = new System.Drawing.Point(27, 27);
            this.loadData.Name = "loadData";
            this.loadData.Size = new System.Drawing.Size(150, 36);
            this.loadData.TabIndex = 0;
            this.loadData.Text = "Load Data";
            this.loadData.UseVisualStyleBackColor = true;
            this.loadData.Click += new System.EventHandler(this.loadData_Click);
            // 
            // confirm
            // 
            this.confirm.Location = new System.Drawing.Point(531, 117);
            this.confirm.Name = "confirm";
            this.confirm.Size = new System.Drawing.Size(107, 36);
            this.confirm.TabIndex = 2;
            this.confirm.Text = "Confirm";
            this.confirm.UseVisualStyleBackColor = true;
            this.confirm.Click += new System.EventHandler(this.confirm_Click);
            // 
            // attrBox
            // 
            this.attrBox.AcceptsTab = true;
            this.attrBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.attrBox.Location = new System.Drawing.Point(237, 118);
            this.attrBox.Name = "attrBox";
            this.attrBox.Size = new System.Drawing.Size(251, 25);
            this.attrBox.TabIndex = 3;
            this.attrBox.Text = "";
            // 
            // kBox
            // 
            this.kBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.kBox.Location = new System.Drawing.Point(237, 195);
            this.kBox.Name = "kBox";
            this.kBox.Size = new System.Drawing.Size(251, 25);
            this.kBox.TabIndex = 4;
            this.kBox.Text = "";
            // 
            // attributesInfo
            // 
            this.attributesInfo.AutoSize = true;
            this.attributesInfo.Location = new System.Drawing.Point(22, 118);
            this.attributesInfo.Name = "attributesInfo";
            this.attributesInfo.Size = new System.Drawing.Size(103, 25);
            this.attributesInfo.TabIndex = 5;
            this.attributesInfo.Text = "Attributes";
            this.attributesInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // kInfo
            // 
            this.kInfo.AutoSize = true;
            this.kInfo.Location = new System.Drawing.Point(22, 195);
            this.kInfo.Name = "kInfo";
            this.kInfo.Size = new System.Drawing.Size(26, 25);
            this.kInfo.TabIndex = 6;
            this.kInfo.Text = "K";
            this.kInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // metricsInfo
            // 
            this.metricsInfo.AutoSize = true;
            this.metricsInfo.Location = new System.Drawing.Point(22, 270);
            this.metricsInfo.Name = "metricsInfo";
            this.metricsInfo.Size = new System.Drawing.Size(82, 25);
            this.metricsInfo.TabIndex = 7;
            this.metricsInfo.Text = "Metrics";
            this.metricsInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // comboBox
            // 
            this.comboBox.FormattingEnabled = true;
            this.comboBox.Location = new System.Drawing.Point(237, 270);
            this.comboBox.Name = "comboBox";
            this.comboBox.Size = new System.Drawing.Size(251, 33);
            this.comboBox.TabIndex = 8;
            // 
            // dataInfo
            // 
            this.dataInfo.AutoSize = true;
            this.dataInfo.Location = new System.Drawing.Point(232, 38);
            this.dataInfo.Name = "dataInfo";
            this.dataInfo.Size = new System.Drawing.Size(154, 25);
            this.dataInfo.TabIndex = 9;
            this.dataInfo.Text = "File not loaded";
            this.dataInfo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // resultsTextBox
            // 
            this.resultsTextBox.Location = new System.Drawing.Point(644, 88);
            this.resultsTextBox.Name = "resultsTextBox";
            this.resultsTextBox.Size = new System.Drawing.Size(251, 143);
            this.resultsTextBox.TabIndex = 10;
            this.resultsTextBox.Text = "";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(639, 36);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(115, 25);
            this.label1.TabIndex = 11;
            this.label1.Text = "RESULTS:";
            // 
            // clearBtn
            // 
            this.clearBtn.Location = new System.Drawing.Point(531, 168);
            this.clearBtn.Name = "clearBtn";
            this.clearBtn.Size = new System.Drawing.Size(107, 36);
            this.clearBtn.TabIndex = 12;
            this.clearBtn.Text = "Clear";
            this.clearBtn.UseVisualStyleBackColor = true;
            this.clearBtn.Click += new System.EventHandler(this.clearBtn_Click);
            // 
            // searchKtextBox
            // 
            this.searchKtextBox.Location = new System.Drawing.Point(644, 319);
            this.searchKtextBox.Name = "searchKtextBox";
            this.searchKtextBox.Size = new System.Drawing.Size(251, 143);
            this.searchKtextBox.TabIndex = 13;
            this.searchKtextBox.Text = "";
            // 
            // clearKbtn
            // 
            this.clearKbtn.Location = new System.Drawing.Point(531, 394);
            this.clearKbtn.Name = "clearKbtn";
            this.clearKbtn.Size = new System.Drawing.Size(107, 36);
            this.clearKbtn.TabIndex = 15;
            this.clearKbtn.Text = "Clear";
            this.clearKbtn.UseVisualStyleBackColor = true;
            this.clearKbtn.Click += new System.EventHandler(this.clearKbtn_Click);
            // 
            // searchBtn
            // 
            this.searchBtn.Location = new System.Drawing.Point(531, 343);
            this.searchBtn.Name = "searchBtn";
            this.searchBtn.Size = new System.Drawing.Size(107, 36);
            this.searchBtn.TabIndex = 14;
            this.searchBtn.Text = "Find K";
            this.searchBtn.UseVisualStyleBackColor = true;
            this.searchBtn.Click += new System.EventHandler(this.searchBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(639, 273);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(115, 25);
            this.label2.TabIndex = 16;
            this.label2.Text = "RESULTS:";
            // 
            // bgw
            // 
            this.bgw.DoWork += new System.ComponentModel.DoWorkEventHandler(this.bgw_DoWork);
            // 
            // resultLabel
            // 
            this.resultLabel.AutoSize = true;
            this.resultLabel.Location = new System.Drawing.Point(754, 481);
            this.resultLabel.Name = "resultLabel";
            this.resultLabel.Size = new System.Drawing.Size(0, 25);
            this.resultLabel.TabIndex = 17;
            this.resultLabel.Visible = false;
            // 
            // progBar
            // 
            this.progBar.Location = new System.Drawing.Point(644, 468);
            this.progBar.Name = "progBar";
            this.progBar.Size = new System.Drawing.Size(251, 10);
            this.progBar.TabIndex = 18;
            this.progBar.Visible = false;
            // 
            // pLabel
            // 
            this.pLabel.AutoSize = true;
            this.pLabel.Location = new System.Drawing.Point(22, 333);
            this.pLabel.Name = "pLabel";
            this.pLabel.Size = new System.Drawing.Size(26, 25);
            this.pLabel.TabIndex = 19;
            this.pLabel.Text = "P";
            this.pLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.pLabel.Visible = false;
            // 
            // pBox
            // 
            this.pBox.AcceptsTab = true;
            this.pBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pBox.Location = new System.Drawing.Point(237, 331);
            this.pBox.Name = "pBox";
            this.pBox.Size = new System.Drawing.Size(251, 25);
            this.pBox.TabIndex = 20;
            this.pBox.Text = "";
            this.pBox.Visible = false;
            // 
            // Form1
            // 
            this.ClientSize = new System.Drawing.Size(907, 552);
            this.Controls.Add(this.pBox);
            this.Controls.Add(this.pLabel);
            this.Controls.Add(this.progBar);
            this.Controls.Add(this.resultLabel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.clearKbtn);
            this.Controls.Add(this.searchBtn);
            this.Controls.Add(this.searchKtextBox);
            this.Controls.Add(this.clearBtn);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.resultsTextBox);
            this.Controls.Add(this.dataInfo);
            this.Controls.Add(this.comboBox);
            this.Controls.Add(this.metricsInfo);
            this.Controls.Add(this.kInfo);
            this.Controls.Add(this.attributesInfo);
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
        private System.Windows.Forms.Label attributesInfo;
        private System.Windows.Forms.Label kInfo;
        private System.Windows.Forms.Label metricsInfo;
        private System.Windows.Forms.ComboBox comboBox;
        private System.Windows.Forms.Label dataInfo;
        private System.Windows.Forms.RichTextBox resultsTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button clearBtn;
        private System.Windows.Forms.RichTextBox searchKtextBox;
        private System.Windows.Forms.Button clearKbtn;
        private System.Windows.Forms.Button searchBtn;
        private System.Windows.Forms.Label label2;
        private System.ComponentModel.BackgroundWorker bgw;
        private System.Windows.Forms.Label resultLabel;
        private System.Windows.Forms.ProgressBar progBar;
        private System.Windows.Forms.Label pLabel;
        private System.Windows.Forms.RichTextBox pBox;
    }
}

