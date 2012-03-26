namespace AnyviewFontModifier
{
    partial class AnyviewFontModifier
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
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.panelDisplay = new System.Windows.Forms.Panel();
            this.comboBoxCharCodeList = new System.Windows.Forms.ComboBox();
            this.buttonPrevChar = new System.Windows.Forms.Button();
            this.buttonNextChar = new System.Windows.Forms.Button();
            this.buttonConfirm = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.buttonOK.Location = new System.Drawing.Point(551, 435);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 0;
            this.buttonOK.Text = "确认修改";
            this.buttonOK.UseVisualStyleBackColor = true;
            // 
            // buttonCancel
            // 
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(632, 435);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 1;
            this.buttonCancel.Text = "放弃修改";
            this.buttonCancel.UseVisualStyleBackColor = true;
            // 
            // panelDisplay
            // 
            this.panelDisplay.BackColor = System.Drawing.Color.Cyan;
            this.panelDisplay.Location = new System.Drawing.Point(0, 0);
            this.panelDisplay.Name = "panelDisplay";
            this.panelDisplay.Size = new System.Drawing.Size(217, 176);
            this.panelDisplay.TabIndex = 2;
            this.panelDisplay.Paint += new System.Windows.Forms.PaintEventHandler(this.panelDisplay_Paint);
            this.panelDisplay.MouseClick += new System.Windows.Forms.MouseEventHandler(this.panelDisplay_MouseClick);
            // 
            // comboBoxCharCodeList
            // 
            this.comboBoxCharCodeList.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxCharCodeList.Font = new System.Drawing.Font("宋体", 24F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.comboBoxCharCodeList.FormattingEnabled = true;
            this.comboBoxCharCodeList.Location = new System.Drawing.Point(456, 25);
            this.comboBoxCharCodeList.Name = "comboBoxCharCodeList";
            this.comboBoxCharCodeList.Size = new System.Drawing.Size(130, 41);
            this.comboBoxCharCodeList.TabIndex = 3;
            // 
            // buttonPrevChar
            // 
            this.buttonPrevChar.Location = new System.Drawing.Point(609, 12);
            this.buttonPrevChar.Name = "buttonPrevChar";
            this.buttonPrevChar.Size = new System.Drawing.Size(75, 23);
            this.buttonPrevChar.TabIndex = 4;
            this.buttonPrevChar.Text = "上一个字符";
            this.buttonPrevChar.UseVisualStyleBackColor = true;
            this.buttonPrevChar.Click += new System.EventHandler(this.buttonPrevChar_Click);
            // 
            // buttonNextChar
            // 
            this.buttonNextChar.Location = new System.Drawing.Point(609, 54);
            this.buttonNextChar.Name = "buttonNextChar";
            this.buttonNextChar.Size = new System.Drawing.Size(75, 23);
            this.buttonNextChar.TabIndex = 5;
            this.buttonNextChar.Text = "下个字符";
            this.buttonNextChar.UseVisualStyleBackColor = true;
            this.buttonNextChar.Click += new System.EventHandler(this.buttonNextChar_Click);
            // 
            // buttonConfirm
            // 
            this.buttonConfirm.Location = new System.Drawing.Point(609, 101);
            this.buttonConfirm.Name = "buttonConfirm";
            this.buttonConfirm.Size = new System.Drawing.Size(75, 56);
            this.buttonConfirm.TabIndex = 6;
            this.buttonConfirm.Text = "确认本字符的修改";
            this.buttonConfirm.UseVisualStyleBackColor = true;
            this.buttonConfirm.Click += new System.EventHandler(this.buttonConfirm_Click);
            // 
            // AnyviewFontModifier
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(719, 470);
            this.Controls.Add(this.buttonConfirm);
            this.Controls.Add(this.buttonNextChar);
            this.Controls.Add(this.buttonPrevChar);
            this.Controls.Add(this.comboBoxCharCodeList);
            this.Controls.Add(this.panelDisplay);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Name = "AnyviewFontModifier";
            this.Text = "点阵字体修正窗口--仅限英文ASCII部分";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.Panel panelDisplay;
        private System.Windows.Forms.ComboBox comboBoxCharCodeList;
        private System.Windows.Forms.Button buttonPrevChar;
        private System.Windows.Forms.Button buttonNextChar;
        private System.Windows.Forms.Button buttonConfirm;
    }
}