// Type: Telerik.WinControls.RichTextBox.FormatProviders.Txt.TxtFormatProvider
// Assembly: Telerik.WinControls.RichTextBox, Version=2011.2.11.712, Culture=neutral, PublicKeyToken=5bb2a467cbec794e
// Assembly location: C:\Program Files (x86)\Telerik\RadControls for WinForms Q2 2011\Bin\Net40\Telerik.WinControls.RichTextBox.dll

using System.Collections.Generic;
using System.IO;
using Telerik.WinControls.RichTextBox.FormatProviders;
using Telerik.WinControls.RichTextBox.Model;

namespace Telerik.WinControls.RichTextBox.FormatProviders.Txt
{
    public class TxtFormatProvider : DocumentFormatProviderBase, ITextBasedDocumentFormatProvider,
                                     IDocumentFormatProvider
    {
        public TxtFormatProvider();

        #region ITextBasedDocumentFormatProvider Members

        public RadDocument Import(string input);
        public new string Export(RadDocument document);
        public override string Name { get; }
        public override IEnumerable<string> SupportedExtensions { get; }
        public override bool CanImport { get; }
        public override bool CanExport { get; }

        #endregion

        public override RadDocument Import(Stream input);
        public override void Export(RadDocument document, Stream output);
    }
}
