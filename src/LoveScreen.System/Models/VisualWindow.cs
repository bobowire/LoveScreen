﻿using LoveScreen.Windows.Enums;
using LoveScreen.Windows.SystemDll;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace LoveScreen.Windows.Models
{
    public interface IVisualWindow
    {
        bool IsAlive { get; }

        bool IsVisible { get; }

        bool IsMaximized { get; }

        IntPtr Handle { get; }

        string Title { get; }

        Rectangle Rectangle { get; }
    }
    class VisualWindow : IVisualWindow
    {
        /// <summary>
        /// Creates a new instance of <see cref="VisualWindow"/>.
        /// </summary>
        /// <param name="Handle">The Window Handle.</param>
        public VisualWindow(IntPtr Handle)
        {
            if (!User32.IsWindow(Handle))
                throw new ArgumentException("Not a Window.", nameof(Handle));

            this.Handle = Handle;
        }

        public bool IsAlive => User32.IsWindow(Handle);

        /// <summary>
        /// Gets whether the Window is Visible.
        /// </summary>
        public bool IsVisible => User32.IsWindowVisible(Handle);

        public bool IsMaximized => User32.IsZoomed(Handle);

        /// <summary>
        /// Gets the Window Handle.
        /// </summary>
        public IntPtr Handle { get; }

        /// <summary>
        /// Gets the Window Title.
        /// </summary>
        public string Title
        {
            get
            {
                var title = new StringBuilder(User32.GetWindowTextLength(Handle) + 1);
                User32.GetWindowText(Handle, title, title.Capacity);
                return title.ToString();
            }
        }

        /// <summary>
        /// Get the Window Rectangle
        /// </summary>
        public Rectangle Rectangle
        {
            get
            {
                var r = new RECT();

                const int extendedFrameBounds = 9;

                if (DwmApi.DwmGetWindowAttribute(Handle, extendedFrameBounds, ref r, Marshal.SizeOf<RECT>()) != 0)
                {
                    if (!User32.GetWindowRect(Handle, out r))
                        return Rectangle.Empty;
                }

                return r.ToRectangle();
            }
        }

        /// <summary>
        /// Gets the Desktop Window.
        /// </summary>
        public static VisualWindow DesktopWindow { get; } = new VisualWindow(User32.GetDesktopWindow());

        /// <summary>
        /// Gets the Foreground Window.
        /// </summary>
        public static VisualWindow ForegroundWindow => new VisualWindow(User32.GetForegroundWindow());

        /// <summary>
        /// Enumerates all Windows.
        /// </summary>
        public static IEnumerable<VisualWindow> Enumerate()
        {
            var list = new List<VisualWindow>();

            User32.EnumWindows((Handle, Param) =>
            {
                var wh = new VisualWindow(Handle);

                list.Add(wh);

                return true;
            }, IntPtr.Zero);

            return list;
        }

        public IEnumerable<VisualWindow> EnumerateChildren()
        {
            var list = new List<VisualWindow>();

            User32.EnumChildWindows(Handle, (Handle, Param) =>
            {
                var wh = new VisualWindow(Handle);

                list.Add(wh);

                return true;
            }, IntPtr.Zero);

            return list;
        }

        /// <summary>
        /// Enumerates all visible windows with a Title.
        /// </summary>
        public static IEnumerable<VisualWindow> EnumerateVisible()
        {
            foreach (var window in Enumerate().Where(W => W.IsVisible && !string.IsNullOrWhiteSpace(W.Title)))
            {
                var hWnd = window.Handle;

                if (!User32.GetWindowLong(hWnd, GetWindowLongValue.ExStyle).HasFlag(WindowStyles.AppWindow))
                {
                    if (User32.GetWindow(hWnd, GetWindowEnum.Owner) != IntPtr.Zero)
                        continue;

                    if (User32.GetWindowLong(hWnd, GetWindowLongValue.ExStyle).HasFlag(WindowStyles.ToolWindow))
                        continue;

                    if (User32.GetWindowLong(hWnd, GetWindowLongValue.Style).HasFlag(WindowStyles.Child))
                        continue;
                }

                const int dwmCloaked = 14;

                // Exclude suspended Windows apps
                DwmApi.DwmGetWindowAttribute(hWnd, dwmCloaked, out var cloaked, Marshal.SizeOf<bool>());

                if (cloaked)
                    continue;

                yield return window;
            }
        }

        /// <summary>
        /// Returns the Widow Title.
        /// </summary>
        public override string ToString() => Title;

        /// <summary>
        /// Determines whether the specified object is equal to the current object.
        /// </summary>
        /// <returns>
        /// true if the specified object  is equal to the current object; otherwise, false.
        /// </returns>
        /// <param name="Obj">The object to compare with the current object. </param>
        public override bool Equals(object Obj) => Obj is VisualWindow w && w.Handle == Handle;

        /// <summary>
        /// Serves as the default hash function. 
        /// </summary>
        /// <returns>
        /// A hash code for the current object.
        /// </returns>
        public override int GetHashCode() => Handle.GetHashCode();

        /// <summary>
        /// Checks whether two <see cref="VisualWindow"/> instances are equal.
        /// </summary>
        public static bool operator ==(VisualWindow W1, VisualWindow W2) => W1?.Handle == W2?.Handle;

        /// <summary>
        /// Checks whether two <see cref="VisualWindow"/> instances are not equal.
        /// </summary>
        public static bool operator !=(VisualWindow W1, VisualWindow W2) => !(W1 == W2);
    }
}