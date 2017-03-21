// Type: Telerik.WinControls.RichTextBox.FileFormats.Html.HtmlFormatProvider
// Assembly: Telerik.WinControls.RichTextBox, Version=2011.2.11.712, Culture=neutral, PublicKeyToken=5bb2a467cbec794e
// Assembly location: C:\Program Files (x86)\Telerik\RadControls for WinForms Q2 2011\Bin\Net40\Telerik.WinControls.RichTextBox.dll

using System.Collections.Generic;
using System.IO;
using Telerik.WinControls.RichTextBox.FormatProviders;
using Telerik.WinControls.RichTextBox.FormatProviders.Html;
using Telerik.WinControls.RichTextBox.Model;

namespace Telerik.WinControls.RichTextBox.FileFormats.Html
{
    public class HtmlFormatProvider : DocumentFormatProviderBase, IConfigurableHtmlFormatProvider,
                                      ITextBasedDocumentFormatProvider, IDocumentFormatProvider
    {
        public HtmlFormatProvider();

        #region IConfigurableHtmlFormatProvider Members

        public RadDocument Import(string input);
        public new string Export(RadDocument document);
        public override string Name { get; }
        public override IEnumerable<string> SupportedExtensions { get; }
        public HtmlExportSettings ExportSettings { get; set; }
        public HtmlImportSettings ImportSettings { get; set; }
        public override bool CanImport { get; }
        public override bool CanExport { get; }

        #endregion

        public override void Export(RadDocument document, Stream output);
        public override RadDocument Import(Stream input);
    }
}
