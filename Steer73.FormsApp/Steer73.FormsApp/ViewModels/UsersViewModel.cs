using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Steer73.FormsApp.Framework;
using Steer73.FormsApp.Model;
using Xamarin.Forms;

namespace Steer73.FormsApp.ViewModels
{
    public class UsersViewModel : ViewModel
    {
        private readonly IUserService _userService;
        private readonly IMessageService _messageService;

        public UsersViewModel()
        {
        }

        public UsersViewModel(
            IUserService userService,
            IMessageService messageService)
        {
            _userService = userService;
            _messageService = messageService;
        }

        public async Task Initialize()
        {
            try
            {
                IsBusy = true;

                var users = await _userService.GetUsers();

                foreach (var user in users)
                {
                    Users.Add(user);
                }

            }
            catch (Exception ex)
            {
                await _messageService.ShowError(ex.Message);
            }
            finally
            {
                IsBusy = false;
            }
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set => SetProperty(ref _isBusy, value);
        }
        public ObservableCollection<User> Users { get; } = new ObservableCollection<User>();
    }
}
