using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using JWL.DB;

namespace JWL.Service
{
    public class ContextManager
    {
        [ThreadStatic]
        private static Entities dataContext = null;
        /// <summary>
        /// 获取DataContext对象
        /// </summary>
        /// <returns></returns>
        public static Entities GetContext()
        {
            if (dataContext == null)
                dataContext = new Entities();
            return dataContext;
        }

        /// <summary>
        /// 重置DataContext对象
        /// </summary>
        public static void Clear()
        {
            dataContext = null;
        }
    }
}
