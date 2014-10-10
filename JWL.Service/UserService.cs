using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using JWL.DB;
using JLib.Extension;


namespace JWL.Service
{
    public class UserService : BaseService<User>
    {
        /// <summary>
        /// 登录验证
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="pwd"></param>
        /// <returns></returns>
        public string CheckUser(string userName, string pwd)
        {
            pwd = pwd.GetMD5("1d53");
            var res = dbc.Users.FirstOrDefault(t => t.UserName == userName && t.Password == pwd);
            var res2 = dbc.Users.FirstOrDefault(t => t.PhoneNo == userName && t.Password == pwd);
            var resString = res == null ? (res2 == null ? null : res2.UserName) : res.UserName;
            return resString;
        }

        public static string GetUserCenterListHtml(string name)
        {
            var html = new StringBuilder();
            var active = "<li class=\"active active_userlist\">";
            html.Append("<div class=\"h_j_title hj_title_usercenterlist\"><span class=\"c_truck_stitle_t\">会员中心</span></div>");
            html.Append("<ul class=\"nav nav-pills nav-stacked nav_usercenterlist\">");
            html.Append(name.Equals("会员首页") ? active : "<li>");
            html.Append("<a href='/UserCenter'>会员首页</a></li>");
            
            html.Append(name.Equals("发布的信息") ? active : "<li>");
            html.Append("<a href='/UserCenter/Published'>发布的信息</a></li>");
           
            html.Append(name.Equals("成交记录查寻") ? active : "<li>");
            html.Append("<a href='/UserCenter/'>成交记录查寻</a></li>");
           
            html.Append(name.Equals("交易记录") ? active : "<li>");
            html.Append("<a href='/UserCenter/'>交易记录</a></li>");
            
            html.Append(name.Equals("帐号安全绑定") ? active : "<li>");
            html.Append("<a href='/UserCenter/'>帐号安全绑定</a></li>");
            
            html.Append(name.Equals("喜欢的会员") ? active : "<li>");
            html.Append("<a href='/UserCenter/'>喜欢的会员</a></li>");
            
            html.Append(name.Equals("修改资料") ? active : "<li>");
            html.Append("<a href='/UserCenter/'>修改资料</a></li>");
           
            html.Append(name.Equals("修改密码") ? active : "<li>");
            html.Append("<a href='/UserCenter/'>修改密码</a></li>");
            
            html.Append(name.Equals("帮助反馈") ? active : "<li>");
            html.Append("<a href='/UserCenter/'>帮助反馈</a></li>");
            html.Append("</ul>");
            return html.ToString();
        }


    }
}
