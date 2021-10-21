﻿using System.Collections.Generic;
using System.Windows;
using System.Windows.Automation.Peers;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Shapes;

namespace ZoomAndPanSample
{
    /// <summary>
    /// Interaction logic for ZoomAndPanControlView.xaml
    /// </summary>
    public partial class ZoomAndPanControlView : UserControl
    {
        public Canvas GetCanvas()
        {
            return this.prancha;
        }
        public void Populate(List<UIElement> uIElements, double width = 1500, double height = 1500)
        {
            this.prancha.Children.Clear();
            this.prancha.Width = width;
            this.prancha.Height = height;
            foreach(var obj in uIElements)
            {
                this.prancha.Children.Add(obj);
            }
            ZoomExtend();
        }
        public void Clear()
        {
            this.prancha.Children.Clear();
        }
        public void ZoomExtend()
        {
            this.ZoomAndPanControl.ZoomExtend();
        }

        public ZoomAndPanControlView()
        {
            InitializeComponent();
            GotFocus += (sender, args) => Keyboard.Focus(ZoomAndPanControl);
        }
        public void Set(List<UIElement> objs)
        {
            this.prancha.Children.Clear();

            foreach(var s in objs)
            {
                this.prancha.Children.Add(s);
            }


        }
        /// <summary>
        ///     Specifies the current state of the mouse handling logic.
        /// </summary>
        private bool _mouseDragging;

        /// <summary>
        ///     The point that was clicked relative to the content that is contained within the ZoomAndPanControl.
        /// </summary>
        private Point _origContentMouseDownPoint;
        
        /// <summary>
        ///     Event raised when a mouse button is clicked down over a Rectangle.
        /// </summary>
        private void Rectangle_MouseDown(object sender, MouseButtonEventArgs e)
        {
            prancha.Focus();
            Keyboard.Focus(prancha);

            if ((Keyboard.Modifiers & ModifierKeys.Shift) != 0)
            {
                //
                // When the shift key is held down special zooming logic is executed in content_MouseDown,
                // so don't handle mouse input here.
                //
                return;
            }

            if (_mouseDragging) return;
            _mouseDragging = true;
            _origContentMouseDownPoint = e.GetPosition(prancha);
            ((Rectangle)sender).CaptureMouse();
            e.Handled = true;
        }

        /// <summary>
        ///     Event raised when a mouse button is released over a Rectangle.
        /// </summary>
        private void Rectangle_MouseUp(object sender, MouseButtonEventArgs e)
        {
            if (!_mouseDragging) return;
            _mouseDragging = false;
            ((Rectangle)sender).ReleaseMouseCapture();
            e.Handled = true;
        }

        /// <summary>
        ///     Event raised when the mouse cursor is moved when over a Rectangle.
        /// </summary>
        private void Rectangle_MouseMove(object sender, MouseEventArgs e)
        {
            if (!_mouseDragging) return;

            var curContentPoint = e.GetPosition(prancha);
            var rectangleDragVector = curContentPoint - _origContentMouseDownPoint;

            //
            // When in 'dragging rectangles' mode update the position of the rectangle as the user drags it.
            //

            _origContentMouseDownPoint = curContentPoint;

            var rectangle = (Rectangle)sender;
            Canvas.SetLeft(rectangle, Canvas.GetLeft(rectangle) + rectangleDragVector.X);
            Canvas.SetTop(rectangle, Canvas.GetTop(rectangle) + rectangleDragVector.Y);

            e.Handled = true;
        }
    }
}
