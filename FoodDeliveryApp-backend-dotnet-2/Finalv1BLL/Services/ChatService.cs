using Finalv1BLL.ModelDTOs;
using Finalv1DAL;
using Finalv1DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finalv1BLL.Services
{
    public  class ChatService
    {
        public static List<ChatDto> Get()
        {
            var chats=DataAccessFactory.ChatData().Get();
            var dto = new List<ChatDto>();
            foreach(var i in chats)
            {
                dto.Add(new ChatDto()
                {
                    Id = i.Id,

                    Uid = i.Uid,
                    DId = i.DId,
                    Msg= i.Msg,

                });
            }
            return dto;
        }
        public static ChatDto GetById(int id)
        {
            var chats = Get();
           var chat=(from i in chats
                     where i.Id == id
                     select i).SingleOrDefault();
            if (chat != null)
            {
                var dto = new ChatDto()
                {
                    Id = id,
                    Uid = chat.Uid,
                    DId = chat.DId,
                    Msg = chat.Msg,
                };
                return dto;
            }
            return null;
        }
        public static bool Update(ChatDto chat)
        {
            var modelchat = new Chat();
            modelchat.Id = chat.Id;
            modelchat.Uid = chat.Uid;
            modelchat.DId = chat.DId;
            modelchat.Msg = chat.Msg;
            return DataAccessFactory.ChatData().Update(modelchat);
        }
        public static bool Delete(int id)
        {
            return DataAccessFactory.ChatData().Delete(id);
        }
        public static List<ChatDto> GetChat(int uid,int did)
        {
            var chats = Get(); 
            var getchats=(from i in chats
                          where i.Uid == uid&&
                          i.DId == did
                          select i).ToList();
            return getchats;

        }
        public static List<ChatDto> GetByMsg(string msg,int uid,int did)
        {
            var chats = Get();
            var getbymsg=(from i in chats
                          where i.Msg.Contains(msg)&&
                          i.DId==did&&
                          i.Uid==uid
                          select i).ToList();
            return getbymsg;
        }
        public static bool Create(ChatDto chat)
        {
            var modelchat = new Chat();
            
            modelchat.Uid = chat.Uid;
            modelchat.DId = chat.DId;
            modelchat.Msg = chat.Msg;
            return DataAccessFactory.ChatData().Create(modelchat);
        }
    }
}
