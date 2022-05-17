using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EMS.SelectDataDialog
{
    public partial class frmSelectHandle : Form
    {
        public frmSelectHandle()
        {
            InitializeComponent();
        }
        public BuyStock.frmBuyStock buyStock;
        public SaleStock.frmResellStock resellStock;
        public BuyStock.frmRebuyStock reBuyStock;
        public SaleStock.frmSellStock sellStock;
        public string M_str_object = "";

        private void selectHandle_Load(object sender, EventArgs e)
        {
            DataSet ds = PublicDim.client.GetAllEmployee("tb_employee");
            dgvSelectHandleList.DataSource = ds.Tables[0].DefaultView;

            //�����б����
            dgvSelectHandleList.Columns[0].HeaderText = "ְԱ���";
            dgvSelectHandleList.Columns[1].HeaderText = "ְԱ����";
            dgvSelectHandleList.Columns[2].HeaderText = "�Ա�";
            dgvSelectHandleList.Columns[3].HeaderText = "���ڲ���";
            dgvSelectHandleList.Columns[4].HeaderText = "��ϵ�绰";
            dgvSelectHandleList.Columns[5].HeaderText = "��ע";
        }

        private void dgvSelectHandleList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (M_str_object == "BuyStock")
            {
                buyStock.txtHandle.Text = dgvSelectHandleList[1, e.RowIndex].Value.ToString();��//ѡ�о�����
                this.Close();
            }
            if (M_str_object == "ResellStock")
            {
                resellStock.txtHandle.Text = dgvSelectHandleList[1, e.RowIndex].Value.ToString();��//ѡ�о�����
                this.Close();
            }
            if (M_str_object == "RebuyStock")
            {
                reBuyStock.txtHandle.Text = dgvSelectHandleList[1, e.RowIndex].Value.ToString();��//ѡ�о�����
                this.Close();
            }
            if (M_str_object == "SellStock")
            {
                sellStock.txtHandle.Text = dgvSelectHandleList[1, e.RowIndex].Value.ToString();��//ѡ�о�����
                this.Close();
            }
        }
    }
}