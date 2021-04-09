using EWalletWPF.Navigation;
using Models.Users;
using Prism.Commands;
using Services;
using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;
using System.Windows;

namespace EWalletWPF.Authentication
{
    public class SignUpViewModel : INotifyPropertyChanged, INavigatable<AuthNavigatableTypes>
    {
        private RegistrationUser _regUser = new RegistrationUser();
        private Action _gotoSignIn;

        private int _passwordLength;
        private string _passwordRepeat;

        public DelegateCommand SignUpCommand { get; }
        public DelegateCommand SignInCommand { get; }

        public AuthNavigatableTypes Type
        {
            get
            {
                return AuthNavigatableTypes.SignUp;
            }
        }

        public string Login
        {
            get
            {
                return _regUser.Login;
            }
            set
            {
                if (_regUser.Login != value)
                {
                    _regUser.Login = value;
                    OnPropertyChanged();
                    SignUpCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public string Password
        {
            get
            {
                return _regUser.Password;
            }
            set
            {
                _passwordLength = value.Length;
                if (_regUser.Password != PasswordEncryptionService.CalculateMD5Hash(value))
                {
                    _regUser.Password = PasswordEncryptionService.CalculateMD5Hash(value);
                    OnPropertyChanged();
                    SignUpCommand.RaiseCanExecuteChanged();
                }
            }
        }
        public string PasswordRepeat
        {
            get
            {
                if (_passwordRepeat != null)
                    return _passwordRepeat;
                return "";
            }
            set
            {
                _passwordRepeat = PasswordEncryptionService.CalculateMD5Hash(value);
                OnPropertyChanged();
                SignUpCommand.RaiseCanExecuteChanged();
            }
        }
        public string FirstName
        {
            get
            {
                return _regUser.FirstName;
            }
            set
            {
                if (_regUser.FirstName != value)
                {
                    _regUser.FirstName = value;
                    OnPropertyChanged();
                    SignUpCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public string LastName
        {
            get
            {
                return _regUser.LastName;
            }
            set
            {
                if (_regUser.LastName != value)
                {
                    _regUser.LastName = value;
                    OnPropertyChanged();
                    SignUpCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public string Email
        {
            get
            {
                return _regUser.Email;
            }
            set
            {
                if (_regUser.Email != value)
                {
                    _regUser.Email = value;
                    OnPropertyChanged();
                    SignUpCommand.RaiseCanExecuteChanged();
                }
            }
        }

        public SignUpViewModel(Action gotoSignIn)
        {
            SignUpCommand = new DelegateCommand(SignUp, IsSignUpEnabled);
            _gotoSignIn = gotoSignIn;
            SignInCommand = new DelegateCommand(_gotoSignIn);
        }

        private async void SignUp()
        {

            var authService = new AuthenticationService();
            try
            {
                await authService.RegisterUserAsync(_regUser);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Sign Up failed: {ex.Message}");
                return;
            }

            MessageBox.Show($"User successfully registered, please Sign In");
            _gotoSignIn.Invoke();
        }

        private bool IsSignUpEnabled()
        {
            return !String.IsNullOrWhiteSpace(Login) && !String.IsNullOrWhiteSpace(Password) && String.Equals(Password, PasswordRepeat)
                && !String.IsNullOrWhiteSpace(FirstName) && !String.IsNullOrWhiteSpace(LastName) && !String.IsNullOrWhiteSpace(Email)
                && _passwordLength >= 8 && IsValidEmailAddress(Email);
        }

        private bool IsValidEmailAddress(string s)
        {
            Regex regex = new Regex(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$");
            return regex.IsMatch(s);
        }

        public void ClearSensitiveData()
        {
            _regUser = new RegistrationUser();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public void UpdateView() { }
    }
}
