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
            var OS = new OperationSelect();
            var expectionString = OS.ReturnMessageIsNumberOutsideRange();
            var checkedNumber = OS.CheckNumberAvailableRange(inputNumber);
            var returnString = OS.InvokeInputedNumberFixProcess(checkedNumber);
            Assert.AreEqual(expectionString, returnString);
        }
        [TestCase(101)]
        public void 例外番号を受け取ったら例外メッセージを返す(int inputNumber)
        {
            //CSVの初期化
            startProcess.TestStartingBeforeOperation_ElemetsCountIs_7();
            var OS = new OperationSelect();
            var expectionString = OS.ReturnMessageIsExceptionDifferentStringFormat();
            var checkedNumber = OS.CheckUsableNumber(inputNumber);
            var returnString = OS.InvokeInputedNumberFixProcess(checkedNumber);
            Assert.AreEqual(expectionString, returnString);
        }
        [TestCase(0)]
        public void プログラム終了のメッセージを渡すとTrueが返ってくる(int inputNumber)
        {
            //CSVの初期化
            startProcess.TestStartingBeforeOperation_ElemetsCountIs_7();
            var OS = new OperationSelect();
            var checkedNumber = OS.CheckNumberAvailableRange(inputNumber);
            var returnString = OS.InvokeInputedNumberFixProcess(checkedNumber);
            var returnBool = OS.IsCheckEndString(returnString);
            Assert.IsTrue(returnBool);
        }
        [TestCase("買い物に行く")]
        [TestCase("会社に行く")]
        [TestCase("掃除をする")]
        public void TODOの追加を行うとTODO追加の完了メッセージが返ってくる(string inpuTodo)
        {
            //CSVの初期化
            startProcess.TestStartingBeforeOperation_ElemetsCountIs_7();
            var CM = new CsvManager();
            var OS = new OperationSelect();
            var expectedString = CM.ReturnMessageIsAdditionCompleted();
            var returnString = OS.OperationNumber1SelectedInAddProcess(inpuTodo);
            Assert.AreEqual(expectedString, returnString);
        }

        
        [Test]
        public void 最初のTODO表示を選択すると最初のTODOが返ってくる()
        {
            //CSVの初期化
            startProcess.TestStartingBeforeOperation_ElemetsCountIs_7();
            var TM = new TodoListManager();
            var OS = new OperationSelect();
            var expectedString = TM.AcquisitionFirstTodo();
            var returnString = OS.InvokeInputedNumberFixProcess(2);
            Assert.AreEqual(expectedString, returnString);
        }
        [Test]
        public void 最後のTODO表示を選択すると最後のTODOが返ってくる()
        {
            //CSVの初期化
            startProcess.TestStartingBeforeOperation_ElemetsCountIs_7();
            var TM = new TodoListManager();
            var OS = new OperationSelect();
            var expectedString = TM.AcquisitionLastTodo();
            var returnString = OS.InvokeInputedNumberFixProcess(3);
            Assert.AreEqual(expectedString, returnString);

        }
        [Test]
        public void TODO一覧表示を選択すると完了メッセージが返ってくる()
        {
            //CSVの初期化
            startProcess.TestStartingBeforeOperation_ElemetsCountIs_7();
            var TM = new TodoListManager();
            var OS = new OperationSelect();
            var expectedString = TM.OutputAllTodo();
            var returnString = OS.InvokeInputedNumberFixProcess(4);
            Assert.AreEqual(expectedString, returnString);
        }
        [Test]
        public void 最初のTODO削除を選択すると完了メッセージが返ってくる()
        {
            //CSVの初期化
            startProcess.TestStartingBeforeOperation_ElemetsCountIs_7();
            var TM = new TodoListManager();
            var OS = new OperationSelect();
            var expectedString = TM.RemoveFirstTodo();
            var returnString = OS.InvokeInputedNumberFixProcess(5);
            Assert.AreEqual(expectedString, returnString);
        }
        [Test]
        public void 最後のTODO削除を選択すると完了メッセージが返ってくる()
        {
            //CSVの初期化
            startProcess.TestStartingBeforeOperation_ElemetsCountIs_7();
            var TM = new TodoListManager();
            var OS = new OperationSelect();
            var expectedString = TM.RemoveLastTodo();
            var returnString = OS.InvokeInputedNumberFixProcess(6);
            Assert.AreEqual(expectedString, returnString);
        }
        [Test]
        public void TODO全削除を選択すると完了メッセージが返ってくる()
        {
            //CSVの初期化
            startProcess.TestStartingBeforeOperation_ElemetsCountIs_7();
            var TM = new TodoListManager();
            var OS = new OperationSelect();
            var expectedString = TM.ReturnMessageIsRemoveAllTodo();
            var returnString = OS.InvokeInputedNumberFixProcess(7);
            Assert.AreEqual(expectedString, returnString);
        }
        [TestCase (1,3)]
        public void TODO入れ替えを選択すると完了メッセージが返ってくる(int replacingPosition, int taegetPosition)
        {
            //CSVの初期化
            startProcess.TestStartingBeforeOperation_ElemetsCountIs_7();
            var TM = new TodoListManager();
            var OS = new OperationSelect();
            var expectedString = TM.ReturnMessageIsSwapTodo();
            var returnString = OS.PassingTodoReplacementElement(replacingPosition, taegetPosition);
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
