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
    public partial class AnyviewFontModifier : Form
    {
        private AnyviewFont font;
        private const int SquareWidth = 16;
        private Bitmap DrawingField;
        private byte[] glyphData;
        public AnyviewFontModifier()
        {
            InitializeComponent();
        }
        public void DrawGlyphOnImage()
        {
            Graphics g = Graphics.FromImage(DrawingField);
            SolidBrush bf = new SolidBrush(panelDisplay.ForeColor);
            SolidBrush bb=new SolidBrush(panelDisplay.BackColor);
            int bytesPerRow = font.getAsciiSizePerGlyph() / font.getHeightOfAscii();
            int x, y,offset,offsetInByte;
            byte b;
            for (y = 0; y < font.getHeightOfAscii(); y++)
            {
                for (x = 0; x < font.getWidthOfAscii(); x++)
                {
                    offset = y * bytesPerRow + x / 8;
                    offsetInByte = x % 8;
                    b = glyphData[offset];
                    b = (byte)(b >> (7 - offsetInByte));
                    if ((b & 1) != 0)
                    {
                        g.FillRectangle(bf, x * SquareWidth, y * SquareWidth, SquareWidth, SquareWidth);
                    }
                    else
                    {
                        g.FillRectangle(bb, x * SquareWidth, y * SquareWidth, SquareWidth, SquareWidth);
                    }
                }
            }
        }
        public void GetGlyphFromImage()
        {
            int bytesPerRow = font.getAsciiSizePerGlyph() / font.getHeightOfAscii();
            int x, y, offset, offsetInByte;
            byte b;
            for (y = 0; y < font.getHeightOfAscii(); y++)
            {
                for (x = 0; x < font.getWidthOfAscii(); x++)
                {
                    offset = y * bytesPerRow + x / 8;
                    offsetInByte = x % 8;
                    b = glyphData[offset];
                    if (DrawingField.GetPixel(x * SquareWidth, y * SquareWidth).ToArgb() == panelDisplay.ForeColor.ToArgb())
                    {
                        b=(byte)(b|(1<<(7-offsetInByte)));
                    }
                    else
                    {
                        b=(byte)(b&(~(1<<(7-offsetInByte))));
                    }
                    glyphData[offset] = b;
                }
            }
        }
        public AnyviewFontModifier(AnyviewFont font)
        {
            InitializeComponent();
            // TODO: Complete member initialization
            this.font = font;
            DrawingField = new Bitmap(font.getWidthOfAscii()*SquareWidth, font.getHeightOfAscii()*SquareWidth);
            panelDisplay.Size = DrawingField.Size;
            panelDisplay.Top = 0;
            panelDisplay.Left = 0;
            comboBoxCharCodeList.Items.Clear();
            for (int code = 0; code <= 255; code++)
            {
                comboBoxCharCodeList.Items.Add(code.ToString()+"  "+(char)(code));
            }
            comboBoxCharCodeList.SelectedIndex = 33;
            glyphData = font.getGlyphData(33);
            DrawGlyphOnImage();
        }

        private void panelDisplay_Paint(object sender, PaintEventArgs e)
        {
            panelDisplay.CreateGraphics().DrawImageUnscaled(DrawingField, 0, 0);
        }

        private void panelDisplay_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                //MessageBox.Show("(" + e.X + ", " + e.Y);
                Graphics g = Graphics.FromImage(DrawingField);
                SolidBrush bf = new SolidBrush(panelDisplay.ForeColor);
                SolidBrush bb = new SolidBrush(panelDisplay.BackColor);
                int x = e.X / SquareWidth;
                int y = e.Y / SquareWidth;
                Color c=DrawingField.GetPixel(e.X, e.Y);
                if (c.ToArgb() == panelDisplay.ForeColor.ToArgb())
                {
                    g.FillRectangle(bb, x * SquareWidth, y * SquareWidth, SquareWidth, SquareWidth);
                }
                else
                {
                    g.FillRectangle(bf, x * SquareWidth, y * SquareWidth, SquareWidth, SquareWidth);
                }
                this.Refresh();
            }
        }

        private void buttonPrevChar_Click(object sender, EventArgs e)
        {
            if (comboBoxCharCodeList.SelectedIndex == 0)
                return;
            comboBoxCharCodeList.SelectedIndex = comboBoxCharCodeList.SelectedIndex - 1;
            glyphData = font.getGlyphData(Convert.ToByte(comboBoxCharCodeList.SelectedIndex));
            DrawGlyphOnImage();
            this.Refresh();
        }

        private void buttonNextChar_Click(object sender, EventArgs e)
        {
            if (comboBoxCharCodeList.SelectedIndex == 255)
                return;
            comboBoxCharCodeList.SelectedIndex = comboBoxCharCodeList.SelectedIndex + 1;
            glyphData = font.getGlyphData(Convert.ToByte(comboBoxCharCodeList.SelectedIndex));
            DrawGlyphOnImage();
            this.Refresh();
        }

        private void buttonConfirm_Click(object sender, EventArgs e)
        {
            GetGlyphFromImage();
            font.setGlyphData(Convert.ToByte(comboBoxCharCodeList.SelectedIndex), glyphData);
        }
    }
}
