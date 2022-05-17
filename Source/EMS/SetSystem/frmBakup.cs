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
    public partial class frmBakup : Form
    {
        public frmBakup()
        {
            InitializeComponent();
        }

        private void btnBak_Click(object sender, EventArgs e)
        {
            string fileName = "";
            SaveFileDialog saveFile = new SaveFileDialog();
            saveFile.DefaultExt = ".bak";
            saveFile.ShowDialog();
            fileName = saveFile.FileName;
            if (fileName == "") return;
            PublicDim.client.BackUp(fileName);
            MessageBox.Show("���ݿⱸ��--�ɹ���", "�ɹ���ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnRestor_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            openFile.Filter = "BakUp files (*.bak)|*.bak";
            openFile.ShowDialog();
            string fileName = "";
            fileName = openFile.FileName;
            if (fileName == "") return;
            PublicDim.client.ReStore(fileName);
            MessageBox.Show("���ݿ�ָ�--�ɹ���", "�ɹ���ʾ", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}