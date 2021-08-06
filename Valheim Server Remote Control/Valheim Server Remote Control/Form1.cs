using System;
using System.Drawing;
using System.Windows.Forms;
using Amazon;
using Amazon.EC2;
using Amazon.EC2.Model;

namespace Valheim_Server_Remote_Control
{
    public partial class Form1 : Form
    {
        private EC2Service ec2Service;

        public Form1()
        {
            InitializeComponent();
            this.ec2Service = new EC2Service();
            serverAddressLabel.Text = Config.ServerAddress;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var status = ec2Service.GetServerStatus();
            serverStatusLabel.Text = status;
            SetStatusColor(status);
        }

        private void StartServerButton_Click(object sender, EventArgs e)
        {
            ec2Service.StartServer();
        }

        private void StopServerButton_Click(object sender, EventArgs e)
        {
            ec2Service.StopServer();
        }

        private void CheckServerStatusButton_Click(object sender, EventArgs e)
        {
            var status = ec2Service.GetServerStatus();
            serverStatusLabel.Text = status;
            SetStatusColor(status);
        }

        private void SetStatusColor(string status)
        {
            switch (status)
            {
                case "running":
                    serverStatusLabel.ForeColor = Color.LimeGreen;
                    break;
                case "pending":
                case "shutting-down":
                case "stopped":
                case "stopping":
                case "terminated":
                    serverStatusLabel.ForeColor = Color.DarkRed;
                    break;
            }
        }
    }
}
