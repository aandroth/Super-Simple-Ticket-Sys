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
    public partial class TicketViewEdit : Form
    {
        public delegate void GoToSearchEntriesWindowDelegate();
        GoToSearchEntriesWindowDelegate goToSearchEntriesWindowDelegate;

        public delegate void RemoveTicketDelegate();
        RemoveTicketDelegate removeTicketDelegate;

        public delegate void EditTicketDelegate(TicketInfo ticketInfo);
        EditTicketDelegate editTicketDelegate;

        public delegate void CloseAllFormsDelegate();
        CloseAllFormsDelegate closeAllFormsDelegate;

        bool cancelButtonClicked = false;

        public TicketViewEdit(GoToSearchEntriesWindowDelegate goToSearchEntries,
                              RemoveTicketDelegate removeTicket,
                              EditTicketDelegate editTicket,
                              CloseAllFormsDelegate closeAllForms, 
                              TicketInfo ticketInfo)
        {
            InitializeComponent();
            goToSearchEntriesWindowDelegate = goToSearchEntries;
            removeTicketDelegate = removeTicket;
            editTicketDelegate = editTicket;
            closeAllFormsDelegate = closeAllForms;

            textBox2.Text = ticketInfo.title;
            textBox1.Text = ticketInfo.description;
            comboBox1.SelectedIndex = ((int)ticketInfo.part);

            button1.Visible = false;
        }
        private void TicketViewEdit_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            editTicketDelegate.Invoke(new TicketInfo(textBox2.Text, (CAR_PARTS)comboBox1.SelectedIndex, textBox1.Text));
            this.Hide();
            cancelButtonClicked = true;
            goBackToSearchEntries();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            cancelButtonClicked = true;
            goBackToSearchEntries();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            removeTicketDelegate.Invoke();
            cancelButtonClicked = true;
            goBackToSearchEntries();
        }
        public void goBackToSearchEntries()
        {
            goToSearchEntriesWindowDelegate.Invoke();
            this.Close();
        }

        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            if (!cancelButtonClicked)
                closeAllFormsDelegate.Invoke();

            if (e.CloseReason == CloseReason.WindowsShutDown) return;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            if (!button1.Visible)
                button1.Visible = true;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            if (!button1.Visible)
                button1.Visible = true;
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!button1.Visible)
                button1.Visible = true;
        }
    }
}
