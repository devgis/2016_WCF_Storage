using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EMS.BuyStock
{
    public partial class frmRebuyStock : Form
    {
        DBSR.cBillInfo billinfo = new DBSR.cBillInfo();
        DBSR.cCurrentAccount currentAccount = new DBSR.cCurrentAccount();
        DBSR.cStockInfo stockinfo = new DBSR.cStockInfo();
        public frmRebuyStock()
        {
            InitializeComponent();
        }

        private void frmRebuyStock_Load(object sender, EventArgs e)
        {
            txtBillDate.Text = DateTime.Now.ToString("yyyy-MM-dd");

            DataSet ds = null;
            string P_Str_newBillCode = "";
            int P_Int_newBillCode = 0;

            ds = PublicDim.client.GetAllBill("tb_rewarehouse_main");
            if (ds.Tables[0].Rows.Count == 0)
            {
                txtBillCode.Text = DateTime.Now.ToString("yyyyMMdd") + "JHTH" + "1000001";
            }
            else
            {
                P_Str_newBillCode = Convert.ToString(ds.Tables[0].Rows[ds.Tables[0].Rows.Count - 1]["billcode"]);
                P_Int_newBillCode = Convert.ToInt32(P_Str_newBillCode.Substring(12, 7)) + 1;
                P_Str_newBillCode = DateTime.Now.ToString("yyyyMMdd") + "JHTH" + P_Int_newBillCode.ToString();
                txtBillCode.Text = P_Str_newBillCode;
            }
            txtHandle.Focus();
        }

        private void btnSelectHandle_Click(object sender, EventArgs e)
        {
            EMS.SelectDataDialog.frmSelectHandle selecthandle;
            selecthandle = new EMS.SelectDataDialog.frmSelectHandle();
            selecthandle.reBuyStock = this;          //将新创建的窗体对象设置为同一个窗体类的实例（对象）
            selecthandle.M_str_object = "RebuyStock";　　//用于识别　是那一个窗体调用的selecthandle窗口的
            selecthandle.ShowDialog();
        }

        private void btnSelectUnits_Click(object sender, EventArgs e)
        {
            EMS.SelectDataDialog.frmSelectUnits selectUnits;
            selectUnits = new EMS.SelectDataDialog.frmSelectUnits();
            selectUnits.reBuyStock = this;          //将新创建的窗体对象设置为同一个窗体类的实例（对象）
            selectUnits.M_str_object = "RebuyStock";　　//用于识别　是那一个窗体调用的selectUnits窗口的
            selectUnits.ShowDialog();
        }

        private void dgvStockList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            SelectDataDialog.frmSelectStock selectStock = new EMS.SelectDataDialog.frmSelectStock();
            selectStock.reBuyStock = this;          //将新创建的窗体对象设置为同一个窗体类的实例（对象）
            selectStock.M_int_CurrentRow = e.RowIndex;
            selectStock.M_str_object = "RebuyStock";　　//用于识别　是那一个窗体调用的selectStock窗口的
            selectStock.ShowDialog();
        }

        private void dgvStockList_CellStateChanged(object sender, DataGridViewCellStateChangedEventArgs e)
        {
            //统计商品进货数量和金额
            try
            {
                float tqty = 0;
                float tsum = 0;
                for (int i = 0; i <= dgvStockList.RowCount; i++)
                {
                    tsum = tsum + Convert.ToSingle(dgvStockList[5, i].Value.ToString());
                    tqty = tqty + Convert.ToSingle(dgvStockList[3, i].Value.ToString());
                    txtFullPayment.Text = tsum.ToString();
                    txtStockQty.Text = tqty.ToString();
                }

            }
            catch { }
        }

        private void dgvStockList_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == 3)　　//计算－－统计商品金额
            {
                try
                {
                    float tsum = Convert.ToSingle(dgvStockList[3, e.RowIndex].Value.ToString()) * Convert.ToSingle(dgvStockList[4, e.RowIndex].Value.ToString());
                    dgvStockList[5, e.RowIndex].Value = tsum.ToString();
                }
                catch { }
            }
            if (e.ColumnIndex == 4)
            {
                try
                {
                    float tsum = Convert.ToSingle(dgvStockList[3, e.RowIndex].Value.ToString()) * Convert.ToSingle(dgvStockList[4, e.RowIndex].Value.ToString());
                    dgvStockList[5, e.RowIndex].Value = tsum.ToString();
                }
                catch { }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            //往来单位和经手人不能为空！
            if (txtHandle.Text == string.Empty || txtUnits.Text == string.Empty)
            {
                MessageBox.Show("供货单位和经手人为必填项！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //列表中数据不能为空
            if (Convert.ToString(dgvStockList[3, 0].Value) == string.Empty || Convert.ToString(dgvStockList[4, 0].Value) == string.Empty || Convert.ToString(dgvStockList[5, 0].Value) == string.Empty)
            {
                MessageBox.Show("请核实列表中数据：‘数量’、‘单价’、‘金额’不能为空！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            //应付金额不能为空
            if (txtFullPayment.Text.Trim() == "0")
            {
                MessageBox.Show("应付金额不能为‘０’！", "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            //向进货表（主表）录入商品单据信息
            billinfo.BillCode = txtBillCode.Text;
            billinfo.Handle = txtHandle.Text;
            billinfo.Units = txtUnits.Text;
            billinfo.Summary = txtSummary.Text;
            billinfo.FullPayment = Convert.ToSingle(txtFullPayment.Text);
            billinfo.Payment = Convert.ToSingle(txtpayment.Text);
            billinfo.BillDate = DateTime.Parse(txtBillDate.Text);
            //执行添加
            PublicDim.client.AddTableMainSellhouse(billinfo, "tb_rewarehouse_main");

            //向进货（明细表）中录入商品单据信息
            for (int i = 0; i < dgvStockList.RowCount - 1; i++)
            {
                billinfo.BillCode = txtBillCode.Text;
                billinfo.TradeCode = dgvStockList[0, i].Value.ToString();
                billinfo.FullName = dgvStockList[1, i].Value.ToString();
                billinfo.TradeUnit = dgvStockList[2, i].Value.ToString();
                billinfo.Qty = Convert.ToSingle(dgvStockList[3, i].Value.ToString());
                billinfo.Price = Convert.ToSingle(dgvStockList[4, i].Value.ToString());
                billinfo.TSum = Convert.ToSingle(dgvStockList[5, i].Value.ToString());
                //执行多行录入数据（添加到明细表中）
                PublicDim.client.AddTableDetailedWarehouse(billinfo, "tb_rewarehouse_detailed");
                 //更新--商品库存数量
                DataSet ds = null;
                stockinfo.TradeCode = dgvStockList[0, i].Value.ToString();
                ds = PublicDim.client.GetStockByTrade(stockinfo, "tb_Stock");
                stockinfo.Qty = Convert.ToSingle(ds.Tables[0].Rows[0]["qty"]);

                stockinfo.Qty = stockinfo.Qty - billinfo.Qty;
                int d = PublicDim.client.UpdateSaleStock_Qty(stockinfo);

            }
            //向往来单位明细表--录入数据--这样以来为分析
            currentAccount.BillCode = txtBillCode.Text;
            currentAccount.AddGathering = Convert.ToSingle(txtFullPayment.Text);
            currentAccount.FactAddFee = Convert.ToSingle(txtpayment.Text);
            currentAccount.Balance = Convert.ToSingle(txtBalance.Text);
            currentAccount.Units = txtUnits.Text;
            currentAccount.BillDate = DateTime.Parse(txtBillDate.Text);
            //执行添加
            int ca = PublicDim.client.AddCurrentAccount(currentAccount);
            MessageBox.Show("进货退货单－－过账成功！", "成功提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
            this.Close();
        }

        private void btnEixt_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtpayment_TextChanged(object sender, EventArgs e)
        {
            try
            {
                txtBalance.Text = Convert.ToString(Convert.ToSingle(txtFullPayment.Text) - Convert.ToSingle(txtpayment.Text));
            }
            catch (Exception ex)
            {
                MessageBox.Show("录入非法字符！！！" + ex.Message, "错误提示", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtpayment.Focus();
            }
        }
    }
}