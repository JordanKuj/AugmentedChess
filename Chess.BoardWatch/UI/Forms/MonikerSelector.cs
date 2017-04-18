using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using AForge.Video.DirectShow;
using System.Diagnostics;

namespace Chess.BoardWatch.UI.Forms
{
    public partial class MonikerSelector : Form
    {
        public MonikerSelector()
        {
            InitializeComponent();
            Choice = -1;
        }

        public int Choice { get; internal set; }

        private Dictionary<int, string> _devices = new Dictionary<int, string>();

        internal void SetDevices(FilterInfoCollection devices)
        {
            var eunmerator = devices.GetEnumerator();
            var count = 0;
            while (eunmerator.MoveNext())
            {
                _devices.Add(count, ((FilterInfo)eunmerator.Current).Name);
                listBox1.Items.Add(_devices[count]);
                count++;
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            var selection = listBox1.SelectedIndex;
            if (selection >= 0)
            {
                button1.Enabled = true;
                Choice = selection;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (Choice >= 0)
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }
    }
}
