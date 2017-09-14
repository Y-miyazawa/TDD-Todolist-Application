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
            var TM = new TodoListManager();
            TM.AddTodoContentToTodoListProcess(inputTodoContents);
            var todoListForTest = new List<string>(TM.TodoList);
            var expectedTodoString = todoListForTest[todoListForTest.Count - 1];
            Assert.AreEqual(expectedTodoString, inputTodoContents);
        }
        [Test]
        public void 最初のTODOを取得するとリストの最初のTODOが返ってくる()
        {
            //CSVの初期化
            startProcess.TestStartingBeforeOperation_ElemetsCountIs_7();
            var TM = new TodoListManager();
            TM.LoadCsvFileToTodoList();
            var expectedTodoString = TM.TodoList[0];
            var firstTodo = TM.AcquisitionFirstTodo();
            Assert.AreEqual(expectedTodoString, firstTodo);
        }
        [Test]
        public void 最後のTODOを取得するとリストの最後のTODOが返ってくる()
        {
            //CSVの初期化
            startProcess.TestStartingBeforeOperation_ElemetsCountIs_7();
            var TM = new TodoListManager();
            TM.LoadCsvFileToTodoList();
            var todoListForTest = new List<string>(TM.TodoList);
            var expectedTodoString = todoListForTest[todoListForTest.Count - 1];
            var lastTodoString = TM.AcquisitionLastTodo();
            Assert.AreEqual(expectedTodoString, lastTodoString);
        }
        [Test]
        public void 全てのTODOの取得するとList型配列が返ってくる()
        {
            //CSVの初期化
            startProcess.TestStartingBeforeOperation_ElemetsCountIs_7();
            var TM = new TodoListManager();
            var expectedList = new List<string>(TM.TodoList);
            var returnList = TM.ReturnTodoListContent();
            CollectionAssert.AreEqual(expectedList, returnList);
        }
        [Test]
        public void 最初のTODOを削除すると完了メッセージが返ってくる()
        {
            //CSVの初期化
            startProcess.TestStartingBeforeOperation_ElemetsCountIs_7();
            var TM = new TodoListManager();
            var expectedString = TM.ReturnMessageIsRemoveTodo();
            var returnString = TM.RemoveFirstTodo();
            Assert.AreEqual(expectedString, returnString);
        }
        [Test]
        public void 最後のTODOを削除すると完了メッセージが返ってくる()
        {
            //CSVの初期化
            startProcess.TestStartingBeforeOperation_ElemetsCountIs_7();
            var TM = new TodoListManager();
            var expectedString = TM.ReturnMessageIsRemoveTodo();
            var returnString = TM.RemoveLastTodo();
            Assert.AreEqual(expectedString, returnString);
        }
        [Test]
        public void 全てのTODOを削除すると完了メッセージが返ってくる()
        {
            //CSVの初期化
            startProcess.TestStartingBeforeOperation_ElemetsCountIs_7();
            var TM = new TodoListManager();
            var expectedString = TM.ReturnMessageIsRemoveAllTodo();
            var returnString = TM.RemoveAllTodo();
            Assert.AreEqual(expectedString, returnString);
        }
        [TestCase(2, 5)]
        [TestCase(1, 3)]
        [TestCase(3, 4)]
        public void リストのTODOを入れ替える(int replacingPosition, int taegetPosition)
        {
            // CSVの初期化
            startProcess.TestStartingBeforeOperation_ElemetsCountIs_7();
            var TM = new TodoListManager();
            var beforeTodoList = new List<string>(TM.TodoList);
            var returnString = TM.SwapTodo(replacingPosition, taegetPosition);
            CollectionAssert.AreNotEqual(TM.TodoList, beforeTodoList);
        }
        [TestCase(1, 8)]
        [TestCase(5, 9)]
        [TestCase(10, 2)]
        public void TODO入れ替えの際にTODOリストの範囲外の数値を入力するとエラーメッセージが返ってくる(int replacingPosition, int taegetPosition)
        {
            // CSVの初期化
            startProcess.TestStartingBeforeOperation_ElemetsCountIs_7();
            var TM = new TodoListManager();
            var expectedString = TM.ReturnMessageIsNumberRangeOutsideTodo();
            var returnString = TM.SwapTodo(replacingPosition, taegetPosition);
            Assert.AreEqual(expectedString, returnString);
        }
        [TestCase(1, 2)]
        [TestCase(3, 5)]
        [TestCase(4, 6)]
        public void TODO入れ替えの際にTODOが一件だけの場合はエラーメッセージが返ってくる(int replacingPosition, int taegetPosition)
        {
            // CSVの初期化
            startProcess.TestStartingBeforeOperation_ElemetsCountIs_1();
            var TM = new TodoListManager();
            var expectedString = TM.ReturnMessageIsTodoListElementsCountIsOne();
            var returnString = TM.SwapTodo(replacingPosition, taegetPosition);
            Assert.AreEqual(expectedString, returnString);
        }
        [TestCase(1, 2)]
        [TestCase(3, 4)]
        [TestCase(5, 6)]
        public void TODO入れ替えの際にTODOリストが空ならエラーメッセージが返ってくる(int replacingPosition, int taegetPosition)
        {
            // CSVの初期化
            startProcess.TestStartingBeforeOperation_ElemetsCountIs_7();
            var TM = new TodoListManager();
            TM.RemoveAllTodo();
            var expectedString = TM.ReturnMessageIsListEmpty();
            var returnString = TM.SwapTodo(replacingPosition, taegetPosition);
            Assert.AreEqual(expectedString, returnString);
        }

        [TestCase(1, 1)]
        [TestCase(3, 3)]
        [TestCase(5, 5)]
        public void TODO入れ替えの際に同じ値が指定されたらエラーメッセージが返ってくる(int replacingPosition, int taegetPosition)
        {
            // CSVの初期化
            startProcess.TestStartingBeforeOperation_ElemetsCountIs_7();
            var TM = new TodoListManager();
            var expectedString = TM.ReturnMessageIsEqualValueSpecified();
            var returnString = TM.SwapTodo(replacingPosition, taegetPosition);
            Assert.AreEqual(expectedString, returnString);
        }

    }
}