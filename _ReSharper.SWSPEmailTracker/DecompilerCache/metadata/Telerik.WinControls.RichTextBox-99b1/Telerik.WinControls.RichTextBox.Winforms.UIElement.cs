// Type: Telerik.WinControls.RichTextBox.Winforms.UIElement
// Assembly: Telerik.WinControls.RichTextBox, Version=2011.2.11.712, Culture=neutral, PublicKeyToken=5bb2a467cbec794e
// Assembly location: C:\Program Files (x86)\Telerik\RadControls for WinForms Q2 2011\Bin\Net40\Telerik.WinControls.RichTextBox.dll

using System;
using System.Drawing;
using System.Windows.Forms;
using Telerik.WinControls;
using Telerik.WinControls.RichTextBox.Base;

namespace Telerik.WinControls.RichTextBox.Winforms
{
    public class UIElement : RadDependencyObject
    {
        protected const int IsTabStopStateKey = 1;
        protected const int StreatchVerticallyStateKey = 2;
        protected const int StreatchHorizontallyStateKey = 4;
        protected const int RightToLeftStateKey = 8;
        protected const int MeasureDirtyStateKey = 16;
        protected const int MeasureInProgressStateKey = 32;
        protected const int ArrangeDirtyStateKey = 64;
        protected const int ArrangeInProgressStateKey = 128;
        protected const int NeverMeasuredProgressStateKey = 256;
        public static RadDependencyProperty ZIndexProperty;
        public static RadDependencyProperty VisibilityProperty;
        public UIElement();
        public int ZIndex { get; set; }
        public ElementVisibility Visibility { get; set; }
        public virtual bool IsHitTestVisible { get; set; }
        public bool RightToLeft { get; set; }
        public bool StretchVertically { get; set; }
        public bool StretchHorizontally { get; set; }
        public Thickness Margin { get; set; }
        public SizeF Size { get; set; }
        public UIElementCollection Children { get; }
        public UIElementZOrderCollection ZOrderChildren { get; }
        public Brush Background { get; set; }
        public Brush BorderBrush { get; set; }
        public bool IsTabStop { get; set; }
        public float ActualHeight { get; }
        public float ActualWidth { get; }
        public RectangleF ControlBoundingRectangle { get; }
        public SizeF DesiredSize { get; }
        public ContentAlignment Alignment { get; set; }
        public UIElementTree Tree { get; internal set; }
        public UIElement Parent { get; internal set; }
        public Cursor Cursor { get; set; }
        public float Opacity { get; set; }
        public object Tag { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        protected UIElementLayoutContext LayoutContext { get; }
        protected bool MeasureDirty { get; set; }
        protected bool MeasureInProgress { get; set; }
        protected bool ArrangeDirty { get; set; }
        protected bool ArrangeInProgress { get; set; }
        protected bool NeverMeasured { get; set; }
        public static RadDependencyProperty NameProperty { get; set; }
        public Geometry Clip { get; set; }
        public string Name { get; set; }
        public Transform RenderTransform { get; set; }
        public bool UseLayoutRounding { get; set; }
        protected virtual void OnParentChanged();
        protected internal virtual void OnPreviewKeyDown(KeyEventArgs e);
        protected internal virtual void OnKeyDown(KeyEventArgs e);
        protected internal virtual void OnKeyUp(KeyEventArgs e);
        protected internal virtual void OnKeyPress(KeyPressEventArgs e);
        protected internal virtual void OnMouseDown(RadMouseEventArgs e);
        protected virtual void OnMouseLeftButtonDown(RadMouseEventArgs e);
        protected virtual void OnMouseRightButtonDown(RadMouseEventArgs e);
        protected virtual void OnMouseUp(RadMouseEventArgs e);
        protected virtual void OnMouseLeftButtonUp(RadMouseEventArgs e);
        protected virtual void OnMouseRightButtonUp(RadMouseEventArgs e);
        protected internal virtual void OnMouseMove(RadMouseEventArgs e);
        protected internal virtual void OnMouseEnter(RadMouseEventArgs e);
        protected internal virtual void OnMouseLeave(RadMouseEventArgs e);
        protected internal virtual void OnGotFocus(EventArgs e);
        protected internal virtual void OnLostFocus(EventArgs e);
        public void Focus();
        public void ReleaseMouseCapture();
        public bool CaptureMouse();
        public GeneralTransform TransformToVisual(UIElement visual);
        protected internal bool GetBitState(int key);
        protected internal virtual void SetBitState(int key, bool value);
        public void UpdateLayout();
        public void InvalidateArrange();
        public void InvalidateMeasure();
        public void Arrange(RectangleF finalRect);
        protected virtual void ArrangeCore(RectangleF finalRect);
        protected virtual SizeF ArrangeOverride(SizeF finalSize);
        public void Measure(SizeF availableSize);
        protected virtual SizeF MeasureOverride(SizeF availableSize);
        protected SizeF GetTransformSpaceBounds(SizeF size);
        protected virtual PointF CalcLayoutOffset(PointF startPoint);
        public virtual void OnApplyTemplate();
        public void Paint(IPaintingContext context);
        protected virtual bool CanPaint(IPaintingContext context);
        protected virtual void PaintCore(IPaintingContext context);
        public event KeyEventHandler PreviewKeyDown;
        public event KeyEventHandler KeyDown;
        public event KeyEventHandler KeyUp;
        public event KeyPressEventHandler KeyPress;
        public event RadMouseEventHandler MouseDown;
        public event RadMouseEventHandler MouseLeftButtonDown;
        public event RadMouseEventHandler MouseRightButtonDown;
        public event RadMouseEventHandler MouseUp;
        public event RadMouseEventHandler MouseLeftButtonUp;
        public event RadMouseEventHandler MouseRightButtonUp;
        public event RadMouseEventHandler MouseMove;
        public event RadMouseEventHandler MouseEnter;
        public event RadMouseEventHandler MouseLeave;
        public event EventHandler GotFocus;
        public event EventHandler LostFocus;
    }
}
