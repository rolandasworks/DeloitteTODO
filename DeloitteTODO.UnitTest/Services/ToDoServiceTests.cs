using DeloitteTODO.ApiModels;
using DeloitteTODO.Data;
using DeloitteTODO.Models;
using DeloitteTODO.Services;
using Moq;
using NUnit.Framework;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace DeloitteTODO.UnitTest.Services
{
    public class ToDoServiceTests
    {
        private Mock<IApplicationDbContext> _applicationDbContext;
        private ToDoData[] _todoArray;

        [SetUp]
        public void SetUp()
        {
            _todoArray = GetTodoData();

            _applicationDbContext = new Mock<IApplicationDbContext>();
            _applicationDbContext.Setup(r => r.GetByIdAsync<ToDoData>(1)).ReturnsAsync(_todoArray[0]);
            _applicationDbContext.Setup(r => r.GetByIdAsync<ToDoData>(2)).ReturnsAsync(_todoArray[1]);
            _applicationDbContext.Setup(r => r.GetByIdAsync<ToDoData>(3)).ReturnsAsync(_todoArray[2]);
            _applicationDbContext.Setup(r => r.GetByIdAsync<ToDoData>(4)).ReturnsAsync(_todoArray[3]);
            _applicationDbContext.Setup(r => r.ListAsync<ToDoData>()).ReturnsAsync(_todoArray.OfType<ToDoData>().ToList());
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
        public void TestAsyncList_userid2()
        {
            var toDoService = new ToDoService(_applicationDbContext.Object);
            var result = toDoService.AsyncList("userid2");

            Assert.AreEqual(result.Result.Count, 2);
        }

        [Test]
        public void AddAsync()
        {
            var toDoService = new ToDoService(_applicationDbContext.Object);
            var result = toDoService.AddAsync(_todoArray[0].ConvertObject());

            Assert.IsTrue(result.Result);
        }

        [Test]
        public void UpdateAsync()
        {
            var toDoService = new ToDoService(_applicationDbContext.Object);
            var result = toDoService.UpdateAsync(_todoArray[0].ConvertObject());

            Assert.IsTrue(result.Result);
        }

        [Test]
        public void DeleteAsync()
        {
            var toDoService = new ToDoService(_applicationDbContext.Object);
            var result = toDoService.DeleteAsync(_todoArray[0].ConvertObject());

            Assert.IsTrue(result.Result);
        }

        private ToDoData[] GetTodoData()
        {
            ToDoData[] todoArray = new ToDoData[4];
            todoArray[0] = new ToDoData() { Id = 1, Describtion = "Test1", UserId = "userid1", IsChecked = false, Date = DateTime.MaxValue };
            todoArray[1] = new ToDoData() { Id = 2, Describtion = "Test2", UserId = "userid2", IsChecked = true, Date = DateTime.MaxValue };
            todoArray[2] = new ToDoData() { Id = 3, Describtion = "Test3", UserId = "userid2", IsChecked = true, Date = new DateTime(2021, 1, 1) };
            todoArray[3] = new ToDoData() { Id = 4, Describtion = "Test4", UserId = "userid4", IsChecked = false, Date = new DateTime(2021, 1, 1) };

            return todoArray;
        }
    }

    public class ToDoItemList : IEnumerable
    {
        public IEnumerator GetEnumerator()
        {
            yield return new ToDoItemDTO { Id = 1, Describtion = "Test1", UserId = "userid1", IsChecked = false, Date = DateTime.MaxValue };
            yield return new ToDoItemDTO { Id = 2, Describtion = "Test2", UserId = "userid2", IsChecked = true, Date = DateTime.MaxValue };
            yield return new ToDoItemDTO { Id = 3, Describtion = "Test3", UserId = "userid2", IsChecked = true, Date = new DateTime(2021, 1, 1) };
            yield return new ToDoItemDTO { Id = 4, Describtion = "Test4", UserId = "userid4", IsChecked = false, Date = new DateTime(2021, 1, 1) };
        }
    }
}
