using System;
using System.Collections.Generic;
using System.Text;
using System.Drawing;
using System.ComponentModel;
using System.Runtime.InteropServices;
using System.Threading;
using System.Diagnostics;
using System.Windows.Forms;

namespace Win32Capture
{
    /// <summary>
    /// Delegate / callback function to call.
    /// </summary>
    /// <param name="picture">The bitmap of the screen captured.</param>
    /// <param name="windowTitle">The Window's title captured</param>
    /// <param name="type">The method the capture was invoked</param>
    public delegate void CaptureProc(Image capture);


    public class CaptureControl
    {
        public const int KeyStrokeUsed = 0;

        public const int mouse_transparent = 254;

        public const int CaptureFormUsed = 1;

        private HookProc keyHook;

        private CaptureProc callBack;

        private int hKeyHook;

        private bool keysChanged = true;

        private bool psDown = false;

        private bool ctrlDown = false;

        private bool altDown = false;



        /// <summary>
        /// The method which will be called after an event occurs
        /// (ie screen capture with keys, or capture button is pressed).
        /// </summary>
        [Description("The callback function to send the Image to when " +
            "a screen is captured.")]
        public CaptureProc CallBackFunction
        {
            get
            {
                return callBack;
            }

            set
            {
                callBack = value;
            }
        }
        public void SetActive()
        {
            keyHook = new HookProc(KeyHook);
            using (Process curProcess = Process.GetCurrentProcess())
            using (ProcessModule curModule = curProcess.MainModule)
            {
                hKeyHook = Win32Functions.SetWindowsHookEx(Win32Defines.WH_KEYBOARD_LL,
                    keyHook, (IntPtr)Win32Functions.GetModuleHandle(curModule.ModuleName), 0);
            }
        }

        public void SetInactive()
        {
            Win32Functions.UnhookWindowsHookEx((IntPtr)hKeyHook);
        }

        private bool captureWindow()
        {
            return !(psDown && ctrlDown && !altDown);
        }

        /// <summary>
        /// Determines whether or not we should take another screenshot
        /// </summary>
        /// <returns>True to continue, false don't continue</returns>
        private bool canContinue()
        {
            return keysChanged;
        }

        private bool isAnimate()
        {
            return (psDown && ctrlDown && altDown);
        }

