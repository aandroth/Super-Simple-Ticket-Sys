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
        public string title;
        public CAR_PARTS part;
        public string description;
        public int id;
        public static int nextId;

        public TicketInfo(string _title, CAR_PARTS _part, string _description)
        {
            title = _title;
            part = _part;
            description = _description;
            id = nextId;
            ++nextId;
        }
    }

    public partial class Form1 : Form
    {
        List<TicketInfo> ticketInfoList = new List<TicketInfo>();
        int nextTicketId = 0;

        public Form1()
        {
            InitializeComponent();

            ticketInfoList.Add(new TicketInfo("Broken Cylinder", CAR_PARTS.ENGINE, "Second cylinder cracked. Needs to be replaced."));
            ticketInfoList.Add(new TicketInfo("Chipped Windshield", CAR_PARTS.WINDSHIELD, "Windshield chipped on the road. Needs repair."));
            ticketInfoList.Add(new TicketInfo("Dented Door", CAR_PARTS.CHASIS, "Door dented in accident. Needs repair."));
            ticketInfoList.Add(new TicketInfo("Cupholder Replacement", CAR_PARTS.OTHER, "Customer wants cupholder sized to fit large slurpee cups. Replace with correct part."));
            ticketInfoList.Add(new TicketInfo("Cracked Pistons", CAR_PARTS.ENGINE, "Pistons cracked and need to be replaced."));
            ticketInfoList.Add(new TicketInfo("Loose Windshield", CAR_PARTS.WINDSHIELD, "Windshield needs to be reglued."));
            ticketInfoList.Add(new TicketInfo("Bent Frame", CAR_PARTS.CHASIS, "Frame is bent under driver's door."));
            ticketInfoList.Add(new TicketInfo("Faded Paint", CAR_PARTS.OTHER, "Needs a fresh coat of paint."));
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            CreateTicketForm ctf = new CreateTicketForm(my_UnhideForm, AddTicketInfo, closeForm);
            ctf.Tag = this;
            ctf.StartPosition = FormStartPosition.Manual;
            ctf.Location = this.Location;
            ctf.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            SearchTickets searchForm = new SearchTickets(my_UnhideForm, GetTicketList, GetTicketById, RemoveTicketById, EditTicketById, closeForm);
            searchForm.Tag = this;
            searchForm.StartPosition = FormStartPosition.Manual;
            searchForm.Location = this.Location;
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

        public List<TicketInfo> GetTicketList()
        {
            return ticketInfoList;
        }

        public TicketInfo GetTicketById(int id)
        {
            TicketInfo tI = ticketInfoList.Where(t => t.id == id).ToList<TicketInfo>()[0];
            int idx = ticketInfoList.IndexOf(tI);
            return ticketInfoList[idx];
        }

        public void RemoveTicketById(int id)
        {
            TicketInfo tI = ticketInfoList.Where(t => t.id == id).ToList<TicketInfo>()[0];
            int idx = ticketInfoList.IndexOf(tI);
            ticketInfoList.RemoveAt(idx);
        }

        public void EditTicketById(int id, TicketInfo ticketInfo)
        {
            TicketInfo tI = ticketInfoList.Where(t => t.id == id).ToList<TicketInfo>()[0];
            int idx = ticketInfoList.IndexOf(tI);
            ticketInfoList[idx] = ticketInfo;
        }

        public void closeForm()
        {
            this.Close();
        }
    }
}
