using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Interop;
using System.Drawing;
using System.Windows.Forms;
namespace TakeMeToWork
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private static bool closingFromYesButton = false;
        private readonly static double screenWidth = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Width,
            screenHeight = System.Windows.Forms.Screen.PrimaryScreen.Bounds.Height;
        public MainWindow()
        {
            InitializeComponent();

            //отключение перемещения
            this.SourceInitialized += Window1_SourceInitialized;
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            
            e.Cancel = true;
            if (closingFromYesButton)
            {
                e.Cancel = false;
                return;
            }
            changeWindowPositon();
        }

        private void Window1_SourceInitialized(object sender, EventArgs e) //отключение меремещения /*
        {
            WindowInteropHelper helper = new WindowInteropHelper(this);
            HwndSource source = HwndSource.FromHwnd(helper.Handle);
            source.AddHook(WndProc);
        }

        const int WM_SYSCOMMAND = 0x0112;
        const int SC_MOVE = 0xF010;

        private IntPtr WndProc(IntPtr hwnd, int msg, IntPtr wParam, IntPtr lParam, ref bool handled)
        {

            switch (msg)
            {
                case WM_SYSCOMMAND:
                    int command = wParam.ToInt32() & 0xfff0;
                    if (command == SC_MOVE)
                    {
                        handled = true;
                    }
                    break;
                default:
                    break;
            }
            return IntPtr.Zero;
        } //отключение перемещения */

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            closingFromYesButton = true;
            System.Windows.MessageBox.Show("+79777304842\nvadim.halyapin@yandex.ru", "Мои контакты", MessageBoxButton.OK);
            Close();
        }

        private void NoButton_Click(object sender, RoutedEventArgs e)
        {
            changeWindowPositon();
        }

        private void changeWindowPositon()
        {
            Random random = new Random();
            this.Top = random.Next((int)(screenHeight - Height - 210));
            this.Left = random.Next((int)(screenWidth - Width - 310));
        }
    }
}
