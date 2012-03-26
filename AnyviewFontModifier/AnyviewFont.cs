using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;

namespace AnyviewFontModifier
{
    public class AnyviewFont
    {
        private string FontFilePath;
        private byte[] VerifyByteString;
        private byte TheOne;
        private byte LengthOfDescriptionString;
        private byte[] DescriptionString;
        private string DescriptionStringText;
        private byte LengthOfAuthorString;
        private byte[] AuthorString;
        private string AuthorStringText;
        private byte WidthOfAscii;
        private byte WidthOfChinese;
        private byte Height;
        private byte[] LengthOfAsciiGlyphData;//big endian
        private byte[] LengthOfChineseGlyphData;//big endian
        private byte FlagOfGBKSet;
        private byte[] AsciiGlyphData;
        private byte[] ChineseGlyphData;
        public int getAsciiSizePerGlyph()
        {
            int w = WidthOfAscii;
            int h = Height;
            int bytesPerRow = w / 8;
            if (w % 8 != 0)
                bytesPerRow++;
            return h * bytesPerRow;
        }
        public byte getWidthOfAscii()
        {
            return WidthOfAscii;
        }
        public byte getHeightOfAscii()
        {
            return Height;
        }
        public byte[] getGlyphData(byte asciiCode)
        {
            if (asciiCode > 255)
            {
                return null;
            }
            byte[] buffer = new byte[getAsciiSizePerGlyph()];
            Array.Copy(AsciiGlyphData, 0 + getAsciiSizePerGlyph() * asciiCode, buffer, 0, buffer.Length);
            return buffer;
        }
        public void setGlyphData(byte asciiCode, byte[] data)
        {
            if (asciiCode > 255)
            {
                return;
            }
            if (data.Length != getAsciiSizePerGlyph())
            {
                return;
            }
            Array.Copy(data, 0, AsciiGlyphData, getAsciiSizePerGlyph() * asciiCode, getAsciiSizePerGlyph());
        }
        private bool ValidateVerifyByteString(byte[] trueVerify,byte[] verify)
        {
            for (int i = 0; i < trueVerify.Length; i++)
            {
                if (trueVerify[i] != verify[i])
                    return false;
            }
            return true;
        }
        public Int32 ByteArrayToInt32_BigEndian(byte[] array)
        {
            int ret = 0;
            if (BitConverter.IsLittleEndian)
            {//test whether the system architect
                //do not use arrayName.Reverse(),it dosen't work!
                Array.Reverse(array, 0, 4);
                ret = BitConverter.ToInt32(array, 0);
                Array.Reverse(array, 0, 4);
            }
            else
            {
                ret = BitConverter.ToInt32(array, 0);
            }
            return ret;
        }
        public AnyviewFont(string fontFilePath)
        {
            this.FontFilePath = fontFilePath;
            FileStream stream = new FileStream(FontFilePath, FileMode.Open);
            byte[] TrueVerify=new byte[]{129, 97, 110, 121, 118, 105, 101, 119,
                    32, 102, 111, 110, 116};
            VerifyByteString=new byte[TrueVerify.Length];
            stream.Read(VerifyByteString, 0, VerifyByteString.Length);
            if (!ValidateVerifyByteString(TrueVerify, VerifyByteString))
            {
                stream.Close();
                throw new Exception("Verify String invalid.Maybe it is not a anyview font file");
            }
            TheOne = (byte)(stream.ReadByte());
            if (TheOne != 1)
            {
                stream.Close();
                throw new Exception("TheOne is not 1.");
            }
            LengthOfDescriptionString = (byte)(stream.ReadByte());
            DescriptionString = new byte[LengthOfDescriptionString];
            stream.Read(DescriptionString, 0, DescriptionString.Length);
            DescriptionStringText = Encoding.UTF8.GetString(DescriptionString);
            LengthOfAuthorString = (byte)(stream.ReadByte());
            AuthorString = new byte[LengthOfAuthorString];
            stream.Read(AuthorString, 0, AuthorString.Length);
            AuthorStringText = Encoding.UTF8.GetString(AuthorString);
            WidthOfAscii = (byte)(stream.ReadByte());
            WidthOfChinese = (byte)(stream.ReadByte());
            Height = (byte)(stream.ReadByte());
            LengthOfAsciiGlyphData = new byte[4];
            stream.Read(LengthOfAsciiGlyphData, 0, LengthOfAsciiGlyphData.Length);
            LengthOfChineseGlyphData = new byte[4];
            stream.Read(LengthOfChineseGlyphData, 0, LengthOfChineseGlyphData.Length);
            FlagOfGBKSet = (byte)(stream.ReadByte());
            if (FlagOfGBKSet != 1 && FlagOfGBKSet != 0)
            {
                throw new Exception("GBK flag is invalid!Maybe it is not GB2312 and GBK charset.");
            }
            AsciiGlyphData = new byte[ByteArrayToInt32_BigEndian(LengthOfAsciiGlyphData)];
            stream.Read(AsciiGlyphData, 0, AsciiGlyphData.Length);
            ChineseGlyphData = new byte[ByteArrayToInt32_BigEndian(LengthOfChineseGlyphData)];
            stream.Read(ChineseGlyphData, 0, ChineseGlyphData.Length);
            stream.Close();
        }
        public void SaveToFile(string fontFilePath)
        {
            FileStream stream = new FileStream(fontFilePath, FileMode.Create);
            stream.Write(VerifyByteString, 0, VerifyByteString.Length);
            stream.WriteByte(1);
            stream.WriteByte(LengthOfDescriptionString);
            stream.Write(DescriptionString, 0, DescriptionString.Length);
            stream.WriteByte(LengthOfAuthorString);
            stream.Write(AuthorString, 0, AuthorString.Length);
            stream.WriteByte(WidthOfAscii);
            stream.WriteByte(WidthOfChinese);
            stream.WriteByte(Height);
            stream.Write(LengthOfAsciiGlyphData, 0, LengthOfAsciiGlyphData.Length);
            stream.Write(LengthOfChineseGlyphData, 0, LengthOfChineseGlyphData.Length);
            stream.WriteByte(FlagOfGBKSet);
            stream.Write(AsciiGlyphData, 0, AsciiGlyphData.Length);
            stream.Write(ChineseGlyphData, 0, ChineseGlyphData.Length);
            stream.Close();
        }
    }
}
