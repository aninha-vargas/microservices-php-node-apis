using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace envio_mensagens_api_c_.Repositories
{
    public interface IMessageService
    {
        IEnumerable<string> GetMessages();
        string GetMessageById(int id);
        void SendMessage(string message);
    }
    public interface IMessageRepository
    {
        Task AddMessageAsync(string message);
    }
    public class MessageRepository : IMessageRepository
    {
        private readonly List<string> _messages;

        public MessageRepository()
        {
            _messages = new List<string>();
        }

        public async Task AddMessageAsync(string message)
        {
            _messages.Add(message);
            await Task.CompletedTask;
        }

        public IEnumerable<string> GetMessages()
        {
            return _messages.ToList();
        }

        public string GetMessageById(int id)
        {
            return _messages.ElementAtOrDefault(id);
        }
    }
}



