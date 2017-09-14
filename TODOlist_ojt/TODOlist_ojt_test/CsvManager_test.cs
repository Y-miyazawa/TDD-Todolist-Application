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
    class CsvManager_test
    {
        TnitializingBeforeTest startProcess = new TnitializingBeforeTest();

        [TestCase(true)]
        public void CSVファイルの読み込みに成功すると空ではないリストが返ってくる(bool expectedValue)
        {
            //CSVの初期化
            startProcess.TestStartingBeforeOperation_ElemetsCountIs_7();
            var CM = new CsvManager();
            var testlist = new List<string>();
            testlist = CM.LoadingProcessToCsv();
            CollectionAssert.AllItemsAreNotNull(testlist);
        }
        [Test]
        public void CSVファイルの書き込みに成功すると成功メッセージが返ってくる()
        {
            //CSVの初期化
            startProcess.TestStartingBeforeOperation_ElemetsCountIs_7();
            var CM = new CsvManager();
            var expectedString = CM.ReturnMessageIsAdditionCompleted();
            var WriteTodoListTest = new List<string> { "xx", "yy", "zz" };
            var ReturnMessage = CM.WritingProcessToCsvFile(WriteTodoListTest);
            Assert.AreEqual(expectedString, ReturnMessage);
        }
        [Test]
        public void CSVファイルが存在するとNullが返ってくる()
        {
            var csvManager = new CsvManager();
            string expectedString = null;
            var returnMessage = csvManager.CheckCsvFileCreate();
            Assert.AreEqual(expectedString,returnMessage);
        }
        [Test,Explicit]
        public void CSVファイルを新規作成すると作成完了メッセージが返ってくる()
        {
            var csvManager = new CsvManager();
            string expectedString = csvManager.ReturnMessageIsCreateCsvFile();
            var returnMessage = csvManager.CheckCsvFileCreate();
            Assert.AreEqual(expectedString, returnMessage);
        }
    }
}
