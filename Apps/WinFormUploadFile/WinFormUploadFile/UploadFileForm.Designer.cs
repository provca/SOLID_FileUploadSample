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
            SuspendLayout();
            // 
            // FilePath_txt
            // 
            FilePath_txt.Location = new Point(12, 12);
            FilePath_txt.Name = "FilePath_txt";
            FilePath_txt.Size = new Size(296, 25);
            FilePath_txt.TabIndex = 0;
            // 
            // SelectFile_btn
            // 
            SelectFile_btn.Location = new Point(12, 42);
            SelectFile_btn.Name = "SelectFile_btn";
            SelectFile_btn.Size = new Size(296, 26);
            SelectFile_btn.TabIndex = 1;
            SelectFile_btn.Text = "Select File";
            SelectFile_btn.UseVisualStyleBackColor = true;
            SelectFile_btn.Click += SelectFile_btn_Click;
            // 
            // UploadFile_btn
            // 
            UploadFile_btn.Location = new Point(12, 73);
            UploadFile_btn.Name = "UploadFile_btn";
            UploadFile_btn.Size = new Size(296, 26);
            UploadFile_btn.TabIndex = 2;
            UploadFile_btn.Text = "Upload File";
            UploadFile_btn.UseVisualStyleBackColor = true;
            UploadFile_btn.Click += UploadFile_btn_Click;
            // 
            // openFileDialog1
            // 
            openFileDialog1.FileName = "openFileDialog1";
            // 
            // UploadFileForm
            // 
            AutoScaleDimensions = new SizeF(7F, 17F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(320, 112);
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
    }
}
