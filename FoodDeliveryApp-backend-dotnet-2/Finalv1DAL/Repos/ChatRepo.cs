using Finalv1DAL.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finalv1DAL.Repos
{
    internal class ChatRepo : Repo, IRepo<Chat, int, bool>
    {
        public bool Create(Chat type)
        {
            db.Chats.Add(type);
            return db.SaveChanges()>0;
        }

        public bool Delete(int id)
        {
            db.Chats.Remove(Get(id));
            return db.SaveChanges() > 0;

        }

        public List<Chat> Get()
        {
            return db.Chats.ToList();
        }

        public Chat Get(int id)
        {
            var chats = Get();
            var chat=(from i in chats
                      where i.Id == id
                      select i).SingleOrDefault();
            return chat;
        }

        public bool Update(Chat type)
        {
            var chat = Get(type.Id);
            chat.Uid = type.Uid;
            chat.DId= type.DId;
            chat.Msg= type.Msg;
            return db.SaveChanges()>0;
            
        }
    }
}