        /// <summary>
        /// Callback for the SetHookEx function
        /// </summary>
        /// <param name="nCode"></param>
        /// <param name="wParam"></param>
        /// <param name="lParam"></param>
        /// <returns></returns>
        public int KeyHook(int nCode, IntPtr wParam, IntPtr lParam)
        {
            
            keysChanged = false;
            if (nCode < 0)
            {
                return Win32Functions.CallNextHookEx(hKeyHook, nCode, wParam, lParam);
            }
            else
            {
                int vkCode = Marshal.ReadInt32(lParam);

                
                //handle key up/key down
                if (wParam == (IntPtr)Win32Defines.WM_KEYDOWN || wParam == (IntPtr)Win32Defines.WM_SYSKEYDOWN)
                {
                    if (vkCode == Key.VK_CONTROL)
                    {
                        ctrlDown = true;
                    }

                    else if (vkCode == Key.VK_SNAPSHOT)
                    {
                        if (!psDown)
                        {
                            psDown = true;
                            keysChanged = true;
                        }
                    }

                    else if (vkCode == Key.VK_ALT)
                    {
                        
                        altDown = true;
                    }
                }
                else if (wParam == (IntPtr)Win32Defines.WM_KEYUP || wParam == (IntPtr)Win32Defines.WM_SYSKEYUP)
                {

                    if (vkCode == Key.VK_CONTROL)
                    {
                        ctrlDown = false;
                    }
                    if (vkCode == Key.VK_SNAPSHOT)
                    {
                        psDown = false;
                    }
                    if (vkCode == Key.VK_ALT)
                    {
                        altDown = false;
                    }
                }


                //make sure a key was down to continue...
                if ((wParam == (IntPtr)Win32Defines.WM_KEYDOWN || wParam == (IntPtr)Win32Defines.WM_SYSKEYDOWN) && canContinue()
                    && vkCode == Key.VK_SNAPSHOT)
                {
                    Image img = null;
                    if (captureWindow())
                    {
                    
                        Win32Functions.RECT windowRect = new Win32Functions.RECT();
                        //get the top level window!!

                        IntPtr hWnd = new IntPtr(Win32Functions.GetForegroundWindow());
                        IntPtr hdcSrc = Win32Functions.GetWindowDC((int)hWnd);

                        Win32Functions.GetWindowRect((int)hWnd, ref windowRect);
                        // create a bitmap from the visible clipping bounds of 
                        //the graphics object from the window
                        int width = windowRect.right - windowRect.left;
                        int height = windowRect.bottom - windowRect.top;
                        // create a device context we can copy to
                        IntPtr hdcDest = Win32Functions.CreateCompatibleDC(hdcSrc);
                        // create a bitmap we can copy it to,
                        // using GetDeviceCaps to get the width/height
                        IntPtr hBitmap = Win32Functions.CreateCompatibleBitmap(hdcSrc, width, height);
                        // select the bitmap object
                        IntPtr hOld = Win32Functions.SelectObject(hdcDest, hBitmap);
                        // bitblt over
                        Win32Functions.BitBlt(hdcDest, 0, 0, width, height, hdcSrc, 0, 0, Win32Defines.SRCCOPY);
                        // restore selection
                        Win32Functions.SelectObject(hdcDest, hOld);
                        // clean up 
                        Win32Functions.DeleteDC(hdcDest);
                        Win32Functions.ReleaseDC(hWnd, hdcSrc);
                        // get a .NET image object for it
                        img = Image.FromHbitmap(hBitmap);
                        // free up the Bitmap object
                        Win32Functions.DeleteObject(hBitmap);
                    }
                    else
                    {
                        Win32Functions.RECT windowRect = new Win32Functions.RECT();
                        //get the top level window!!

                        IntPtr hWnd = new IntPtr(Win32Functions.GetDesktopWindow());
                        IntPtr hdcSrc = Win32Functions.GetWindowDC((int)hWnd);

                        Win32Functions.GetWindowRect((int)hWnd, ref windowRect);
                        // create a bitmap from the visible clipping bounds of 
                        //the graphics object from the window
                        int width = windowRect.right - windowRect.left;
                        int height = windowRect.bottom - windowRect.top;
                        // create a device context we can copy to
                        IntPtr hdcDest = Win32Functions.CreateCompatibleDC(hdcSrc);
                        // create a bitmap we can copy it to,
                        // using GetDeviceCaps to get the width/height
                        IntPtr hBitmap = Win32Functions.CreateCompatibleBitmap(hdcSrc, width, height);
                        // select the bitmap object
                        IntPtr hOld = Win32Functions.SelectObject(hdcDest, hBitmap);
                        // bitblt over
                        Win32Functions.BitBlt(hdcDest, 0, 0, width, height, hdcSrc, 0, 0, Win32Defines.SRCCOPY);
                        // restore selection
                        Win32Functions.SelectObject(hdcDest, hOld);
                        // clean up 
                        Win32Functions.DeleteDC(hdcDest);
                        Win32Functions.ReleaseDC(hWnd, hdcSrc);
                        // get a .NET image object for it
                        img = Image.FromHbitmap(hBitmap);
                        // free up the Bitmap object
                        Win32Functions.DeleteObject(hBitmap);
                    }

                    callBack(img);

                }
              
                return Win32Functions.CallNextHookEx(hKeyHook, nCode, wParam, lParam);
            }
        }

