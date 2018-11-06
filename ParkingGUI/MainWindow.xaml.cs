using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
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

namespace ParkingGUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            ApiHelper.InitializeClient();
        }

        private async void Button_Click(object sender, RoutedEventArgs e)
        {
            bool check = await ApiProcessor.GetParkClient(textBoxLicenseNumber.Text);

            if (check)
            {
                Success successWindow = new Success(textBoxLicenseNumber.Text);
                successWindow.Show();
            }
            else
            {
                Failure failureWindow = new Failure();
                failureWindow.Show();
            }
        }
    }
}
