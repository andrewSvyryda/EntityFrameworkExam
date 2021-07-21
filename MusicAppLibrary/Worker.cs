using System;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.Linq;

namespace MusicAppLibrary
{
    public enum TimeSection { Day = 1, Week = 7, Month = 30, Year = 365 }
    public static class Hasher
    {
        public static string ComputeHash(string rawData)
        {
            using (SHA256 sha256Hash = SHA256.Create())
            {
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
    }
    public class ApiWorker
    {
        public static List<DiscountDTO> GetAllDiscounts()
        {
            using HttpClient client = new();
            HttpResponseMessage resp = client.GetAsync("https://localhost:44392/api/Discounts").Result;
            return resp.IsSuccessStatusCode ? JsonConvert.DeserializeObject<List<DiscountDTO>>(resp.Content.ReadAsStringAsync().Result) : null;
        }
        public static DiscountDTO GetDiscountById(int Id)
        {
            using HttpClient client = new();
            HttpResponseMessage resp = client.GetAsync($"https://localhost:44392/api/Discounts/GetById?Id={Id}").Result;
            return resp.IsSuccessStatusCode ? JsonConvert.DeserializeObject<DiscountDTO>(resp.Content.ReadAsStringAsync().Result) : null;
        }
        public static List<DiscountDTO> GetDiscountsByDiscId(int Id)
        {
            using HttpClient client = new();
            HttpResponseMessage resp = client.GetAsync($"https://localhost:44392/api/Discounts/GetByDiscId?DiscId={Id}").Result;
            return resp.IsSuccessStatusCode ? JsonConvert.DeserializeObject<List<DiscountDTO>>(resp.Content.ReadAsStringAsync().Result) : null;
        }

        public static DiscountDTO PostDiscount(DiscountDTO Discount)
        {
            using HttpClient client = new();
            StringContent content = new(JsonConvert.SerializeObject(Discount), Encoding.UTF8, "application/json");
            HttpResponseMessage resp = client.PostAsync($"https://localhost:44392/api/Discounts/CreateDiscount", content).Result;
            return resp.IsSuccessStatusCode ? JsonConvert.DeserializeObject<DiscountDTO>(resp.Content.ReadAsStringAsync().Result) : null;
        }




        public static List<DiscDTO> GetAllDiscs()
        {
            using HttpClient client = new();
            HttpResponseMessage resp = client.GetAsync("https://localhost:44392/api/Discs").Result;
            return resp.IsSuccessStatusCode ? JsonConvert.DeserializeObject<List<DiscDTO>>(resp.Content.ReadAsStringAsync().Result) : null;
        }
        public static DiscDTO GetDiscById(int Id)
        {
            using HttpClient client = new();
            HttpResponseMessage resp = client.GetAsync($"https://localhost:44392/api/Discs/GetById?Id={Id}").Result;
            return resp.IsSuccessStatusCode ? JsonConvert.DeserializeObject<DiscDTO>(resp.Content.ReadAsStringAsync().Result) : null;
        }
        public static List<DiscDTO> GetNewDiscs(int Count)
        {
            using HttpClient client = new();
            HttpResponseMessage resp = client.GetAsync($"https://localhost:44392/api/Discs/GetNewDiscs?Count={Count}").Result;
            return resp.IsSuccessStatusCode ? JsonConvert.DeserializeObject<List<DiscDTO>>(resp.Content.ReadAsStringAsync().Result) : null;
        }
        public static List<DiscDTO> GetBestDiscs(int Count)
        {
            using HttpClient client = new();
            HttpResponseMessage resp = client.GetAsync($"https://localhost:44392/api/Discs/BestSellingDiscs?Count={Count}").Result;
            return resp.IsSuccessStatusCode ? JsonConvert.DeserializeObject<List<DiscDTO>>(resp.Content.ReadAsStringAsync().Result) : null;
        }
        public static List<DiscDTO> GetDiscsByGenreId(int Id)
        {
            using HttpClient client = new();
            HttpResponseMessage resp = client.GetAsync($"https://localhost:44392/api/Discs/GetByGenreId?Id={Id}").Result;
            return resp.IsSuccessStatusCode ? JsonConvert.DeserializeObject<List<DiscDTO>>(resp.Content.ReadAsStringAsync().Result) : null;
        }
        public static List<DiscDTO> GetDiscsByGroupId(int Id)
        {
            using HttpClient client = new();
            HttpResponseMessage resp = client.GetAsync($"https://localhost:44392/api/Discs/GetByGroupId?Id={Id}").Result;
            return resp.IsSuccessStatusCode ? JsonConvert.DeserializeObject<List<DiscDTO>>(resp.Content.ReadAsStringAsync().Result) : null;
        }
        public static List<DiscDTO> GetDiscsByName(string Name)
        {
            using HttpClient client = new();
            HttpResponseMessage resp = client.GetAsync($"https://localhost:44392/api/Discs/GetByName?Name={Name}").Result;
            return resp.IsSuccessStatusCode ? JsonConvert.DeserializeObject<List<DiscDTO>>(resp.Content.ReadAsStringAsync().Result) : null;
        }
        public static DiscDTO PostDisc(DiscDTO Disc)
        {
            if(Disc.Discounts != null && Disc.DiscountsId.Count == 0)
            {
                Disc.DiscountsId = Disc.Discounts.Select(d => d.Id).ToList();
            }
            using HttpClient client = new();
            StringContent content = new(JsonConvert.SerializeObject(Disc), Encoding.UTF8, "application/json");
            HttpResponseMessage resp = client.PostAsync($"https://localhost:44392/api/Discs/CreateDisc", content).Result;
            return resp.IsSuccessStatusCode ? JsonConvert.DeserializeObject<DiscDTO>(resp.Content.ReadAsStringAsync().Result) : null;
        }
        public static int? RestoreDiscCount(DiscDTO Disc, int Count)
        {
            using HttpClient client = new();
            StringContent content = new(JsonConvert.SerializeObject(new { DiscId = Disc.Id, Count }), Encoding.UTF8, "application/json");
            HttpResponseMessage resp = client.PutAsync($"https://localhost:44392/api/Discs/RestoreDiscCount", content).Result;
            return resp.IsSuccessStatusCode ? JsonConvert.DeserializeObject<int>(resp.Content.ReadAsStringAsync().Result) : null;
        }
        public static DiscDTO ChangeDisc(DiscDTO Disc)
        {
            if (Disc.Discounts != null && Disc.DiscountsId.Count == 0)
            {
                Disc.DiscountsId = Disc.Discounts.Select(d => d.Id).ToList();
            }
            using HttpClient client = new();
            StringContent content = new(JsonConvert.SerializeObject(Disc), Encoding.UTF8, "application/json");
            HttpResponseMessage resp = client.PutAsync($"https://localhost:44392/api/Discs/ChangeDisc", content).Result;
            return resp.IsSuccessStatusCode ? JsonConvert.DeserializeObject<DiscDTO>(resp.Content.ReadAsStringAsync().Result) : null;
        }




        public static List<GenreDTO> GetAllGenres()
        {
            using HttpClient client = new();
            HttpResponseMessage resp = client.GetAsync("https://localhost:44392/api/Genres").Result;
            return resp.IsSuccessStatusCode ? JsonConvert.DeserializeObject<List<GenreDTO>>(resp.Content.ReadAsStringAsync().Result) : null;
        }
        public static GenreDTO GetGenreById(int Id)
        {
            using HttpClient client = new();
            HttpResponseMessage resp = client.GetAsync($"https://localhost:44392/api/Genres/GetById?Id={Id}").Result;
            return resp.IsSuccessStatusCode ? JsonConvert.DeserializeObject<GenreDTO>(resp.Content.ReadAsStringAsync().Result) : null;
        }
        public static List<GenreDTO> GetBestGenres(int Count, TimeSection Section)
        {
            using HttpClient client = new();
            HttpResponseMessage resp = client.GetAsync($"https://localhost:44392/api/Genres/GetBestGenres?count={Count}&section={Section}").Result;
            return resp.IsSuccessStatusCode ? JsonConvert.DeserializeObject<List<GenreDTO>>(resp.Content.ReadAsStringAsync().Result) : null;
        }
        public static GenreDTO PostGenre(GenreDTO Genre)
        {
            using HttpClient client = new();
            StringContent content = new(JsonConvert.SerializeObject(Genre), Encoding.UTF8, "application/json");
            HttpResponseMessage resp = client.PostAsync($"https://localhost:44392/api/Genres/CreateGenre", content).Result;
            return resp.IsSuccessStatusCode ? JsonConvert.DeserializeObject<GenreDTO>(resp.Content.ReadAsStringAsync().Result) : null;
        }



        public static List<GroupDTO> GetAllGroups()
        {
            using HttpClient client = new();
            HttpResponseMessage resp = client.GetAsync("https://localhost:44392/api/Groups").Result;
            return resp.IsSuccessStatusCode ? JsonConvert.DeserializeObject<List<GroupDTO>>(resp.Content.ReadAsStringAsync().Result) : null;
        }
        public static GroupDTO GetGroupById(int Id)
        {
            using HttpClient client = new();
            HttpResponseMessage resp = client.GetAsync($"https://localhost:44392/api/Groups/GetById?Id={Id}").Result;
            return resp.IsSuccessStatusCode ? JsonConvert.DeserializeObject<GroupDTO>(resp.Content.ReadAsStringAsync().Result) : null;
        }
        public static List<GroupDTO> GetBestGroups(int Count)
        {
            using HttpClient client = new();
            HttpResponseMessage resp = client.GetAsync($"https://localhost:44392/api/Groups/GetBest?Count={Count}").Result;
            return resp.IsSuccessStatusCode ? JsonConvert.DeserializeObject<List<GroupDTO>>(resp.Content.ReadAsStringAsync().Result) : null;
        }
        public static GroupDTO PostGroup(GroupDTO Group)
        {
            using HttpClient client = new();
            StringContent content = new(JsonConvert.SerializeObject(Group), Encoding.UTF8, "application/json");
            HttpResponseMessage resp = client.PostAsync($"https://localhost:44392/api/Groups/CreateGroup", content).Result;
            return resp.IsSuccessStatusCode ? JsonConvert.DeserializeObject<GroupDTO>(resp.Content.ReadAsStringAsync().Result) : null;
        }


        public static List<PublisherDTO> GetAllPublishers()
        {
            using HttpClient client = new();
            HttpResponseMessage resp = client.GetAsync("https://localhost:44392/api/Publishers").Result;
            return resp.IsSuccessStatusCode ? JsonConvert.DeserializeObject<List<PublisherDTO>>(resp.Content.ReadAsStringAsync().Result) : null;
        }
        public static PublisherDTO GetPublisherById(int Id)
        {
            using HttpClient client = new();
            HttpResponseMessage resp = client.GetAsync($"https://localhost:44392/api/Publishers/GetById?Id={Id}").Result;
            return resp.IsSuccessStatusCode ? JsonConvert.DeserializeObject<PublisherDTO>(resp.Content.ReadAsStringAsync().Result) : null;
        }
        public static PublisherDTO PostPublisher(PublisherDTO Publisher)
        {
            using HttpClient client = new();
            StringContent content = new(JsonConvert.SerializeObject(Publisher), Encoding.UTF8, "application/json");
            HttpResponseMessage resp = client.PostAsync($"https://localhost:44392/api/Publishers/CreatePublisher", content).Result;
            return resp.IsSuccessStatusCode ? JsonConvert.DeserializeObject<PublisherDTO>(resp.Content.ReadAsStringAsync().Result) : null;
        }


        public static List<SaleDTO> GetAllSales()
        {
            using HttpClient client = new();
            HttpResponseMessage resp = client.GetAsync("https://localhost:44392/api/Sales").Result;
            return resp.IsSuccessStatusCode ? JsonConvert.DeserializeObject<List<SaleDTO>>(resp.Content.ReadAsStringAsync().Result) : null;
        }
        public static SaleDTO GetSaleById(int Id)
        {
            using HttpClient client = new();
            HttpResponseMessage resp = client.GetAsync($"https://localhost:44392/api/Sales/GetById?Id={Id}").Result;
            return resp.IsSuccessStatusCode ? JsonConvert.DeserializeObject<SaleDTO>(resp.Content.ReadAsStringAsync().Result) : null;
        }
        public static List<SaleDTO> GetSalesByUserId(int Id)
        {
            using HttpClient client = new();
            HttpResponseMessage resp = client.GetAsync($"https://localhost:44392/api/Sales/GetByUserId?UserId={Id}").Result;
            return resp.IsSuccessStatusCode ? JsonConvert.DeserializeObject<List<SaleDTO>>(resp.Content.ReadAsStringAsync().Result) : null;
        }
        public static SaleDTO PostSale(SaleDTO Sale)
        {
            if (Sale.DiscsId == null || Sale.DiscsId.Count == 0 && Sale.Discs != null)
                Sale.DiscsId = Sale.Discs.Select(d => d.Id).ToList();
            using HttpClient client = new();
            StringContent content = new(JsonConvert.SerializeObject(Sale), Encoding.UTF8, "application/json");
            HttpResponseMessage resp = client.PostAsync($"https://localhost:44392/api/Sales/CreateSale", content).Result;
            return resp.IsSuccessStatusCode ? JsonConvert.DeserializeObject<SaleDTO>(resp.Content.ReadAsStringAsync().Result) : null;
        }


        public static List<TrackDTO> GetAllTracks()
        {
            using HttpClient client = new();
            HttpResponseMessage resp = client.GetAsync("https://localhost:44392/api/Tracks").Result;
            return resp.IsSuccessStatusCode ? JsonConvert.DeserializeObject<List<TrackDTO>>(resp.Content.ReadAsStringAsync().Result) : null;
        }
        public static TrackDTO GetTrackById(int Id)
        {
            using HttpClient client = new();
            HttpResponseMessage resp = client.GetAsync($"https://localhost:44392/api/Tracks/GetById?Id={Id}").Result;
            return resp.IsSuccessStatusCode ? JsonConvert.DeserializeObject<TrackDTO>(resp.Content.ReadAsStringAsync().Result) : null;
        }
        public static List<TrackDTO> GetTracksByDiscId(int Id)
        {
            using HttpClient client = new();
            HttpResponseMessage resp = client.GetAsync($"https://localhost:44392/api/Tracks/GetByDiscId?DiscId={Id}").Result;
            return resp.IsSuccessStatusCode ? JsonConvert.DeserializeObject<List<TrackDTO>>(resp.Content.ReadAsStringAsync().Result) : null;
        }
        public static TrackDTO PostTrack(TrackDTO Track)
        {
            using HttpClient client = new();
            StringContent content = new(JsonConvert.SerializeObject(Track), Encoding.UTF8, "application/json");
            HttpResponseMessage resp = client.PostAsync($"https://localhost:44392/api/Tracks/CreateTrack", content).Result;
            return resp.IsSuccessStatusCode ? JsonConvert.DeserializeObject<TrackDTO>(resp.Content.ReadAsStringAsync().Result) : null;
        }


        public static List<UserDTO> GetAllUsers()
        {
            using HttpClient client = new();
            HttpResponseMessage resp = client.GetAsync("https://localhost:44392/api/Users").Result;
            return resp.IsSuccessStatusCode ? JsonConvert.DeserializeObject<List<UserDTO>>(resp.Content.ReadAsStringAsync().Result) : null;
        }
        public static UserDTO GetUserById(int Id)
        {
            using HttpClient client = new();
            HttpResponseMessage resp = client.GetAsync($"https://localhost:44392/api/Users/GetById?Id={Id}").Result;
            return resp.IsSuccessStatusCode ? JsonConvert.DeserializeObject<UserDTO>(resp.Content.ReadAsStringAsync().Result) : null;
        }
        public static UserDTO Login(string Login, string Password)
        {
            Password = Hasher.ComputeHash(Password);
            using HttpClient client = new();
            HttpResponseMessage resp = client.GetAsync($"https://localhost:44392/api/Users/Login?login={Login}&password={Password}").Result;
            return resp.IsSuccessStatusCode ? JsonConvert.DeserializeObject<UserDTO>(resp.Content.ReadAsStringAsync().Result) : null;
        }
        public static UserDTO PostUser(UserDTO User)
        {
            if (User.OldPassword != null) User.OldPassword = Hasher.ComputeHash(User.OldPassword);
            if (User.Password != null) User.Password = Hasher.ComputeHash(User.Password);
            using HttpClient client = new();
            StringContent content = new(JsonConvert.SerializeObject(User), Encoding.UTF8, "application/json");
            HttpResponseMessage resp = client.PostAsync($"https://localhost:44392/api/Users/CreateUser", content).Result;
            return resp.IsSuccessStatusCode ? JsonConvert.DeserializeObject<UserDTO>(resp.Content.ReadAsStringAsync().Result) : null;
        }
        public static int ChangeUser(UserDTO User)
        {
            if (User.OldPassword != null) User.OldPassword = Hasher.ComputeHash(User.OldPassword);
            if (User.Password != null) User.Password = Hasher.ComputeHash(User.Password);
            using HttpClient client = new();
            StringContent content = new(JsonConvert.SerializeObject(User), Encoding.UTF8, "application/json");
            HttpResponseMessage resp = client.PutAsync($"https://localhost:44392/api/Users/ChangeUser", content).Result;
            return resp.IsSuccessStatusCode ? JsonConvert.DeserializeObject<int>(resp.Content.ReadAsStringAsync().Result) : -1;
        }

    }
}