        public Bitmap captureWindowBit(int HWND)
        {
            Win32Functions.RECT windowRect = new Win32Functions.RECT();

            IntPtr hWnd = new IntPtr(HWND);

            IntPtr hdcSrc = Win32Functions.GetWindowDC((int)hWnd);

            Win32Functions.GetWindowRect((int)hWnd, ref windowRect);
            
            // create a bitmap from the visible clipping bounds of 
            //the graphics object from the window

            int width = windowRect.right - windowRect.left;

            int height = windowRect.bottom - windowRect.top;
            
            // create a device context we can copy to
            IntPtr hdcDest = Win32Functions.CreateCompatibleDC(hdcSrc);
           
            // create a bitmap we can copy it to,
            // using GetDeviceCaps to get the width/height
            IntPtr hBitmap = Win32Functions.CreateCompatibleBitmap(hdcSrc, width, height);
            
            // select the bitmap object
            IntPtr hOld = Win32Functions.SelectObject(hdcDest, hBitmap);
            
            // bitblt over
            Win32Functions.BitBlt(hdcDest, 0, 0, width, height, hdcSrc, 0, 0,
             Win32Defines.SRCCOPY);

            
            // restore selection
            Win32Functions.SelectObject(hdcDest, hOld);
            
            // clean up 
            Win32Functions.DeleteDC(hdcDest);
            Win32Functions.ReleaseDC(hWnd, hdcSrc);
            
            // get a .NET Bitmap object for it
            Bitmap bmp = new Bitmap(Image.FromHbitmap(hBitmap), new Size(width, height));
            
            // free up the Bitmap object
            Win32Functions.DeleteObject(hBitmap);

            return bmp;


        }

        public Bitmap captureClientBit(int HWND)
        {
            Win32Functions.RECT windowRect = new Win32Functions.RECT();

            IntPtr hWnd = new IntPtr(HWND);

            IntPtr hdcSrc = Win32Functions.GetWindowDC((int)hWnd);

            Win32Functions.GetClientRect((int)hWnd, ref windowRect);

            Win32Functions.WINDOWINFO  window = new Win32Functions.WINDOWINFO();
            window.cbSize = System.Runtime.InteropServices.Marshal.SizeOf(window);
            
            Win32Functions.GetWindowInfo((int)hWnd, ref window);

            // create a bitmap from the visible clipping bounds of 
            //the graphics object from the window

            int width = windowRect.right - windowRect.left;

            int height = windowRect.bottom - windowRect.top;

            // create a device context we can copy to
            IntPtr hdcDest = Win32Functions.CreateCompatibleDC(hdcSrc);

            // create a bitmap we can copy it to,
            // using GetDeviceCaps to get the width/height
            IntPtr hBitmap = Win32Functions.CreateCompatibleBitmap(hdcSrc, width, height);

            // select the bitmap object
            IntPtr hOld = Win32Functions.SelectObject(hdcDest, hBitmap);

            // bitblt over
            Win32Functions.BitBlt(hdcDest, 0,
                0, width, height, hdcSrc, window.rcClient.left - window.rcWindow.left,
                window.rcClient.top - window.rcWindow.top,
              Win32Defines.SRCCOPY);


            // restore selection
            Win32Functions.SelectObject(hdcDest, hOld);

            // clean up 
            Win32Functions.DeleteDC(hdcDest);
            Win32Functions.ReleaseDC(hWnd, hdcSrc);

            // get a .NET Bitmap object for it
            Bitmap bmp = new Bitmap(Image.FromHbitmap(hBitmap), new Size(width, height));

            // free up the Bitmap object
            Win32Functions.DeleteObject(hBitmap);

            return bmp;


        }

        

