using Plugin.AudioRecorder;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;

namespace SimpleChat
{
    public partial class ChatPage : ContentPage
    {
        private ChatViewModel ChatViewModel { get; set; }

        private readonly AudioRecorderService audioRecordService = new AudioRecorderService()

        {
            StopRecordingOnSilence = false,
            StopRecordingAfterTimeout = false,
        };

        private int count = 0;

        public ChatPage(User user)
        {
            InitializeComponent();
            ChatViewModel = new ChatViewModel(user, editor, listView);
            BindingContext = ChatViewModel;
        }

        private void OnSetFocus(object sender, EventArgs e) => ChatViewModel.ScrollToEnd();

        private async void OnRecorderClicked(object sender, EventArgs e) {
            ImageButton button = (ImageButton) sender;
            if (!audioRecordService.IsRecording)
            {
                button.Source = "stop_button.png";
                recordTime.IsVisible = true;
                count++;
                audioRecordService.FilePath = "/data/user/0/com.companyname.simplechat/cache/ARS_recording"+count+".wav";
                await audioRecordService.StartRecording();
            } else
            {
                button.Source = "play_button.png";
                recordTime.IsVisible = false;
                await audioRecordService.StopRecording();
                ChatViewModel.AddRecording(audioRecordService.FilePath);
            }
            
            int secs = 0;
            recordTime.Text = "00:00";
            while (audioRecordService.IsRecording)
            {
                await Task.Delay(1000);
                secs++;
                recordTime.Text = TimeSpan.FromSeconds(secs).ToString(@"mm\:ss"); ;
            }
        }
    }
}