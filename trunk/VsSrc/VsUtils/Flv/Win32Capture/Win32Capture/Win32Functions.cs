using System;
using System.Collections.Generic;
using System.Text;
using System.Runtime.InteropServices;

namespace Win32Capture
{
    public delegate bool Win32Callback(int h, int lParam);

    public delegate int HookProc(int nCode, IntPtr wParam, IntPtr lParam);

    internal delegate bool enumWndCallBack(int h, int lParam);

    public delegate void GetWindowsCallback(ApplicationWindows window);

    class Win32Functions
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct RECT
        {
            public int left;
            public int top;
            public int right;
            public int bottom;

        }

        [StructLayout(LayoutKind.Sequential)]
        public struct POINT
        {
            public int x;
            public int y;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct CURSORINFO
        {
            public int cbSize;
            public int cbInfo;
            public IntPtr hCursor;
            public POINT point;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct PICONINFO
        {
            public bool fIcon;
            public int xHotSpot;
            public int yHotSpot;
            public IntPtr hbmMask;
            public IntPtr hbmColor;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct TITLEBARAINFO
        {
            public const int CCHILDREN_TITLEBAR = 5;
            public int cbSize;
            public RECT titleBarRect;
            [MarshalAs(UnmanagedType.ByValArray, SizeConst = CCHILDREN_TITLEBAR + 1)]
            public uint[] rgstate;
        }

        [StructLayout(LayoutKind.Sequential)]
        public struct WINDOWINFO
        {
            public int cbSize;
            public RECT rcWindow;
            public RECT rcClient;
            public int dwStyle;
            public int dwExStyle;
            public int dwWindowStatus;
            public uint cxWindowBorders;
            public uint cyWindowBorders;
            public ushort atomWindowType;
            public ushort wCreatorVersion;

        }
        
        


        [DllImport("user32.dll", CharSet = CharSet.Auto,
        CallingConvention = CallingConvention.StdCall)]
        public static extern int SetWindowsHookEx(int idHook, HookProc lpfn,
        IntPtr hInstance, int threadId);

        [DllImport("user32.dll", CharSet = CharSet.Auto,
        CallingConvention = CallingConvention.StdCall)]
        public static extern int CallNextHookEx(int idHook, int nCode,
        IntPtr wParam, IntPtr lParam);

        [DllImport("kernel32.dll")]
        public static extern int GetModuleHandle(string s);

        [DllImport("user32.dll")]
        public static extern bool UnhookWindowsHookEx(IntPtr id);

        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateCompatibleBitmap(IntPtr hdc,
            int nWidth, int nHeight);

        [DllImport("gdi32.dll")]
        public static extern IntPtr CreateCompatibleDC(IntPtr hdc);

        [DllImport("gdi32.dll")]
        public static extern IntPtr SelectObject(IntPtr hdc, IntPtr bmp);

        [DllImport("user32.dll")]
        public static extern int GetForegroundWindow();

        [DllImport("user32.dll")]
        public static extern int GetDesktopWindow();

        [DllImport("User32.dll")]
        public static extern int GetWindowRect(int h, ref RECT y);

        [DllImport("User32.dll")]
        public static extern int GetClientRect(int h, ref RECT y);

        [DllImport("gdi32.dll")]
        public static extern IntPtr DeleteDC(IntPtr hDc);

        [DllImport("gdi32.dll")]
        public static extern IntPtr DeleteObject(IntPtr hDc);

        [DllImport("gdi32.dll")]
        public static extern bool BitBlt(IntPtr hdcDest, int xDest,
            int yDest, int wDest, int hDest, IntPtr hdcSource,
            int xSrc, int ySrc, uint RasterOp);

        [DllImport("gdi32.dll")]
        public static extern bool StretchBlt(IntPtr hdcDest, int xDest,
            int yDest, int wDest, int hDest, IntPtr hdcSource,
            int xSrc, int ySrc, int wSource, int hSource, uint RasterOp);

        [DllImport("user32.dll")]
        public static extern IntPtr GetWindowDC(Int32 ptr);

        [DllImport("user32.dll")]
        public static extern IntPtr ReleaseDC(IntPtr hWnd, IntPtr hDc);

        [DllImport("user32.dll")]
        public static extern bool EnumWindows(enumWndCallBack callback, int lParam);

        [DllImport("User32.Dll")]
        public static extern void GetWindowText(int h, StringBuilder s, int nMaxCount);

        [DllImport("User32.Dll")]
        public static extern bool IsWindowVisible(int hwnd);

        [DllImport("Gdi32.Dll")]
        public static extern int GetBitmapBits(IntPtr hbitmap, int bytesToCopy, [Out]byte[] buffer);

       // [DllImport("Gdi32.Dll")]
      //  public static extern int GetDIBits(IntPtr hDc, IntPtr hBitmap, int scanLine, int endScanLine, [Out]byte[] buffer, ref BITMAPINFOHEADER info, int usage);

        [DllImport("kernel32.Dll")]
        public static extern int GetLastError();

        [DllImport("user32.Dll")]
        public static extern int GetClassLong(IntPtr hWnd, int nIndex);

        [DllImport("user32.Dll")]
        public static extern int SendMessage(int hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.Dll")]
        public static extern int SendMessageTimeout(int hWnd, int Msg, int wParam, int lParam, int fuFlags, int uTimeout,
           out int lpdwResult);

        [DllImport("user32.Dll")]
        public static extern bool GetCursorPos(ref POINT point);

        [DllImport("user32.Dll")]
        public static extern int GetCursor();
        [DllImport("user32.Dll")]
        public static extern bool GetCursorInfo(ref CURSORINFO cInfo);

        [DllImport("user32.Dll")]
        public static extern bool GetIconInfo(IntPtr cInfo, ref PICONINFO pInfo);

        [DllImport("user32.Dll")]
        public static extern bool DrawIconEx(IntPtr hdcDest, int x, int y, int icon, int w, int h, int ptr, int a, int f);

        [DllImport("user32.Dll")]
        public static extern bool GetTitleBarInfo(int hwnd, ref TITLEBARAINFO info);

        [DllImport("user32.Dll")]
        public static extern bool GetWindowInfo(int hwnd, ref WINDOWINFO info);



    }

}