        public byte[] captureClientBytes(int HWND, int pwidth, int pheight)
        {
            Win32Functions.RECT windowRect = new Win32Functions.RECT();

            IntPtr hWnd = new IntPtr(HWND);

            IntPtr hdcSrc = Win32Functions.GetWindowDC((int)hWnd);

            Win32Functions.GetClientRect((int)hWnd, ref windowRect);

            Win32Functions.WINDOWINFO window = new Win32Functions.WINDOWINFO();
            window.cbSize = System.Runtime.InteropServices.Marshal.SizeOf(window);

            Win32Functions.GetWindowInfo((int)hWnd, ref window);

            // create a device context we can copy to
            IntPtr hdcDest = Win32Functions.CreateCompatibleDC(hdcSrc);

            // create a bitmap we can copy it to,
            // using GetDeviceCaps to get the width/height
            IntPtr hBitmap = Win32Functions.CreateCompatibleBitmap(hdcSrc, pwidth, pheight);

            //// select the bitmap object
            IntPtr hOld = Win32Functions.SelectObject(hdcDest, hBitmap);

            // bitblt over
            Win32Functions.BitBlt(hdcDest, 0,
                0, pwidth, pheight, hdcSrc, window.rcClient.left - window.rcWindow.left,
                window.rcClient.top - window.rcWindow.top,
              (uint)(Win32Defines.SRCCOPY ));

            Win32Functions.CURSORINFO ci = new Win32Functions.CURSORINFO();
            ci.cbSize = System.Runtime.InteropServices.Marshal.SizeOf(ci);
            Win32Functions.GetCursorInfo(ref ci);
            Win32Functions.PICONINFO pi = new Win32Functions.PICONINFO();
            Win32Functions.GetIconInfo(ci.hCursor, ref pi);
            Win32Functions.DrawIconEx(hdcDest, ci.point.x - window.rcClient.left - pi.xHotSpot,
                ci.point.y - window.rcClient.top - pi.yHotSpot, (int)ci.hCursor, 0, 0, 0, 0, 3);
            Win32Functions.SelectObject(hdcDest, hOld);
            Win32Functions.ReleaseDC(hWnd, hdcDest);
            Win32Functions.DeleteDC(hdcDest);
            Win32Functions.ReleaseDC(hWnd, hdcSrc);

            byte[] b = new byte[(pwidth * pheight * 4)];

            Win32Functions.GetBitmapBits(hBitmap, (pwidth * pheight * 4), b);

            Win32Functions.DeleteObject(hBitmap);

            return b;
        }

        /// <summary>
        /// Returns a rectangle representing the X,Y, and width of the given window specified
        /// by the HWND parameter.
        /// </summary>
        /// <param name="HWND">The Handle of the window to retrieve information about.</param>
        /// <param name="client">If true, it returns the rectangle representing the client area (no menu or titlebar), false
        /// returns the rectangle representing the window border and menus.</param>
        /// <returns></returns>
        public Rectangle getWindowDimensions(int HWND, bool client)
        {
            Rectangle winRect = new Rectangle();
            Win32Functions.WINDOWINFO window = new Win32Functions.WINDOWINFO();
            window.cbSize = System.Runtime.InteropServices.Marshal.SizeOf(window);
            Win32Functions.GetWindowInfo(HWND, ref window);

            if (!client)
            {
                winRect.X = window.rcWindow.left;
                winRect.Y = window.rcWindow.top;
                winRect.Width = window.rcWindow.right - window.rcWindow.left;
                winRect.Height = window.rcWindow.bottom - window.rcWindow.top;

            }
            else
            {
                winRect.X = window.rcClient.left;
                winRect.Y = window.rcClient.top;
                winRect.Width = window.rcClient.right - window.rcClient.left;
                winRect.Height = window.rcClient.bottom - window.rcClient.top;
            }

            return winRect;

        }

