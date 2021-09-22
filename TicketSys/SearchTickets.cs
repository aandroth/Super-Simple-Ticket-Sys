using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TicketSys
{
    public partial class SearchTickets : Form
    {
        public delegate void ExeUnhide();
        ExeUnhide exe;
        public SearchTickets(ExeUnhide e)
        {
            InitializeComponent();
            exe = e;
        }

        private void SearchTickets_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            exe.Invoke();
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }
    }
}
