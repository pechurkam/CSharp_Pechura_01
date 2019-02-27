using System.Windows.Controls;

namespace WpfApp1
{
    public partial class SignInView : UserControl
    {
        public SignInView()
        {
            InitializeComponent();
            DataContext = new Horoscope();
        }
    }
}
