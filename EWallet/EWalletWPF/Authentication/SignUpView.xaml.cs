using System.Windows;
using System.Windows.Controls;

namespace EWalletWPF.Authentication
{
    /// <summary>
    /// Interaction logic for SignUpView.xaml
    /// </summary>
    public partial class SignUpView : UserControl
    {
        public SignUpView()
        {
            InitializeComponent();
        }

        private void TbPassword_OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            ((SignUpViewModel)DataContext).Password = TbPassword.Password;
        }

        private void TbPasswordRepeat_OnPasswordChanged(object sender, RoutedEventArgs e)
        {
            ((SignUpViewModel)DataContext).PasswordRepeat = TbPasswordRepeat.Password;
        }

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
