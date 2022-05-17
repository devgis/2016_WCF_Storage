using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EMS.SaleStock
{
    public partial class frmSellStockSum : Form
    {
        DBSR.cBillInfo billinfo = new DBSR.cBillInfo();
        public frmSellStockSum()
        {
            InitializeComponent();
        }

        private void tlbtnSumDetailed_Click(object sender, EventArgs e)
        {
            DataSet ds = null;
            billinfo.Handle = tltxtHandle.Text;
            billinfo.Units = tltxtUnits.Text;
            ds = PublicDim.client.SellStockSumDetailed(billinfo, "tb_SellStockSumDetailed", dtpStar.Value, dtpEnd.Value);
            dgvStockList.DataSource = ds.Tables[0].DefaultView;
        }

        private void tlbtnSum_Click(object sender, EventArgs e)
        {
            DataSet ds = null;
            ds = PublicDim.client.SellStockSum("tb_SellStock");
            dgvStockList.DataSource = ds.Tables[0].DefaultView;
        }
    }
}