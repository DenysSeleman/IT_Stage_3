using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WinFormsClient
{
    public partial class MainMenuForm : Form
    {
        ServiceDBMS.ServiceDBMSClient proxy;
        string cellOldValue = "";
        string cellNewValue = "";

        public MainMenuForm()
        {
            InitializeComponent();
            proxy = new ServiceDBMS.ServiceDBMSClient();
            cbTypes.SelectedIndex = 0;
            tbTypeInterval.Enabled = false;
            cbTypes.DropDownStyle = ComboBoxStyle.DropDownList;
            cbJoinTables1Table.DropDownStyle = ComboBoxStyle.DropDownList;
            cbJoinTables2Table.DropDownStyle = ComboBoxStyle.DropDownList;
        }

        private void butCreate_Click(object sender, EventArgs e)
        {
            if (proxy.CreateDB(tbCreateDBName.Text))
            {
                tabControl.TabPages.Clear();
                dataGridView.Rows.Clear();
                dataGridView.Columns.Clear();
                Text = "Database " + "\"" + proxy.GetDBName() + "\"";
                tbCreateDBName.Text = "";
            }
        }

        private void butAddTable_Click(object sender, EventArgs e)
        {
            if (proxy.AddTable(tbAddTableName.Text))
            {
                tabControl.TabPages.Add(tbAddTableName.Text);
                cbJoinTables1Table.Items.Add(tbAddTableName.Text);
                cbJoinTables2Table.Items.Add(tbAddTableName.Text);
                tbAddTableName.Text = "";
            }
        }

        private void tabControl_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ind = tabControl.SelectedIndex;
            if (ind == -1) return;
            VisualTable(ind);
        }

        void VisualTable(int ind)
        {
            var listCNames = proxy.GetListCNames(ind);
            var listCTypes = proxy.GetListCTypes(ind);
            var listRows = proxy.GetListRows(ind);
            try
            {
                dataGridView.Rows.Clear();
                dataGridView.Columns.Clear();

                for (int i = 0; i < listCNames.Length; i++)
                {
                    DataGridViewTextBoxColumn column = new DataGridViewTextBoxColumn();
                    column.Name = listCNames[i];
                    column.HeaderText = listCNames[i] + " (" + listCTypes[i] + ")";
                    dataGridView.Columns.Add(column);
                }

                for (int i = 0; i < listRows.Length; i++)
                {
                    DataGridViewRow row = new DataGridViewRow();
                    foreach (string s in listRows[i])
                    {
                        DataGridViewCell cell = new DataGridViewTextBoxCell();
                        cell.Value = s;
                        row.Cells.Add(cell);
                    }
                    try
                    {
                        dataGridView.Rows.Add(row);
                    }
                    catch { }
                }
            }
            catch { }
        }

        private void butAddColumn_Click(object sender, EventArgs e)
        {
            if (proxy.AddColumn(tabControl.SelectedIndex, tbAddColumnName.Text, cbTypes.Text, tbTypeInterval.Text))
            {
                int ind = tabControl.SelectedIndex;
                if (ind != -1) VisualTable(ind);
                tbAddColumnName.Text = "";
                tbTypeInterval.Text = "Interval";
            }
        }

        private void butAddRow_Click(object sender, EventArgs e)
        {
            if (proxy.AddRow(tabControl.SelectedIndex))
            {
                int ind = tabControl.SelectedIndex;
                if (ind != -1) VisualTable(ind);
            }
        }

        private void dataGridView_CellBeginEdit(object sender, DataGridViewCellCancelEventArgs e)
        {
            cellOldValue = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();
        }

        private void dataGridView_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value == null)
                cellNewValue = "";
            else
                cellNewValue = dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value.ToString();

            if (cellNewValue == "")
            {
                dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = cellNewValue;
                proxy.ChangeValue(cellNewValue, tabControl.SelectedIndex, e.ColumnIndex, e.RowIndex);
            }
            else if (!proxy.ChangeValue(cellNewValue, tabControl.SelectedIndex, e.ColumnIndex, e.RowIndex))
                dataGridView.Rows[e.RowIndex].Cells[e.ColumnIndex].Value = cellOldValue;

            int ind = tabControl.SelectedIndex;
            if (ind != -1) VisualTable(ind);
        }

        private void butDeleteRow_Click(object sender, EventArgs e)
        {
            if (dataGridView.Rows.Count == 0) return;
            try
            {
                proxy.DeleteRow(tabControl.SelectedIndex, dataGridView.CurrentCell.RowIndex);
            }
            catch { }

            int ind = tabControl.SelectedIndex;
            if (ind != -1) VisualTable(ind);
        }

        private void butDeleteColumn_Click(object sender, EventArgs e)
        {
            if (dataGridView.Columns.Count == 0) return;
            try
            {
                proxy.DeleteColumn(tabControl.SelectedIndex, dataGridView.CurrentCell.ColumnIndex);
            }
            catch { }

            int ind = tabControl.SelectedIndex;
            if (ind != -1) VisualTable(ind);
        }

        private void butDeleteTable_Click(object sender, EventArgs e)
        {
            if (tabControl.TabCount == 0) return;
            string tname = tabControl.SelectedTab.Text;
            try
            {
                proxy.DeleteTable(tabControl.SelectedIndex);
                tabControl.TabPages.RemoveAt(tabControl.SelectedIndex);
            }
            catch { }
            cbJoinTables1Table.Items.Remove(tname);
            cbJoinTables2Table.Items.Remove(tname);

            int ind = tabControl.SelectedIndex;
            if (ind != -1)
                VisualTable(ind);
            else
            {
                dataGridView.Rows.Clear();
                dataGridView.Columns.Clear();
            }
        }

        private void butSaveDB_Click(object sender, EventArgs e)
        {
            Stream myStream;

            sfdSaveDB.Filter = "tdb files (*.tdb)|*.tdb";
            sfdSaveDB.FilterIndex = 1;
            sfdSaveDB.RestoreDirectory = true;

            if (sfdSaveDB.ShowDialog() == DialogResult.OK)
            {
                if ((myStream = sfdSaveDB.OpenFile()) != null)
                {
                    myStream.Close();
                    proxy.SaveDB(sfdSaveDB.FileName);
                }
            }
        }

        private void butOpen_Click(object sender, EventArgs e)
        {
            ofdOpenDB.Filter = "tdb files (*.tdb)|*.tdb";
            ofdOpenDB.FilterIndex = 1;
            ofdOpenDB.RestoreDirectory = true;

            if (ofdOpenDB.ShowDialog() == DialogResult.OK)
            {
                proxy.OpenDB(ofdOpenDB.FileName);

                tabControl.TabPages.Clear();
                dataGridView.Rows.Clear();
                dataGridView.Columns.Clear();
                Text = "Database " + "\"" + proxy.GetDBName() + "\"";

                var buf = proxy.GetTableNameList();
                foreach (string s in buf)
                    tabControl.TabPages.Add(s);

                int ind = tabControl.SelectedIndex;
                if (ind != -1) VisualTable(ind);
            }

            cbJoinTables1Table.Items.Clear();
            cbJoinTables2Table.Items.Clear();
            cbJoinTables1Table.Text = "";
            cbJoinTables2Table.Text = "";
            foreach (string tname in proxy.GetTableNameList())
            {
                cbJoinTables1Table.Items.Add(tname);
                cbJoinTables2Table.Items.Add(tname);
            }
        }

        private void cbTypes_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbTypes.Text == "CharInvl" || cbTypes.Text == "String(CharInvl)")
                tbTypeInterval.Enabled = true;
            else
                tbTypeInterval.Enabled = false;
        }

        private void butJoinTables_Click(object sender, EventArgs e)
        {
            string t1name = cbJoinTables1Table.Text, t2name = cbJoinTables2Table.Text;
            if (proxy.JoinTables(t1name, t2name))
            {
                var tableNameList = proxy.GetTableNameList();
                string tName = tableNameList[tableNameList.Length - 1];
                tabControl.TabPages.Add(tName);
            }
        }
    }
}
