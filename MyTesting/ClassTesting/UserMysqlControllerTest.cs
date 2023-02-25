using Firebase.Auth;
using Microsoft.AspNetCore.Mvc;
using MinimalApiSample.Controller;
using MinimalApiSample.IIterfaces;
using MinimalApiSample.ModelsMysql;
using Moq;
using MyTesting.ModelFake;
using Org.BouncyCastle.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace MyTesting.ClassTesting
{
    public class UserMysqlControllerTest
    {
        //private readonly UserMysqlController _controller;
        //private readonly IDataServiceMsql _service;


        private Mock<IDataServiceMysql> _serviceUserMysql;

        public UserMysqlControllerTest()
        {
            //_service = new MysqlServiceFake();
            //_controller = new UserMysqlController(_service);

            _serviceUserMysql = new Mock<IDataServiceMysql>();


        }


        [Fact]
        public async Task GetTest()
        {
            _serviceUserMysql.Setup(x => x.GetDataIdAsync(UserListFake.user.Id)).ReturnsAsync(UserListFake.user);
            //arrange
            var UserMysqlController = new UserMysqlController(_serviceUserMysql.Object);
            // art 
            var UserMysqlResult = await UserMysqlController.GetByIdAsync(UserListFake.user.Id) as ObjectResult;
            var actResult = UserMysqlResult;
            //assert
            Assert.IsType<OkObjectResult>(actResult);
            Assert.Equal(UserListFake.user.Name, ((UserMysql)actResult.Value).Name);
            Assert.Equal(HttpStatusCode.OK, ((HttpStatusCode)UserMysqlResult.StatusCode));
            Assert.Equal(UserListFake.user.Id, ((UserMysql)actResult.Value).Id);

        }
        [Fact]
        public async Task GetAllTest()
        {

            _serviceUserMysql.Setup(x => x.GetDataAsync()).ReturnsAsync(UserListFake._UserMysql);

            //arrange
            var UserMysqlController = new UserMysqlController(_serviceUserMysql.Object);
            // art 
            var UserMysqlResult = await UserMysqlController.GetTodoItems() as ObjectResult;
            var actResult = UserMysqlResult;

            //assert
            Assert.IsType<OkObjectResult>(actResult);
            Assert.Equal(HttpStatusCode.OK, ((HttpStatusCode)UserMysqlResult.StatusCode));

        }

        [Fact]
        public async Task PostTest()
        {
            _serviceUserMysql.Setup(x => x.PostItemAsync(UserListFake.user)).ReturnsAsync(UserListFake.user);
            //arrange
            var UserMysqlController = new UserMysqlController(_serviceUserMysql.Object);

            // art 
            var UserMysqlResult = await UserMysqlController.PostItem(UserListFake.user) as ObjectResult;
            var actResult = UserMysqlResult;

            //assert
            Assert.IsType<OkObjectResult>(actResult);
            Assert.Equal(HttpStatusCode.OK, ((HttpStatusCode)UserMysqlResult.StatusCode));


        }
        [Fact]
        public async Task DeleteTest()
        {
            _serviceUserMysql.Setup(x => x.DeleteDataIdAsync(UserListFake.user.Id)).ReturnsAsync(UserListFake.user);
            //arrange
            var UserMysqlController = new UserMysqlController(_serviceUserMysql.Object);

            // art 
            var UserMysqlResult = await UserMysqlController.DeleteByIdAsync(UserListFake.user.Id) as ObjectResult;
            var actResult = UserMysqlResult;

            //assert
            Assert.IsType<OkObjectResult>(actResult);
            Assert.Equal(HttpStatusCode.OK, ((HttpStatusCode)UserMysqlResult.StatusCode));


        }
        [Fact]
        public async Task PutTest()
        {
            _serviceUserMysql.Setup(x => x.PutItemAsync(UserListFake.user)).ReturnsAsync(UserListFake.user);
            //arrange
            var UserMysqlController = new UserMysqlController(_serviceUserMysql.Object);

            // art 
            var UserMysqlResult = await UserMysqlController.PutItem(UserListFake.user) as ObjectResult;
            var actResult = UserMysqlResult;

            //assert
            Assert.IsType<OkObjectResult>(actResult);
            Assert.Equal(HttpStatusCode.OK, ((HttpStatusCode)UserMysqlResult.StatusCode));


        }
    }
}
