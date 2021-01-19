using DeloitteTODO.Domain.DTO;
using DeloitteTODO.Domain.Entities;
using DeloitteTODO.Domain.Interfaces;
using DeloitteTODO.Domain.Services;
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

        private Mock<IUnitOfWork> _unitOfWork;
        private ToDoData[] _todoArray;

        [SetUp]
        public void SetUp()
        {
            _todoArray = GetTodoData();

            _unitOfWork = new Mock<IUnitOfWork>();

            _unitOfWork.Setup(r => r.ToDoRepository.GetByIdAsync<ToDoData>(1)).ReturnsAsync(_todoArray[0]);
            _unitOfWork.Setup(r => r.ToDoRepository.GetByIdAsync<ToDoData>(2)).ReturnsAsync(_todoArray[1]);
            _unitOfWork.Setup(r => r.ToDoRepository.GetByIdAsync<ToDoData>(3)).ReturnsAsync(_todoArray[2]);
            _unitOfWork.Setup(r => r.ToDoRepository.GetByIdAsync<ToDoData>(4)).ReturnsAsync(_todoArray[3]);
            _unitOfWork.Setup(r => r.ToDoRepository.ListAsync<ToDoData>()).ReturnsAsync(_todoArray.OfType<ToDoData>().ToList());
        }

        [Test, TestCaseSource(typeof(ToDoItemList))]
        public void TestGetByIdAsync(ToDoItemDTO toDoItemDTO)
        {
            var toDoService = new ToDoService(_unitOfWork.Object);
            var result = toDoService.GetTodoById(toDoItemDTO.Id);

            Assert.AreEqual(result.Result.Id, toDoItemDTO.Id);
            Assert.AreEqual(result.Result.Describtion, toDoItemDTO.Describtion);
            Assert.AreEqual(result.Result.UserId, toDoItemDTO.UserId);
            Assert.AreEqual(result.Result.IsChecked, toDoItemDTO.IsChecked);
        }
        [Test]
        public void TestAsyncList_userid2()
        {
            var toDoService = new ToDoService(_unitOfWork.Object);
            var result = toDoService.GetList("userid2");

            Assert.AreEqual(result.Result.Count, 2);
        }

        [Test]
        public void AddAsync()
        {
            var toDoService = new ToDoService(_unitOfWork.Object);
            var result = toDoService.AddTodo(_todoArray[0].ConvertObject());

            Assert.IsTrue(result.Result);
        }

        [Test]
        public void UpdateAsync()
        {
            var toDoService = new ToDoService(_unitOfWork.Object);
            var result = toDoService.UpdateTodo(_todoArray[0].ConvertObject());

            Assert.IsTrue(result.Result);
        }

        [Test]
        public void DeleteAsync()
        {
            var toDoService = new ToDoService(_unitOfWork.Object);
            var result = toDoService.DeleteTodo(_todoArray[0].ConvertObject());

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
