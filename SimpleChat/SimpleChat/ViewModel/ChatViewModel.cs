using Plugin.AudioRecorder;
using Plugin.Media;
using Plugin.Media.Abstractions;
using SimpleChat.DataModel;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace SimpleChat
{
    public class ChatViewModel
    {
        public Editor Editor { get; set; }

        public ListView ListView { get; set; }

        public User User { get; set; }

        public string EnteredText { get; set; }

        public ObservableCollection<Chat> Messages { get; set; } = new ObservableCollection<Chat>();

        public ICommand SendCommand { get; set; }

        public ICommand OpenGalleryCommand { get; set; }

        public Command<Chat> PlayOrStopAudioCommand { get; set; }


        private AudioPlayer audioPlayer = new AudioPlayer();

        public ChatViewModel(User user, Editor editor, ListView listView)
        {
            User = user;
            SendCommand = new Command(Send);
            OpenGalleryCommand = new Command(OpenGallery);
            PlayOrStopAudioCommand = new Command<Chat>(PlayOrStopAudio);
            Editor = editor;
            ListView = listView;
        }

        private void Send()
        {
            Messages.Add(new Chat { ChatType = ChatType.Text, Message = EnteredText, Received = false });
            EnteredText = "";
            Editor.Text = EnteredText;
            ReceiveMessage();
        }

        private async void OpenGallery()
        {
            PickMediaOptions mediaOptions = new PickMediaOptions()
            {
                PhotoSize = PhotoSize.Small,
            };

            List<MediaFile> selectedImageFiles = await CrossMedia.Current.PickPhotosAsync(mediaOptions);

            if (selectedImageFiles != null)
            {
                selectedImageFiles.ForEach(file => {
                    var fileImageSource = ImageSource.FromStream(() => file.GetStream());
                    Messages.Add(new Chat { ChatType = ChatType.Image, FileImageSource = fileImageSource, Received = false });
                });
                ScrollToEnd(1000);
                ReceiveMessage();
            }
        }

        public void AddRecording(string path)
        {
            Messages.Add(new Chat { ChatType = ChatType.Audio, AudioFilePath = path, Received = false });
            ReceiveMessage();
        }

        private void PlayOrStopAudio(Chat chat)
        {
            audioPlayer.Play(chat.AudioFilePath);
        }

        private async void ReceiveMessage() {
            ScrollToEnd();
            await Task.Delay(2000);
            Messages.Add(new Chat { ChatType = ChatType.Text, Message = "Test", Received = true });
            ScrollToEnd();
        }

        public async void ScrollToEnd(int duration = 300) {
            if (Messages.Count > 0) {
                await Task.Delay(duration);
                ListView.ScrollTo(Messages[Messages.Count - 1], ScrollToPosition.End, true);
            }
        }
    }
}
