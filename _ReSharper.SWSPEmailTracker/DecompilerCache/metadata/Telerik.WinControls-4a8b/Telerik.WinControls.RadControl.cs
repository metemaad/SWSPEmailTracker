// Type: Telerik.WinControls.RadControl
// Assembly: Telerik.WinControls, Version=2011.2.11.712, Culture=neutral, PublicKeyToken=5bb2a467cbec794e
// Assembly location: C:\Program Files (x86)\Telerik\RadControls for WinForms Q2 2011\Bin\Telerik.WinControls.dll

using System;
using System.ComponentModel;
using System.ComponentModel.Design.Serialization;
using System.Drawing;
using System.Drawing.Design;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using Telerik.WinControls.Keyboard;
using Telerik.WinControls.Layouts;
using Telerik.WinControls.Themes.Design;

namespace Telerik.WinControls
{
    [TypeDescriptionProvider(typeof (ReplaceRadControlProvider))]
    [ToolboxItem(false)]
    [Designer(
        "Telerik.WinControls.RadControlDesigner, Telerik.WinControls.UI.Design, Version=2011.2.11.0712, Culture=neutral, PublicKeyToken=5bb2a467cbec794e"
        )]
    [DesignerSerializer(
        "Telerik.WinControls.Design.RadControlCodeDomSerializer, Telerik.WinControls.UI.Design, Version=2011.2.11.0712, Culture=neutral, PublicKeyToken=5bb2a467cbec794e"
        ,
        "System.ComponentModel.Design.Serialization.CodeDomSerializer, System.Design, Version=2.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
        )]
    public class RadControl : ScrollableControl, INotifyPropertyChanged, ISupportInitializeNotification,
                              ISupportInitialize, IComponentTreeHandler, ILayoutHandler
    {
        protected ComponentInputBehavior behavior;
        protected ComponentThemableElementTree elementTree;
        public RadControl();

        [Browsable(false)]
        public bool IsLoaded { get; }

        [Browsable(false)]
        public virtual ComponentThemableElementTree ElementTree { get; }

        [Browsable(false)]
        public ComponentInputBehavior Behavior { get; }

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public bool UseNewLayoutSystem { get; set; }

        [Category("Behavior")]
        [SettingsBindable(true)]
        [Editor(
            "Telerik.WinControls.UI.TextOrHtmlSelector, Telerik.WinControls.RadMarkupEditor, Version=2011.2.11.0712, Culture=neutral, PublicKeyToken=5bb2a467cbec794e"
            , typeof (UITypeEditor))]
        [Description("Gets or sets the text associated with this control.")]
        [Bindable(true)]
        [DefaultValue("")]
        [Localizable(true)]
        [Browsable(true)]
        public override string Text { get; set; }

        [Category("StyleSheet")]
        [DefaultValue(true)]
        public bool EnableTheming { get; set; }

        [Category("StyleSheet")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual string ThemeClassName { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Description("Gets or sets StyleSheet for the control.")]
        [DefaultValue(null)]
        [Browsable(true)]
        [Category("StyleSheet")]
        public StyleSheet Style { get; set; }

        [Description("Determines whether to use compatible text rendering engine (GDI+) or not (GDI).")]
        [DefaultValue(true)]
        [Category("Behavior")]
        public virtual bool UseCompatibleTextRendering { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Visible)]
        [Category("Layout")]
        [DefaultValue(false)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        [Description(
            "Gets or sets a value indicating whether the control is automatically resized to display its entire contents."
            )]
        [Browsable(true)]
        public override bool AutoSize { get; set; }

        public override Size MaximumSize { get; set; }
        public override Size MinimumSize { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public virtual bool Focusable { get; set; }

        [Description(
            "Gets or sets the BackColor of the control. This is actually the BackColor property of the root element.")]
        public override Color BackColor { get; set; }

        [Description(
            "Gets or sets the ForeColor of the control. This is actually the ForeColor property of the root element.")]
        public override Color ForeColor { get; set; }

        [Description("Gets or sets the Font of the control. This is actually the Font property of the root element.")]
        public override Font Font { get; set; }

        protected bool IsInitializing { get; }
        public override ISite Site { get; set; }

        [Description(
            "Gets or sets a value indicating whether the control causes validation to be performed on any controls that require validation when it receives focus."
            )]
        public new bool CausesValidation { get; set; }

        protected override bool ScaleChildren { get; }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        [Browsable(false)]
        public bool IsDesignMode { get; }

        [Browsable(false)]
        public bool IsDisplayed { get; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public RadElement FocusedElement { get; set; }

        [DefaultValue(false)]
        [Category("Accessibility")]
        [Browsable(true)]
        [Description(
            "Indicates focus cues display, when available, based on the corresponding control type and the current UI state."
            )]
        public virtual bool AllowShowFocusCues { get; set; }

        [Description(
            "Gets or sets a value indicating whether ToolTips are shown for the RadItem objects contained in the RadControl."
            )]
        [Category("Behavior")]
        [DefaultValue(true)]
        public virtual bool ShowItemToolTips { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [Category("Behavior")]
        [TypeConverter(typeof (ExpandableObjectConverter))]
        public InputBindingsCollection CommandBindings { get; }

        [Browsable(true)]
        [DefaultValue(false)]
        public bool EnableKeyMap { get; set; }

        [Browsable(false)]
        public bool IsThemeClassNameSet { get; }

        #region IComponentTreeHandler Members

        public void InvokeLayoutCallback(LayoutCallback callback);
        public virtual void LoadElementTree();
        public virtual void LoadElementTree(Size desiredSize);
        public virtual void InvalidateElement(RadElement element);
        public void InvalidateElement(RadElement element, Rectangle bounds);
        public void SuspendUpdate();
        public void ResumeUpdate();
        public void InvalidateIfNotSuspended();
        public virtual void RegisterHostedControl(RadHostItem hostElement);
        public virtual void UnregisterHostedControl(RadHostItem hostElement, bool removeControl);
        public bool GetShowFocusCues();
        void IComponentTreeHandler.CallOnMouseCaptureChanged(EventArgs e);
        void IComponentTreeHandler.CallOnToolTipTextNeeded(object sender, ToolTipTextNeededEventArgs e);
        void IComponentTreeHandler.CallOnScreenTipNeeded(object sender, ScreenTipNeededEventArgs e);
        object IComponentTreeHandler.GetAmbientPropertyValue(RadProperty property);
        void IComponentTreeHandler.OnAmbientPropertyChanged(RadProperty property);
        void IComponentTreeHandler.ControlThemeChangedCallback();
        bool IComponentTreeHandler.OnFocusRequested(RadElement element);
        bool IComponentTreeHandler.OnCaptureChangeRequested(RadElement element, bool capture);
        void IComponentTreeHandler.InitializeRootElement(RootRadElement rootElement);
        RootRadElement IComponentTreeHandler.CreateRootElement();
        void IComponentTreeHandler.CreateChildItems(RadElement parent);
        void IComponentTreeHandler.CallOnThemeNameChanged(ThemeNameChangedEventArgs e);
        void IComponentTreeHandler.CallSetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified);
        Size IComponentTreeHandler.CallGetPreferredSize(Size proposedSize);
        void IComponentTreeHandler.CallOnLayout(LayoutEventArgs e);
        void IComponentTreeHandler.OnDisplayPropertyChanged(RadPropertyChangedEventArgs e);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public virtual bool ControlDefinesThemeForElement(RadElement element);

        string IComponentTreeHandler.get_Name();
        void IComponentTreeHandler.set_Name([In] string obj0);

        [Browsable(false)]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ILayoutManager LayoutManager { get; }

        [Description("Gets the RootElement of a Control.")]
        [DesignerSerializationVisibility(DesignerSerializationVisibility.Content)]
        [TypeConverter(typeof (ExpandableObjectConverter))]
        [Category("Data")]
        [Browsable(true)]
        public RootRadElement RootElement { get; }

        [Editor(
            "Telerik.WinControls.Design.ThemeNameEditor, Telerik.WinControls.UI.Design, Version=2011.2.11.0712, Culture=neutral, PublicKeyToken=5bb2a467cbec794e"
            , typeof (UITypeEditor))]
        [DefaultValue("")]
        [Browsable(true)]
        [Category("StyleSheet")]
        [Description("Gets or sets theme name.")]
        public string ThemeName { get; set; }

        [Browsable(true)]
        [DefaultValue(null)]
        [Category("Appearance")]
        [Description("Gets or sets the ImageList that contains the images displayed by this control.")]
        public ImageList ImageList { get; set; }

        [Category("Appearance")]
        [DefaultValue(typeof (Size), "16,16")]
        [Browsable(true)]
        public Size ImageScalingSize { get; set; }

        [Browsable(true)]
        [Description("Gets or sets the ImageList that contains the images displayed by this control.")]
        [Category("Appearance")]
        [DefaultValue(null)]
        public virtual ImageList SmallImageList { get; set; }

        [Browsable(false)]
        [DefaultValue(typeof (Size), "16,16")]
        [Category("Appearance")]
        public Size SmallImageScalingSize { get; set; }

        RadControlDesignTimeData IComponentTreeHandler.DesignTimeData { get; }
        bool IComponentTreeHandler.Initializing { get; }
        bool IComponentTreeHandler.IsDesignMode { get; }
        ComponentThemableElementTree IComponentTreeHandler.ElementTree { get; }
        ComponentInputBehavior IComponentTreeHandler.Behavior { get; }
        string IComponentTreeHandler.ThemeClassName { get; set; }

        [Description("Occurs when a RadItem instance inside the RadControl requires ToolTip text. ")]
        [Category("Behavior")]
        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public event ToolTipTextNeededEventHandler ToolTipTextNeeded;

        public event ThemeNameChangedEventHandler ThemeNameChanged;

        #endregion

        #region INotifyPropertyChanged Members

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        [Browsable(false)]
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region ISupportInitializeNotification Members

        public virtual void BeginInit();
        public virtual void EndInit();
        bool ISupportInitializeNotification.IsInitialized { get; }
        public event EventHandler Initialized;

        #endregion

        protected virtual void Construct();
        protected virtual ComponentInputBehavior CreateBehavior();
        protected virtual bool GetUseNewLayout();
        protected virtual void OnLoad(Size desiredSize);
        protected internal virtual Size GetInitialDesiredSize(Size availableSize, bool useNewLayoutSystem);
        protected override void OnCreateControl();
        protected override void OnHandleDestroyed(EventArgs e);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeBackColor();

        protected override void OnBackColorChanged(EventArgs e);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeForeColor();

        protected override void OnForeColorChanged(EventArgs e);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool ShouldSerializeFont();

        protected override void OnFontChanged(EventArgs e);
        protected override void OnParentChanged(EventArgs e);
        protected virtual bool ShouldSerializeProperty(RadProperty property);
        protected internal virtual void OnDisplayPropertyChanged(RadPropertyChangedEventArgs e);
        protected override void OnEnabledChanged(EventArgs e);
        protected override void OnBindingContextChanged(EventArgs e);
        protected override void OnLocationChanged(EventArgs e);
        protected override void OnPaddingChanged(EventArgs e);
        protected override void OnRightToLeftChanged(EventArgs e);
        public override void Refresh();
        public void RepaintElements(params RadElement[] elements);
        protected virtual void OnInvalidated(RadElement element);
        public void ResumeUpdate(bool invalidate);
        protected virtual void OnNotifyPropertyChanged(string propertyName);
        protected virtual void OnNotifyPropertyChanged(PropertyChangedEventArgs e);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void ResetBackColor();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public override void ResetForeColor();

        protected override void OnPaint(PaintEventArgs e);
        protected virtual bool GetCausesValidation();
        protected override void WndProc(ref Message m);
        protected virtual void OnCaptureLosing();
        protected IntPtr SendMessage(int msg, bool wparam, int lparam);
        protected override void Dispose(bool disposing);

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        public void RadAccessibilityNotifyClients(AccessibleEvents accEvent, int childID);

        [EditorBrowsable(EditorBrowsableState.Never)]
        public bool CanEditUIElement(RadElement element);

        protected virtual bool CanEditElementAtDesignTime(RadElement element);
        protected override bool ProcessMnemonic(char charCode);
        protected override void ScaleControl(SizeF factor, BoundsSpecified specified);
        protected override void OnLayout(LayoutEventArgs e);
        public override Size GetPreferredSize(Size proposedSize);
        protected override void SetBoundsCore(int x, int y, int width, int height, BoundsSpecified specified);
        protected override void OnAutoSizeChanged(EventArgs e);
        protected override void OnMouseCaptureChanged(EventArgs e);
        protected override void OnGotFocus(EventArgs e);
        protected override void OnLostFocus(EventArgs e);
        protected virtual void OnToolTipTextNeeded(object sender, ToolTipTextNeededEventArgs e);
        protected virtual void OnScreenTipNeeded(object sender, ScreenTipNeededEventArgs e);
        protected override void OnMouseUp(MouseEventArgs e);
        protected override void OnMouseDown(MouseEventArgs e);
        protected override void OnClick(EventArgs e);
        protected override void OnDoubleClick(EventArgs e);
        protected override void OnMouseEnter(EventArgs e);
        protected override void OnMouseWheel(MouseEventArgs e);
        protected override void OnMouseLeave(EventArgs e);
        protected override void OnMouseMove(MouseEventArgs e);
        protected override void OnMouseHover(EventArgs e);
        protected override void OnPreviewKeyDown(PreviewKeyDownEventArgs e);
        protected override void OnKeyDown(KeyEventArgs e);
        protected override void OnKeyPress(KeyPressEventArgs e);
        protected override void OnKeyUp(KeyEventArgs e);
        protected internal virtual void OnThemeNameChanged(ThemeNameChangedEventArgs e);
        protected virtual RadControlDesignTimeData CreateDesignTimeData();

        [EditorBrowsable(EditorBrowsableState.Never)]
        public RadElement GetChildAt(int index);

        protected virtual void OnThemeChanged();
        protected virtual bool ProcessFocusRequested(RadElement element);
        protected virtual bool ProcessCaptureChangeRequested(RadElement element, bool capture);
        protected virtual void InitializeRootElement(RootRadElement rootElement);
        protected virtual RootRadElement CreateRootElement();
        protected virtual void CreateChildItems(RadElement parent);
        public event EventHandler ElementInvalidated;

        [Description("Occurs prior the ScreenTip of a RadItem instance inside the RadControl is displayed.")]
        [Category("Behavior")]
        public event ScreenTipNeededEventHandler ScreenTipNeeded;
    }
}
