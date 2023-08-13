using BitTrade.BLL.Services;
using BitTrade.Common.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace BitTrade.Controllers.ApiControllers
{
    public class MessageController : ApiBaseController
    {
        private readonly IMessageService _messageService;

        public MessageController(IMessageService messageService)
        {
            _messageService = messageService;
        }

        public IHttpActionResult Get(int id, [FromUri] int lastMessageID)
        {
            var hasNewMessages = _messageService.HasNewMessages(id, lastMessageID);

            return Success(hasNewMessages);
        }

        public IHttpActionResult Post(MessageModel model)
        {
            if (!ModelState.IsValid)
            {
                return Error(ModelErrors);
            }

            try
            {
                _messageService.Add(model);
            }
            catch (Exception ex)
            {
                return Error(ex);
            }

            return Success();
        }
    }
}
