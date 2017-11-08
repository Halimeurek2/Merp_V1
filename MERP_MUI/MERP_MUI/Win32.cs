using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.InteropServices;

namespace MERP_MUI
{
    internal class Win32
    {
        [DllImport("user32.dll", SetLastError = true)]
        public extern static bool UpdateLayeredWindow(IntPtr handle, IntPtr hdcDst, ref Point pptDst, ref Size pSize, IntPtr hDc, ref Point pptSrc, int crKey, ref BlendFunction pBlend, int dwFlags);

        [DllImport("user32.dll", ExactSpelling = false, SetLastError = true)]
        public extern static long SetWindowLong(IntPtr handle, int index, IntPtr dwNewLong);

        [DllImport("user32.dll", ExactSpelling = false, SetLastError = true)]
        public extern static IntPtr GetWindowLong(IntPtr handle, int index);

        [DllImport("user32.dll", SetLastError = true)]
        public extern static IntPtr GetDC(IntPtr handle);

        [DllImport("user32.dll", SetLastError = false)]
        public extern static int ReleaseDC(IntPtr hWnd, IntPtr hDc);

        [DllImport("user32.dll", SetLastError = false)]
        public extern static bool ReleaseCapture();

        [DllImport("user32.dll", SetLastError = true)]
        public extern static int SendMessage(IntPtr handle, int msg, int wparam, int lparam);

        [DllImport("user32.dll", SetLastError = false)]
        public extern static bool GetCursorPos(ref Point lpPoint);

        [DllImport("user32.dll", SetLastError = false)]
        public extern static short GetKeyState(int nVirtKey);

        [DllImport("user32.dll", SetLastError = false)]
        public extern static bool PtInRect(ref Rect lpRect, Point pt);

        [DllImport("user32.dll", ExactSpelling = false, SetLastError = false)]
        public extern static bool GetWindowRect(IntPtr handle, ref Rect rect);

        [DllImport("gdi32.dll", SetLastError = true)]
        public extern static IntPtr CreateCompatibleDC(IntPtr hDc);

        [DllImport("gdi32.dll", SetLastError = true)]
        public extern static bool DeleteDC(IntPtr hDc);

        [DllImport("gdi32.dll", SetLastError = false)]
        public extern static IntPtr SelectObject(IntPtr hDc, IntPtr hgdiObject);

        [DllImport("gdi32.dll", SetLastError = true)]
        public extern static bool DeleteObject(IntPtr hgdiObject);

        public struct Point
        {
            public int X;
            public int Y;
        }

        public struct Size
        {
            public int X;
            public int Y;
        }

        public struct Rect
        {
            public int Left;
            public int Top;
            public int Right;
            public int Bottom;
        }

        public struct BlendFunction
        {
            public byte BlendOp;
            public byte BlendFlags;
            public byte SourceConstantAlpha;
            public byte AlphaFormat;
        }

        public const byte AC_SRC_OVER = 0x00;
        public const byte AC_SRC_ALPHA = 0x01;
        public const int ULW_COLORKEY = 0x00000001;
        public const int ULW_ALPHA = 0x00000002;
        public const int WS_EX_LAYERED = 0x00080000;
        public const int WS_EX_TRANSPARENT = 0x00000020;
        public const int GWL_EXSTYLE = -20;
        public const int WM_SYSCOMMAND = 0x0112;
        public const int WM_PRINT = 791;
        public const int SC_DRAGMOVE = 0xf012;

        public const int PRF_CHECKVISIBLE = 1;
        public const int PRF_NONCLIENT = 2;
        public const int PRF_CLIENT = 4;
        public const int PRF_ERASEBKGND = 8;
        public const int PRF_CHILDREN = 0x10;
        public const int PRF_OWNED = 0x20;

        public const int VK_CONTROL = 0x11;

    }
}
