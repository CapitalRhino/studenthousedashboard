using Logic;
using Models;
using Tests.Mocks;

namespace Tests
{

    [TestClass]
    public class UserManagerTest
    {
        // constants
        readonly string USER_NAME = "user";
        readonly string USER_PASSWORD = "password";

        [TestMethod]
        public void AuthenticatedUserWrongPasswordTest()
        {
            // Arrange
            UserManager userManager = new UserManager(new UserRepositoryFake());

            // Act
            userManager.CreateUser(USER_NAME, BCrypt.Net.BCrypt.HashPassword(USER_PASSWORD), UserRole.TENANT);
            User? result = userManager.AuthenticatedUser(USER_NAME, "incorrect");

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void AuthenticatedUserNullPasswordTest()
        {
            // Arrange
            UserManager userManager = new UserManager(new UserRepositoryFake());

            // Act
            userManager.CreateUser(USER_NAME, BCrypt.Net.BCrypt.HashPassword(USER_PASSWORD), UserRole.TENANT);
            userManager.AuthenticatedUser(USER_NAME, null);

            // Assert
            // ArgumentNullException expected
        }

        [TestMethod]
        public void AuthenticatedUserWrongNameTest()
        {
            // Arrange
            UserManager userManager = new UserManager(new UserRepositoryFake());
            userManager.CreateUser(USER_NAME, USER_PASSWORD, UserRole.TENANT);

            // Act
            User? result = userManager.AuthenticatedUser("incorrect", USER_PASSWORD);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void AuthenticatedUserCorrectDetailsTest()
        {
            // Arrange
            UserManager userManager = new UserManager(new UserRepositoryFake());

            User user = userManager.CreateUser(USER_NAME, BCrypt.Net.BCrypt.HashPassword(USER_PASSWORD), UserRole.TENANT);

            // Act
            User? result = userManager.AuthenticatedUser(USER_NAME, USER_PASSWORD);

            // Assert
            Assert.AreEqual(user, result);
        }

        [TestMethod]
        public void CreateUserCorrectDetailsTest()
        {
            // Arrange
            UserManager userManager = new UserManager(new UserRepositoryFake());

            int userId = 1;
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(USER_PASSWORD);
            User user = new User(userId, USER_NAME, hashedPassword, UserRole.TENANT);

            // Act
            User result = userManager.CreateUser(USER_NAME, hashedPassword, UserRole.TENANT);

            // Assert
            Assert.AreEqual(user.ID, result.ID);
            Assert.AreEqual(user.Name, result.Name);
            Assert.AreEqual(user.Password, result.Password);
            Assert.AreEqual(user.Role, result.Role);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateUserDuplicateNameTest()
        {
            // Arrange
            UserManager userManager = new UserManager(new UserRepositoryFake());

            // Act
            userManager.CreateUser(USER_NAME, BCrypt.Net.BCrypt.HashPassword(USER_PASSWORD), UserRole.TENANT);
            userManager.CreateUser(USER_NAME, BCrypt.Net.BCrypt.HashPassword(USER_PASSWORD), UserRole.TENANT);

            // Assert
            // ArgumentException expected
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateUserEmptyNameTest()
        {
            // Arrange
            UserManager userManager = new UserManager(new UserRepositoryFake());

            // Act
            userManager.CreateUser("", BCrypt.Net.BCrypt.HashPassword(USER_PASSWORD), UserRole.TENANT);

            // Assert
            // ArgumentException expected
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void CreateUserEmptyPasswordTest()
        {
            // Arrange
            UserManager userManager = new UserManager(new UserRepositoryFake());

            // Act
            userManager.CreateUser(USER_NAME, "", UserRole.TENANT);

            // Assert
            // ArgumentException expected
        }

        [TestMethod]
        public void DisableUserTest()
        {
            // Arrange
            UserManager userManager = new UserManager(new UserRepositoryFake());
            User user = userManager.CreateUser(USER_NAME, BCrypt.Net.BCrypt.HashPassword(USER_PASSWORD), UserRole.TENANT);

            // Act
            userManager.DisableUser(user.ID);

            // Assert
            Assert.AreEqual(user.Name, $"Deleted User {user.ID}");
            Assert.AreEqual(user.Password, "0");
        }

    }
}