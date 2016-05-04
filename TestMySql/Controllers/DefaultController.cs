using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using TestMySql.Model;
using TestMySql.BLL;

namespace TestMySql.Controllers
{
    public class DefaultController : ApiController
    {
        /// <summary>
        /// 测试用
        /// </summary>
        /// <returns></returns>   
        public CommonCallBack GetUserList()
        {
            CommonCallBack user = new CommonCallBack();
            user.code = 1;
            user.opcode = "200";
            return user;
        }


        public HouserRentModelBase GetHouseRentList()
        {
            HouserRentModelBase houserentbase = new HouserRentModelBase();
            houserentbase.code = 2;
            houserentbase.opcode = "100";
            houserentbase.msg = "获得房租信息成功";
            houserentbase.status = "成功";
            houserentbase.houserentlist = TestMySql.BLL.HouserentBLL.GetHouseRentList();
            return houserentbase;
        }


    }
}
