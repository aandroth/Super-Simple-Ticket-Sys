﻿using System;
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
        public delegate void GoToHomeWindowDelegate();
        GoToHomeWindowDelegate goToHomeWindowDelegate;

        public delegate void GoToSearchWindowDelegate();
        GoToSearchWindowDelegate goToSearchWindowDelegate;

        public delegate void CloseAllFormsDelegate();
        CloseAllFormsDelegate closeAllFormsDelegate;

        public SearchEntriesForm()
        {
            InitializeComponent();
        }
        public SearchEntriesForm(GoToHomeWindowDelegate goHome, 
                                 GoToSearchWindowDelegate goSearch, 
                                 CloseAllFormsDelegate closeAllForms, 
                                 List<TicketInfo> ticketList)
        {
            InitializeComponent();

            goToHomeWindowDelegate = goHome;
            goToSearchWindowDelegate  = goSearch;
            closeAllFormsDelegate = closeAllForms;

            dataGridView1.Columns.Add("Titles", "Tickets");
            dataGridView1.Columns[0].Width = dataGridView1.Width;

            foreach(TicketInfo t in ticketList)
                dataGridView1.Rows.Add(t.title);
        }

        private void SearchEntriesList_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            goToHomeWindowDelegate.Invoke();
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            goToSearchWindowDelegate.Invoke();
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        protected override void OnFormClosing(FormClosingEventArgs e)
        {
            base.OnFormClosing(e);
            closeAllFormsDelegate.Invoke();

            if (e.CloseReason == CloseReason.WindowsShutDown) return;
        }
    }
}