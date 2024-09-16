namespace WinFormUploadFile
{
    partial class UploadFileForm
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
            FilePath_txt = new TextBox();
            SelectFile_btn = new Button();
            UploadFile_btn = new Button();
            openFileDialog1 = new OpenFileDialog();
            CustomFileName_txt = new TextBox();
            CustomFileName_lbl = new Label();
            Separator1_lbl = new Label();
            SelectFolder_btn = new Button();
            FolderTarget_txt = new TextBox();
            Separator2_lbl = new Label();
            CustomFolder_lbl = new Label();
            label1 = new Label();
            folderBrowserDialog1 = new FolderBrowserDialog();
            SuspendLayout();
            // 
            // FilePath_txt
            // 
            FilePath_txt.Location = new Point(12, 12);
            FilePath_txt.Name = "FilePath_txt";
            FilePath_txt.Size = new Size(296, 25);
            FilePath_txt.TabIndex = 1;
            // 
            // SelectFile_btn
            // 
            SelectFile_btn.Location = new Point(12, 43);
            SelectFile_btn.Name = "SelectFile_btn";
            SelectFile_btn.Size = new Size(296, 26);
            SelectFile_btn.TabIndex = 2;
            SelectFile_btn.Text = "Select File";
            SelectFile_btn.UseVisualStyleBackColor = true;
            SelectFile_btn.Click += SelectFile_btn_Click;
            // 
            // UploadFile_btn
            // 
            UploadFile_btn.Location = new Point(12, 277);
            UploadFile_btn.Name = "UploadFile_btn";
            UploadFile_btn.Size = new Size(296, 26);
            UploadFile_btn.TabIndex = 6;
            UploadFile_btn.Text = "Upload File";
            UploadFile_btn.UseVisualStyleBackColor = true;
            UploadFile_btn.Click += UploadFile_btn_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // CustomFileName_txt
            // 
            CustomFileName_txt.Location = new Point(12, 116);
            CustomFileName_txt.Name = "CustomFileName_txt";
            CustomFileName_txt.Size = new Size(296, 25);
            CustomFileName_txt.TabIndex = 3;
            // 
            // CustomFileName_lbl
            // 
            CustomFileName_lbl.AutoSize = true;
            CustomFileName_lbl.Font = new Font("Segoe UI", 8.25F, FontStyle.Italic);
            CustomFileName_lbl.ForeColor = SystemColors.ControlDarkDark;
            CustomFileName_lbl.Location = new Point(12, 93);
            CustomFileName_lbl.Name = "CustomFileName_lbl";
            CustomFileName_lbl.Size = new Size(130, 13);
            CustomFileName_lbl.TabIndex = 0;
            CustomFileName_lbl.Text = "Rename the file (optional):";
            // 
            // Separator1_lbl
            // 
            Separator1_lbl.BorderStyle = BorderStyle.Fixed3D;
            Separator1_lbl.Location = new Point(12, 80);
            Separator1_lbl.Name = "Separator1_lbl";
            Separator1_lbl.Size = new Size(296, 2);
            Separator1_lbl.TabIndex = 0;
            Separator1_lbl.Text = "---";
            // 
            // SelectFolder_btn
            // 
            SelectFolder_btn.Location = new Point(12, 221);
            SelectFolder_btn.Name = "SelectFolder_btn";
            SelectFolder_btn.Size = new Size(296, 26);
            SelectFolder_btn.TabIndex = 5;
            SelectFolder_btn.Text = "Select Folder";
            SelectFolder_btn.UseVisualStyleBackColor = true;
            SelectFolder_btn.Click += SelectFolder_btn_Click;
            // 
            // FolderTarget_txt
            // 
            FolderTarget_txt.Location = new Point(12, 190);
            FolderTarget_txt.Name = "FolderTarget_txt";
            FolderTarget_txt.Size = new Size(296, 25);
            FolderTarget_txt.TabIndex = 4;
            // 
            // Separator2_lbl
            // 
            Separator2_lbl.BorderStyle = BorderStyle.Fixed3D;
            Separator2_lbl.Location = new Point(12, 154);
            Separator2_lbl.Name = "Separator2_lbl";
            Separator2_lbl.Size = new Size(296, 2);
            Separator2_lbl.TabIndex = 0;
            Separator2_lbl.Text = "---";
            // 
            // CustomFolder_lbl
            // 
            CustomFolder_lbl.AutoSize = true;
            CustomFolder_lbl.Font = new Font("Segoe UI", 8.25F, FontStyle.Italic);
            CustomFolder_lbl.ForeColor = SystemColors.ControlDarkDark;
            CustomFolder_lbl.Location = new Point(12, 169);
            CustomFolder_lbl.Name = "CustomFolder_lbl";
            CustomFolder_lbl.Size = new Size(89, 13);
            CustomFolder_lbl.TabIndex = 0;
            CustomFolder_lbl.Text = "CustomFolder_lbl";
            // 
            // label1
            // 
            label1.BorderStyle = BorderStyle.Fixed3D;
            label1.Location = new Point(12, 261);
            label1.Name = "label1";
            label1.Size = new Size(296, 2);
            label1.TabIndex = 10;
            label1.Text = "---";
            // 
            // UploadFileForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(320, 315);
            Controls.Add(label1);
            Controls.Add(CustomFolder_lbl);
            Controls.Add(Separator2_lbl);
            Controls.Add(SelectFolder_btn);
            Controls.Add(FolderTarget_txt);
            Controls.Add(Separator1_lbl);
            Controls.Add(CustomFileName_lbl);
            Controls.Add(CustomFileName_txt);
            Controls.Add(UploadFile_btn);
            Controls.Add(SelectFile_btn);
            Controls.Add(FilePath_txt);
            Font = new Font("Segoe UI", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Name = "UploadFileForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Upload File";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox FilePath_txt;
        private Button SelectFile_btn;
        private Button UploadFile_btn;
        private OpenFileDialog openFileDialog1;
        private TextBox CustomFileName_txt;
        private Label CustomFileName_lbl;
        private Label Separator1_lbl;
        private Button SelectFolder_btn;
        private TextBox FolderTarget_txt;
        private Label Separator2_lbl;
        private Label CustomFolder_lbl;
        private Label label1;
        private FolderBrowserDialog folderBrowserDialog1;
    }
}
