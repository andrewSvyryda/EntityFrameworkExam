using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using MusicAppLibrary;
namespace MusicalShopUI
{
    public class OrderDiscsPageVeiwModel : INotifyPropertyChanged
    {
        public void RefreshData()
        {
            List<GroupDTO> tmp = ApiWorker.GetAllGroups();
            if (tmp == null)
                MessageBox.Show("Some connection error");
            else
                GroupsList = new ObservableCollection<GroupDTO>(tmp);

            List<GenreDTO> tmp1 = ApiWorker.GetAllGenres();
            if (tmp1 == null)
                MessageBox.Show("Some connection error");
            else
                GenresList = new ObservableCollection<GenreDTO>(tmp1);
        }
        public OrderDiscsPageVeiwModel(UserDTO user, Page page)
        {
            this.user = user;
            this.page = page;
            RefreshData();
            GetAll = new RelayCommand(
                o =>
                {
                    List<DiscDTO> tmp = ApiWorker.GetAllDiscs();
                    if(tmp == null)
                        MessageBox.Show("Some error");
                    else
                        DiscsList = new ObservableCollection<DiscDTO>(tmp);
                });
            GetBest = new RelayCommand(
                o =>
                {
                    List<DiscDTO> tmp = ApiWorker.GetBestDiscs((int)Count1);
                    if (tmp == null)
                        MessageBox.Show("Some error");
                    else
                        DiscsList = new ObservableCollection<DiscDTO>(tmp);
                },
                o => Count1 != null && Count1 >= 1
                );
            GetNew = new RelayCommand(
                o =>
                {
                    List<DiscDTO> tmp = ApiWorker.GetNewDiscs((int)Count2);
                    if (tmp == null)
                        MessageBox.Show("Some error");
                    else
                        DiscsList = new ObservableCollection<DiscDTO>(tmp);
                },
                o => Count2 != null && Count2 >= 1
                );
            GetByGenre = new RelayCommand(
                o =>
                {
                    List<DiscDTO> tmp = ApiWorker.GetDiscsByGenreId(selectedGenre.Id);
                    if (tmp == null)
                        MessageBox.Show("Some error");
                    else
                        DiscsList = new ObservableCollection<DiscDTO>(tmp);
                },
                o => selectedGenre != null
                );
            GetByGroup = new RelayCommand(
                o =>
                {
                    List<DiscDTO> tmp = ApiWorker.GetDiscsByGroupId(selectedGroup.Id);
                    if (tmp == null)
                        MessageBox.Show("Some error");
                    else
                        DiscsList = new ObservableCollection<DiscDTO>(tmp);
                },
                o => selectedGroup != null
                );
            GetByName = new RelayCommand(
                o =>
                {
                    List<DiscDTO> tmp = ApiWorker.GetDiscsByName(Name);
                    if (tmp == null)
                        MessageBox.Show("Some connection error");
                    else
                        DiscsList = new ObservableCollection<DiscDTO>(tmp);
                },
                o => !string.IsNullOrWhiteSpace(Name)
                );
            Order = new RelayCommand(
                o =>
                {
                    SaleDTO tmp = ApiWorker.PostSale(new SaleDTO { Discs = SelectedDiscs, SaleDate = DateTime.Now, UserId = user.Id,  });
                    if (tmp == null)
                        MessageBox.Show("Some connection error");
                    else
                        MessageBox.Show("Success!!! Price: " + tmp.Price);
                },
                o => SelectedDiscs.Count != 0
                );
            SelectedDiscs.CollectionChanged += RecountPrice;
        }

        private void RecountPrice(object sender, NotifyCollectionChangedEventArgs e)
        {
            float price = 0;
            if(SelectedDiscs.Count != 0)
            {
                foreach (DiscDTO disc in SelectedDiscs)
                {
                    float discDiscount = 0;
                    foreach (DiscountDTO discount in disc.Discounts)
                    {
                        if (discount.DiscountValue != 0 && discount.DateFrom < DateTime.Now && discount.DateTo > DateTime.Now)
                        {
                            discDiscount += (100 - discDiscount) * ((float)discount.DiscountValue / 100);
                        }
                    }
                    price += disc.Price * ((100 - discDiscount) / 100);
                }
            }
            price *= (100 - (float)user.CurrentDiscount) / 100;
            Price = price;
        }

        public RelayCommand GetAll { get; set; }
        public RelayCommand GetBest { get; set; }
        public RelayCommand GetNew { get; set; }
        public RelayCommand GetByGenre { get; set; }
        public RelayCommand GetByGroup { get; set; }
        public RelayCommand Order { get; set; }
        public RelayCommand GetByName { get; set; }

        private ObservableCollection<DiscDTO> selectedDiscs = new();
        public ObservableCollection<DiscDTO> SelectedDiscs
        {
            get => selectedDiscs;
            set
            {
                selectedDiscs = value;
                NotifyChange();
            }
        }
        private float price;
        public float Price
        {
            get => price;
            set
            {
                price = value;
                NotifyChange();
            }
        }
        private ObservableCollection<GroupDTO> groupsList;
        public ObservableCollection<GroupDTO> GroupsList
        {
            get => groupsList;
            set
            {
                groupsList = value;
                NotifyChange();
            }
        }
        private ObservableCollection<GenreDTO> genresList;
        public ObservableCollection<GenreDTO> GenresList
        {
            get => genresList;
            set
            {
                genresList = value;
                NotifyChange();
            }
        }
        private GenreDTO selectedGenre;
        public GenreDTO SelectedGenre { 
            get => selectedGenre;
            set
            {
                selectedGenre = value;
                NotifyChange();
            }
        }
        private GroupDTO selectedGroup { get; set; }
        public GroupDTO SelectedGroup
        {
            get => selectedGroup;
            set
            {
                selectedGroup = value;
                NotifyChange();
            }
        }
        private string name { get; set; }
        public string Name
        {
            get => name;
            set
            {
                name = value;
                NotifyChange();
            }
        }
        private int? count1 { get; set; }
        public int? Count1
        {
            get => count1;
            set
            {
                count1 = value;
                NotifyChange();
            }
        }
        private int? count2 { get; set; }
        public int? Count2
        {
            get => count2;
            set
            {
                count2 = value;
                NotifyChange();
            }
        }
        private Page page { get; set; }
        private UserDTO user { get; set; }
        private ObservableCollection<DiscDTO> discsList;
        public ObservableCollection<DiscDTO> DiscsList 
        {
            get => discsList;
            set
            {
                discsList = value;
                NotifyChange();
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyChange([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
