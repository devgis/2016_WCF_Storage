using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EMSWCF
{
    #region 定义往来单位--数据结构
    public class cUnitsInfo
    {
        private string unitcode = "";
        private string fullname = "";
        private string tax = "";
        private string tel = "";
        private string linkman = "";
        private string address = "";
        private string accounts = "";
        private float gathering = 0;
        private float payment = 0;
        /// <summary>
        /// 单位编号
        /// </summary>
        public string UnitCode
        {
            get { return unitcode; }
            set { unitcode = value; }
        }
        /// <summary>
        /// 单位全称
        /// </summary>
        public string FullName
        {
            get { return fullname; }
            set { fullname = value; }
        }
        /// <summary>
        /// 单位税号
        /// </summary>
        public string Tax
        {
            get { return tax; }
            set { tax = value; }
        }
        /// <summary>
        /// 联系人
        /// </summary>
        public string LinkMan
        {
            get { return linkman; }
            set { linkman = value; }
        }
        /// <summary>
        /// 联系电话
        /// </summary>
        public string Tel
        {
            get { return tel; }
            set { tel = value; }
        }
        /// <summary>
        /// 单位地址
        /// </summary>
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        /// <summary>
        /// 开户行及账号
        /// </summary>
        public string Accounts
        {
            get { return accounts; }
            set { accounts = value; }
        }
        /// <summary>
        /// 累计应收款
        /// </summary>
        public float Gathering
        {
            get { return gathering; }
            set { gathering = value; }
        }
        /// <summary>
        /// 累计应付款
        /// </summary>
        public float Payment
        {
            get { return payment; }
            set { payment = value; }
        }
    }

    #endregion

    #region 定义库存商品--数据结构
    public class cStockInfo
    {
        private string tradecode = "";
        private string fullname = "";
        private string tradetpye = "";
        private string standard = "";
        private string tradeunit = "";
        private string produce = "";
        private float qty = 0;
        private float price = 0;
        private float averageprice = 0;
        private float saleprice = 0;
        private float check = 0;
        private float upperlimit = 0;
        private float lowerlimit = 0;
        /// <summary>
        /// 商品编号
        /// </summary>
        public string TradeCode
        {
            get { return tradecode; }
            set { tradecode = value; }
        }
        /// <summary>
        /// 单位全称
        /// </summary>
        public string FullName
        {
            get { return fullname; }
            set { fullname = value; }
        }
        /// <summary>
        /// 商品型号
        /// </summary>
        public string TradeType
        {
            get { return tradetpye; }
            set { tradetpye = value; }
        }
        /// <summary>
        /// 商品规格
        /// </summary>
        public string Standard
        {
            get { return standard; }
            set { standard = value; }
        }
        /// <summary>
        /// 商品单位
        /// </summary>
        public string Unit
        {
            get { return tradeunit; }
            set { tradeunit = value; }
        }
        /// <summary>
        /// 商品产地
        /// </summary>
        public string Produce
        {
            get { return produce; }
            set { produce = value; }
        }
        /// <summary>
        /// 库存数量
        /// </summary>
        public float Qty
        {
            get { return qty; }
            set { qty = value; }
        }
        /// <summary>
        /// 进货时最后一次价格
        /// </summary>
        public float Price
        {
            get { return price; }
            set { price = value; }
        }
        /// <summary>
        /// 加权平均价格
        /// </summary>
        public float AveragePrice
        {
            get { return averageprice; }
            set { averageprice = value; }
        }
        /// <summary>
        /// 销售时的最后一次销价
        /// </summary>
        public float SalePrice
        {
            get { return saleprice; }
            set { saleprice = value; }
        }
        /// <summary>
        /// 盘点数量
        /// </summary>
        public float Check
        {
            get { return check; }
            set { check = value; }
        }
        /// <summary>
        /// 库存报警上限
        /// </summary>
        public float UpperLimit
        {
            get { return upperlimit; }
            set { upperlimit = value; }
        }
        /// <summary>
        /// 库存报警下限
        /// </summary>
        public float LowerLimit
        {
            get { return lowerlimit; }
            set { lowerlimit = value; }
        }
    }

    #endregion

    #region 定义公司职员--数据结构
    public class cEmployeeInfo
    {
        private string employeecode = "";
        private string fullname = "";
        private string sex = "";
        private string dept = "";
        private string tel = "";
        private string memo = "";
        /// <summary>
        /// 职员编号
        /// </summary>
        public string EmployeeCode
        {
            get { return employeecode; }
            set { employeecode = value; }
        }
        /// <summary>
        /// 职员姓名
        /// </summary>
        public string FullName
        {
            get { return fullname; }
            set { fullname = value; }
        }
        /// <summary>
        /// 职员性别
        /// </summary>
        public string Sex
        {
            get { return sex; }
            set { sex = value; }
        }
        /// <summary>
        /// 所在部门
        /// </summary>
        public string Dept
        {
            get { return dept; }
            set { dept = value; }
        }
        /// <summary>
        /// 职员电话
        /// </summary>
        public string Tel
        {
            get { return tel; }
            set { tel = value; }
        }
        /// <summary>
        /// 备注信息
        /// </summary>
        public string Memo
        {
            get { return memo; }
            set { memo = value; }
        }
    }

    #endregion

    #region 定义过账单据--数据结构
    public class cBillInfo
    {
        //主表结构
        private DateTime billdate = DateTime.Now;
        private string billcode = "";
        private string units = "";
        private string handle = "";
        private string summary = "";
        private float fullpayment = 0;
        private float payment = 0;

        //明细表结构
        private string tradecode = "";
        private string fullname = "";
        private string tradeunit = "";
        private float qty = 0;
        private float price = 0;
        private float tsum = 0;

        /// <summary>
        /// 录单日期
        /// </summary>
        public DateTime BillDate
        {
            get { return billdate; }
            set { billdate = value; }
        }
        /// <summary>
        /// 单据编号
        /// </summary>
        public string BillCode
        {
            get { return billcode; }
            set { billcode = value; }
        }
        /// <summary>
        /// 供货单位
        /// </summary>
        public string Units
        {
            get { return units; }
            set { units = value; }
        }
        /// <summary>
        /// 经手人
        /// </summary>
        public string Handle
        {
            get { return handle; }
            set { handle = value; }
        }
        /// <summary>
        /// 摘要
        /// </summary>
        public string Summary
        {
            get { return summary; }
            set { summary = value; }
        }
        /// <summary>
        /// 应付金额
        /// </summary>
        public float FullPayment
        {
            get { return fullpayment; }
            set { fullpayment = value; }
        }
        /// <summary>
        /// 实付金额
        /// </summary>
        public float Payment
        {
            get { return payment; }
            set { payment = value; }
        }

        //***************明细表结构******************//
        /// <summary>
        /// 商品编号
        /// </summary>
        public string TradeCode
        {
            get { return tradecode; }
            set { tradecode = value; }
        }

        /// <summary>
        /// 商品名称
        /// </summary>
        public string FullName
        {
            get { return fullname; }
            set { fullname = value; }
        }
        /// <summary>
        /// 商品单位
        /// </summary>
        public string TradeUnit
        {
            get { return tradeunit; }
            set { tradeunit = value; }
        }
        /// <summary>
        /// 数量
        /// </summary>
        public float Qty
        {
            get { return qty; }
            set { qty = value; }
        }
        /// <summary>
        /// 价格
        /// </summary>
        public float Price
        {
            get { return price; }
            set { price = value; }
        }
        /// <summary>
        /// 金额=数量*价格
        /// </summary>
        public float TSum
        {
            get { return tsum; }
            set { tsum = value; }
        }
    }
    #endregion

    #region 定义往来账本明细--数据结构
    public class cCurrentAccount
    {
        private DateTime billdate = DateTime.Now;
        private string billcode = "";
        private float addgathering = 0;             //应收增加
        private float factaddfee = 0;             //实际增加
        private float reducegathering = 0;        //应收减少
        private float factreducegathering = 0;    //实际减少
        private float balance = 0;  //应收与增加 差额
        private string units = "";

        /// <summary>
        /// 录单日期
        /// </summary>
        public DateTime BillDate
        {
            get { return billdate; }
            set { billdate = value; }
        }/// <summary>
        /// 单据编号
        /// </summary>
        public string BillCode
        {
            get { return billcode; }
            set { billcode = value; }
        }/// <summary>
        /// 应收增加
        /// </summary>
        public float AddGathering
        {
            get { return addgathering; }
            set { addgathering = value; }
        }/// <summary>
        /// 实际增加
        /// </summary>
        public float FactAddFee
        {
            get { return factaddfee; }
            set { factaddfee = value; }
        }/// <summary>
        /// 应收减少
        /// </summary>
        public float ReduceGathering
        {
            get { return reducegathering; }
            set { reducegathering = value; }
        }/// <summary>
        /// 实际减少
        /// </summary>
        public float FactReduceGathering
        {
            get { return factreducegathering; }
            set { factreducegathering = value; }
        }/// <summary>
        /// 余额(应收金额-实际金额)
        /// </summary>
        public float Balance
        {
            get { return balance; }
            set { balance = value; }
        }/// <summary>
        /// 往来单位
        /// </summary>
        public string Units
        {
            get { return units; }
            set { units = value; }
        }
    }

    #endregion

    #region 定义本单位信息设置--数据结构
    public class cUnits
    {
        private string fullname = "";
        private string tax = "";
        private string tel = "";
        private string linkman = "";
        private string address = "";
        private string accounts = "";

        /// <summary>
        /// 单位全称
        /// </summary>
        public string FullName
        {
            get { return fullname; }
            set { fullname = value; }
        }
        /// <summary>
        /// 税号
        /// </summary>
        public string Tax
        {
            get { return tax; }
            set { tax = value; }
        }
        /// <summary>
        /// 单位电话
        /// </summary>
        public string Tel
        {
            get { return tel; }
            set { tel = value; }
        }
        /// <summary>
        /// 联系人
        /// </summary>
        public string Linkman
        {
            get { return linkman; }
            set { linkman = value; }
        }
        /// <summary>
        /// 联系地址
        /// </summary>
        public string Address
        {
            get { return address; }
            set { address = value; }
        }
        /// <summary>
        /// 开户行及账号
        /// </summary>
        public string Accounts
        {
            get { return accounts; }
            set { accounts = value; }
        }
    }

    #endregion

    #region 定义往来账明细表－－－数据结构
    public class cCurrentaccount
    {
        private DateTime billdate = DateTime.Now;
        private string billcode = "";
        private float addgathering = 0;
        private float factaddfee = 0;
        private float reducegathering = 0;
        private float factfee = 0;
        private float balance = 0;
        private string units = "";
        /// <summary>
        /// 录单日期
        /// </summary>
        public DateTime BillDate
        {
            get { return billdate; }
            set { billdate = value; }
        }
        /// <summary>
        /// 单据编号
        /// </summary>
        public string BillCode
        {
            get { return billcode; }
            set { billcode = value; }
        }
        /// <summary>
        /// 应收增加
        /// </summary>
        public float AddGathering
        {
            get { return addgathering; }
            set { addgathering = value; }
        }
        /// <summary>
        /// 实际增加
        /// </summary>
        public float FactAddfee
        {
            get { return factaddfee; }
            set { factaddfee = value; }
        }
        /// <summary>
        /// 应收减少
        /// </summary>
        public float ReduceGathering
        {
            get { return reducegathering; }
            set { reducegathering = value; }
        }
        /// <summary>
        /// 实际减少
        /// </summary>
        public float FactFee
        {
            get { return factfee; }
            set { factfee = value; }
        }
        /// <summary>
        /// 应收余额
        /// </summary>
        public float Balance
        {
            get { return balance; }
            set { balance = value; }
        }
        /// <summary>
        /// 往来单位
        /// </summary>
        public string Units
        {
            get { return units; }
            set { units = value; }
        }
    }
    #endregion

    #region 定义权限－－数据结构
    public class cPopedom
    {
        private int id = 0;
        private string sysuser = "";
        private string password = "";
        Boolean stock = false;
        Boolean vendition = false;
        Boolean storage = false;
        Boolean system = false;
        Boolean base_info = false;
        /// <summary>
        /// ID
        /// </summary>
        public int ID
        {
            get { return id; }
            set { id = value; }
        }
        /// <summary>
        /// 用户名称
        /// </summary>
        public string SysUser
        {
            get { return sysuser; }
            set { sysuser = value; }
        }
        /// <summary>
        /// 用户密码
        /// </summary>
        public string Password
        {
            get { return password; }
            set { password = value; }
        }
        /// <summary>
        /// 进货权限
        /// </summary>
        public Boolean Stock
        {
            get { return stock; }
            set { stock = value; }
        }
        /// <summary>
        /// 销售权限
        /// </summary>
        public Boolean Vendition
        {
            get { return vendition; }
            set { vendition = value; }
        }
        /// <summary>
        /// 库存权限
        /// </summary>
        public Boolean Storage
        {
            get { return storage; }
            set { storage = value; }
        }
        /// <summary>
        /// 系统设置权限
        /// </summary>
        public Boolean SystemSet
        {
            get { return system; }
            set { system = value; }
        }
        /// <summary>
        /// 基本信息权限
        /// </summary>
        public Boolean Base_Info
        {
            get { return base_info; }
            set { base_info = value; }
        }
    }
    #endregion
}