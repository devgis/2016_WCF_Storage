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
    public partial class frmSelectUnits : Form
    {
        public BuyStock.frmBuyStock buyStock;
        public SaleStock.frmResellStock resellStock;
        public SaleStock.frmSellStock sellStock;
        public BuyStock.frmRebuyStock reBuyStock;

        public string M_str_object = "";

        public frmSelectUnits()
        {
            InitializeComponent();
        }

        private void SelectUnits_Load(object sender, EventArgs e)
        {
            DataSet ds = PublicDim.client.GetAllUnits("tb_Units");
            dgvSelectUnitsList.DataSource = ds.Tables[0].DefaultView;

            //�����б����
            dgvSelectUnitsList.Columns[0].HeaderText = "��λ���";
            dgvSelectUnitsList.Columns[1].HeaderText = "��λ����";
            dgvSelectUnitsList.Columns[2].HeaderText = "˰��";
            dgvSelectUnitsList.Columns[3].HeaderText = "��λ�绰";
            dgvSelectUnitsList.Columns[4].HeaderText = "��ϵ��";
            dgvSelectUnitsList.Columns[5].HeaderText = "��λ��ַ";
            dgvSelectUnitsList.Columns[6].HeaderText = "�����м��˺�";
            dgvSelectUnitsList.Columns[7].HeaderText = "�ۼ�Ӧ�տ�";
            dgvSelectUnitsList.Columns[8].HeaderText = "�ۼ�Ӧ����";
        }

        private void dgvSelectUnitsList_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (M_str_object == "BuyStock")
            {
                buyStock.txtUnits.Text = dgvSelectUnitsList[1, e.RowIndex].Value.ToString();��//ѡ�о�����
                this.Close();
            }
            if (M_str_object == "ResellStock")
            {
                resellStock.txtUnits.Text = dgvSelectUnitsList[1, e.RowIndex].Value.ToString();��//ѡ�о�����
                this.Close();
            }
            if (M_str_object == "RebuyStock")
            {
                reBuyStock.txtUnits.Text = dgvSelectUnitsList[1, e.RowIndex].Value.ToString();��//ѡ�о�����
                this.Close();
            }
            if (M_str_object == "SellStock")
            {
                sellStock.txtUnits.Text = dgvSelectUnitsList[1, e.RowIndex].Value.ToString();��//ѡ�о�����
                this.Close();
            }
        }
    }
}