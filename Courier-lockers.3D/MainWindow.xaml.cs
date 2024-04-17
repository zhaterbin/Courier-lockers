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
            Closed += (s, e) => process.Close();
        }

        private async void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            HwndSource hwndSource = (HwndSource)PresentationSource.FromVisual(panel);
            var h = hwndSource.Handle;
            process = new Process();
            process.StartInfo.FileName = "Repository.exe";
            process.StartInfo.Arguments = "-parentHWND " + h.ToString() + " " + Environment.CommandLine;
            process.StartInfo.UseShellExecute = true;
            process.StartInfo.CreateNoWindow = true;
            process.Start();
            await Task.Delay(1000);
            EnumChildWindows(h, WindowEnum, IntPtr.Zero);
        }

        [DllImport("user32.dll")]
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

        private int WindowEnum(IntPtr hwnd, IntPtr lparam)
        {
            unityHWND = hwnd;
            MoveWindow(unityHWND, 0, 0, 500, 300, true);
            return 0;
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

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            MoveWindow(unityHWND, 60, 60, 300, 100, true);
            //ActivateUnityWindow();
        }
        
    }
}
