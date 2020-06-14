using DogWalker.V3Files.Models;
using DogWalker.V3Files.ModelViews;
using DogWalker.V3Files.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
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
    /// Interaction logic for Schedule.xaml
    /// </summary>
    public partial class Schedule : Window
    {
        public readonly static Service sc = new Service();
        public static ModelView mv = new ModelView();

        public Schedule()
        {
            InitializeComponent();
            Schedule.mv.Schedule = sc.GetSchedules();
            DataContext = Schedule.mv;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < dgSchedule.Items.Count; i++)
            {
                var item = dgSchedule.Items[i];
                var cbDelete = dgSchedule.Columns[0].GetCellContent(item) as CheckBox;
                if (cbDelete.IsChecked == true && cbDelete != null)
                {
                    var toDelete = dgSchedule.Columns[1].GetCellContent(item).DataContext as SCHEDULE;
                    string walkID = toDelete.WalkID.ToString();
                    using (var context = new DWEntities())
                    {
                        foreach (var walk in context.WALKS)
                        {
                            if (walk.WalkID == int.Parse(walkID))
                            {
                                MessageBox.Show($"Walk ID# {walkID} Removed");
                                context.WALKS.Remove(walk);
                            }
                        }
                        context.SaveChanges();
                    }
                }
            }
            Schedule.mv.Schedule = sc.GetSchedules();
            DataContext = Schedule.mv;
            dgSchedule.Items.Refresh();
        }
    }
}
