using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TODOlist_ojt;

namespace TODOlist_ojt_test
{
    [TestFixture]
    class TodolistManager_test
    {
        TnitializingBeforeTest startProcess = new TnitializingBeforeTest();

        [TestCase("買い物に行く")]
        public void 文字列を渡すとTODOリストに追加される(string inputTodoContents)
        {
            //CSVの初期化
            startProcess.TestStartingBeforeOperation_ElemetsCountIs_7();
            var todoListManager = new TodoListManager();
            todoListManager.AddTodoContentToTodoListProcess(inputTodoContents);
            var todoListForTest = new List<string>(todoListManager.TodoList);
            var expectedTodoString = todoListForTest[todoListForTest.Count - 1];
            Assert.AreEqual(expectedTodoString, inputTodoContents);
        }
        [Test]
        public void 最初のTODOを取得するとリストの最初のTODOが返ってくる()
        {
            //CSVの初期化
            startProcess.TestStartingBeforeOperation_ElemetsCountIs_7();
            var todoListManager = new TodoListManager();
            todoListManager.LoadCsvFileToTodoList();
            var expectedTodoString = todoListManager.TodoList[0];
            var firstTodo = todoListManager.AcquisitionFirstTodo();
            Assert.AreEqual(expectedTodoString, firstTodo);
        }
        [Test]
        public void 最後のTODOを取得するとリストの最後のTODOが返ってくる()
        {
            //CSVの初期化
            startProcess.TestStartingBeforeOperation_ElemetsCountIs_7();
            var todoListManager = new TodoListManager();
            todoListManager.LoadCsvFileToTodoList();
            var todoListForTest = new List<string>(todoListManager.TodoList);
            var expectedTodoString = todoListForTest[todoListForTest.Count - 1];
            var lastTodoString = todoListManager.AcquisitionLastTodo();
            Assert.AreEqual(expectedTodoString, lastTodoString);
        }
        [Test]
        public void 全てのTODOの取得するとList型配列が返ってくる()
        {
            //CSVの初期化
            startProcess.TestStartingBeforeOperation_ElemetsCountIs_7();
            var todoListManager = new TodoListManager();
            todoListManager.LoadCsvFileToTodoList();
            var expectedList = todoListManager.TodoList;
            var returnList = todoListManager.ReturnTodoListContent();
            CollectionAssert.AreEqual(expectedList, returnList);
        }
        [Test]
        public void 最初のTODOを削除すると完了メッセージが返ってくる()
        {
            //CSVの初期化
            startProcess.TestStartingBeforeOperation_ElemetsCountIs_7();
            var todoListManager = new TodoListManager();
            var expectedString = todoListManager.ReturnMessageIsRemoveTodo();
            var returnString = todoListManager.RemoveFirstTodo();
            Assert.AreEqual(expectedString, returnString);
        }
        [Test]
        public void 最後のTODOを削除すると完了メッセージが返ってくる()
        {
            //CSVの初期化
            startProcess.TestStartingBeforeOperation_ElemetsCountIs_7();
            var todoListManager = new TodoListManager();
            var expectedString = todoListManager.ReturnMessageIsRemoveTodo();
            var returnString = todoListManager.RemoveLastTodo();
            Assert.AreEqual(expectedString, returnString);
        }
        [Test]
        public void 全てのTODOを削除すると完了メッセージが返ってくる()
        {
            //CSVの初期化
            startProcess.TestStartingBeforeOperation_ElemetsCountIs_7();
            var todoListManager = new TodoListManager();
            var expectedString = todoListManager.ReturnMessageIsRemoveAllTodo();
            var returnString = todoListManager.RemoveAllTodo();
            Assert.AreEqual(expectedString, returnString);
        }
        [TestCase(2, 5)]
        [TestCase(1, 3)]
        [TestCase(3, 4)]
        public void リストのTODOを入れ替える(int replacingPosition, int taegetPosition)
        {
            // CSVの初期化
            startProcess.TestStartingBeforeOperation_ElemetsCountIs_7();
            var todoListManager = new TodoListManager();
            var beforeTodoList = new List<string>(todoListManager.TodoList);
            var returnString = todoListManager.SwapTodo(replacingPosition, taegetPosition);
            CollectionAssert.AreNotEqual(todoListManager.TodoList, beforeTodoList);
        }
        [TestCase(1, 8)]
        [TestCase(5, 9)]
        [TestCase(10, 2)]
        public void TODO入れ替えの際にTODOリストの範囲外の数値を入力するとエラーメッセージが返ってくる(int replacingPosition, int taegetPosition)
        {
            // CSVの初期化
            startProcess.TestStartingBeforeOperation_ElemetsCountIs_7();
            var todoListManager = new TodoListManager();
            var expectedString = todoListManager.ReturnMessageIsNumberRangeOutsideTodo();
            var returnString = todoListManager.SwapTodo(replacingPosition, taegetPosition);
            Assert.AreEqual(expectedString, returnString);
        }
        [TestCase(1, 2)]
        [TestCase(3, 5)]
        [TestCase(4, 6)]
        public void TODO入れ替えの際にTODOが一件だけの場合はエラーメッセージが返ってくる(int replacingPosition, int taegetPosition)
        {
            // CSVの初期化
            startProcess.TestStartingBeforeOperation_ElemetsCountIs_1();
            var todoListManager = new TodoListManager();
            var expectedString = todoListManager.ReturnMessageIsTodoListElementsCountIsOne();
            var returnString = todoListManager.SwapTodo(replacingPosition, taegetPosition);
            Assert.AreEqual(expectedString, returnString);
        }
        [TestCase(1, 2)]
        [TestCase(3, 4)]
        [TestCase(5, 6)]
        public void TODO入れ替えの際にTODOリストが空ならエラーメッセージが返ってくる(int replacingPosition, int taegetPosition)
        {
            // CSVの初期化
            startProcess.TestStartingBeforeOperation_ElemetsCountIs_7();
            var todoListManager = new TodoListManager();
            todoListManager.RemoveAllTodo();
            var expectedString = todoListManager.ReturnMessageIsListEmpty();
            var returnString = todoListManager.SwapTodo(replacingPosition, taegetPosition);
            Assert.AreEqual(expectedString, returnString);
        }

        [TestCase(1, 1)]
        [TestCase(3, 3)]
        [TestCase(5, 5)]
        public void TODO入れ替えの際に同じ値が指定されたらエラーメッセージが返ってくる(int replacingPosition, int taegetPosition)
        {
            // CSVの初期化
            startProcess.TestStartingBeforeOperation_ElemetsCountIs_7();
            var todoListManager = new TodoListManager();
            var expectedString = todoListManager.ReturnMessageIsEqualValueSpecified();
            var returnString = todoListManager.SwapTodo(replacingPosition, taegetPosition);
            Assert.AreEqual(expectedString, returnString);
        }

    }
}