using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Task_manager
{
    public partial class Form1 : Form
    {
        Process[] processes;

        public Form1()
        {
            InitializeComponent();

            listView1.Columns.Add("Имя процесса");
            listView1.Columns.Add("ID");

            processes = Process.GetProcesses();

            foreach (Process process in processes)
            {
                ListViewItem item = new ListViewItem(process.ProcessName);
                item.SubItems.Add(process.Id.ToString());
                listView1.Items.Add(item);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            listView1.Items.Clear();

            Process[] processes = Process.GetProcesses();
            foreach (Process process in processes)
            {
                ListViewItem item = new ListViewItem(process.ProcessName);
                item.SubItems.Add(process.Id.ToString());
                listView1.Items.Add(item);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void закрытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count > 0)
            {
                int processId = int.Parse(listView1.SelectedItems[0].SubItems[1].Text);
                Process process = Process.GetProcessById(processId);
                process.Kill();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Process proc = new Process();
            proc.StartInfo.FileName = textBox1.Text;
            proc.Start();
        }
    }
}
