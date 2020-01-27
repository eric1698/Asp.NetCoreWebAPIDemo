using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace IDAL
{
    public interface IRepositoryBase<T> where T :class
    {
        /// <summary>
        /// 讀取所有符合條件的資料
        /// </summary>       
        Task<IEnumerable<T>> Reads(Expression<Func<T, bool>> predicate);
        /// <summary>
        /// 更新
        /// </summary>   
        void Update(T source);
        /// <summary>
        /// 刪除
        /// </summary>   
        void Delete(int id);
        /// <summary>
        /// 新增
        /// </summary>   
        void Create(T source);
    }
}
