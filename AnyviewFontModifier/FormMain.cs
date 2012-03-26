using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace AnyviewFontModifier
{
    public partial class FormMain : Form
    {
        public FormMain()
        {
            InitializeComponent();
        }

        private void buttonFontFileSelect_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Multiselect = false;
            ofd.Filter = "Anyview Font Files (*.font)|*.font";
            DialogResult dr = ofd.ShowDialog();
            if (dr == DialogResult.OK)
            {
                textBoxFontFilePath.Text = ofd.FileName;
            }
        }

        private void buttonStart_Click(object sender, EventArgs e)
        {
            if (textBoxFontFilePath.Text == null)
                return;
            if (textBoxFontFilePath.Text.Length < 1)
                return;
            AnyviewFont font=null;
            try
            {
                font = new AnyviewFont(textBoxFontFilePath.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                MessageBox.Show(ex.StackTrace);
                return;
            }
            AnyviewFontModifier modifier = new AnyviewFontModifier(font);
            DialogResult dr = modifier.ShowDialog();
            if (dr == DialogResult.OK)
            {
                //write modified font data back to this file
                //...
                font.SaveToFile("y:\\hoxily\\download\\anyview3.0\\fonts\\font.font");
            }
        }
    }
}
