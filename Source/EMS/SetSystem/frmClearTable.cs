using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace EMS.SetSystem
{
    public partial class frmClearTable : Form
    {
        public frmClearTable()
        {
            InitializeComponent();
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            if (chkCurrent.Checked) //判断往来账明细表复选框是否选中
                PublicDim.client.ClearTable("tb_currentaccount");//清理往来对账明细信息
            if (chkWarehouse.Checked)//判断进货表复选框是否选中
            {
                PublicDim.client.ClearTable("tb_warehouse_main");//清理进货主表信息
                PublicDim.client.ClearTable("tb_warehouse_detailed");//清理进货明细表信息
            }
            if (chkRewarehouse.Checked)//判断进货退货表复选框是否选中
            {
                PublicDim.client.ClearTable("tb_rewarehouse_main");//清理进货退货主表信息
                PublicDim.client.ClearTable("tb_rewarehouse_detailed");//清理进货退货明细表信息
            }
            if (chkSell.Checked)//判断销售表复选框是否选中
            {
                PublicDim.client.ClearTable("tb_sell_main");//清理销售主表信息
                PublicDim.client.ClearTable("tb_sell_detailed");//清理销售明细表信息
            }
            if (chkResell.Checked)//判断销售退货表复选框是否选中
            {
                PublicDim.client.ClearTable("tb_resell_main");//清理销售退货主表信息
                PublicDim.client.ClearTable("tb_resell_detailed");//清理销售退货明细表信息
            }
            if (chkUser.Checked) PublicDim.client.ClearTable("tb_power");//清理用户信息
            if (chkUnit.Checked) PublicDim.client.ClearTable("tb_unit");//清理本单位信息
            if (chkStock.Checked) PublicDim.client.ClearTable("tb_stock");//清理库存信息
            if (chkEmployee.Checked) PublicDim.client.ClearTable("tb_employee");//清理公司职员信息
            if (chkUnits.Checked) PublicDim.client.ClearTable("tb_units");//清理往来单位信息
            MessageBox.Show("系统数据清理成功！","成功提示",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();//关闭当前窗体
        }
    }
}