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
    public partial class frmBuyStockSum : Form
    {
        DBSR.cBillInfo billinfo = new DBSR.cBillInfo();
        public frmBuyStockSum()
        {
            InitializeComponent();
        }

        private void tlbtnSumDetailed_Click(object sender, EventArgs e)
        {
            DataSet ds = null;
            billinfo.Handle = tltxtHandle.Text;
            billinfo.Units = tltxtUnits.Text;
            ds = PublicDim.client.BuyStockSumDetailed(billinfo, "tb_StockSumDetailed", dtpStar.Value, dtpEnd.Value);
            dgvStockList.DataSource = ds.Tables[0].DefaultView;
        }

        private void tlbtnSum_Click(object sender, EventArgs e)
        {
            DataSet ds = null;
            ds = PublicDim.client.BuyStockSum("tb_StockSum");
            dgvStockList.DataSource = ds.Tables[0].DefaultView;
        }
    }
}