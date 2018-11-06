using System.Windows.Forms;

namespace Elreg.Log
{
    public partial class MessageForm : Form
    {
        public MessageForm()
        {
            InitializeComponent();
        }

        public string ErrorMessage
        {
            set { lblMessage.Text = value; }
        }
    }
}
