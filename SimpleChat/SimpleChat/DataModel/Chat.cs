using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Plugin.AudioRecorder;

namespace SimpleChat.DataModel
{
    public class Chat
    {
        public string Message { get; set; }
        public ImageSource FileImageSource { get; set; }
        public string AudioFilePath { get; set; }
        public bool Received { get; set; }
        public ChatType ChatType { get; set; }
    }

    public enum ChatType {
        Text,
        Image,
        Audio
    }
}
