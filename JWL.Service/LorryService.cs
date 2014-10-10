using JWL.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace JWL.Service
{
    public class LorryService:BaseService<Lorry>
    {
        /// <summary>
        /// 根据用户用找货车
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public Lorry GetLorryByUserName(string userName)
        {
            var res = dbc.Lorries.FirstOrDefault(t => t.User.UserName == userName);
            if (res != null) return res;
            return null;
        }
    }
}
