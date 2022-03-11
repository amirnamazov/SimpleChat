using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;

namespace SimpleChat
{
    public class MainViewModel
    {
        public ObservableCollection<User> Users { get; set; } = new ObservableCollection<User>();

        public ICommand AddItemCommand { get; set; }

        public Command<User> NavigateToChatPageCommand { get; set; }

        public MainViewModel() {

            AddItem();
            AddItem();

            AddItemCommand = new Command(AddItem);
            NavigateToChatPageCommand = new Command<User>(NavigateToChatPage);
        }

        public int count = 0;

        public void AddItem() {
            count++;
            Users.Add(new User { Name = $"User #{count}" });
        }

        public void NavigateToChatPage(User user) {
            Application.Current.MainPage.Navigation.PushAsync(new ChatPage(user));
        }
    }
}
