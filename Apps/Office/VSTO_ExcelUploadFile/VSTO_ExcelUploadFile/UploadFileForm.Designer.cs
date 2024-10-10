using System.Threading.Tasks;

namespace VSTO_ExcelUploadFile
{
    partial class UploadFileForm
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
            this.FilePath_txt = new System.Windows.Forms.TextBox();
            this.SelectFile_btn = new System.Windows.Forms.Button();
            this.Separator1_lbl = new System.Windows.Forms.Label();
            this.CustomFileName_lbl = new System.Windows.Forms.Label();
            this.Separator2_lbl = new System.Windows.Forms.Label();
            this.CustomFileName_txt = new System.Windows.Forms.TextBox();
            this.FilePathTarget_txt = new System.Windows.Forms.TextBox();
            this.FilePathTarget_lbl = new System.Windows.Forms.Label();
            this.Separator3_lbl = new System.Windows.Forms.Label();
            this.SelectFolder_btn = new System.Windows.Forms.Button();
            this.UploadFile_btn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // FilePath_txt
            // 
            this.FilePath_txt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FilePath_txt.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.FilePath_txt.Location = new System.Drawing.Point(12, 12);
            this.FilePath_txt.Name = "FilePath_txt";
            this.FilePath_txt.Size = new System.Drawing.Size(296, 23);
            this.FilePath_txt.TabIndex = 0;
            // 
            // SelectFile_btn
            // 
            this.SelectFile_btn.Location = new System.Drawing.Point(12, 41);
            this.SelectFile_btn.Name = "SelectFile_btn";
            this.SelectFile_btn.Size = new System.Drawing.Size(296, 23);
            this.SelectFile_btn.TabIndex = 1;
            this.SelectFile_btn.Text = "Select File";
            this.SelectFile_btn.UseVisualStyleBackColor = true;
            this.SelectFile_btn.Click += new System.EventHandler(this.SelectFile_btn_Click);
            // 
            // Separator1_lbl
            // 
            this.Separator1_lbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Separator1_lbl.Location = new System.Drawing.Point(12, 80);
            this.Separator1_lbl.Name = "Separator1_lbl";
            this.Separator1_lbl.Size = new System.Drawing.Size(296, 2);
            this.Separator1_lbl.TabIndex = 2;
            this.Separator1_lbl.Text = "---";
            // 
            // CustomFileName_lbl
            // 
            this.CustomFileName_lbl.AutoSize = true;
            this.CustomFileName_lbl.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomFileName_lbl.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.CustomFileName_lbl.Location = new System.Drawing.Point(12, 93);
            this.CustomFileName_lbl.Name = "CustomFileName_lbl";
            this.CustomFileName_lbl.Size = new System.Drawing.Size(130, 13);
            this.CustomFileName_lbl.TabIndex = 3;
            this.CustomFileName_lbl.Text = "Rename the file (optional):";
            // 
            // Separator2_lbl
            // 
            this.Separator2_lbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Separator2_lbl.Location = new System.Drawing.Point(12, 154);
            this.Separator2_lbl.Name = "Separator2_lbl";
            this.Separator2_lbl.Size = new System.Drawing.Size(296, 2);
            this.Separator2_lbl.TabIndex = 5;
            this.Separator2_lbl.Text = "---";
            // 
            // CustomFileName_txt
            // 
            this.CustomFileName_txt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.CustomFileName_txt.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.CustomFileName_txt.Location = new System.Drawing.Point(12, 116);
            this.CustomFileName_txt.Name = "CustomFileName_txt";
            this.CustomFileName_txt.Size = new System.Drawing.Size(296, 23);
            this.CustomFileName_txt.TabIndex = 4;
            // 
            // FilePathTarget_txt
            // 
            this.FilePathTarget_txt.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FilePathTarget_txt.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.FilePathTarget_txt.Location = new System.Drawing.Point(12, 190);
            this.FilePathTarget_txt.Name = "FilePathTarget_txt";
            this.FilePathTarget_txt.Size = new System.Drawing.Size(296, 23);
            this.FilePathTarget_txt.TabIndex = 7;
            // 
            // FilePathTarget_lbl
            // 
            this.FilePathTarget_lbl.AutoSize = true;
            this.FilePathTarget_lbl.Font = new System.Drawing.Font("Segoe UI", 8.25F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FilePathTarget_lbl.ForeColor = System.Drawing.SystemColors.ControlDarkDark;
            this.FilePathTarget_lbl.Location = new System.Drawing.Point(12, 169);
            this.FilePathTarget_lbl.Name = "FilePathTarget_lbl";
            this.FilePathTarget_lbl.Size = new System.Drawing.Size(89, 13);
            this.FilePathTarget_lbl.TabIndex = 6;
            this.FilePathTarget_lbl.Text = "CustomFolder_lbl";
            // 
            // Separator3_lbl
            // 
            this.Separator3_lbl.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.Separator3_lbl.Location = new System.Drawing.Point(12, 261);
            this.Separator3_lbl.Name = "Separator3_lbl";
            this.Separator3_lbl.Size = new System.Drawing.Size(296, 2);
            this.Separator3_lbl.TabIndex = 8;
            this.Separator3_lbl.Text = "---";
            // 
            // SelectFolder_btn
            // 
            this.SelectFolder_btn.Location = new System.Drawing.Point(12, 221);
            this.SelectFolder_btn.Name = "SelectFolder_btn";
            this.SelectFolder_btn.Size = new System.Drawing.Size(296, 23);
            this.SelectFolder_btn.TabIndex = 9;
            this.SelectFolder_btn.Text = "Select Folder";
            this.SelectFolder_btn.UseVisualStyleBackColor = true;
            this.SelectFolder_btn.Click += new System.EventHandler(this.SelectFolder_btn_Click);
            // 
            // UploadFile_btn
            // 
            this.UploadFile_btn.Location = new System.Drawing.Point(12, 277);
            this.UploadFile_btn.Name = "UploadFile_btn";
            this.UploadFile_btn.Size = new System.Drawing.Size(296, 23);
            this.UploadFile_btn.TabIndex = 10;
            this.UploadFile_btn.Text = "Upload File";
            this.UploadFile_btn.UseVisualStyleBackColor = true;
            this.UploadFile_btn.Click += new System.EventHandler(this.UploadFile_btn_Click);
            // 
            // UploadFileForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(320, 315);
            this.Controls.Add(this.UploadFile_btn);
            this.Controls.Add(this.SelectFolder_btn);
            this.Controls.Add(this.Separator3_lbl);
            this.Controls.Add(this.FilePathTarget_txt);
            this.Controls.Add(this.FilePathTarget_lbl);
            this.Controls.Add(this.Separator2_lbl);
            this.Controls.Add(this.CustomFileName_txt);
            this.Controls.Add(this.CustomFileName_lbl);
            this.Controls.Add(this.Separator1_lbl);
            this.Controls.Add(this.SelectFile_btn);
            this.Controls.Add(this.FilePath_txt);
            this.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.Name = "UploadFileForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Upload File";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox FilePath_txt;
        private System.Windows.Forms.Button SelectFile_btn;
        private System.Windows.Forms.Label Separator1_lbl;
        private System.Windows.Forms.Label CustomFileName_lbl;
        private System.Windows.Forms.Label Separator2_lbl;
        private System.Windows.Forms.TextBox CustomFileName_txt;
        private System.Windows.Forms.TextBox FilePathTarget_txt;
        private System.Windows.Forms.Label FilePathTarget_lbl;
        private System.Windows.Forms.Label Separator3_lbl;
        private System.Windows.Forms.Button SelectFolder_btn;
        private System.Windows.Forms.Button UploadFile_btn;
    }
}