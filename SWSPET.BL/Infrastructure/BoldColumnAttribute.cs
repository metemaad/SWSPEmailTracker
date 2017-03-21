using System;
using System.Drawing;

namespace SWSPET.BL.Infrastructure
{
    public class BoldColumnAttribute : Attribute
    {
        public Color ForeColor { get; set; }
        public float FontSize { get; set; }
        public string FontName { get; set; }

        public BoldColumnAttribute ()
        {
            FontStyle = FontStyle.Regular;
            FontName = "Tahoma";
            FontSize = 8;
        }

        public BoldColumnAttribute(string fontName, float fontSize, FontStyle fontStyle, Color foreColor)
        {
            FontStyle = fontStyle;
            FontName = fontName;
            FontSize = fontSize;
            ForeColor = foreColor;

        }
        public BoldColumnAttribute(string fontName, float fontSize, FontStyle fontStyle)
        {
            FontStyle = fontStyle;
            FontName = fontName;
            FontSize = fontSize;
          

        }
        public FontStyle FontStyle { get; set; }
    }
}