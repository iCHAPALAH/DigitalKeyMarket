using System.Linq.Expressions;
using DigitalKeyMarket.BL.Users.Provider;
using DigitalKeyMarket.DataAccess.Entities;
using DigitalKeyMarket.DataAccess.Repository;
using Moq;
using NUnit.Framework;

namespace DigitalKeyMarket.BL.UnitTests.Users;

public class UsersProviderTests
{
    [Test]
    public void GetUsersTest()
    {
        Expression expression = null;
        var repositoryMock = new Mock<IRepository<UserEntity>>();
        repositoryMock.Setup(repository => repository.GetAll(It.IsAny<Expression<Func<UserEntity, bool>>>()))
            .Callback((Expression<Func<UserEntity, bool>> x) => expression = x);
        var usersProvider = new UsersProvider(repositoryMock.Object, Utils.Mapper);
        usersProvider.GetUsers();

        repositoryMock.Verify(repository => repository
            .GetAll(It.IsAny<Expression<Func<UserEntity, bool>>>()), Times.Once);
    }
}