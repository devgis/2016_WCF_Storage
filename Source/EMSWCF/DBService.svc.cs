﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.ServiceModel.Web;
using System.Text;
using System.Data.SqlClient;
using System.Data;

namespace EMSWCF
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“Service1”。
    public class DBService : IDBService
    {
        DataBase data = new DataBase();//创建DataBase类的对象

        #region 添加--往来单位信息
        /// <summary>
        /// 添加往来单位
        /// </summary>
        /// <param name="client"></param>
        /// <returns>返回往来单位id</returns>
        public int AddUnits(cUnitsInfo units)
        {
            SqlParameter[] prams = {
									    data.MakeInParam("@unitcode",  SqlDbType.VarChar, 5, units.UnitCode),
                						data.MakeInParam("@fullname",  SqlDbType.VarChar, 30, units.FullName),
                						data.MakeInParam("@tax",  SqlDbType.VarChar, 30, units.Tax),
                						data.MakeInParam("@tel",  SqlDbType.VarChar, 20, units.Tel),
                						data.MakeInParam("@linkman",  SqlDbType.VarChar, 10, units.LinkMan),
                						data.MakeInParam("@address",  SqlDbType.VarChar, 60, units.Address),
                						data.MakeInParam("@accounts",  SqlDbType.VarChar, 80, units.Accounts),
										
			};
            return (data.RunProc("INSERT INTO tb_units (unitcode, fullname, tax, tel, linkman, address, accounts) VALUES (@unitcode,@fullname,@tax,@tel,@linkman,@address,@accounts)", prams));
        }
        #endregion

        #region 修改--往来单位信息
        /// <summary>
        /// 修改往来单位信息
        /// </summary>
        /// <param name="units"></param>
        /// <returns></returns>
        public int UpdateUnits(cUnitsInfo units)
        {
            SqlParameter[] prams = {
									    data.MakeInParam("@unitcode",  SqlDbType.VarChar, 5, units.UnitCode),
                						data.MakeInParam("@fullname",  SqlDbType.VarChar, 30, units.FullName),
                						data.MakeInParam("@tax",  SqlDbType.VarChar, 30, units.Tax),
                						data.MakeInParam("@tel",  SqlDbType.VarChar, 20, units.Tel),
                						data.MakeInParam("@linkman",  SqlDbType.VarChar, 10, units.LinkMan),
                						data.MakeInParam("@address",  SqlDbType.VarChar, 60, units.Address),
                						data.MakeInParam("@accounts",  SqlDbType.VarChar, 80, units.Accounts),
			};
            return (data.RunProc("update tb_units set fullname=@fullname,tax=@tax,tel=@tel,linkman=@linkman,address=@address,accounts=@accounts where unitcode=@unitcode", prams));
        }
        #endregion

        #region 删除--往来单位信息
        /// <summary>
        /// 删除往来单位
        /// </summary>
        /// <param name="client"></param>
        /// <returns>返回往来单位id</returns>
        public int DeleteUnits(cUnitsInfo units)
        {
            SqlParameter[] prams = {
									    data.MakeInParam("@unitcode",  SqlDbType.VarChar, 5, units.UnitCode),
			};
            return (data.RunProc("delete from tb_units where unitcode=@unitcode", prams));
        }
        #endregion

        #region 查询--往来单位信息
        /// <summary>
        /// 根据--单位编号--得到往来单位信息
        /// </summary>
        /// <param name="units"></param>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet FindUnitsByUnitCode(cUnitsInfo units, string tbName)
        {
            SqlParameter[] prams = {
									    data.MakeInParam("@unitcode",  SqlDbType.VarChar, 5, units.UnitCode+"%"),
			};
            return (data.RunProcReturn("select * from tb_units where unitcode like @unitcode", prams, tbName));
        }
        /// <summary>
        /// 根据--单位名称--得到往来单位信息
        /// </summary>
        /// <param name="units"></param>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet FindUnitsByFullName(cUnitsInfo units, string tbName)
        {
            SqlParameter[] prams = {
									    data.MakeInParam("@fullname",  SqlDbType.VarChar, 30, units.FullName+"%"),
			};
            return (data.RunProcReturn("select * from tb_units where fullname like @fullname", prams, tbName));
        }
        /// <summary>
        /// 得到所有--往来单位信息
        /// </summary>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet GetAllUnits(string tbName)
        {
            return (data.RunProcReturn("select * from tb_units ORDER BY unitcode", tbName));
        }
        #endregion


        #region 添加--库存商品信息
        /// <summary>
        /// 添加库存商品基本信息
        /// </summary>
        /// <param name="stock">库存商品数据结构类对象</param>
        /// <returns></returns>
        public int AddStock(cStockInfo stock)
        {
            SqlParameter[] prams = {
									    data.MakeInParam("@tradecode",  SqlDbType.VarChar, 5, stock.TradeCode),
                						data.MakeInParam("@fullname",  SqlDbType.VarChar, 30,stock.FullName),
                						data.MakeInParam("@type",  SqlDbType.VarChar, 10, stock.TradeType),
                						data.MakeInParam("@standard",  SqlDbType.VarChar, 10, stock.Standard),
                						data.MakeInParam("@unit",  SqlDbType.VarChar, 4, stock.Unit),
                						data.MakeInParam("@produce",  SqlDbType.VarChar, 20, stock.Produce),
			};
            return (data.RunProc("INSERT INTO tb_stock (tradecode, fullname, type, standard, unit, produce) VALUES (@tradecode,@fullname,@type,@standard,@unit,@produce)", prams));
        }
        #endregion

        #region 修改--库存商品信息
        /// <summary>
        /// 修改库存商品信息
        /// </summary>
        /// <param name="stock">库存商品数据结构类对象</param>
        /// <returns></returns>
        public int UpdateStock(cStockInfo stock)
        {
            SqlParameter[] prams = {
									    data.MakeInParam("@tradecode",  SqlDbType.VarChar, 5, stock.TradeCode),
                						data.MakeInParam("@fullname",  SqlDbType.VarChar, 30,stock.FullName),
                						data.MakeInParam("@type",  SqlDbType.VarChar, 10, stock.TradeType),
                						data.MakeInParam("@standard",  SqlDbType.VarChar, 10, stock.Standard),
                						data.MakeInParam("@unit",  SqlDbType.VarChar, 4, stock.Unit),
                						data.MakeInParam("@produce",  SqlDbType.VarChar, 20, stock.Produce),
			};
            return (data.RunProc("update tb_stock set fullname=@fullname,type=@type,standard=@standard,unit=@unit,produce=@produce where tradecode=@tradecode", prams));
        }
        #endregion

        #region 删除--库存商品信息
        /// <summary>
        /// 删除库存商品信息
        /// </summary>
        /// <param name="stock">库存商品数据结构类对象</param>
        /// <returns></returns>
        public int DeleteStock(cStockInfo stock)
        {
            SqlParameter[] prams = {
									    data.MakeInParam("@tradecode",  SqlDbType.VarChar, 5, stock.TradeCode),
			};
            return (data.RunProc("delete from tb_stock where tradecode=@tradecode", prams));
        }
        #endregion

        #region 查询--往来单位信息
        /// <summary>
        /// 根据--商品产地--得到库存商品信息
        /// </summary>
        /// <param name="stock">库存商品数据结构类对象</param>
        /// <param name="tbName">映射原表名称</param>
        /// <returns></returns>
        public DataSet FindStockByProduce(cStockInfo stock, string tbName)
        {
            SqlParameter[] prams = {
									    data.MakeInParam("@produce",  SqlDbType.VarChar, 5, stock.Produce+"%"),
			};
            return (data.RunProcReturn("select * from tb_stock where produce like @produce", prams, tbName));
        }
        /// <summary>
        /// 根据--商品名称--得到库存商品信息
        /// </summary>
        /// <param name="units"></param>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet FindStockByFullName(cStockInfo stock, string tbName)
        {
            SqlParameter[] prams = {
									    data.MakeInParam("@fullname",  SqlDbType.VarChar, 30, stock.FullName+"%"),
			};
            return (data.RunProcReturn("select * from tb_stock where fullname like @fullname", prams, tbName));
        }
        /// <summary>
        /// 得到所有--库存商品信息
        /// </summary>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet GetAllStock(string tbName)
        {
            return (data.RunProcReturn("select * from tb_Stock ORDER BY tradecode", tbName));
        }
        #endregion


        #region 添加--公司职员信息
        /// <summary>
        /// 添加--公司职员--信息
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public int AddEmployee(cEmployeeInfo employee)
        {
            SqlParameter[] prams = {
									    data.MakeInParam("@employeecode",  SqlDbType.VarChar, 5, employee.EmployeeCode),
                						data.MakeInParam("@fullname",  SqlDbType.VarChar, 20,employee.FullName),
                						data.MakeInParam("@sex",  SqlDbType.VarChar, 4, employee.Sex),
                						data.MakeInParam("@dept",  SqlDbType.VarChar, 20, employee.Dept),
                						data.MakeInParam("@tel",  SqlDbType.VarChar, 20, employee.Tel),
                						data.MakeInParam("@memo",  SqlDbType.VarChar, 20, employee.Memo),
			};
            return (data.RunProc("INSERT INTO tb_Employee (employeecode, fullname, sex, dept, tel, memo) VALUES (@employeecode,@fullname,@sex,@dept,@tel,@memo)", prams));
        }
        #endregion

        #region 修改--公司职员信息
        /// <summary>
        /// 修改--公司职员--信息
        /// </summary>
        /// <param name="units"></param>
        /// <returns></returns>
        public int UpdateEmployee(cEmployeeInfo employee)
        {
            SqlParameter[] prams = {
									    data.MakeInParam("@employeecode",  SqlDbType.VarChar, 5, employee.EmployeeCode),
                						data.MakeInParam("@fullname",  SqlDbType.VarChar, 20,employee.FullName),
                						data.MakeInParam("@sex",  SqlDbType.VarChar, 4, employee.Sex),
                						data.MakeInParam("@dept",  SqlDbType.VarChar, 20, employee.Dept),
                						data.MakeInParam("@tel",  SqlDbType.VarChar, 20, employee.Tel),
                						data.MakeInParam("@memo",  SqlDbType.VarChar, 20, employee.Memo),
			};
            return (data.RunProc("update tb_Employee set fullname=@fullname,sex=@sex,dept=@dept,tel=@tel,memo=@memo where employeecode=@employeecode", prams));
        }
        #endregion

        #region 删除--公司职员信息
        /// <summary>
        /// 删除--公司职员--信息
        /// </summary>
        /// <param name="client"></param>
        /// <returns></returns>
        public int DeleteEmployee(cEmployeeInfo employee)
        {
            SqlParameter[] prams = {
									    data.MakeInParam("@employeecode",  SqlDbType.VarChar, 5, employee.EmployeeCode),
			};
            return (data.RunProc("delete from tb_employee where employeecode=@employeecode", prams));
        }
        #endregion

        #region 查询--公司职员信息
        /// <summary>
        /// 根据--职员所在部门--得到公司职员信息
        /// </summary>
        /// <param name="units"></param>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet FindEmployeeByDept(cEmployeeInfo employee, string tbName)
        {
            SqlParameter[] prams = {
									    data.MakeInParam("@dept",  SqlDbType.VarChar, 20, employee.Dept+"%"),
			};
            return (data.RunProcReturn("select * from tb_employee where dept like @dept", prams, tbName));
        }
        /// <summary>
        /// 根据--职员姓名--得到公司职员信息
        /// </summary>
        /// <param name="units"></param>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet FindEmployeeByFullName(cEmployeeInfo employee, string tbName)
        {
            SqlParameter[] prams = {
									    data.MakeInParam("@fullname",  SqlDbType.VarChar, 20, employee.FullName+"%"),
			};
            return (data.RunProcReturn("select * from tb_employee where fullname like @fullname", prams, tbName));
        }
        /// <summary>
        /// 得到所有--公司职员信息
        /// </summary>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet GetAllEmployee(string tbName)
        {
            return (data.RunProcReturn("select * from tb_Employee ORDER BY employeecode", tbName));
        }
        #endregion


        #region 商品进销存---单据过账

        /// <summary>
        /// 得到所有tbName表中信息－－主要用来：得到最大的单据编号然后自动编号
        /// </summary>
        /// <param name="tbName">数据表名称</param>
        /// <returns></returns>
        public DataSet GetAllBill(string tbName_trueName)
        {
            return (data.RunProcReturn("select * from " + tbName_trueName + "", tbName_trueName));
        }
        /// <summary>
        /// 处理进货单和销售退货单-数据---向主表中添加数据
        /// </summary>
        /// <param name="billinfo">过账单据数据结构类对象</param>
        /// <param name="AddTableName_trueName">数据库中数据表名称</param>
        /// <returns></returns>
        public int AddTableMainWarehouse(cBillInfo billinfo, string AddTableName_trueName)
        {
            SqlParameter[] prams = {
									    data.MakeInParam("@billdate",  SqlDbType.DateTime, 8, billinfo.BillDate),
                						data.MakeInParam("@billcode",  SqlDbType.VarChar, 20,billinfo.BillCode),
                						data.MakeInParam("@units",  SqlDbType.VarChar, 30, billinfo.Units),
                						data.MakeInParam("@handle",  SqlDbType.VarChar, 10, billinfo.Handle),
                						data.MakeInParam("@summary",  SqlDbType.VarChar, 100, billinfo.Summary),
                						data.MakeInParam("@fullpayment",  SqlDbType.Float, 8, billinfo.FullPayment),
                                        data.MakeInParam("@payment",  SqlDbType.Float, 8, billinfo.Payment),
			};
            return (data.RunProc("INSERT INTO " + AddTableName_trueName + " (billdate, billcode, units, handle, summary, fullpayment,payment) VALUES (@billdate,@billcode,@units,@handle,@summary,@fullpayment,@payment)", prams));
        }
        /// <summary>
        /// 处理进货退货单和销售单-数据---向主表中添加数据
        /// </summary>
        /// <param name="billinfo">过账单据数据结构类对象</param>
        /// <param name="AddTableName_trueName">数据库中数据表名称</param>
        /// <returns></returns>
        public int AddTableMainSellhouse(cBillInfo billinfo, string AddTableName_trueName)
        {
            SqlParameter[] prams = {
									    data.MakeInParam("@billdate",  SqlDbType.DateTime, 8, billinfo.BillDate),
                						data.MakeInParam("@billcode",  SqlDbType.VarChar, 20,billinfo.BillCode),
                						data.MakeInParam("@units",  SqlDbType.VarChar, 30, billinfo.Units),
                						data.MakeInParam("@handle",  SqlDbType.VarChar, 10, billinfo.Handle),
                						data.MakeInParam("@summary",  SqlDbType.VarChar, 100, billinfo.Summary),
                						data.MakeInParam("@fullpayment",  SqlDbType.Float, 8, billinfo.FullPayment),
                                        data.MakeInParam("@payment",  SqlDbType.Float, 8, billinfo.Payment),
			};
            return (data.RunProc("INSERT INTO " + AddTableName_trueName + " (billdate, billcode, units, handle, summary, fullgathering,gathering) VALUES (@billdate,@billcode,@units,@handle,@summary,@fullpayment,@payment)", prams));
        }



        /// <summary>
        /// 向明细表中添加数据－进货单－销售退货单－销售单－进货退货单
        /// </summary>
        /// <param name="billinfo">过账单据数据结构类对象</param>
        /// <param name="AddTableName_trueName">数据库中数据表名称</param>
        /// <returns></returns>
        public int AddTableDetailedWarehouse(cBillInfo billinfo, string AddTableName_trueName)
        {
            SqlParameter[] prams = {
									    data.MakeInParam("@billcode",  SqlDbType.VarChar, 20, billinfo.BillCode),
                						data.MakeInParam("@tradecode",  SqlDbType.VarChar, 20,billinfo.TradeCode),
                						data.MakeInParam("@fullname",  SqlDbType.VarChar, 20, billinfo.FullName),
                						data.MakeInParam("@unit",  SqlDbType.VarChar, 10, billinfo.TradeUnit),
                						data.MakeInParam("@qty",  SqlDbType.Float, 8, billinfo.Qty),
                						data.MakeInParam("@price",  SqlDbType.Float, 8, billinfo.Price),
                                        data.MakeInParam("@tsum",  SqlDbType.Float, 8, billinfo.TSum),
                                        data.MakeInParam("@billdate",  SqlDbType.DateTime, 8, billinfo.BillDate),
            };
            return (data.RunProc("INSERT INTO " + AddTableName_trueName + " (billcode, tradecode, fullname, unit, qty, price,tsum,billdate) VALUES (@billcode,@tradecode,@fullname,@unit,@qty,@price,@tsum,@billdate)", prams));
        }
        /// <summary>
        /// 修改库存数量和加权平均价格
        /// </summary>
        /// <param name="stock">库存商品数据结构类对象</param>
        /// <returns></returns>
        public int UpdateStock_QtyAndAveragerprice(cStockInfo stock)
        {
            SqlParameter[] prams = {
									    data.MakeInParam("@tradecode",  SqlDbType.VarChar, 5, stock.TradeCode),
                						data.MakeInParam("@qty",  SqlDbType.Float, 30,stock.Qty),
                                        data.MakeInParam("@price",  SqlDbType.Float, 30,stock.Price),
                						data.MakeInParam("@averageprice",  SqlDbType.Float, 10, stock.AveragePrice),
			};
            return (data.RunProc("update tb_stock set qty=@qty,price=@averageprice,averageprice=@averageprice where tradecode=@tradecode", prams));
        }
        /// <summary>
        /// 修改销售商品和进货退货商品--后的库存商品数量
        /// </summary>
        /// <param name="stock"></param>
        /// <returns></returns>
        public int UpdateSaleStock_Qty(cStockInfo stock)
        {
            SqlParameter[] prams = {
									    data.MakeInParam("@tradecode",  SqlDbType.VarChar, 5, stock.TradeCode),
                						data.MakeInParam("@qty",  SqlDbType.Float, 30,stock.Qty),
			};
            return (data.RunProc("update tb_stock set qty=@qty where tradecode=@tradecode", prams));
        }
        /// <summary>
        /// 修改库存数量和销售（和进货退货）最后一次价格
        /// </summary>
        /// <param name="stock">库存商品数据结构类对象</param>
        /// <returns></returns>
        public int UpdateStock_Qty(cStockInfo stock)
        {
            SqlParameter[] prams = {
									    data.MakeInParam("@tradecode",  SqlDbType.VarChar, 5, stock.TradeCode),
                						data.MakeInParam("@qty",  SqlDbType.Float, 30,stock.Qty),
                                        data.MakeInParam("@price",  SqlDbType.Float, 30,stock.SalePrice),
			};
            return (data.RunProc("update tb_stock set qty=@qty,saleprice=@price where tradecode=@tradecode", prams));
        }
        /// <summary>
        /// 根据商品编号TradeCode,主要得到数量和加权平均价格，用于对其更新。
        /// </summary>
        /// <param name="stock">库存商品数据结构类对象</param>
        /// <param name="tbName">映射虚拟表名称</param>
        /// <returns></returns>
        public DataSet GetStockByTrade(cStockInfo stock, string tbName)
        {
            SqlParameter[] prams = {
									    data.MakeInParam("@tradecode",SqlDbType.VarChar, 30, stock.TradeCode),
			};
            return (data.RunProcReturn("select * from tb_stock where tradecode like @tradecode", prams, tbName));
        }
        #endregion

        #region 商品进销存---往来账明细表
        /// <summary>
        /// 添加数据---往来账本明细表
        /// </summary>
        /// <param name="currentAccount"></param>
        /// <returns></returns>
        public int AddCurrentAccount(cCurrentAccount currentAccount)
        {
            SqlParameter[] prams = {
									    data.MakeInParam("@billdate",  SqlDbType.DateTime, 8, currentAccount.BillDate),
                						data.MakeInParam("@billcode",  SqlDbType.VarChar, 20,currentAccount.BillCode),
                						data.MakeInParam("@addgathering",  SqlDbType.Float, 8, currentAccount.AddGathering),
                						data.MakeInParam("@factaddfee",  SqlDbType.Float, 8,currentAccount.FactAddFee),
                						data.MakeInParam("@reducegathering",  SqlDbType.Float, 8,currentAccount.ReduceGathering),
                						data.MakeInParam("@factfee",  SqlDbType.Float, 8, currentAccount.FactReduceGathering),
                                        data.MakeInParam("@balance",  SqlDbType.Float, 8, currentAccount.Balance),
                                        data.MakeInParam("@units",  SqlDbType.VarChar, 20,currentAccount.Units),
			};
            return (data.RunProc("INSERT INTO tb_currentaccount (billdate, billcode, addgathering, factaddfee, reducegathering, factfee,balance,units) VALUES (@billdate,@billcode,@addgathering,@factaddfee,@reducegathering,@factfee,@balance,@units)", prams));
        }
        #endregion


        #region 进货管理--进货分析
        /// <summary>
        /// 商品进货分析--不含进货退货
        /// </summary>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet BuyStockAnalyse(string tbName)
        {
            return (data.RunProcReturn("SELECT a.tradecode, a.fullname, a.averageprice, b.qty, b.tsum FROM tb_stock a INNER JOIN (SELECT SUM(qty) AS qty, SUM(tsum) AS tsum, fullname FROM tb_rewarehouse_detailed GROUP BY fullname) b ON a.fullname = b.fullname WHERE (a.price > 0)", tbName));
        }

        /// <summary>
        /// 商品进货分析（含退货）
        /// </summary>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet BuyAllStockAnalyse(string tbName)
        {
            return (data.RunProcReturn("select tradecode,fullname,sum(qty) as qty,AVG(price) AS price,sum(tsum) as tsum from tb_warehouse_detailed group by tradecode,fullname", tbName));
        }
        #endregion

        #region  进货管理--进货统计
        /// <summary>
        /// 进货商品－－详细统计
        /// </summary>
        /// <param name="billinfo"></param>
        /// <param name="tbName"></param>
        /// <param name="starDateTime"></param>
        /// <param name="endDateTime"></param>
        /// <returns></returns>
        public DataSet BuyStockSumDetailed(cBillInfo billinfo, string tbName, DateTime starDateTime, DateTime endDateTime)
        {
            SqlParameter[] prams = {
                						data.MakeInParam("@units",  SqlDbType.VarChar, 30, "%"+billinfo.Units+"%"),
                						data.MakeInParam("@handle",  SqlDbType.VarChar, 10,"%"+ billinfo.Handle+"%"),
			};
            return (data.RunProcReturn("SELECT b.tradecode AS 商品编号, b.fullname AS 商品名称, SUM(b.qty) AS 进货数量,SUM(b.tsum) AS 进货金额 FROM tb_warehouse_main a INNER JOIN (SELECT billcode, tradecode, fullname, SUM(qty) AS qty, SUM(tsum) AS tsum FROM tb_warehouse_detailed GROUP BY tradecode, billcode, fullname) b ON a.billcode = b.billcode AND a.units LIKE @units AND a.handle LIKE @handle WHERE (a.billdate BETWEEN '" + starDateTime + "' AND '" + endDateTime + "') GROUP BY b.tradecode, b.fullname", prams, tbName));
        }
        /// <summary>
        /// 进货商品－－统计所有
        /// </summary>
        /// <param name="billinfo"></param>
        /// <param name="tbName"></param>
        /// <param name="starDateTime"></param>
        /// <param name="endDateTime"></param>
        /// <returns></returns>
        public DataSet BuyStockSum(string tbName)
        {
            return (data.RunProcReturn("select tradecode as 商品编号,fullname as 商品名称,sum(qty) as 进货数量,sum(tsum)as 进货金额 from tb_warehouse_detailed group by tradecode, fullname", tbName));
        }
        #endregion


        #region  销售管理--销售统计
        /// <summary>
        /// 销售商品－－详细统计
        /// </summary>
        /// <param name="billinfo"></param>
        /// <param name="tbName"></param>
        /// <param name="starDateTime"></param>
        /// <param name="endDateTime"></param>
        /// <returns></returns>
        public DataSet SellStockSumDetailed(cBillInfo billinfo, string tbName, DateTime starDateTime, DateTime endDateTime)
        {
            SqlParameter[] prams = {
                						data.MakeInParam("@units",  SqlDbType.VarChar, 30,"%"+ billinfo.Units+"%"),
                						data.MakeInParam("@handle",  SqlDbType.VarChar, 10,"%"+ billinfo.Handle+"%"),
			};
            return (data.RunProcReturn("SELECT b.tradecode AS 商品编号, b.fullname AS 商品名称, SUM(b.qty) AS 销售数量,SUM(b.tsum) AS 销售金额 FROM tb_sell_main a INNER JOIN (SELECT billcode, tradecode, fullname, SUM(qty) AS qty, SUM(tsum) AS tsum FROM tb_sell_detailed GROUP BY tradecode, billcode, fullname) b ON a.billcode = b.billcode AND a.units LIKE @units AND a.handle LIKE @units WHERE (a.billdate BETWEEN '" + starDateTime + "' AND '" + endDateTime + "') GROUP BY b.tradecode, b.fullname", prams, tbName));
        }
        /// <summary>
        /// 销售商品－－统计所有
        /// </summary>
        /// <param name="billinfo"></param>
        /// <param name="tbName"></param>
        /// <param name="starDateTime"></param>
        /// <param name="endDateTime"></param>
        /// <returns></returns>
        public DataSet SellStockSum(string tbName)
        {
            return (data.RunProcReturn("select tradecode as 商品编号,fullname as 商品名称,sum(qty) as 销售数量,sum(tsum) as 销售金额 from tb_sell_detailed group by tradecode, fullname", tbName));
        }
        #endregion

        #region 销售管理--月销售状况
        /// <summary>
        /// 统计商品销售状况
        /// </summary>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet SellStockStatusSum(string tbName)
        {
            return (data.RunProcReturn("select a.tradecode as 商品编号,a.fullname as 商品名称,a.qty as 销售数量,a.price AS 销售均价,a.tsum as 销售金额,b.qty2 as '退货数量',b.tsum2 as '退货金额' from (SELECT tradecode,fullname,avg(price)as price,sum(qty) AS qty, sum(tsum) as tsum from tb_sell_detailed group by tradecode,fullname) a left join (SELECT tradecode,fullname,sum(qty) AS qty2, sum(tsum) as tsum2 from tb_resell_detailed group by tradecode,fullname) b on a.tradecode=b.tradecode ", tbName));
        }

        /// <summary>
        /// 明细账本－－－‘商品销售’和‘商品销售退货’
        /// </summary>
        /// <param name="strTradeCode"></param>
        /// <param name="starDateTime"></param>
        /// <param name="endDateTime"></param>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet SellStockDetailed(string strTradeCode, DateTime starDateTime, DateTime endDateTime, string tbName)
        {
            return (data.RunProcReturn("SELECT billdate as 销售日期, billcode as 单据编号, tradecode as 商品编号, fullname as 商品名称, price as 销售价格, qty as 销售数量, tsum as 销售金额 FROM " + tbName + " where tradecode = '" + strTradeCode + "' AND billdate BETWEEN '" + starDateTime.Date.ToShortDateString() + "' AND '" + endDateTime.Date.ToShortDateString() + "'", tbName));
        }
        #endregion

        #region 销售管理--商品销售排行
        /// <summary>
        /// 设置排行榜条件－－往来单位-下拉列表
        /// </summary>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet SetUnitsList(string tbName)
        {
            return (data.RunProcReturn("select * from tb_units", tbName));
        }
        /// <summary>
        /// 设置排行榜条件－－经手人-下拉列表
        /// </summary>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet SetHandleList(string tbName)
        {
            return (data.RunProcReturn("select * from tb_employee", tbName));
        }
        /// <summary>
        /// 按销售金额排行
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="units"></param>
        /// <param name="StarDateTime"></param>
        /// <param name="EndDateTime"></param>
        /// <returns></returns>
        public DataSet GetTSumDesc(string handle, string units, DateTime StarDateTime, DateTime EndDateTime, string tbName)
        {
            return (data.RunProcReturn("SELECT * FROM (SELECT b.tradecode AS 商品编号, b.fullname AS 商品名称, SUM(b.qty) AS 销售数量, SUM(b.tsum) AS 销售金额 FROM tb_sell_main a INNER JOIN (SELECT billcode, tradecode, fullname, SUM(qty) AS qty, SUM(tsum) AS tsum FROM tb_sell_detailed GROUP BY tradecode, billcode, fullname) b ON a.billcode = b.billcode AND a.units LIKE '%" + units + "%' AND a.handle LIKE '%" + handle + "%' WHERE (a.billdate BETWEEN '" + StarDateTime + "' AND '" + EndDateTime + "')GROUP BY b.tradecode, b.fullname) DERIVEDTBL ORDER BY 销售金额 DESC", tbName));
        }
        /// <summary>
        /// 按销售数量排行
        /// </summary>
        /// <param name="handle"></param>
        /// <param name="units"></param>
        /// <param name="StarDateTime"></param>
        /// <param name="EndDateTime"></param>
        /// <returns></returns>
        public DataSet GetQtyDesc(string handle, string units, DateTime StarDateTime, DateTime EndDateTime, string tbName)
        {
            return (data.RunProcReturn("SELECT * FROM (SELECT b.tradecode AS 商品编号, b.fullname AS 商品名称, SUM(b.qty) AS 销售数量, SUM(b.tsum) AS 销售金额 FROM tb_sell_main a INNER JOIN (SELECT billcode, tradecode, fullname, SUM(qty) AS qty, SUM(tsum) AS tsum FROM tb_sell_detailed GROUP BY tradecode, billcode, fullname) b ON a.billcode = b.billcode AND a.units LIKE '%" + units + "%' AND a.handle LIKE '%" + handle + "%' WHERE (a.billdate BETWEEN '" + StarDateTime + "' AND '" + EndDateTime + "')GROUP BY b.tradecode, b.fullname) DERIVEDTBL ORDER BY 销售数量 DESC", tbName));
        }
        #endregion

        #region 销售管理--商品销售成本明细
        /// <summary>
        /// 根据单据编号--得到销售明细表中数据
        /// </summary>
        /// <param name="stock"></param>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet GetDetailedkByBillCode(string billCode, string tbName)
        {
            return (data.RunProcReturn("SELECT tradecode,fullname,price,tsum,SUM(qty) AS qty FROM tb_sell_detailed WHERE (billcode = '" + billCode + "')group by tradecode,fullname,price,tsum", tbName));
        }
        /// <summary>
        /// 根据单据编号--得到销售明细表中数据
        /// </summary>
        /// <param name="stock"></param>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet GetStockByTradeCode(string tradeCode, string tbName)
        {
            return (data.RunProcReturn("select * from tb_stock where tradecode ='" + tradeCode + "'", tbName));
        }
        /// <summary>
        /// 根据日期－－查询销售主表中数据
        /// </summary>
        /// <param name="starDataTime"></param>
        /// <param name="endDataTime"></param>
        /// <returns></returns>
        public DataSet FindSellStock(DateTime starDataTime, DateTime endDataTime)
        {
            return (data.RunProcReturn("select * from tb_sell_main where (billdate BETWEEN '" + starDataTime + " ' AND '" + endDataTime + " ')", "tb_sell_main"));
        }
        #endregion


        #region 库存管理--库存状况
        /// <summary>
        /// 检索库存商品--并按数量排序
        /// </summary>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet setStockStatus(string tbName)
        {
            return (data.RunProcReturn("select * from tb_stock order by qty", tbName));
        }
        /// <summary>
        /// 根据商品编号，获得库存商品中所有信息
        /// </summary>
        /// <param name="tradeCode"></param>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet GetStockLimitByTradeCode(string tradeCode, string tbName)
        {
            return (data.RunProcReturn("select * from tb_Stock where tradecode='" + tradeCode + "'", tbName));
        }
        /// <summary>
        /// 库存商品上下限设置
        /// </summary>
        /// <param name="stock"></param>
        /// <returns></returns>
        public int UpdateStockLimit(cStockInfo stock)
        {
            SqlParameter[] prams = {
									    data.MakeInParam("@tradecode",  SqlDbType.VarChar,5,stock.TradeCode),
                						data.MakeInParam("@upperlimit",  SqlDbType.Float, 8, stock.UpperLimit),
                						data.MakeInParam("@lowerlimit",  SqlDbType.Float, 8, stock.LowerLimit),
            };
            return (data.RunProc("update tb_stock set upperlimit=@upperlimit,lowerlimit=@lowerlimit where tradecode=@tradecode", prams));
        }
        #endregion

        #region 库存商品上下限报警
        /// <summary>
        /// 库存商品下限报警
        /// </summary>
        /// <returns></returns>
        public DataSet GetLowerLimit()
        {
            return (data.RunProcReturn("SELECT tradecode as 商品编号, fullname as 商品名称, qty as 库存数量,upperlimit as 库存上限,lowerlimit as 库存下限 from tb_stock WHERE (qty < lowerlimit) and lowerlimit > 0", "tb_stock"));
        }
        /// <summary>
        /// 库存商品上限报警
        /// </summary>
        /// <returns></returns>
        public DataSet GetUpperLimit()
        {
            return (data.RunProcReturn("SELECT tradecode as 商品编号, fullname as 商品名称, qty as 库存数量,upperlimit as 库存上限,lowerlimit as 库存下限 FROM tb_stock WHERE (upperlimit < qty) and upperlimit>0", "tb_stock"));
        }
        #endregion

        #region 库存盘点
        public int CheckStock(cStockInfo stock)
        {
            SqlParameter[] prams = {
									    data.MakeInParam("@tradecode",  SqlDbType.VarChar, 5, stock.TradeCode),
                						data.MakeInParam("@check",  SqlDbType.Float, 8,stock.Check),
			};
            return (data.RunProc("update tb_stock set stockcheck=@check where tradecode=@tradecode", prams));
        }
        #endregion


        #region 本单位信息设置--系统设置
        /// <summary>
        /// 本单位信息设置
        /// </summary>
        /// <param name="units"></param>
        /// <returns></returns>
        public int UpdateSysUnits(cUnits units)
        {
            SqlParameter[] prams = {
                						data.MakeInParam("@fullname",  SqlDbType.VarChar, 30, units.FullName),
                						data.MakeInParam("@tax",  SqlDbType.VarChar, 30, units.Tax),
                						data.MakeInParam("@tel",  SqlDbType.VarChar, 20, units.Tel),
                						data.MakeInParam("@linkman",  SqlDbType.VarChar, 10, units.Linkman),
                						data.MakeInParam("@address",  SqlDbType.VarChar, 60, units.Address),
                						data.MakeInParam("@accounts",  SqlDbType.VarChar, 80, units.Accounts),
			};
            return (data.RunProc("update tb_unit set fullname=@fullname,tax=@tax,tel=@tel,linkman=@linkman,address=@address,accounts=@accounts", prams));
        }
        public int InsertSysUnits(cUnits units)
        {
            SqlParameter[] prams = {
                						data.MakeInParam("@fullname",  SqlDbType.VarChar, 30, units.FullName),
                						data.MakeInParam("@tax",  SqlDbType.VarChar, 30, units.Tax),
                						data.MakeInParam("@tel",  SqlDbType.VarChar, 20, units.Tel),
                						data.MakeInParam("@linkman",  SqlDbType.VarChar, 10, units.Linkman),
                						data.MakeInParam("@address",  SqlDbType.VarChar, 60, units.Address),
                						data.MakeInParam("@accounts",  SqlDbType.VarChar, 80, units.Accounts),
			};
            return (data.RunProc("insert into tb_unit (fullname,tax,tel,linkman,address,accounts) values (@fullname,@tax,@tel,@linkman,@address,@accounts)", prams));
        }
        /// <summary>
        /// 得到本单位信息设置
        /// </summary>
        /// <param name="tbName"></param>
        /// <returns></returns>
        public DataSet GetAllUnit()
        {
            return (data.RunProcReturn("select * from tb_unit", "tb_unit"));
        }
        #endregion

        #region  数据库备份与恢复--系统设置
        /// <summary>
        /// 备份数据库
        /// </summary>
        /// <param name="bakUpName"></param>
        public void BackUp(string bakUpName)
        {
            data.RunProc("BACKUP DATABASE db_EMS TO DISK ='" + bakUpName + "'");
        }
        /// <summary>
        /// 恢复数据库
        /// </summary>
        /// <param name="reStoreName"></param>
        public void ReStore(string reStoreName)
        {
            data.RunProc("backup log db_EMS to disk='" + reStoreName + "'use master RESTORE DATABASE db_EMS from disk='" + reStoreName + "'");
        }
        #endregion

        #region  系统数据清理--系统设置
        /// <summary>
        /// 根据指定的数据表清除数据表中数据
        /// </summary>
        /// <param name="tbName_true"></param>
        public void ClearTable(string tbName_true)
        {
            data.RunProc("delete from " + tbName_true + "");
        }
        #endregion

        #region 系统操作员及权限设置--系统设置
        /// <summary>
        /// 添加系统操作员
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="pwd"></param>
        public void AddSysUser(string userName, string pwd)
        {
            data.RunProc("INSERT INTO tb_power (sysuser, password) VALUES ('" + userName + "', '" + pwd + "')");
        }
        /// <summary>
        /// 删除系统操作员
        /// </summary>
        /// <param name="ID"></param>
        public void DeleteSysUser(int ID)
        {
            data.RunProc("delete from tb_power where id='" + ID + "'");
        }
        /// <summary>
        /// 获得所有系统用户信息
        /// </summary>
        /// <returns></returns>
        public DataSet GetAllUser()
        {
            return (data.RunProcReturn("select * from tb_power", "tb_Power"));
        }
        /// <summary>
        /// 根据用户名称---查询系统用户
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public bool FindUserName(string userName)
        {
            DataSet ds = null;
            ds = data.RunProcReturn("select * from tb_power where sysuser='" + userName + "'", "tb_power");
            if (ds.Tables[0].Rows.Count > 0)
            { return true; }
            else
            { return false; }
        }
        /// <summary>
        /// 修改系统用户信息及所对应的权限
        /// </summary>
        /// <param name="popedom"></param>
        public void UpdateSysUser(cPopedom popedom)
        {
            SqlParameter[] prams = {
                                        data.MakeInParam("@id",  SqlDbType.Int, 4, popedom.ID),
									    data.MakeInParam("@sysuser",  SqlDbType.VarChar, 20, popedom.SysUser),
                						data.MakeInParam("@password",  SqlDbType.VarChar, 20,popedom.Password),
                						data.MakeInParam("@stock",  SqlDbType.Bit, 1, popedom.Stock),
                						data.MakeInParam("@vendition",  SqlDbType.Bit, 1, popedom.Vendition),
                						data.MakeInParam("@storage",  SqlDbType.Bit, 1, popedom.Storage),
                						data.MakeInParam("@system",  SqlDbType.Bit, 1, popedom.SystemSet),
                                        data.MakeInParam("@base",  SqlDbType.Bit, 1, popedom.Base_Info),
			};
            int i = data.RunProc("update tb_power set sysuser=@sysuser,password=@password,stock=@stock,vendition=@vendition,storage=@storage,system=@system,base=@base where id=@id", prams);
        }
        #endregion

        #region 往来单位对账
        /// <summary>
        /// 往来单位列表--并统计应收额-增加及减少
        /// </summary>
        /// <returns></returns>
        public DataSet GetUnitsList()
        {
            return (data.RunProcReturn("SELECT units as 往来单位, SUM(addgathering) AS 应收增加, SUM(reducegathering) AS 应收减少 FROM tb_currentaccount GROUP BY units", "tb_currentaccount"));
        }
        /// <summary>
        ///查询在指定的日期段中--是否存在－－查询结果
        /// </summary>
        /// <param name="units"></param>
        /// <param name="starDateTime"></param>
        /// <param name="endDateTime"></param>
        /// <returns></returns>
        public DataSet FindCurrentAccountDate(string units, DateTime starDateTime, DateTime endDateTime)
        {
            return (data.RunProcReturn("SELECT * FROM tb_currentaccount WHERE units='" + units + "' AND billdate BETWEEN '" + starDateTime + "'AND '" + endDateTime + "'", "tb_currentaccount"));
        }
        /// <summary>
        /// 往来对账－－根据单据编号--查询明细表中数据
        /// </summary>
        /// <param name="billcode"></param>
        /// <param name="tb_Detailed_true"></param>
        /// <returns></returns>
        public DataSet FindDetailde(string tb_Detailed_true, string billcode)
        {
            return (data.RunProcReturn("select * from " + tb_Detailed_true + " where (billcode='" + billcode + "')ORDER BY tsum", "detailed"));
        }
        /// <summary>
        /// 往来对账－－根据单据编号--查询主表中数据
        /// </summary>
        /// <param name="tb_Main_true"></param>
        /// <param name="billcode"></param>
        /// <returns></returns>
        public DataSet FindMain(string tb_Main_true, string billcode)
        {
            return (data.RunProcReturn("select * from " + tb_Main_true + " where billcode='" + billcode + "'", "main"));
        }
        #endregion

        #region 辅助工具管理
        //ShellExecute Me.hWnd, "open", "http://www.mingrisoft.com", 1, 1, 5
        public void OpenInernet()
        {

        }
        #endregion

        #region 系统登录
        /// <summary>
        /// 系统登录
        /// </summary>
        /// <param name="popedom"></param>
        /// <returns></returns>
        public DataSet Login(cPopedom popedom)
        {
            SqlParameter[] prams = {
									    data.MakeInParam("@sysuser",  SqlDbType.VarChar, 20, popedom.SysUser),
                						data.MakeInParam("@password",  SqlDbType.VarChar, 20,popedom.Password),
			};
            return (data.RunProcReturn("SELECT * FROM tb_power WHERE (sysuser = @sysuser) AND (password = @password)", prams, "tb_power"));
        }
        #endregion
    }
}
