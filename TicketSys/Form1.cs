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

    public enum CAR_PARTS { ENGINE, CHASIS, WINDSHIELD, OTHER}
    public struct TicketInfo
    {
        string title;
        CAR_PARTS part;
        string description;

        public TicketInfo(string _title, CAR_PARTS _part, string _description)
        {
            title = _title;
            part = _part;
            description = _description;
        }
    }

    public partial class Form1 : Form
    {
        List<TicketInfo> ticketInfoList = new List<TicketInfo>();

        public Form1()
        {
            InitializeComponent();

            ticketInfoList.Add(new TicketInfo("Broken Cylinder", CAR_PARTS.ENGINE, "Second cylinder cracked. Needs to be replaced."));
            ticketInfoList.Add(new TicketInfo("Chipped Windshield", CAR_PARTS.WINDSHIELD, "Windshield chipped on the road. Needs repair."));
            ticketInfoList.Add(new TicketInfo("Dented Door", CAR_PARTS.CHASIS, "Door dented in accident. Needs repair."));
            ticketInfoList.Add(new TicketInfo("Cupholder Replacement", CAR_PARTS.OTHER, "Customer wants cupholder sized to fit large slurpee cups. Replace with correct part."));
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void TicketSysLabel_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            CreateTicketForm ctf = new CreateTicketForm(my_UnhideForm, AddTicketInfo);
            ctf.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            SearchTickets searchForm = new SearchTickets(my_UnhideForm);
            searchForm.ShowDialog();
        }

        public void my_UnhideForm()
        {
            this.Show();
        }

        public void AddTicketInfo(TicketInfo ticketInfo)
        {
            ticketInfoList.Add(ticketInfo);
        }

        public void SearchTicketInfo(TicketInfo ticketInfo)
        {
            ticketInfoList.Add(ticketInfo);
        }
    }
}
