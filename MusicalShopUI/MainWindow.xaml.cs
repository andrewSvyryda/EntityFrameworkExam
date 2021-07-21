using MusicAppLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
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

namespace MusicalShopUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Frame.NavigationService.Navigate(new LoginPage());

            /*
            
            
            textBlock.Text = ApiWorker.GetAllDiscounts().ToString();
            textBlock.Text = ApiWorker.GetDiscountById(2).ToString();
            textBlock.Text = ApiWorker.GetDiscountsByDiscId(2).ToString();
            textBlock.Text = ApiWorker.PostDiscount(new DiscountDTO { DateFrom = DateTime.Now, DateTo = DateTime.Now, DiscountValue = 10, Name = "Discount" }).ToString();
            textBlock.Text = ApiWorker.GetAllDiscs().ToString();
            textBlock.Text = ApiWorker.GetDiscById(2).ToString();
            textBlock.Text = ApiWorker.GetNewDiscs(2).ToString();
            textBlock.Text = ApiWorker.GetDiscsByGenreId(2).ToString();
            textBlock.Text = ApiWorker.GetDiscsByName("d").ToString();
            textBlock.Text = JsonConvert.SerializeObject(tmp);
            textBlock.Text = ApiWorker.PostDisc(new() { Name = "nd2", Count = 5, DiscountsId = new List<int> { 1, 2 }, GenreId = 1, GroupId = 1, Price = 120, PublisherId = 1, PublishDate = DateTime.Now }).ToString();

            textBlock.Text = ApiWorker.RestoreDiscCount(new DiscDTO { Id = 2 }, 3).ToString();
            textBlock.Text = ApiWorker.ChangeDisc(new() { Id = 1, Name = "nd1", Count = 5, DiscountsId = new List<int> { }, GenreId = 1, GroupId = 1, Price = 120, PublisherId = 1, PublishDate = DateTime.Now }).ToString();
            textBlock.Text = ApiWorker.GetAllGenres().ToString();
            textBlock.Text = ApiWorker.GetGenreById(1).ToString();
            textBlock.Text = ApiWorker.GetBestGenres(2, TimeSection.Month).ToString();
            textBlock.Text = ApiWorker.PostGenre(new GenreDTO { Name = "Ng11" }).ToString();

            textBlock.Text = ApiWorker.GetAllGroups().ToString();
            textBlock.Text = ApiWorker.GetGroupById(1).ToString();
            textBlock.Text = ApiWorker.GetBestGroups(2).ToString();
            textBlock.Text = ApiWorker.PostGroup(new GroupDTO { Name = "Ngr11" }).ToString();

            textBlock.Text = ApiWorker.GetAllPublishers().ToString();
            textBlock.Text = ApiWorker.GetPublisherById(1).ToString();
            textBlock.Text = ApiWorker.PostPublisher(new PublisherDTO { Name = "p11" }).ToString();

            textBlock.Text = ApiWorker.GetAllSales().ToString();
            textBlock.Text = ApiWorker.GetSaleById(1).ToString();
            textBlock.Text = ApiWorker.GetSalesByUserId(1).ToString();
            textBlock.Text = ApiWorker.PostSale(new SaleDTO { DiscsId = new List<int> { 1, 2, 3 }, Price = 1, SaleDate = DateTime.Now, UserId = 1 }).ToString();
            textBlock.Text = JsonConvert.SerializeObject(new SaleDTO { DiscsId = new List<int> { 1, 2, 3 }, Price = 1, SaleDate = DateTime.Now, UserId = 1 });
            extBlock.Text = ApiWorker.GetAllTracks().ToString();
            textBlock.Text = ApiWorker.GetTrackById(1).ToString();
            textBlock.Text = ApiWorker.GetTracksByDiscId(1).ToString();
            textBlock.Text = ApiWorker.PostTrack(new TrackDTO { Name = "nt1", DiscId = 1, DurationInSec = 150 }).ToString();

            textBlock.Text = ApiWorker.GetAllUsers().ToString();
            textBlock.Text = ApiWorker.GetUserById(1).ToString();
            textBlock.Text = ApiWorker.PostUser(new UserDTO { Name = "Name 1", CurrentDiscount = 10, IsAdmin = false, Login = "login", Password = "123456789" }).ToString();
            textBlock.Text = ApiWorker.Login("login", "123456789").ToString();
            
            UserDTO dto = new () { Name = "Name 2", CurrentDiscount = 20, IsAdmin = false, Login = "login", OldPassword = "123456789" };


            textBlock.Text = ApiWorker.ChangeUser(dto).ToString();
            

            */
        }
    }
}
