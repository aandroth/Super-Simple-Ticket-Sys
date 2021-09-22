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
    public partial class CreateTicketForm : Form
    {
        public delegate void ExeUnhide();
        public delegate void SendBackTicketInfo(TicketInfo ticketInfo);

        ExeUnhide exe;
        SendBackTicketInfo sendBackTicketInfo;

        string ticketTitle = "";
        string ticketPart = "Other";
        string ticketDescription = "";

        public CreateTicketForm()
        {
            InitializeComponent();
        }
        public CreateTicketForm(ExeUnhide e, SendBackTicketInfo sendTicket)
        {
            InitializeComponent();
            exe = e;
            sendBackTicketInfo = sendTicket;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
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
            sendBackTicketInfo.Invoke(new TicketInfo(textBox1.Text, comboBox1.Text, textBox2.Text));

            this.Hide();
            exe.Invoke();
            this.Close();
        }
    }
}
