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
    class OperationSelect_test
    {
        TnitializingBeforeTest startProcess = new TnitializingBeforeTest();

        [TestCase(-1)]
        [TestCase(-10)]
        [TestCase(10)]
        [TestCase(24)]
        public void 機能の選択時に範囲外の数値を入力するとエラーメッセージが返ってくる(int inputNumber)
        {
            //CSVの初期化
            startProcess.TestStartingBeforeOperation_ElemetsCountIs_7();
            var operationSelect = new OperationSelect();
            var expectionString = operationSelect.ReturnMessageIsNumberOutsideRange();
            var checkedNumber = operationSelect.CheckNumberAvailableRange(inputNumber);
            var returnString = operationSelect.InvokeInputedNumberFixProcess(checkedNumber);
            Assert.AreEqual(expectionString, returnString);
        }
        [TestCase(101)]
        public void 例外番号を受け取ったら例外メッセージを返す(int inputNumber)
        {
            //CSVの初期化
            startProcess.TestStartingBeforeOperation_ElemetsCountIs_7();
            var operationSelect = new OperationSelect();
            var expectionString = operationSelect.ReturnMessageIsExceptionDifferentStringFormat();
            var checkedNumber = operationSelect.CheckUsableNumber(inputNumber);
            var returnString = operationSelect.InvokeInputedNumberFixProcess(checkedNumber);
            Assert.AreEqual(expectionString, returnString);
        }
        [TestCase(0)]
        public void プログラム終了のメッセージを渡すとTrueが返ってくる(int inputNumber)
        {
            //CSVの初期化
            startProcess.TestStartingBeforeOperation_ElemetsCountIs_7();
            var operationSelect = new OperationSelect();
            var checkedNumber = operationSelect.CheckNumberAvailableRange(inputNumber);
            var returnString = operationSelect.InvokeInputedNumberFixProcess(checkedNumber);
            var returnBool = operationSelect.IsCheckEndMessage(returnString);
            Assert.IsTrue(returnBool);
        }
        [TestCase("買い物に行く")]
        [TestCase("会社に行く")]
        [TestCase("掃除をする")]
        public void TODOの追加を行うとTODO追加の完了メッセージが返ってくる(string inpuTodo)
        {
            //CSVの初期化
            startProcess.TestStartingBeforeOperation_ElemetsCountIs_7();
            var csvManager = new CsvManager();
            var operationSelect = new OperationSelect();
            var expectedString = csvManager.ReturnMessageIsAdditionCompleted();
            var returnString = operationSelect.OperationNumber1SelectedInAddProcess(inpuTodo);
            Assert.AreEqual(expectedString, returnString);
        }

        
        [Test]
        public void 最初のTODO表示を選択すると最初のTODOが返ってくる()
        {
            //CSVの初期化
            startProcess.TestStartingBeforeOperation_ElemetsCountIs_7();
            var todoListManager = new TodoListManager();
            var operationSelect = new OperationSelect();
            var expectedString = todoListManager.AcquisitionFirstTodo();
            var returnString = operationSelect.InvokeInputedNumberFixProcess(2);
            Assert.AreEqual(expectedString, returnString);
        }
        [Test]
        public void 最後のTODO表示を選択すると最後のTODOが返ってくる()
        {
            //CSVの初期化
            startProcess.TestStartingBeforeOperation_ElemetsCountIs_7();
            var todoListManager = new TodoListManager();
            var operationSelect = new OperationSelect();
            var expectedString = todoListManager.AcquisitionLastTodo();
            var returnString = operationSelect.InvokeInputedNumberFixProcess(3);
            Assert.AreEqual(expectedString, returnString);

        }
        [Test]
        public void TODO一覧表示を選択するとList型配列が返ってくる()
        {
            //CSVの初期化
            startProcess.TestStartingBeforeOperation_ElemetsCountIs_7();
            var todoListManager = new TodoListManager();
            var operationSelect = new OperationSelect();
            todoListManager.LoadCsvFileToTodoList();
            var expectedList = todoListManager.TodoList;
            var returnList = operationSelect.GetAllTodoList();
            CollectionAssert.AreEqual(expectedList, returnList);
        }
        [Test]
        public void 最初のTODO削除を選択すると完了メッセージが返ってくる()
        {
            //CSVの初期化
            startProcess.TestStartingBeforeOperation_ElemetsCountIs_7();
            var todoListManager = new TodoListManager();
            var operationSelect = new OperationSelect();
            var expectedString = todoListManager.RemoveFirstTodo();
            var returnString = operationSelect.InvokeInputedNumberFixProcess(5);
            Assert.AreEqual(expectedString, returnString);
        }
        [Test]
        public void 最後のTODO削除を選択すると完了メッセージが返ってくる()
        {
            //CSVの初期化
            startProcess.TestStartingBeforeOperation_ElemetsCountIs_7();
            var todoListManager = new TodoListManager();
            var operationSelect = new OperationSelect();
            var expectedString = todoListManager.RemoveLastTodo();
            var returnString = operationSelect.InvokeInputedNumberFixProcess(6);
            Assert.AreEqual(expectedString, returnString);
        }
        [Test]
        public void TODO全削除を選択すると完了メッセージが返ってくる()
        {
            //CSVの初期化
            startProcess.TestStartingBeforeOperation_ElemetsCountIs_7();
            var todoListManager = new TodoListManager();
            var operationSelect = new OperationSelect();
            var expectedString = todoListManager.ReturnMessageIsRemoveAllTodo();
            var returnString = operationSelect.InvokeInputedNumberFixProcess(7);
            Assert.AreEqual(expectedString, returnString);
        }
        [TestCase (1,3)]
        public void TODO入れ替えを選択すると完了メッセージが返ってくる(int replacingPosition, int taegetPosition)
        {
            //CSVの初期化
            startProcess.TestStartingBeforeOperation_ElemetsCountIs_7();
            var todoListManager = new TodoListManager();
            var operationSelect = new OperationSelect();
            var expectedString = todoListManager.ReturnMessageIsSwapTodo();
            var returnString = operationSelect.CheckReturnExceptionMessage(replacingPosition, taegetPosition);
            Assert.AreEqual(expectedString, returnString);
        }

        [Test]
        public void 機能一覧表を呼び出すとリスト配列で返ってくる()
        {
            var operationSelect = new OperationSelect();
            var retunList = operationSelect.ReturnFunctionList();
            CollectionAssert.AllItemsAreNotNull(retunList);
        }
    }
}
