using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Courier_lockers._3D
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Loaded += MainWindow_Loaded;

        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            HwndSource hwndSource = (HwndSource)PresentationSource.FromVisual(panel);
            var h = hwndSource.Handle;

            IntPtr hwnd = h;
            process = new Process();
            process.StartInfo.FileName = "Courier Lockers.exe";

            process.StartInfo.Arguments = "-parentHWND " + hwnd.ToString() + " " + Environment.CommandLine;
            process.StartInfo.UseShellExecute = true;
            process.StartInfo.CreateNoWindow = true;

            process.Start();


            EnumChildWindows(hwnd, WindowEnum, IntPtr.Zero);
            panel1_Resize();
            // tcpClient = new(new IPEndPoint(IPAddress.Loopback, 10010));
            //tcpClient.Connect(new IPEndPoint(IPAddress.Loopback, 10001));

        }
        TcpClient tcpClient;
        [DllImport("User32.dll")]
        static extern bool MoveWindow(IntPtr handle, int x, int y, int width, int height, bool redraw);

        internal delegate int WindowEnumProc(IntPtr hwnd, IntPtr lparam);

        [DllImport("user32.dll")]
        internal static extern bool EnumChildWindows(IntPtr hwnd, WindowEnumProc func, IntPtr lParam);

        [DllImport("user32.dll")]
        static extern int SendMessage(IntPtr hWnd, int msg, IntPtr wParam, IntPtr lParam);

        private Process process;
        private IntPtr unityHWND = IntPtr.Zero;

        private const int WM_ACTIVATE = 0x0006;
        private readonly IntPtr WA_ACTIVE = new IntPtr(1);
        private readonly IntPtr WA_INACTIVE = new IntPtr(0);
        private void ActivateUnityWindow()
        {
            SendMessage(unityHWND, WM_ACTIVATE, WA_ACTIVE, IntPtr.Zero);
        }

        private void DeactivateUnityWindow()
        {
            SendMessage(unityHWND, WM_ACTIVATE, WA_INACTIVE, IntPtr.Zero);
        }

        private int WindowEnum(IntPtr hwnd, IntPtr lparam)
        {
            unityHWND = hwnd;
            ActivateUnityWindow();
            return 0;
        }

        private void panel1_Resize()
        {
            MoveWindow(unityHWND, 0, 0, Convert.ToInt32(panel.Width), Convert.ToInt32(panel.Height), true);
            ActivateUnityWindow();
        }

        private void ToggleButton_Checked(object sender, RoutedEventArgs e)
        {
            Socket socket = new(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(new IPEndPoint(IPAddress.Loopback, 10001));
            var buffer = Encoding.UTF8.GetBytes("0");
            socket.Send(buffer);
            socket.Dispose();
        }
        private void ToggleButton_Unchecked(object sender, RoutedEventArgs e)
        {
            Socket socket = new(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            socket.Connect(new IPEndPoint(IPAddress.Loopback, 10001));
            var buffer = Encoding.UTF8.GetBytes("1");
            socket.Send(buffer);
            socket.Dispose();
        }
    }
}
