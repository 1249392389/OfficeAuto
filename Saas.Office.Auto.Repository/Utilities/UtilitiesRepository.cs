using Saas.Office.Auto.GlobalUtilities.Cookie;
using Saas.Office.Auto.IRepository.Infrastructure;
using Saas.Office.Auto.IRepository.Utilities;
using Saas.Office.Auto.Model;
using Saas.Office.Auto.Repository.Infrastructure;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity.Infrastructure;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas.Office.Auto.Repository.Utilities
{
    /// <summary>
    /// 数据库调用
    /// </summary>
    public class UtilitiesRepository : UnitOfWork, IUtilitiesRepository
    {
        public UtilitiesRepository(IDatabaseFactory databaseFactory)
            : base(databaseFactory)
        {

        }

        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="pagerModel"></param>
        /// <returns></returns>
        public PagerModel<T> SearchPage<T>(PagerModel<T> pagerModel)
        {
            PagerModel<T> resultPage = new PagerModel<T>();
            int pageNum = pagerModel.pageNum ?? 1;
            int pageSize = 10;
            //if (pagerModel.pageSize.HasValue)
            //{
            //    pageSize = pagerModel.pageSize.Value;
            //}
            //else
            //{
            //    pageSize = ConfigManager.Current.Settings.PageSize;
            //}
            int RowNum = pageSize * (pageNum - 1);
            List<T> pageRecord = new List<T>();
            string Pagersql = @"SELECT TOP {0} * 
                                FROM 
                                (
                                SELECT ROW_NUMBER() OVER (ORDER BY @Id) AS RowNumber,{1}
                                ) A
                                WHERE RowNumber > @RowNum";
            Pagersql = String.Format(Pagersql, pageSize, pagerModel.sql);
            var arg = new DbParameter[]{
                    new SqlParameter{ParameterName = "Id",Value = pagerModel.pkid},
                    new SqlParameter{ParameterName = "RowNum",Value = RowNum},
                };
            pageRecord = this.adminDatabaseFactory.Database.SqlQuery<T>(Pagersql, arg).ToList();
            resultPage.pageRecord = pageRecord;//无论是否有数据都要赋值，目的就是为了开发人员使用方便
            if (pageRecord != null && pageRecord.Count > 0)
            {
                DbRawSqlQuery<int> countRecords = this.adminDatabaseFactory.Database.SqlQuery<int>(pagerModel.countSql);
                resultPage.countRecord = countRecords.FirstOrDefault();
            }
            return resultPage;
        }
    }
}
