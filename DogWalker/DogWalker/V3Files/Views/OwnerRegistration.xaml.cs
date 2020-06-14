using DogWalker.V3Files.Models;
using DogWalker.V3Files.ModelViews;
using DogWalker.V3Files.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
    /// Interaction logic for OwnerRegistration.xaml
    /// </summary>
    public partial class OwnerRegistration : Window
    {
        public readonly static Service sc = new Service();
        public static ModelView mv = new ModelView();

        public OwnerRegistration()
        {
            InitializeComponent();
            OwnerRegistration.mv.Owners = sc.GetOwners();
            DataContext = OwnerRegistration.mv;
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            ClearFields();
        }

        private void btnRegister_Click(object sender, RoutedEventArgs e)
        {
            string firstName = txtFirstName.Text;
            string lastName = txtLastName.Text;
            string address = txtAddress.Text;
            string postal = txtPostal.Text;
            string phone = txtPhone.Text;
            if (string.IsNullOrEmpty(firstName)
                || string.IsNullOrEmpty(lastName)
                || string.IsNullOrEmpty(address)
                || string.IsNullOrEmpty(postal)
                || string.IsNullOrEmpty(phone))
            {
                MessageBox.Show("Please complete all fields to register");
            }
            else
            {
                using (var context = new DWEntities())
                {
                    var newOwner = context.OWNERS.Add(new OWNER()
                    {
                        Address = address,
                        FirstName = firstName,
                        LastName = lastName,
                        Phone = phone,
                        Postal = postal
                    });
                    context.SaveChanges();
                    MessageBox.Show($"{firstName} {lastName} added to Database");
                    ClearFields();
                    WalkRegistration window = new WalkRegistration(newOwner);
                    window.Show();
                    this.Close();
                }
            }
        }

        private void btnSelect_Click(object sender, RoutedEventArgs e)
        {
            if (lbOwners.SelectedItem != null)
            {
                WalkRegistration window = new WalkRegistration(lbOwners.SelectedItem as OWNER);
                window.Show();
                this.Close();
            }
            else
            {
                MessageBox.Show("Please select a owner.");
            }
        }
        private void ClearFields()
        {
            txtFirstName.Clear();
            txtLastName.Clear();
            txtAddress.Clear();
            txtPostal.Clear();
            txtPhone.Clear();
        }
    }
}
