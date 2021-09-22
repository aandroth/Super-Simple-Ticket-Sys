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
        ExeUnhide exe;

        public delegate void SendBackTicketInfo(TicketInfo ticketInfo);
        SendBackTicketInfo sendBackTicketInfo;

        public delegate void CloseAllFormsDelegate();
        CloseAllFormsDelegate closeAllFormsDelegate;

        bool cancelButtonClicked = false;

        string ticketTitle = "";
        CAR_PARTS ticketPart = CAR_PARTS.OTHER;
        string ticketDescription = "";

        public CreateTicketForm()
        {
            InitializeComponent();
        }
        public CreateTicketForm(ExeUnhide e, SendBackTicketInfo sendTicket, CloseAllFormsDelegate closeAllForms)
        {
            InitializeComponent();
            exe = e;
            sendBackTicketInfo = sendTicket;
            closeAllFormsDelegate = closeAllForms;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            sendBackTicketInfo.Invoke(new TicketInfo(textBox1.Text, (CAR_PARTS)comboBox1.SelectedIndex, textBox2.Text));

            this.Hide();
            exe.Invoke();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            cancelButtonClicked = true;
            exe.Invoke();
            this.Close();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (!cancelButtonClicked)
                closeAllFormsDelegate.Invoke();

            if (e.CloseReason == CloseReason.WindowsShutDown) return;
        }
    }
}
