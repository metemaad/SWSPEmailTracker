// Type: Telerik.WinControls.UI.RadButtonBase
// Assembly: Telerik.WinControls.UI, Version=2011.2.11.712, Culture=neutral, PublicKeyToken=5bb2a467cbec794e
// Assembly location: C:\Program Files (x86)\Telerik\RadControls for WinForms Q2 2011\Bin\Telerik.WinControls.UI.dll

using System;
using System.ComponentModel;
using System.Drawing;
using System.Drawing.Design;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.Design;
using Telerik.WinControls.Primitives;

namespace Telerik.WinControls.UI
{
    [DefaultEvent("Click")]
    [DefaultProperty("Text")]
    [ToolboxItem(false)]
    [Description("Responds to user clicks.")]
    [DefaultBindingProperty("Text")]
    public class RadButtonBase : RadControl
    {
        public RadButtonBase();
        protected override Size DefaultSize { get; }

        [Localizable(true)]
        [Description(
            "Includes the trailing space at the end of each line. By default the boundary rectangle returned by the Overload:System.Drawing.Graphics.MeasureString method excludes the space at the end of each line. Set this flag to include that space in measurement."
            )]
        [Category("Appearance")]
        [DefaultValue(true)]
        public bool MeasureTrailingSpaces { get; set; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual RadButtonElement ButtonElement { get; }

        [Description("Gets or sets the text associated with this item.")]
        [Editor(
            "Telerik.WinControls.UI.TextOrHtmlSelector, Telerik.WinControls.RadMarkupEditor, Version=2011.2.11.0712, Culture=neutral, PublicKeyToken=5bb2a467cbec794e"
            , typeof (UITypeEditor))]
        [Category("Behavior")]
        [Bindable(true)]
        [Localizable(true)]
        [SettingsBindable(true)]
        public override string Text { get; set; }

        [RadDescription("Image", typeof (RadButtonElement))]
        [RefreshProperties(RefreshProperties.All)]
        [Localizable(true)]
        [Category("Appearance")]
        public Image Image { get; set; }

        [Editor(
            "Telerik.WinControls.Design.ImageIndexEditor, Telerik.WinControls.UI.Design, Version=2011.2.11.0712, Culture=neutral, PublicKeyToken=5bb2a467cbec794e"
            , typeof (UITypeEditor))]
        [TypeConverter(
            "Telerik.WinControls.Design.NoneExcludedImageIndexConverter, Telerik.WinControls.UI.Design, Version=2011.2.11.0712, Culture=neutral, PublicKeyToken=5bb2a467cbec794e"
            )]
        [RelatedImageList("ImageList")]
        [Localizable(true)]
        [RadDefaultValue("ImageIndex", typeof (RadButtonElement))]
        [Category("Appearance")]
        [RadDescription("ImageIndex", typeof (RadButtonElement))]
        [RefreshProperties(RefreshProperties.All)]
        public int ImageIndex { get; set; }

        [TypeConverter(
            "Telerik.WinControls.Design.RadImageKeyConverter, Telerik.WinControls.UI.Design, Version=2011.2.11.0712, Culture=neutral, PublicKeyToken=5bb2a467cbec794e"
            )]
        [Category("Appearance")]
        [RadDescription("ImageKey", typeof (RadButtonElement))]
        [RadDefaultValue("ImageKey", typeof (RadButtonElement))]
        [RefreshProperties(RefreshProperties.All)]
        [Localizable(true)]
        [RelatedImageList("ImageList")]
        [Editor(
            "Telerik.WinControls.Design.ImageKeyEditor, Telerik.WinControls.UI.Design, Version=2011.2.11.0712, Culture=neutral, PublicKeyToken=5bb2a467cbec794e"
            , typeof (UITypeEditor))]
        public virtual string ImageKey { get; set; }

        [Browsable(true)]
        [Category("Appearance")]
        [Localizable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        [RadDefaultValue("DisplayStyle", typeof (RadButtonElement))]
        [Description("Specifies the options for display of image and text primitives in the element.")]
        public DisplayStyle DisplayStyle { get; set; }

        [Description("True if the text should wrap to the available layout rectangle otherwise, false.")]
        [RadPropertyDefaultValue("TextWrap", typeof (TextPrimitive))]
        [Category("Appearance")]
        public bool TextWrap { get; set; }

        [Description("Gets or sets the position of text and image relative to each other.")]
        [Category("Appearance")]
        [RadDefaultValue("TextImageRelation", typeof (RadButtonElement))]
        [Localizable(true)]
        [RefreshProperties(RefreshProperties.Repaint)]
        public TextImageRelation TextImageRelation { get; set; }

        [RadDefaultValue("ImageAlignment", typeof (RadButtonElement))]
        [RefreshProperties(RefreshProperties.Repaint)]
        [Localizable(true)]
        [Description("Gets or sets the alignment of image content on the drawing surface.")]
        [Category("Appearance")]
        public ContentAlignment ImageAlignment { get; set; }

        protected virtual ContentAlignment DefaultTextAlignment { get; }

        [Localizable(true)]
        [Category("Appearance")]
        [Description("Gets or sets the alignment of text content on the drawing surface.")]
        [RefreshProperties(RefreshProperties.Repaint)]
        public ContentAlignment TextAlignment { get; set; }

        [DefaultValue(true)]
        [Category("Appearance")]
        [Description("Determines whether the button can be clicked by using mnemonic characters.")]
        public bool UseMnemonic { get; set; }

        public override bool AutoSize { get; set; }

        [Browsable(true)]
        [DefaultValue(true)]
        [Category("Accessibility")]
        [Description(
            "Indicates focus cues display, when available, based on the corresponding control type and the current UI state."
            )]
        public override bool AllowShowFocusCues { get; set; }

        protected override void CreateChildItems(RadElement parent);
        protected override void InitializeRootElement(RootRadElement rootElement);
        public override bool ControlDefinesThemeForElement(RadElement element);
        protected override AccessibleObject CreateAccessibilityInstance();
        protected virtual RadButtonElement CreateButtonElement();
        public bool ShouldSerializeImage();
        public void ResetImage();
        public void PerformClick();
        protected override bool ProcessMnemonic(char charCode);
        protected override void OnClick(EventArgs e);
        protected override void OnGotFocus(EventArgs e);

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public new event EventHandler DoubleClick;

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        [Browsable(false)]
        public new event MouseEventHandler MouseDoubleClick;
    }
}
