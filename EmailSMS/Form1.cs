using System;
using System.Windows.Forms;
using CommonUtils;
using Message = OpenPop.Mime.Message;

namespace EmailSMS
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //richTextBox1.AppendText("Working...");
            var emailSMS = new EmailSMS(@"EX0224195\Ronnie.Lawson+induction@esendex.com");
            var messages = emailSMS.GetMessages(Utility.GetSecret("password"));
            richTextBox1.Text = "";
            foreach (Message message in messages)
            {
                richTextBox1.AppendText($"message: {message.Headers.Date}: {message.Headers.From} - {message.Headers.Subject}\n");
            }
        }
    }
}
