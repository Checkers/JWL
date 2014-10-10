using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JWL.DB;
using System.Data.Entity;

namespace JWL.Service
{
    public class BaseService<T> where T :class
    {
        public Entities dbc = ContextManager.GetContext();


        /// <summary>
        /// 添加实体
        /// </summary>
        /// <param name="enity"></param>
        /// <returns>返回改变条目</returns>
        public int Add(T enity)
        {
            dbc.Set<T>().Add(enity);
            return dbc.SaveChanges();
        }

        /// <summary>
        /// 删除实体
        /// </summary>
        /// <param name="enity"></param>
        /// <returns>返回改变条目</returns>
        public int Del(T enity)
        {
            dbc.Set<T>().Remove(enity);
            return dbc.SaveChanges();
        }

        /// <summary>
        /// 查询实体
        /// </summary>
        /// <param name="enity">查询条件,null就是所有</param>
        /// <returns>返回改变条目</returns>
        public IQueryable<T> GetAll()
        {
            return dbc.Set<T>();
        }

        /// <summary>
        /// 查询单个实体
        /// </summary>
        /// <param name="enity">查询条件</param>
        /// <returns>返回改变条目</returns>
        public T GetSingle(Func<T, bool> func)
        {
            return dbc.Set<T>().FirstOrDefault(func);
        }


        /// <summary>
        /// 修改实体
        /// </summary>
        /// <param name="func"></param>
        /// <returns>修改条目</returns>
        public int Modity(T entity)
        {
            dbc.Set<T>().Attach(entity);
            dbc.Entry(entity).State = EntityState.Modified;
            return dbc.SaveChanges();
        }
    }
}
