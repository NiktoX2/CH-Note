using Microsoft.Win32;
using System.IO;
using System.Windows;
using System.Windows.Input;

namespace Note
{
    public partial class MainWindow : Window
    {
        private readonly string fileType = "Текстовый документ (*.txt)|*.txt|Все файлы (*.*)|*.*";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void Border_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                DragMove();
            }
        }

        private void MinimizeButton_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState = WindowState.Minimized;
        }

        private void ButtonFullDefault_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.MainWindow.WindowState = Application.Current.MainWindow.WindowState != WindowState.Maximized ? WindowState.Maximized : WindowState.Normal;
        }

        private void SaveButton_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog saveFileDialog = new SaveFileDialog
            {
                Filter = fileType,
                Title = "Сохранение файл"
            };

            bool? result = saveFileDialog.ShowDialog();

            if (result == true)
            {
                StreamWriter streamWriter = new StreamWriter(saveFileDialog.FileName);
                streamWriter.WriteLine(textBox.Text);
                streamWriter.Close();
            }
        }

        private void OpenButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog()
            {
                Filter = fileType,
                Title = "Выберите файл"
            };

            bool? result = ofd.ShowDialog();

            if (result == true)
            {
                textBox.Text = File.ReadAllText(ofd.FileName);
            }
        }
    }
}