        public byte[] captureDesktopBytes()
        {
            Win32Functions.RECT windowRect = new Win32Functions.RECT();

            IntPtr hWnd = new IntPtr(Win32Functions.GetDesktopWindow());

            IntPtr hdcSrc = Win32Functions.GetWindowDC((int)hWnd);

            Win32Functions.WINDOWINFO window = new Win32Functions.WINDOWINFO();
            window.cbSize = System.Runtime.InteropServices.Marshal.SizeOf(window);

            Win32Functions.GetWindowRect((int)hWnd, ref windowRect);

            Win32Functions.GetWindowInfo((int)hWnd, ref window);

            // create a bitmap from the visible clipping bounds of 
            //the graphics object from the window

            int width = windowRect.right - windowRect.left;

            int height = windowRect.bottom - windowRect.top;

            // create a device context we can copy to
            IntPtr hdcDest = Win32Functions.CreateCompatibleDC(hdcSrc);

            // create a bitmap we can copy it to,
            // using GetDeviceCaps to get the width/height
            IntPtr hBitmap = Win32Functions.CreateCompatibleBitmap(hdcSrc, width, height);

            //// select the bitmap object
            IntPtr hOld = Win32Functions.SelectObject(hdcDest, hBitmap);

            // bitblt over
            Win32Functions.BitBlt(hdcDest, 0, 0, width, height, hdcSrc, 0, 0,
            Win32Defines.SRCCOPY);
            Win32Functions.CURSORINFO ci = new Win32Functions.CURSORINFO();
            ci.cbSize = System.Runtime.InteropServices.Marshal.SizeOf(ci);
            Win32Functions.GetCursorInfo(ref ci);
            Win32Functions.PICONINFO pi = new Win32Functions.PICONINFO();
            Win32Functions.GetIconInfo(ci.hCursor, ref pi);
            Win32Functions.DrawIconEx(hdcDest, ci.point.x - windowRect.left - pi.xHotSpot, ci.point.y - windowRect.top - pi.yHotSpot, (int)ci.hCursor, 0, 0, 0, 0, 3);
            Win32Functions.SelectObject(hdcDest, hOld);
            Win32Functions.ReleaseDC(hWnd, hdcDest);
            Win32Functions.DeleteDC(hdcDest);
            Win32Functions.ReleaseDC(hWnd, hdcSrc);

            byte[] b = new byte[(width * height * 4)];

            Win32Functions.GetBitmapBits(hBitmap, (width * height * 4), b);

            Win32Functions.DeleteObject(hBitmap);

            return b;
        }

        public Bitmap captureDesktopBitmap()
        {
            Win32Functions.RECT windowRect = new Win32Functions.RECT();

            IntPtr hWnd = new IntPtr(Win32Functions.GetDesktopWindow());

            IntPtr hdcSrc = Win32Functions.GetWindowDC((int)hWnd);

            Win32Functions.GetClientRect((int)hWnd, ref windowRect);

            Win32Functions.WINDOWINFO window = new Win32Functions.WINDOWINFO();
            window.cbSize = System.Runtime.InteropServices.Marshal.SizeOf(window);

            Win32Functions.GetWindowInfo((int)hWnd, ref window);

            // create a bitmap from the visible clipping bounds of 
            //the graphics object from the window

            int width = windowRect.right - windowRect.left;

            int height = windowRect.bottom - windowRect.top;

            // create a device context we can copy to
            IntPtr hdcDest = Win32Functions.CreateCompatibleDC(hdcSrc);

            // create a bitmap we can copy it to,
            // using GetDeviceCaps to get the width/height
            IntPtr hBitmap = Win32Functions.CreateCompatibleBitmap(hdcSrc, width, height);

            // select the bitmap object
            IntPtr hOld = Win32Functions.SelectObject(hdcDest, hBitmap);

            // bitblt over
            Win32Functions.BitBlt(hdcDest, 0,
                0, width, height, hdcSrc, window.rcClient.left - window.rcWindow.left,
                window.rcClient.top - window.rcWindow.top,
              Win32Defines.SRCCOPY);


            // restore selection
            Win32Functions.SelectObject(hdcDest, hOld);

            // clean up 
            Win32Functions.DeleteDC(hdcDest);
            Win32Functions.ReleaseDC(hWnd, hdcSrc);

            // get a .NET Bitmap object for it
            Bitmap bmp = new Bitmap(Image.FromHbitmap(hBitmap), new Size(width, height));

            // free up the Bitmap object
            Win32Functions.DeleteObject(hBitmap);

            return bmp;

        }

        public int GetDesktopWindow()
        {
            return Win32Functions.GetDesktopWindow();
        }
        


