using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TODOlist_ojt;

namespace TODOlist_ojt_test
{
    [TestFixture]
    class OperationManager_test
    {
        TnitializingBeforeTest startProcess = new TnitializingBeforeTest();

        [TestCase("買い物に行く")]
        [TestCase("書類をまとめる")]
        [TestCase("ドライブに行く")]
        public void TODOを追加をすると追加完了メッセージが返ってくる(string addTodoString)
        {
            //CSVの初期化
            startProcess.TestStartingBeforeOperation_ElemetsCountIs_7();
            var operationManager = new OperationManager();
            var csvManager = new CsvManager();
            var expectedString = csvManager.ReturnMessageIsAdditionCompleted();
            var requestString = operationManager.ReceivedNumber1WhenAddProcess(addTodoString);
            Assert.AreEqual(expectedString, requestString);
        }

        [TestCase("aaa")]
        public void 最初のTODOを取得すると最初のTODOが返ってくる(string expectedString)
        {
            //CSVの初期化
            startProcess.TestStartingBeforeOperation_ElemetsCountIs_7();
            var operationManager = new OperationManager();
            var requestString = operationManager.InvokeProcessFixOperationNumber(2);
            Assert.AreEqual(expectedString, requestString);
        }
        [TestCase("ggg")]
        public void 最後のTODOを取得すると最後のTODOが返ってくる(string expectedString)
        {
            //CSVの初期化
            startProcess.TestStartingBeforeOperation_ElemetsCountIs_7();
            var operationManager = new OperationManager();
            var requestString = operationManager.InvokeProcessFixOperationNumber(3);
            Assert.AreEqual(expectedString, requestString);
        }
        [Test]
        public void TODO一覧を取得するとList型配列が返ってくる()
        {
            //CSVの初期化
            startProcess.TestStartingBeforeOperation_ElemetsCountIs_7();
            var operationManager = new OperationManager();
            var todoListManager = new TodoListManager();
            todoListManager.LoadCsvFileToTodoList();
            var expectedList = new List<string>(todoListManager.TodoList);
            var returnList = operationManager.RequestGetAllTodo();
            CollectionAssert.AreEqual(expectedList, returnList);
        }
        [Test]
        public void 最初のTODOを削除すると完了メッセージが返ってくる()
        {
            // CSVの初期化
            startProcess.TestStartingBeforeOperation_ElemetsCountIs_7();
            var operationManager = new OperationManager();
            var todoListManager = new TodoListManager();
            var expectedString = todoListManager.ReturnMessageIsRemoveTodo();
            var requestString = operationManager.InvokeProcessFixOperationNumber(5);
            Assert.AreEqual(expectedString, requestString);
        }
        [Test]
        public void 最後のTODOを削除すると完了メッセージが返ってくる()
        {
            // CSVの初期化
            startProcess.TestStartingBeforeOperation_ElemetsCountIs_7();
            var operationManager = new OperationManager();
            var todoListManager = new TodoListManager();
            var expectedString = todoListManager.ReturnMessageIsRemoveTodo();
            var requestString = operationManager.InvokeProcessFixOperationNumber(6);
            Assert.AreEqual(expectedString, requestString);
        }
        [Test]
        public void TODOを全削除すると完了メッセージが返ってくる()
        {
            //CSVの初期化
            startProcess.TestStartingBeforeOperation_ElemetsCountIs_7();
            var operationManager = new OperationManager();
            var todoListManager = new TodoListManager();
            var expectedString = todoListManager.ReturnMessageIsRemoveAllTodo();
            var requestString = operationManager.InvokeProcessFixOperationNumber(7);
            Assert.AreEqual(expectedString, requestString);
        }
        [TestCase(4, 2)]
        public void TODOを入れ替えると完了メッセージが返ってくる(int replacingPosition, int taegetPosition)
        {
            //CSVの初期化
            startProcess.TestStartingBeforeOperation_ElemetsCountIs_7();
            var operationManager = new OperationManager();
            var todoListManager = new TodoListManager();
            var expectedString = todoListManager.ReturnMessageIsSwapTodo();
            var requestString = operationManager.ReceivedNumber8WhenSwapProcess(replacingPosition, taegetPosition);
            Assert.AreEqual(expectedString, requestString);
        }
    }
}
