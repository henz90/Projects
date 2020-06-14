using DogWalker.V3Files.Models;
using DogWalker.V3Files.ModelViews;
using DogWalker.V3Files.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
    /// Interaction logic for WalkRegistration.xaml
    /// </summary>
    public partial class WalkRegistration : Window
    {
        public readonly static Service sc = new Service();
        public static ModelView mv = new ModelView();
        private DOG dog = new DOG();

        public WalkRegistration(OWNER owner)
        {
            InitializeComponent();
            WalkRegistration.mv.Dogs = sc.GetDogs(owner);
            DataContext = WalkRegistration.mv;
            Calendar.SelectedDate = DateTime.Now;
            ownerID.Text = owner.OwnerID.ToString();
        }

        private void btnSelectDog_Click(object sender, RoutedEventArgs e)
        {
            if (lbDogs.SelectedItem != null)
            {
                dog = lbDogs.SelectedItem as DOG;
                txtDogName.Text = dog.Name;
                side.IsEnabled = true;
                dogID.Text = dog.DogID.ToString();
                if (dog.Alone == true)
                {
                    rbAlone.IsChecked = true;
                }
                else
                {
                    rbPack.IsChecked = true;
                }
            }
            else
            {
                MessageBox.Show("Please select a dog from the list or add one.");
            }
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            Calendar.SelectedDate = DateTime.Now;
            cbMorning.IsChecked = false;
            cbAfternoon.IsChecked = false;
            cbEvening.IsChecked = false;
            cbNight.IsChecked = false;
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            if (Calendar.SelectedDate.Value >= DateTime.Today)
            {
                if (cbMorning.IsChecked == true ||
                cbAfternoon.IsChecked == true ||
                cbEvening.IsChecked == true ||
                cbNight.IsChecked == true)
                {
                    if (cbMorning.IsChecked == true)
                    {
                        using (var context = new DWEntities())
                        {
                            var newWalk = context.WALKS.Add(new WALK()
                            {
                                DogID = int.Parse(dogID.Text),
                                Date = Calendar.SelectedDate.Value,
                                Time = "Morning"
                            });
                            context.SaveChanges();
                        }
                    }
                    if (cbAfternoon.IsChecked == true)
                    {
                        using (var context = new DWEntities())
                        {
                            var newWalk = context.WALKS.Add(new WALK()
                            {
                                DogID = int.Parse(dogID.Text),
                                Date = Calendar.SelectedDate.Value,
                                Time = "Noon"
                            });
                            context.SaveChanges();
                        }
                    }
                    if (cbEvening.IsChecked == true)
                    {
                        using (var context = new DWEntities())
                        {
                            var newWalk = context.WALKS.Add(new WALK()
                            {
                                DogID = int.Parse(dogID.Text),
                                Date = Calendar.SelectedDate.Value,
                                Time = "Evening"
                            });
                            context.SaveChanges();
                        }
                    }
                    if (cbNight.IsChecked == true)
                    {
                        using (var context = new DWEntities())
                        {
                            var newWalk = context.WALKS.Add(new WALK()
                            {
                                DogID = int.Parse(dogID.Text),
                                Date = Calendar.SelectedDate.Value,
                                Time = "Night"
                            });
                            context.SaveChanges();
                        }
                    }
                    MessageBox.Show($"{txtDogName.Text} will be walked on {Calendar.SelectedDate.Value.ToShortDateString()}");
                    this.Close();
                }
                else
                {
                    MessageBox.Show($"Please enter a time of day for {txtDogName.Text} to be walked.");
                }
            }
            else
            {
                MessageBox.Show($"Please select today or an upcoming day.");
            }
        }

        private void btnAddDog_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrEmpty(txtDogName.Text))
            {
                MessageBox.Show("Please enter dog name.");
            }
            else
            {
                bool status;
                if (rbAlone.IsChecked == true)
                {
                    status = true;
                }
                else
                {
                    status = false;
                }
                using (var context = new DWEntities())
                {
                    var newDog = context.DOGS.Add(new DOG()
                    {
                        OwnerID = int.Parse(ownerID.Text),
                        Name = txtDogName.Text,
                        Alone = status
                    });
                    context.SaveChanges();
                    dogID.Text = newDog.DogID.ToString();
                    MessageBox.Show($"{txtDogName.Text} added to database.");
                    side.IsEnabled = true;
                }
            }
        }

        private void cbRecur_Checked(object sender, RoutedEventArgs e)
        {

        }
    }
}
