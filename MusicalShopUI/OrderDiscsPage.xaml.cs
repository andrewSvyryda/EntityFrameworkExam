using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using MusicAppLibrary;
namespace MusicalShopUI
{
    /// <summary>
    /// Interaction logic for ShowDiscsPage.xaml
    /// </summary>
    public partial class OrderDiscsPage : Page
    {
        public OrderDiscsPage(UserDTO user)
        {
            InitializeComponent();
            OrderDiscsPageVeiwModel viewModel = new(user, this);
            this.DataContext = new OrderDiscsPageVeiwModel(user, this);
            new SelectedItemsBinder(DiscsView, viewModel.SelectedDiscs);
        }
    }
}
