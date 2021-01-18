using DeloitteTODO.ApiModels;
using DeloitteTODO.Data;
using DeloitteTODO.Models;
using DeloitteTODO.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections;

namespace DeloitteTODO.UnitTest.Services
{
    public class ToDoServiceTests
    {
        private Mock<IApplicationDbContext> _applicationDbContext;

        [SetUp]
        public void SetUp()
        {
            _applicationDbContext = new Mock<IApplicationDbContext>();
            _applicationDbContext.Setup(r => r.GetByIdAsync<ToDoData>(1)).ReturnsAsync(new ToDoData() { Id = 1, Describtion = "Test1", UserId = "userid1", IsChecked = false, Date = DateTime.MaxValue });
            _applicationDbContext.Setup(r => r.GetByIdAsync<ToDoData>(2)).ReturnsAsync(new ToDoData() { Id = 2, Describtion = "Test2", UserId = "userid2", IsChecked = true, Date = DateTime.MaxValue });
            _applicationDbContext.Setup(r => r.GetByIdAsync<ToDoData>(3)).ReturnsAsync(new ToDoData() { Id = 3, Describtion = "Test3", UserId = "userid3", IsChecked = true, Date = new DateTime(2021, 1, 1) });
            _applicationDbContext.Setup(r => r.GetByIdAsync<ToDoData>(4)).ReturnsAsync(new ToDoData() { Id = 4, Describtion = "Test4", UserId = "userid4", IsChecked = false, Date = new DateTime(2021, 1, 1) });
        }

        [Test, TestCaseSource(typeof(ToDoItemList))]
        public void TestGetByIdAsync(ToDoItemDTO toDoItemDTO)
        {
            var toDoService = new ToDoService(_applicationDbContext.Object);
            var result = toDoService.GetByIdAsync(toDoItemDTO.Id);

            Assert.AreEqual(result.Result.Id, toDoItemDTO.Id);
            Assert.AreEqual(result.Result.Describtion, toDoItemDTO.Describtion);
            Assert.AreEqual(result.Result.UserId, toDoItemDTO.UserId);
            Assert.AreEqual(result.Result.IsChecked, toDoItemDTO.IsChecked);
        }

        [Test]
        public void TestAsyncList()
        {
            //todo
            Assert.Pass();
        }

        [Test]
        public void AddAsync()
        {
            //todo
            Assert.Pass();
        }


        [Test]
        public void UpdateAsync()
        {
            //todo
            Assert.Pass();
        }


        [Test]
        public void DeleteAsync()
        {
            //todo
            Assert.Pass();
        }
    }

    class ToDoItemList : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new ToDoItemDTO { Id = 1, Describtion = "Test1", UserId = "userid1", IsChecked = false, Date = DateTime.MaxValue };
            yield return new ToDoItemDTO { Id = 2, Describtion = "Test2", UserId = "userid2", IsChecked = true, Date = DateTime.MaxValue };
            yield return new ToDoItemDTO { Id = 3, Describtion = "Test3", UserId = "userid3", IsChecked = true, Date = new DateTime(2021, 1, 1) };
            yield return new ToDoItemDTO { Id = 4, Describtion = "Test4", UserId = "userid4", IsChecked = false, Date = new DateTime(2021, 1, 1) };
        }
    }
}
