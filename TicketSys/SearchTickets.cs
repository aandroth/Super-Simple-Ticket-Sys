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
        public delegate void GoToHomeWindowDelegate();
        GoToHomeWindowDelegate goToHomeWindowDelegate;

        public delegate List<TicketInfo> GetTicketListDelegate();
        GetTicketListDelegate getTicketListDelegate;

        public delegate void CloseAllFormsDelegate();
        CloseAllFormsDelegate closeAllFormsDelegate;
        public SearchTickets(GoToHomeWindowDelegate goHome, GetTicketListDelegate getTickets, CloseAllFormsDelegate closeAllForms)
        {
            InitializeComponent();
            goToHomeWindowDelegate = goHome;
            getTicketListDelegate = getTickets;
            closeAllFormsDelegate = closeAllForms;
        }

        private void SearchTickets_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            List<TicketInfo> ticketInfoList = getTicketListDelegate.Invoke();
            SearchEntriesForm sef = new SearchEntriesForm(goBackToHome, my_UnhideForm, closeAllForms, ticketInfoList);
            sef.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            goBackToHome();
        }
        public void my_UnhideForm()
        {
            this.Show();
        }
        public void goBackToHome()
        {
            goToHomeWindowDelegate.Invoke();
            this.Close();
        }
        public void closeAllForms()
        {
            this.Close();
        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            closeAllFormsDelegate.Invoke();

            if (e.CloseReason == CloseReason.WindowsShutDown) return;
        }
    }
}
