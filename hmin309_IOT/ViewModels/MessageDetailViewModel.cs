using System;

using hmin309_IOT.Models;

namespace hmin309_IOT.ViewModels
{
    public class MessageDetailViewModel : BaseViewModel
    {
        public Message Message { get; set; }
        public MessageDetailViewModel(Message message = null)
        {
            Title = message?.student_message;
            Message = message;
        }
    }
}
