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
        public delegate void GoToHomeWindowDelegate();
        GoToHomeWindowDelegate goToHomeWindowDelegate;

        public delegate void GoToSearchWindowDelegate();
        GoToSearchWindowDelegate goToSearchWindowDelegate;
        public SearchEntriesForm()
        {
            InitializeComponent();
        }
        public SearchEntriesForm(GoToHomeWindowDelegate goHome, GoToSearchWindowDelegate goSearch)
        {
            InitializeComponent();

            goToHomeWindowDelegate = goHome;
            goToSearchWindowDelegate  = goSearch;
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
    }
}
