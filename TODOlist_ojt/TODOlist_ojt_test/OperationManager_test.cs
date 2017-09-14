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
            var OM = new OperationManager();
            var CM = new CsvManager();
            var expectedString = CM.ReturnMessageIsAdditionCompleted();
            var requestString = OM.ReceivedNumber1WhenAddProcess(addTodoString);
            Assert.AreEqual(expectedString, requestString);
        }

        [TestCase("aaa")]
        public void 最初のTODOを取得すると最初のTODOが返ってくる(string expectedString)
        {
            //CSVの初期化
            startProcess.TestStartingBeforeOperation_ElemetsCountIs_7();
            var OM = new OperationManager();
            var requestString = OM.InvokeProcessFixOperationNumber(2);
            Assert.AreEqual(expectedString, requestString);
        }
        [TestCase("ggg")]
        public void 最後のTODOを取得すると最後のTODOが返ってくる(string expectedString)
        {
            //CSVの初期化
            startProcess.TestStartingBeforeOperation_ElemetsCountIs_7();
            var OM = new OperationManager();
            var requestString = OM.InvokeProcessFixOperationNumber(3);
            Assert.AreEqual(expectedString, requestString);
        }
        [Test]
        public void TODO一覧を取得するとList型配列が返ってくる()
        {
            //CSVの初期化
            startProcess.TestStartingBeforeOperation_ElemetsCountIs_7();
            var OM = new OperationManager();
            var TM = new TodoListManager();
            var expectedList = new List<string>(TM.TodoList);
            var returnList = OM.RequestOutputAllTodo();
            CollectionAssert.AreEqual(expectedList, returnList);
        }
        [Test]
        public void 最初のTODOを削除すると完了メッセージが返ってくる()
        {
            // CSVの初期化
            startProcess.TestStartingBeforeOperation_ElemetsCountIs_7();
            var OM = new OperationManager();
            var TM = new TodoListManager();
            var expectedString = TM.ReturnMessageIsRemoveTodo();
            var requestString = OM.InvokeProcessFixOperationNumber(5);
            Assert.AreEqual(expectedString, requestString);
        }
        [Test]
        public void 最後のTODOを削除すると完了メッセージが返ってくる()
        {
            // CSVの初期化
            startProcess.TestStartingBeforeOperation_ElemetsCountIs_7();
            var OM = new OperationManager();
            var TM = new TodoListManager();
            var expectedString = TM.ReturnMessageIsRemoveTodo();
            var requestString = OM.InvokeProcessFixOperationNumber(6);
            Assert.AreEqual(expectedString, requestString);
        }
        [Test]
        public void TODOを全削除すると完了メッセージが返ってくる()
        {
            //CSVの初期化
            startProcess.TestStartingBeforeOperation_ElemetsCountIs_7();
            var OM = new OperationManager();
            var TM = new TodoListManager();
            var expectedString = TM.ReturnMessageIsRemoveAllTodo();
            var requestString = OM.InvokeProcessFixOperationNumber(7);
            Assert.AreEqual(expectedString, requestString);
        }
        [TestCase(4, 2)]
        public void TODOを入れ替えると完了メッセージが返ってくる(int replacingPosition, int taegetPosition)
        {
            //CSVの初期化
            startProcess.TestStartingBeforeOperation_ElemetsCountIs_7();
            var OM = new OperationManager();
            var TM = new TodoListManager();
            var expectedString = TM.ReturnMessageIsSwapTodo();
            var requestString = OM.ReceivedNumber8WhenSwapProcess(replacingPosition, taegetPosition);
            Assert.AreEqual(expectedString, requestString);
        }
    }
}
