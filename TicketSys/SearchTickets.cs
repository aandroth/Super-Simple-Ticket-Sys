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
    public partial class SearchTickets : Form
    {
        public delegate void GoToHomeWindowDelegate();
        GoToHomeWindowDelegate goToHomeWindowDelegate;
        public SearchTickets(GoToHomeWindowDelegate goHome)
        {
            InitializeComponent();
            goToHomeWindowDelegate = goHome;
        }

        private void SearchTickets_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            SearchEntriesForm sef = new SearchEntriesForm(goBackToHome, my_UnhideForm);
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
    }
}
