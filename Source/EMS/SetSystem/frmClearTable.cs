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
            if (chkCurrent.Checked) //�ж���������ϸ��ѡ���Ƿ�ѡ��
                PublicDim.client.ClearTable("tb_currentaccount");//��������������ϸ��Ϣ
            if (chkWarehouse.Checked)//�жϽ�����ѡ���Ƿ�ѡ��
            {
                PublicDim.client.ClearTable("tb_warehouse_main");//�������������Ϣ
                PublicDim.client.ClearTable("tb_warehouse_detailed");//���������ϸ����Ϣ
            }
            if (chkRewarehouse.Checked)//�жϽ����˻���ѡ���Ƿ�ѡ��
            {
                PublicDim.client.ClearTable("tb_rewarehouse_main");//��������˻�������Ϣ
                PublicDim.client.ClearTable("tb_rewarehouse_detailed");//��������˻���ϸ����Ϣ
            }
            if (chkSell.Checked)//�ж����۱�ѡ���Ƿ�ѡ��
            {
                PublicDim.client.ClearTable("tb_sell_main");//��������������Ϣ
                PublicDim.client.ClearTable("tb_sell_detailed");//����������ϸ����Ϣ
            }
            if (chkResell.Checked)//�ж������˻���ѡ���Ƿ�ѡ��
            {
                PublicDim.client.ClearTable("tb_resell_main");//���������˻�������Ϣ
                PublicDim.client.ClearTable("tb_resell_detailed");//���������˻���ϸ����Ϣ
            }
            if (chkUser.Checked) PublicDim.client.ClearTable("tb_power");//�����û���Ϣ
            if (chkUnit.Checked) PublicDim.client.ClearTable("tb_unit");//������λ��Ϣ
            if (chkStock.Checked) PublicDim.client.ClearTable("tb_stock");//��������Ϣ
            if (chkEmployee.Checked) PublicDim.client.ClearTable("tb_employee");//����˾ְԱ��Ϣ
            if (chkUnits.Checked) PublicDim.client.ClearTable("tb_units");//����������λ��Ϣ
            MessageBox.Show("ϵͳ��������ɹ���","�ɹ���ʾ",MessageBoxButtons.OK,MessageBoxIcon.Information);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();//�رյ�ǰ����
        }
    }
}