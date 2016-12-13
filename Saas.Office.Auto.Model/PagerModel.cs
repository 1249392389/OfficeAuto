using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas.Office.Auto.Model
{
    public class PagerModel<T>
    {
        #region Properties
        /// <summary>
        /// 总记录数sql语句
        /// </summary>
        public string countSql { get; set; }

        /// <summary>
        /// sql语句
        /// </summary>
        public string sql { get; set; }

        /// <summary>
        /// 指定表主键
        /// </summary>
        public string pkid { get; set; }

        /// <summary>
        /// 当前第几页
        /// </summary>
        public int? pageNum { get; set; }

        /// <summary>
        /// 每页条数
        /// </summary>
        public int? pageSize { get; set; }

        /// <summary>
        /// 一共多少条记录
        /// </summary>
        public int countRecord { get; set; }
        /// <summary>
        /// 当前也记录
        /// </summary>
        public List<T> pageRecord { get; set; }
        #endregion
    }
}
