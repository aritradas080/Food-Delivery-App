using Finalv1DAL.Interfaces;
using Finalv1DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Finalv1DAL.Repos
{
    internal class TokenRepo : Repo, IRepo<Token, int, string>
    {
        public string Create(Token type)
        {
            db.Tokens.Add(type);
            db.SaveChanges();
            return type.Tokens;
        }

        public string Delete(int id)
        {
            var token=Get(id);
            db.Tokens.Remove(token);
            db.SaveChanges();
            return "";
        }

        public List<Token> Get()
        {
            return db.Tokens.ToList();
        }

        public Token Get(int id)
        {
            return db.Tokens.Find(id);
        }

        public string Update(Token type)
        {
            var token=Get(type.Id);
            token.Id= type.Id;
            token.UId= type.UId;
            token.Tokens=type.Tokens;
            token.ExpTime= type.ExpTime;
            token.CreateTime= type.CreateTime;
            token.Role= type.Role;
            db.SaveChanges();
            return "";
        }
    }
}
