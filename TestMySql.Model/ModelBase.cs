using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestMySql.EF;

namespace TestMySql.Model
{
    public abstract class ModelBase
    {
        public string apprid { get; set; }
    }
    public abstract class ApiModelBase
    {
        public int userid { get; set; }
    }
    public abstract class CallbackModelBase
    {
        /// <summary>
        /// 返回代码编号
        /// </summary>
        public int code { get; set; }
        /// <summary>
        /// 消息内容
        /// </summary>
        public string msg { get; set; }
        /// <summary>
        /// 操作代码
        /// </summary>
        public string opcode { get; set; }
        public string apprid { get; set; }
        public string status { get; set; }
    }

    public  class HouserRentModelBase:CallbackModelBase
    {
        public List<houserent> houserentlist { get; set; }
    }


    [Serializable]
    public class CommonCallBack : CallbackModelBase
    {

    }
    [Serializable]
    public class CommonParaModel : ModelBase
    {

    }
    [Serializable]
    public class ApiCommonParaModel : ApiModelBase
    {

    }

}
