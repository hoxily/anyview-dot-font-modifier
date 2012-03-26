namespace AnyviewFontModifier
{
    partial class FormMain
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.textBoxFontFilePath = new System.Windows.Forms.TextBox();
            this.buttonFontFileSelect = new System.Windows.Forms.Button();
            this.buttonStart = new System.Windows.Forms.Button();
            this.labelDescription = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxFontFilePath
            // 
            this.textBoxFontFilePath.Location = new System.Drawing.Point(31, 67);
            this.textBoxFontFilePath.Name = "textBoxFontFilePath";
            this.textBoxFontFilePath.ReadOnly = true;
            this.textBoxFontFilePath.Size = new System.Drawing.Size(263, 21);
            this.textBoxFontFilePath.TabIndex = 0;
            // 
            // buttonFontFileSelect
            // 
            this.buttonFontFileSelect.Location = new System.Drawing.Point(311, 67);
            this.buttonFontFileSelect.Name = "buttonFontFileSelect";
            this.buttonFontFileSelect.Size = new System.Drawing.Size(57, 23);
            this.buttonFontFileSelect.TabIndex = 1;
            this.buttonFontFileSelect.Text = "..";
            this.buttonFontFileSelect.UseVisualStyleBackColor = true;
            this.buttonFontFileSelect.Click += new System.EventHandler(this.buttonFontFileSelect_Click);
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(288, 122);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(80, 28);
            this.buttonStart.TabIndex = 2;
            this.buttonStart.Text = "开始优化";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // labelDescription
            // 
            this.labelDescription.AutoSize = true;
            this.labelDescription.Location = new System.Drawing.Point(86, 9);
            this.labelDescription.Name = "labelDescription";
            this.labelDescription.Size = new System.Drawing.Size(245, 12);
            this.labelDescription.TabIndex = 3;
            this.labelDescription.Text = "选择好font文件，点击开始优化进行优化工作";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(416, 201);
            this.Controls.Add(this.labelDescription);
            this.Controls.Add(this.buttonStart);
            this.Controls.Add(this.buttonFontFileSelect);
            this.Controls.Add(this.textBoxFontFilePath);
            this.Name = "FormMain";
            this.Text = "Anyview Font Modifier 点阵字体手工优化工具";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxFontFilePath;
        private System.Windows.Forms.Button buttonFontFileSelect;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Label labelDescription;
    }
}

