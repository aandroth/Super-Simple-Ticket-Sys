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
    public partial class SearchEntriesForm : Form
    {
        public delegate void GoToSearchWindowDelegate();
        GoToSearchWindowDelegate goToSearchWindowDelegate;

        public SearchTickets.GetTicketDelegate getTicketDelegate;
        public SearchTickets.RemoveTicketDelegate removeTicketDelegate;
        public SearchTickets.EditTicketDelegate editTicketDelegate;

        public delegate List<TicketInfo> GetFilteredTicketListDelegate();
        GetFilteredTicketListDelegate getFilteredTicketListDelegate;

        public delegate void CloseAllFormsDelegate();
        CloseAllFormsDelegate closeAllFormsDelegate;

        bool cancelButtonClicked = false;
        List<TicketInfo> ticketList;
        int selectedTicketId = 0;

        public SearchEntriesForm()
        {
            InitializeComponent();
        }
        public SearchEntriesForm(GoToSearchWindowDelegate goSearch, 
                                 CloseAllFormsDelegate closeAllForms,
                                 GetFilteredTicketListDelegate getFilteredTicketList,
                                 SearchTickets.RemoveTicketDelegate removeTicket,
                                 SearchTickets.EditTicketDelegate editTicket,
                                 SearchTickets.GetTicketDelegate getTicket)
        {
            InitializeComponent();

            goToSearchWindowDelegate  = goSearch;
            closeAllFormsDelegate = closeAllForms;
            getFilteredTicketListDelegate = getFilteredTicketList;
            getTicketDelegate = getTicket;
            removeTicketDelegate = removeTicket;
            editTicketDelegate = editTicket;

            dataGridView1.Columns.Add("Titles", "Tickets");

            loadFilteredTicketList();
        }

        public void loadFilteredTicketList()
        {
            dataGridView1.Rows.Clear();

            ticketList = getFilteredTicketListDelegate.Invoke();
            foreach (TicketInfo t in ticketList)
                dataGridView1.Rows.Add(t.title);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            cancelButtonClicked = true;
            goToSearchWindowDelegate.Invoke();
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            this.Hide();
            selectedTicketId = ticketList[dataGridView1.CurrentCell.RowIndex].id;
            TicketViewEdit tve = new TicketViewEdit(my_UnhideForm,
                                                    removeTicketAtSelectedIndex,
                                                    editTicketAtSelectedIndex,
                                                    closeAllForms,
                                                    getTicketDelegate.Invoke(selectedTicketId));
            tve.Tag = this;
            tve.StartPosition = FormStartPosition.Manual;
            tve.Location = this.Location;
            tve.ShowDialog();
        }
        public void my_UnhideForm()
        {
            this.Show();
        }
        public void closeAllForms()
        {
            this.Close();
        }

        public void removeTicketAtSelectedIndex()
        {
            removeTicketDelegate.Invoke(selectedTicketId);
            loadFilteredTicketList();
        }

        public void editTicketAtSelectedIndex(TicketInfo ticketInfo)
        {
            editTicketDelegate.Invoke(selectedTicketId, ticketInfo);
            loadFilteredTicketList();
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
