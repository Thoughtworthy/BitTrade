using BitTrade.Common.Models;
using BitTrade.DAL;
using BitTrade.DAL.Interfaces;
using BitTrade.DAL.Repositories;
using System.Collections.Generic;
using System.Linq;

namespace BitTrade.BLL.Services
{
    public interface IMessageService
    {
        IEnumerable<ConversationModel> GetConversations(int? userID);
        IEnumerable<MessageModel> GetByUserID(int id);
        void Add(MessageModel model);
        bool HasNewMessages(int fromUserID, int lastMessageID);
    }
}
