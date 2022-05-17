using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data;

namespace EMSWCF
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的接口名“IService1”。
    [ServiceContract]
    public interface IDBService
    {
        #region 添加--往来单位信息
        [OperationContract]
        int AddUnits(cUnitsInfo units);
        #endregion

        #region 修改--往来单位信息
        [OperationContract]
        int UpdateUnits(cUnitsInfo units);
        #endregion

        #region 删除--往来单位信息
        [OperationContract]
        int DeleteUnits(cUnitsInfo units);
        #endregion

        #region 查询--往来单位信息
        [OperationContract]
        DataSet FindUnitsByUnitCode(cUnitsInfo units, string tbName);
        [OperationContract]
        DataSet FindUnitsByFullName(cUnitsInfo units, string tbName);
        [OperationContract]
        DataSet GetAllUnits(string tbName);
        #endregion


        #region 添加--库存商品信息
        [OperationContract]
        int AddStock(cStockInfo stock);
        #endregion

        #region 修改--库存商品信息
        [OperationContract]
        int UpdateStock(cStockInfo stock);
        #endregion

        #region 删除--库存商品信息
        [OperationContract]
        int DeleteStock(cStockInfo stock);
        #endregion

        #region 查询--往来单位信息
        [OperationContract]
        DataSet FindStockByProduce(cStockInfo stock, string tbName);
        [OperationContract]
        DataSet FindStockByFullName(cStockInfo stock, string tbName);
        [OperationContract]
        DataSet GetAllStock(string tbName);
        #endregion


        #region 添加--公司职员信息
        [OperationContract]
        int AddEmployee(cEmployeeInfo employee);
        #endregion

        #region 修改--公司职员信息
        [OperationContract]
        int UpdateEmployee(cEmployeeInfo employee);
        #endregion

        #region 删除--公司职员信息
        [OperationContract]
        int DeleteEmployee(cEmployeeInfo employee);
        #endregion

        #region 查询--公司职员信息
        [OperationContract]
        DataSet FindEmployeeByDept(cEmployeeInfo employee, string tbName);
        [OperationContract]
        DataSet FindEmployeeByFullName(cEmployeeInfo employee, string tbName);
        [OperationContract]
        DataSet GetAllEmployee(string tbName);
        #endregion


        #region 商品进销存---单据过账
        [OperationContract]
        DataSet GetAllBill(string tbName_trueName);
        [OperationContract]
        int AddTableMainWarehouse(cBillInfo billinfo, string AddTableName_trueName);
        [OperationContract]
        int AddTableMainSellhouse(cBillInfo billinfo, string AddTableName_trueName);
        [OperationContract]
        int AddTableDetailedWarehouse(cBillInfo billinfo, string AddTableName_trueName);
        [OperationContract]
        int UpdateStock_QtyAndAveragerprice(cStockInfo stock);
        [OperationContract]
        int UpdateSaleStock_Qty(cStockInfo stock);
        [OperationContract]
        int UpdateStock_Qty(cStockInfo stock);
        [OperationContract]
        DataSet GetStockByTrade(cStockInfo stock, string tbName);
        #endregion

        #region 商品进销存---往来账明细表
        [OperationContract]
        int AddCurrentAccount(cCurrentAccount currentAccount);
        #endregion


        #region 进货管理--进货分析
        [OperationContract]
        DataSet BuyStockAnalyse(string tbName);
        [OperationContract]
        DataSet BuyAllStockAnalyse(string tbName);
        #endregion

        #region  进货管理--进货统计
        [OperationContract]
        DataSet BuyStockSumDetailed(cBillInfo billinfo, string tbName, DateTime starDateTime, DateTime endDateTime);
        [OperationContract]
        DataSet BuyStockSum(string tbName);
        #endregion


        #region  销售管理--销售统计
        [OperationContract]
        DataSet SellStockSumDetailed(cBillInfo billinfo, string tbName, DateTime starDateTime, DateTime endDateTime);
        [OperationContract]
        DataSet SellStockSum(string tbName);
        #endregion

        #region 销售管理--月销售状况
        [OperationContract]
        DataSet SellStockStatusSum(string tbName);
        [OperationContract]
        DataSet SellStockDetailed(string strTradeCode, DateTime starDateTime, DateTime endDateTime, string tbName);
        #endregion

        #region 销售管理--商品销售排行
        [OperationContract]
        DataSet SetUnitsList(string tbName);
        [OperationContract]
        DataSet SetHandleList(string tbName);
        [OperationContract]
        DataSet GetTSumDesc(string handle, string units, DateTime StarDateTime, DateTime EndDateTime, string tbName);
        [OperationContract]
        DataSet GetQtyDesc(string handle, string units, DateTime StarDateTime, DateTime EndDateTime, string tbName);
        #endregion

        #region 销售管理--商品销售成本明细
        [OperationContract]
        DataSet GetDetailedkByBillCode(string billCode, string tbName);
        [OperationContract]
        DataSet GetStockByTradeCode(string tradeCode, string tbName);
        [OperationContract]
        DataSet FindSellStock(DateTime starDataTime, DateTime endDataTime);
        #endregion


        #region 库存管理--库存状况
        [OperationContract]
        DataSet setStockStatus(string tbName);
        [OperationContract]
        DataSet GetStockLimitByTradeCode(string tradeCode, string tbName);
        [OperationContract]
        int UpdateStockLimit(cStockInfo stock);
        #endregion

        #region 库存商品上下限报警
        [OperationContract]
        DataSet GetLowerLimit();
        [OperationContract]
        DataSet GetUpperLimit();
        #endregion

        #region 库存盘点
        [OperationContract]
        int CheckStock(cStockInfo stock);
        #endregion


        #region 本单位信息设置--系统设置
        [OperationContract]
        int UpdateSysUnits(cUnits units);
        [OperationContract]
        int InsertSysUnits(cUnits units);
        [OperationContract]
        DataSet GetAllUnit();
        #endregion

        #region  数据库备份与恢复--系统设置
        [OperationContract]
        void BackUp(string bakUpName);
        [OperationContract]
        void ReStore(string reStoreName);
        #endregion

        #region  系统数据清理--系统设置
        [OperationContract]
        void ClearTable(string tbName_true);
        #endregion

        #region 系统操作员及权限设置--系统设置
        [OperationContract]
        void AddSysUser(string userName, string pwd);
        [OperationContract]
        void DeleteSysUser(int ID);
        [OperationContract]
        DataSet GetAllUser();
        [OperationContract]
        bool FindUserName(string userName);
        [OperationContract]
        void UpdateSysUser(cPopedom popedom);
        #endregion

        #region 往来单位对账
        [OperationContract]
        DataSet GetUnitsList();
        [OperationContract]
        DataSet FindCurrentAccountDate(string units, DateTime starDateTime, DateTime endDateTime);
        [OperationContract]
        DataSet FindDetailde(string tb_Detailed_true, string billcode);
        [OperationContract]
        DataSet FindMain(string tb_Main_true, string billcode);
        #endregion

        #region 辅助工具管理
        [OperationContract]
        void OpenInernet();
        #endregion

        #region 系统登录
        [OperationContract]
        DataSet Login(cPopedom popedom);
        #endregion
    }


    // 使用下面示例中说明的数据约定将复合类型添加到服务操作。
    [DataContract]
    public class CompositeType
    {
        bool boolValue = true;
        string stringValue = "Hello ";

        [DataMember]
        public bool BoolValue
        {
            get { return boolValue; }
            set { boolValue = value; }
        }

        [DataMember]
        public string StringValue
        {
            get { return stringValue; }
            set { stringValue = value; }
        }
    }
}
