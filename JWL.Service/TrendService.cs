using JWL.DB;
using JWL.Service.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using JLib.Extension;

namespace JWL.Service
{
    public class TrendService:BaseService<Trend>
    {
        GoodService gs = new GoodService();

        /// <summary>
        /// 根据货源找动向
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public string GetTrendsByGid(int id)
        {
            var good = gs.GetSingle(t => t.ID == id);
            var res = dbc.Trends.Where(t=>t.DestAddress==good.SrcAddress&&t.ReachTime<=good.SendTime&&t.GoBackTime>=good.SendTime).ToList();
            if (!res.Any()) return "[]";
            var resObjs = new List<QueryTrendDTO>();
            foreach (var item in res) { 
                var tDto = new QueryTrendDTO { 
                     UID=item.Lorry.User.ID,
                     UserName=item.Lorry.User.UserName,
                     Phone =item.Lorry.User.PhoneNo,
                     LorryNo = item.LorryNo,
                     UpdateTime = item.UpdateTime,
                     SrcAddress=item.SrcAddress,
                     DestAddress=item.DestAddress,
                     LorryTypeName = item.Lorry.LorryType.ToString(),
                     LorryLength=item.Lorry.LorryLength,
                     CarryWeight =item.Lorry.CarryWeight,
                     CurrentLocation=item.CurrentCity
                };
                resObjs.Add(tDto);
            }

            var restr = JsonConvert.SerializeObject(resObjs);
            return restr;
        }
    }
}
