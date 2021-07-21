using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using MusicAppLibrary;
namespace MusicalShopUI
{
    public class LoginPageVeiwModel : INotifyPropertyChanged
    {
        private Page page { get; set; }
        private string password;
        public string Password
        {
            get => password;
            set
            {
                password = value;
                NotifyChange();
            }
        }
        private string login;
        public string Login
        {
            get => login;
            set
            {
                login = value;
                NotifyChange();
            }
        }
        private string name;
        public string Name
        {
            get => name;
            set
            {
                name = value;
                NotifyChange();
            }
        }
        public RelayCommand LoginCommand { get; set; }
        public RelayCommand RegisterCommand { get; set; }
        public RelayCommand ToLoginPageCommand { get; set; }
        public RelayCommand ToRegisterPageCommand { get; set; }
        public LoginPageVeiwModel(Page page)
        {
            this.page = page;
            LoginCommand = new RelayCommand(
                o =>
                {
                    UserDTO user = ApiWorker.Login(Login, Password);
                    if (user == null)
                        MessageBox.Show("Incorrect login or password");
                    else
                        page.NavigationService.Navigate(new OrderDiscsPage(user));
                },
                o => !string.IsNullOrWhiteSpace(Login) && !string.IsNullOrWhiteSpace(Password)
                );
            RegisterCommand = new RelayCommand(
                o =>
                {
                    UserDTO user = ApiWorker.PostUser(new UserDTO { Login = Login, Password = Password, Name = Name, CurrentDiscount = 0, IsAdmin = false, });
                    if (user == null)
                        MessageBox.Show("Incorrect login or password or name");
                    else
                        page.NavigationService.Navigate(new LoginPage());
                },
                o => !string.IsNullOrWhiteSpace(Login) && !string.IsNullOrWhiteSpace(Password) && !string.IsNullOrWhiteSpace(Name)
                );
            ToLoginPageCommand = new RelayCommand(
                o =>
                {
                    page.NavigationService.Navigate(new LoginPage());
                }
                );
            ToRegisterPageCommand = new RelayCommand(
                o =>
                {
                    page.NavigationService.Navigate(new RegisterPage());
                }
                );
        }

        public event PropertyChangedEventHandler PropertyChanged;
        private void NotifyChange([CallerMemberName] string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
