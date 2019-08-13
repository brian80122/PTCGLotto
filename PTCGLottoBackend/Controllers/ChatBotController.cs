using System;
using System.IO;
using isRock.LineBot;
using Microsoft.AspNetCore.Mvc;
using PTCGLottoLibrary.Interfaces;
using PTCGLottoLibrary.Services;

namespace PTCGLottoBackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatBotController : ControllerBase
    {
        private IPTCGService _pTCGService;
        private isRock.LineBot.Bot _bot;

        public ChatBotController(IPTCGService pTCGService, Bot bot)
        {
            _pTCGService = pTCGService;
            _bot = bot;
        }

        [HttpPost]
        public ActionResult POST()
        {
            try
            {
                string postData = "";
                using (var reader = new StreamReader(Request.Body))
                {
                    postData = reader.ReadToEnd();
                }

                if (string.IsNullOrEmpty(postData))
                {
                    return Ok();
                }
                var ReceivedMessage = isRock.LineBot.Utility.Parsing(postData);
                if (ReceivedMessage.events[0].message.text.Contains("抽"))
                {
                    var random = _pTCGService.PickCard(new PTCGLottoLibrary.Models.ServiceModels.PTCGService.PickCardRequest());
                    _bot.ReplyMessage(ReceivedMessage.events[0].replyToken, new Uri(random.ImageUrl));
                }

                return Ok();
            }
            catch (Exception ex)
            {
                return Ok();
            }

        }
        [Route("Receive"), HttpPost]
        public void Message(MessageModel model)
        {

        }
    }

    public class MessageModel
    {
        public string Message { get; set; }
    }
}