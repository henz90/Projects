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

namespace DogWalker.V3Files.Views
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            OwnerRegistration ownerRegistrationWindow = new OwnerRegistration();
            ownerRegistrationWindow.Show();
        }

        private void btnSchedule_Click(object sender, RoutedEventArgs e)
        {
            Schedule scheduleWindow = new Schedule();
            scheduleWindow.Show();
        }
    }
}
