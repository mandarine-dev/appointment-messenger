using Xamarin.Forms;
using XamarinChatApp.Models;

namespace XamarinChatApp.CustomCells
{
    public class MessageDataTemplateSelector : DataTemplateSelector
    {
        private readonly DataTemplate _incomingDataTemplate;
        private readonly DataTemplate _outgoingDataTemplate;

        public MessageDataTemplateSelector()
        {
            _incomingDataTemplate = new DataTemplate(typeof(IncomingViewCell));
            _outgoingDataTemplate = new DataTemplate(typeof(OutgoingViewCell));
        }

        protected override DataTemplate OnSelectTemplate(object item, BindableObject container)
        {
            if (!(item is Message messageVm))
                return null;
            return messageVm.IsIncoming() ? _incomingDataTemplate : _outgoingDataTemplate;
        }
    }
}
