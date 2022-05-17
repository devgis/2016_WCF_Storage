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
    public partial class frmBuyStockAnalyse : Form
    {
        public frmBuyStockAnalyse()
        {
            InitializeComponent();
        }

        private void tlbtnAllBuyStock_Click(object sender, EventArgs e)
        {
            DataSet ds = null;
            ds = PublicDim.client.BuyAllStockAnalyse("tb_warehouse_detailed");
            dgvStockList.DataSource = ds.Tables[0].DefaultView;
            this.SetdgvStockListHeadText();
        }

        private void SetdgvStockListHeadText()
        {
            dgvStockList.Columns[0].HeaderText = "��Ʒ���";
            dgvStockList.Columns[1].HeaderText = "��Ʒ����";
            dgvStockList.Columns[2].HeaderText = "�����۸�";
            dgvStockList.Columns[3].HeaderText = "��������";
            dgvStockList.Columns[4].HeaderText = "�ϼƽ��";
        }

        private void tlbtnBuyStock_Click(object sender, EventArgs e)
        {
            DataSet ds = null;
            ds = PublicDim.client.BuyStockAnalyse("tb_stockOrtb_warehouse_detailed");
            dgvStockList.DataSource = ds.Tables[0].DefaultView;
            this.SetdgvStockListHeadText();
        }

        private void tlbtnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}