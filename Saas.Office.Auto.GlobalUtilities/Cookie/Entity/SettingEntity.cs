using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Saas.Office.Auto.GlobalUtilities.Cookie.Entity
{
    public class SettingEntity
    {
        private string _areas = string.Empty;

        private double _cookieExpires = 0;

        private int _currentRedisExpires = 0;

        private int _pageSize = 0;

        private int _pagerBarShowNum = 0;

        private string _errorPage = string.Empty;

        private string _authErrorPage = string.Empty;

        private string _noFilesAuthor = string.Empty;

        public string NoFilesAuthor
        {
            get
            { return _noFilesAuthor; }
        }

        public string AuthErrorPage
        {
            get
            { return _authErrorPage; }
        }
        public string ErrorPage
        {
            get
            { return _errorPage; }
        }
        public int PageSize
        {
            get
            { return _pageSize; }
        }
        public int PagerBarShowNum
        {
            get
            { return _pagerBarShowNum; }
        }

        public int CurrentRedisExpires
        {
            get
            { return _currentRedisExpires; }
        }

        public double CookieExpires
        {
            get
            { return _cookieExpires; }
        }
        public string Areas
        {
            get
            { return _areas; }
        }
        public SettingEntity(Dictionary<string, string> dic)
        {
            this._areas = dic["Areas"];
            this._cookieExpires = double.Parse(dic["CookieExpires"]);
            //this._currentRedisExpires = int.Parse(dic["CurrentRedisExpires"]);
            this._pageSize = int.Parse(dic["PageSize"]);
            this._pagerBarShowNum = int.Parse(dic["PagerBarShowNum"]);
            //this._errorPage = dic["ErrorPage"];
            //this._authErrorPage = dic["AuthErrorPage"];
            //this._noFilesAuthor = dic["NoFilesAuthor"];
        }
    }
}
