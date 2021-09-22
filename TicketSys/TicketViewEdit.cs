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

        public delegate void CloseAllFormsDelegate();
        CloseAllFormsDelegate closeAllFormsDelegate;
        public TicketViewEdit(CloseAllFormsDelegate closeAllForms)
        {
            InitializeComponent();
            closeAllFormsDelegate = closeAllForms;
        }

        private void TicketViewEdit_Load(object sender, EventArgs e)
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
