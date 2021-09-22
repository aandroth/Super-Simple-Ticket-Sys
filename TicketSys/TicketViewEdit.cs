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

        public delegate void CloseAllFormsDelegate();
        CloseAllFormsDelegate closeAllFormsDelegate;

        bool cancelButtonClicked = false;

        public TicketViewEdit(GoToSearchEntriesWindowDelegate goToSearchEntries, CloseAllFormsDelegate closeAllForms, TicketInfo ticketInfo)
        {
            InitializeComponent();
            goToSearchEntriesWindowDelegate = goToSearchEntries;
            closeAllFormsDelegate = closeAllForms;

            textBox2.Text = ticketInfo.title;
            textBox1.Text = ticketInfo.description;
            comboBox1.SelectedIndex = ((int)ticketInfo.part);
        }
        private void TicketViewEdit_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            cancelButtonClicked = true;
            goBackToHome();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            cancelButtonClicked = true;
            goBackToHome();
        }
        public void goBackToHome()
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
    }
}
