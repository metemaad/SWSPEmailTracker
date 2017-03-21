// Type: System.Windows.Forms.ScrollableControl
// Assembly: System.Windows.Forms, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b77a5c561934e089
// Assembly location: C:\Program Files (x86)\Reference Assemblies\Microsoft\Framework\.NETFramework\v4.0\System.Windows.Forms.dll

using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime;
using System.Runtime.InteropServices;
using System.Windows.Forms.Layout;

namespace System.Windows.Forms
{
    [ComVisible(true)]
    [ClassInterface(ClassInterfaceType.AutoDispatch)]
    [Designer(
        "System.Windows.Forms.Design.ScrollableControlDesigner, System.Design, Version=4.0.0.0, Culture=neutral, PublicKeyToken=b03f5f7f11d50a3a"
        )]
    public class ScrollableControl : Control, IArrangedElement, IComponent, IDisposable
    {
        protected const int ScrollStateAutoScrolling = 1;
        protected const int ScrollStateHScrollVisible = 2;
        protected const int ScrollStateVScrollVisible = 4;
        protected const int ScrollStateUserHasScrolled = 8;
        protected const int ScrollStateFullDrag = 16;
        public ScrollableControl();

        [Localizable(true)]
        [DefaultValue(false)]
        public virtual bool AutoScroll { [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        get; set; }

        [Localizable(true)]
        public Size AutoScrollMargin { [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        public Point AutoScrollPosition { get; set; }

        [Localizable(true)]
        public Size AutoScrollMinSize { [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        get; set; }

        protected override CreateParams CreateParams { get; }

        #region IArrangedElement Members

        public override Rectangle DisplayRectangle { get; }

        #endregion

        protected bool HScroll { [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        get; [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        set; }

        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Always)]
        public HScrollProperties HorizontalScroll { get; }

        protected bool VScroll { [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        get; [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
        set; }

        [EditorBrowsable(EditorBrowsableState.Always)]
        [Browsable(false)]
        public VScrollProperties VerticalScroll { get; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        [Browsable(false)]
        [EditorBrowsable(EditorBrowsableState.Never)]
        public ScrollableControl.DockPaddingEdges DockPadding { get; }

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected virtual void AdjustFormScrollbars(bool displayScrollbars);

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected bool GetScrollState(int bit);

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected override void OnLayout(LayoutEventArgs levent);

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected override void OnMouseWheel(MouseEventArgs e);

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected override void OnRightToLeftChanged(EventArgs e);

        protected override void OnPaintBackground(PaintEventArgs e);
        protected override void OnPaddingChanged(EventArgs e);

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected override void OnVisibleChanged(EventArgs e);

        [EditorBrowsable(EditorBrowsableState.Never)]
        protected override void ScaleCore(float dx, float dy);

        protected override void ScaleControl(SizeF factor, BoundsSpecified specified);
        protected void SetDisplayRectLocation(int x, int y);
        public void ScrollControlIntoView(Control activeControl);
        protected virtual Point ScrollToControl(Control activeControl);
        protected virtual void OnScroll(ScrollEventArgs se);
        public void SetAutoScrollMargin(int x, int y);
        protected void SetScrollState(int bit, bool value);

        [EditorBrowsable(EditorBrowsableState.Advanced)]
        protected override void WndProc(ref Message m);

        public event ScrollEventHandler Scroll;

        #region Nested type: DockPaddingEdges

        [TypeConverter(typeof (ScrollableControl.DockPaddingEdgesConverter))]
        public class DockPaddingEdges : ICloneable
        {
            [RefreshProperties(RefreshProperties.All)]
            public int All { get; set; }

            [RefreshProperties(RefreshProperties.All)]
            public int Bottom { get; set; }

            [RefreshProperties(RefreshProperties.All)]
            public int Left { get; set; }

            [RefreshProperties(RefreshProperties.All)]
            public int Right { get; set; }

            [RefreshProperties(RefreshProperties.All)]
            public int Top { get; set; }

            #region ICloneable Members

            object ICloneable.Clone();

            #endregion

            public override bool Equals(object other);
            public override int GetHashCode();
            public override string ToString();
        }

        #endregion

        #region Nested type: DockPaddingEdgesConverter

        public class DockPaddingEdgesConverter : TypeConverter
        {
            [TargetedPatchingOptOut("Performance critical to inline this type of method across NGen image boundaries")]
            public DockPaddingEdgesConverter();

            public override PropertyDescriptorCollection GetProperties(ITypeDescriptorContext context, object value,
                                                                       Attribute[] attributes);

            public override bool GetPropertiesSupported(ITypeDescriptorContext context);
        }

        #endregion
    }
}
