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
using System.Windows.Shapes;

namespace ParkingGUI
{
    /// <summary>
    /// Interaction logic for Failure.xaml
    /// </summary>
    public partial class Failure : Window
    {
        public Failure(string licenseNumber)
        {
            InitializeComponent();
            LicenseNumberChecked = licenseNumber;
            DataContext = this;
        }
        public string LicenseNumberChecked { get; set; }
    }
}