        public byte[] captureWindowBytes(int HWND, int pwidth, int pheight)
        {
            Win32Functions.RECT windowRect = new Win32Functions.RECT();

            IntPtr hWnd = new IntPtr(HWND);

            IntPtr hdcSrc = Win32Functions.GetWindowDC((int)hWnd);

            Win32Functions.GetWindowRect((int)hWnd, ref windowRect);

            // create a device context we can copy to
            IntPtr hdcDest = Win32Functions.CreateCompatibleDC(hdcSrc);

            // create a bitmap we can copy it to,
            // using GetDeviceCaps to get the width/height
            IntPtr hBitmap = Win32Functions.CreateCompatibleBitmap(hdcSrc, pwidth, pheight);

            //// select the bitmap object
            IntPtr hOld = Win32Functions.SelectObject(hdcDest, hBitmap);

            // bitblt over
            Win32Functions.BitBlt(hdcDest, 0, 0, pwidth, pheight, hdcSrc, 0, 0,
             (uint)(Win32Defines.SRCCOPY ));
            Win32Functions.CURSORINFO ci = new Win32Functions.CURSORINFO();
            ci.cbSize = System.Runtime.InteropServices.Marshal.SizeOf(ci);
            Win32Functions.GetCursorInfo(ref ci);
            Win32Functions.PICONINFO pi = new Win32Functions.PICONINFO();
            Win32Functions.GetIconInfo(ci.hCursor, ref pi);
            Win32Functions.DrawIconEx(hdcDest, ci.point.x - windowRect.left - pi.xHotSpot, ci.point.y - windowRect.top - pi.yHotSpot, (int)ci.hCursor, 0, 0, 0, 0, 3);
            Win32Functions.SelectObject(hdcDest, hOld);
            Win32Functions.ReleaseDC(hWnd, hdcDest);
            Win32Functions.DeleteDC(hdcDest);
            Win32Functions.ReleaseDC(hWnd, hdcSrc);

            byte[] b = new byte[(pwidth * pheight * 4)];

            Win32Functions.GetBitmapBits(hBitmap, (pwidth * pheight * 4), b);

            Win32Functions.DeleteObject(hBitmap);

            return b;


        }

        




    }


    public class ApplicationWindows
    {

        public string title;
        
        public int HWND;

        public static GetWindowsCallback func;

        public Bitmap icon;

        public ApplicationWindows(string title, int hwnd, Bitmap hIcon)
        {
            this.title = title;
            this.HWND = hwnd;
            this.icon = hIcon;
        }



        public static void getWindows(GetWindowsCallback callback_func)
        {

            func = callback_func;
            Win32Functions.EnumWindows(new enumWndCallBack(enumWndProc), 0);
        }

        public static bool enumWndProc(int hwnd, int lparam)
        {
            StringBuilder sb = new StringBuilder(1024);
            
            Win32Functions.GetWindowText(hwnd, sb, sb.Capacity);


            if (Win32Functions.IsWindowVisible(hwnd) && sb.ToString().Length > 0 )
            {
                Bitmap icon = null;

                int result = 0;

                IntPtr hIcon = (IntPtr)0;

                Win32Functions.SendMessageTimeout(hwnd, 0x007f, 1, 0, 0x0002,1000, out result);
                hIcon = new IntPtr(result);

                if (hIcon == IntPtr.Zero)
                {
                    Win32Functions.SendMessageTimeout(hwnd, 0x007f, 0, 0, 0x0002, 1000, out result);
                    hIcon = new IntPtr(result);
                }

                if (hIcon == IntPtr.Zero)
                {
                    hIcon = (IntPtr)Win32Functions.GetClassLong((IntPtr)hwnd, (-14));
    
                }

                if (hIcon == IntPtr.Zero)
                {
                    hIcon = (IntPtr)Win32Functions.GetClassLong((IntPtr)hwnd, (-34));

                }

                if (hIcon == IntPtr.Zero)
                {
    
    
                    Win32Functions.SendMessageTimeout(hwnd, 0x0037,
                    0,
                    0,
                    0x0002,
                    1000, out result);
                        hIcon = new IntPtr(result);

                }

                if ((int)hIcon > 1)
                {
                    try
                    {
                        icon = Bitmap.FromHicon(hIcon);
                    }
                    catch { }
                }
                else
                {
                    //use a default icon..
                }
                func.Invoke(new ApplicationWindows(sb.ToString(), hwnd, icon));
            }

            return true;
        }

        public override string ToString()
        {
            return this.title;
        }

    }
}
