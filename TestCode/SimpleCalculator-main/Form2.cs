using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SimpleCalculator
{
    public partial class Form2 : Form
    {
        public Form2(List<string> historyList)
        {
            InitializeComponent();

            this.Text = "전체 History";

            foreach (string item in historyList)
            {
                everyHistoryBox.Text += item+"\r\n";
                Console.WriteLine("새창에 뜰 item들 : "+item);
            }
            
        }
    }
}
