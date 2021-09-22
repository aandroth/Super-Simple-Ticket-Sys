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

        public delegate TicketInfo GetTicketDelegate(int idx);
        GetTicketDelegate getTicketDelegate;

        public delegate void RemoveTicketDelegate(int idx);
        RemoveTicketDelegate removeTicketDelegate;

        public delegate void EditTicketDelegate(int idx, TicketInfo ticket);
        EditTicketDelegate editTicketDelegate;

        public delegate List<TicketInfo> GetTicketListDelegate();
        GetTicketListDelegate getTicketListDelegate;

        public delegate void CloseAllFormsDelegate();
        CloseAllFormsDelegate closeAllFormsDelegate;

        bool cancelButtonClicked = false;

        public SearchTickets(GoToHomeWindowDelegate goHome, 
                             GetTicketListDelegate getTickets,
                             GetTicketDelegate getTicket,
                             RemoveTicketDelegate removeTicket,
                             EditTicketDelegate editTicket,
                             CloseAllFormsDelegate closeAllForms)
        {
            InitializeComponent();
            goToHomeWindowDelegate = goHome;
            getTicketDelegate = getTicket;
            getTicketListDelegate = getTickets;
            removeTicketDelegate = removeTicket;
            editTicketDelegate = editTicket;
            closeAllFormsDelegate = closeAllForms;

            comboBox1.SelectedIndex = 0;
        }

        private void SearchTickets_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            SearchEntriesForm sef = new SearchEntriesForm(goBackToHome, 
                                                          my_UnhideForm, 
                                                          closeAllForms, 
                                                          getFilteredTickets, 
                                                          removeTicketDelegate,
                                                          editTicketDelegate,
                                                          getTicketDelegate);
            sef.ShowDialog();
        }

        private List<TicketInfo> getFilteredTickets()
        {
            List<TicketInfo> allTickets = getTicketListDelegate.Invoke();

            List<string> keywordList = textBox1.Text.Split(',').ToList<string>();

            List<TicketInfo> filteredTickets = allTickets.Where((t) => filterByPart(t.part)).Where((t) => keywordList.All(s => t.title.Contains(s))).ToList<TicketInfo>();

            return filteredTickets;
        }

        private bool filterByPart(CAR_PARTS part)
        {
            if (comboBox1.SelectedIndex == 0)
                return true;
            return (int)part == comboBox1.SelectedIndex - 1;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            cancelButtonClicked = true;
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
            if(!cancelButtonClicked)
                closeAllFormsDelegate.Invoke();

            if (e.CloseReason == CloseReason.WindowsShutDown) return;
        }
    }
}
