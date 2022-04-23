using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Moq;
using NUnit.Framework;
using Steer73.FormsApp.Framework;
using Steer73.FormsApp.Model;
using Steer73.FormsApp.ViewModels;

namespace Steer73.FormsApp.Tests.ViewModels
{
    [TestFixture]
    public class UsersViewModelTests
    {
        [Test]
        public async Task InitializeFetchesTheData()
        {
            var userService = new Mock<IUserService>();
            var messageService = new Mock<IMessageService>();

            var viewModel = new UsersViewModel(
                userService.Object,
                messageService.Object);

            userService
                .Setup(p => p.GetUsers())
                .Returns(Task.FromResult(Enumerable.Empty<User>()))
                .Verifiable();

            await viewModel.Initialize();

            userService.VerifyAll();
        }


        [Test]
        public async Task InitializeShowErrorMessageOnFetchingError()
        {
            var userService = new Mock<IUserService>();
            var messageService = new Mock<IMessageService>();

            var viewModel = new UsersViewModel(
                userService.Object,
                messageService.Object);

            //Inititalise a null Users list to make the initialize method to throw and exception
            IEnumerable<User> Users = null;

            userService.Setup(o => o.GetUsers()).Returns(Task.FromResult(Users)).Verifiable();

            messageService.Setup(x => x.ShowError(It.IsAny<string>())).Verifiable();

            await viewModel.Initialize();

            messageService.VerifyAll();

        }
    }
}
