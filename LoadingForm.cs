using System;
using System.Windows.Forms;

namespace TubeSaver
{
    public partial class LoadingForm : Form
    {
        private int dotCount = 0;
        private readonly string baseMessage = "Carregando informações";

        public LoadingForm()
        {
            InitializeComponent();
            labelAguarde.Text = baseMessage;
            timer1.Interval = 500;
            timer1.Tick += timer_Tick;
            timer1.Start();

            this.ControlBox = false;
        }

        private void LoadingForm_Load(object sender, EventArgs e)
        {

        }

        private void timer_Tick(object sender, EventArgs e)
        {
            dotCount = (dotCount + 1) % 4;
            labelAguarde.Text = baseMessage + new string('.', dotCount);
        }
    }
}
