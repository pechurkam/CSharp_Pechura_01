using System.Windows.Controls;
using CSharp_Pechura_01;

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
