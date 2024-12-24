using DigitalKeyMarket.BL.Users.Exceptions;
using DigitalKeyMarket.BL.Users.Manager;
using DigitalKeyMarket.BL.Users.Model;
using DigitalKeyMarket.DataAccess.Entities;
using DigitalKeyMarket.DataAccess.Repository;
using FluentAssertions;
using Moq;
using NUnit.Framework;

namespace DigitalKeyMarket.BL.UnitTests.Users;

public static class UserManagerTests
{
    [Test]
    public static void DeleteUserTest()
    {
        var users = new List<UserEntity>
        {
            new()
        };

        var usersRepositoryMock = new Mock<IRepository<UserEntity>>();
        usersRepositoryMock.Setup(repository => repository.Delete(It.IsAny<UserEntity>()))
            .Callback(() => { users.RemoveAt(0); });
        usersRepositoryMock.Setup(repository => repository.GetById(0))
            .Returns(new UserEntity());

        var rolesRepositoryMock = new Mock<IRepository<RoleEntity>>();

        var usersManager = new UsersManager(
            usersRepositoryMock.Object,
            rolesRepositoryMock.Object,
            Utils.Mapper);
        usersManager.DeleteUser(0);

        usersRepositoryMock.Verify(repository => repository
            .Delete(It.IsAny<UserEntity>()), Times.Once);
        usersRepositoryMock.Verify(repository => repository
            .GetById(It.IsAny<int>()), Times.Once);
        users.Should().BeEmpty();
    }

    [Test]
    public static void UpdateUserTest()
    {
        var userEntity = new UserEntity
        {
            Username = "JohnDoe"
        };

        var newUserEntity = new UserEntity
        {
            Username = "JohnDoe"
        };

        var usersRepositoryMock = new Mock<IRepository<UserEntity>>();
        usersRepositoryMock.Setup(repository => repository.Save(It.IsAny<UserEntity>()))
            .Returns(() => newUserEntity);
        usersRepositoryMock.Setup(repository => repository.GetById(0))
            .Returns(userEntity);

        var rolesRepositoryMock = new Mock<IRepository<RoleEntity>>();

        var usersManager = new UsersManager(
            usersRepositoryMock.Object,
            rolesRepositoryMock.Object,
            Utils.Mapper);
        var model = usersManager.UpdateUser(0, new UpdateUserModel());

        usersRepositoryMock.Verify(repository => repository
            .GetById(It.IsAny<int>()), Times.Once);
        usersRepositoryMock.Verify(repository => repository
            .Save(It.IsAny<UserEntity>()), Times.Once);
        model.Username.Should().Be("JohnDoe");

        usersRepositoryMock = new Mock<IRepository<UserEntity>>();
        usersRepositoryMock.Setup(repository => repository.GetById(It.IsAny<int>()))
            .Returns(() => null);

        usersManager = new UsersManager(
            usersRepositoryMock.Object,
            rolesRepositoryMock.Object,
            Utils.Mapper);

        var expectedAct = () => usersManager.UpdateUser(0, new UpdateUserModel());
        expectedAct.Should().Throw<UserNotFoundException>();
    }
}