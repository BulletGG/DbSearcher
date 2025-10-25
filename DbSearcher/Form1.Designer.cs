namespace DbSearcher
{
    partial class Form1
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.searchbtn = new System.Windows.Forms.Button();
            this.casesensitive = new System.Windows.Forms.CheckBox();
            this.exactmatches = new System.Windows.Forms.CheckBox();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.querytxt = new System.Windows.Forms.TextBox();
            this.choosefilebtn = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // searchbtn
            // 
            this.searchbtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(39)))));
            this.searchbtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.searchbtn.Font = new System.Drawing.Font("Nirmala UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.searchbtn.ForeColor = System.Drawing.Color.White;
            this.searchbtn.Location = new System.Drawing.Point(4, 105);
            this.searchbtn.Name = "searchbtn";
            this.searchbtn.Size = new System.Drawing.Size(215, 63);
            this.searchbtn.TabIndex = 0;
            this.searchbtn.Text = "Search";
            this.searchbtn.UseVisualStyleBackColor = false;
            this.searchbtn.Click += new System.EventHandler(this.searchbtn_Click);
            // 
            // casesensitive
            // 
            this.casesensitive.AutoSize = true;
            this.casesensitive.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.casesensitive.Location = new System.Drawing.Point(125, 43);
            this.casesensitive.Name = "casesensitive";
            this.casesensitive.Size = new System.Drawing.Size(97, 17);
            this.casesensitive.TabIndex = 1;
            this.casesensitive.Text = "Case sensitive";
            this.casesensitive.UseVisualStyleBackColor = true;
            // 
            // exactmatches
            // 
            this.exactmatches.AutoSize = true;
            this.exactmatches.Font = new System.Drawing.Font("Nirmala UI", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exactmatches.ForeColor = System.Drawing.Color.Black;
            this.exactmatches.Location = new System.Drawing.Point(4, 43);
            this.exactmatches.Name = "exactmatches";
            this.exactmatches.Size = new System.Drawing.Size(97, 17);
            this.exactmatches.TabIndex = 2;
            this.exactmatches.Text = "Exact matches";
            this.exactmatches.UseVisualStyleBackColor = true;
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // querytxt
            // 
            this.querytxt.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(147)))), ((int)(((byte)(171)))));
            this.querytxt.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.querytxt.Font = new System.Drawing.Font("Nirmala UI", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.querytxt.ForeColor = System.Drawing.Color.White;
            this.querytxt.Location = new System.Drawing.Point(4, 12);
            this.querytxt.Name = "querytxt";
            this.querytxt.Size = new System.Drawing.Size(215, 25);
            this.querytxt.TabIndex = 3;
            this.querytxt.Text = "Query here";
            this.querytxt.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // choosefilebtn
            // 
            this.choosefilebtn.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(33)))), ((int)(((byte)(34)))), ((int)(((byte)(39)))));
            this.choosefilebtn.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.choosefilebtn.Font = new System.Drawing.Font("Nirmala UI", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.choosefilebtn.ForeColor = System.Drawing.Color.White;
            this.choosefilebtn.Location = new System.Drawing.Point(4, 62);
            this.choosefilebtn.Name = "choosefilebtn";
            this.choosefilebtn.Size = new System.Drawing.Size(215, 37);
            this.choosefilebtn.TabIndex = 4;
            this.choosefilebtn.Text = "Choose file";
            this.choosefilebtn.UseVisualStyleBackColor = false;
            this.choosefilebtn.Click += new System.EventHandler(this.choosefilebtn_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(189)))), ((int)(((byte)(212)))), ((int)(((byte)(231)))));
            this.ClientSize = new System.Drawing.Size(223, 169);
            this.Controls.Add(this.choosefilebtn);
            this.Controls.Add(this.querytxt);
            this.Controls.Add(this.exactmatches);
            this.Controls.Add(this.casesensitive);
            this.Controls.Add(this.searchbtn);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "DbSearcher";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button searchbtn;
        private System.Windows.Forms.CheckBox casesensitive;
        private System.Windows.Forms.CheckBox exactmatches;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.TextBox querytxt;
        private System.Windows.Forms.Button choosefilebtn;
    }
}

