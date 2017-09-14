using System;
using System.Collections.Generic;

namespace TODOlist_ojt
{

    public class OperationSelect
    {
        OperationManager operationManager = new OperationManager();
        
        /// <summary>
        /// 受け取った数値が使用可能かチェックする
        /// </summary>
        public int CheckUsableNumber(int inputNumber)
        {
            if (inputNumber != 101)
                inputNumber = CheckNumberAvailableRange(inputNumber);
            return inputNumber;
        }
        /// <summary>
        /// 入力された数値が存在する機能番号と一致するかのチェックを行う
        /// 範囲外なら9を返す
        /// </summary>
        public int CheckNumberAvailableRange(int inputNumber)
        {
            return 0 <= inputNumber && inputNumber <= 8 ? inputNumber : 9;
        }
        /// <summary>
        /// 受け取ったメッセージが終了時のメッセージの場合はTrueを返す
        /// </summary>
        public bool IsCheckEndString(string receivedString)
        {
            var expectedString = ReturnMessageIsProgramEnd();
            return receivedString == expectedString ? true : false;
        }
        /// <summary>
        /// 入力された数値を識別してそれに対応する処理を呼び出す
        /// </summary>
        public string InvokeInputedNumberFixProcess(int operationNumber)
        {
            if (operationNumber == 0)
                return ReturnMessageIsProgramEnd();
            if (operationNumber == 9)
                return ReturnMessageIsNumberOutsideRange();
            if (operationNumber == 10)
                return ReturnNull();
            if (operationNumber == 101)
                return ReturnMessageIsExceptionDifferentStringFormat();

            return operationManager.InvokeProcessFixOperationNumber(operationNumber);
        }

        /// <summary>
        /// 操作番号1が選択された時の処理(TODO追加)
        /// </summary>
        public string OperationNumber1SelectedInAddProcess(string inputTodo)
        {
            return operationManager.ReceivedNumber1WhenAddProcess(inputTodo);
        }

        /// <summary>
        /// TODOリストを取得する
        /// </summary>
        /// <returns></returns>
        public List<string> GetAllTodoList()
        {
            return operationManager.RequestOutputAllTodo();
        }

        /// <summary>
        /// 操作番号8が選択された時の処理（入れ替え番号選択時のTODOリストの表示）
        /// </summary>
        public void OperationNumber8SelectedInOutputProcess()
        {
            operationManager.ReceivedNumber8WhenOutputProcess();
        }
        /// <summary>
        /// TODOリストの入れ替え
        /// </summary>
        public string PassingTodoReplacementElement(int SwapTodoNumber1, int SwapTodoNumber2)
        {
            if (SwapTodoNumber1 == 101)
                return ReturnMessageIsExceptionDifferentStringFormat();
            if (SwapTodoNumber2 == 101)
                return ReturnMessageIsExceptionDifferentStringFormat();
            return operationManager.ReceivedNumber8WhenSwapProcess(SwapTodoNumber1, SwapTodoNumber2);
        }

        public string ReturnMessageIsInputNumber()
        {
            return "操作番号を入力：";
        }

        /// <summary>
        /// 追加するTODOの入力時に返すメッセージ
        /// </summary>
        public string ReturnMessageIsInputAddTodo()
        {
            return "追加するTODOを入力：";
        }
        /// <summary>
        /// 一つ目の入れ替えたいTODO番号入力時に返すメッセージ
        /// </summary>
        public string ReturnMessageIsInputSwapTodoNumber1()
        {
            return "一つ目のTODO番号を入力：";
        }
        /// <summary>
        /// 二つ目の入れ替えたいTODO番号入力時に返すメッセージ
        /// </summary>
        public string ReturnMessageIsInputSwapTodoNumber2()
        {
            return "二つ目のTODO番号を入力：";
        }
        /// <summary>
        /// 入力した数値が範囲外だった場合に返すエラーメッセージ
        /// </summary>
        public string ReturnMessageIsNumberOutsideRange()
        {
            return "[!] 正しい操作番号を入力してください。";
        }
        /// <summary>
        /// 入力した数値が半角数字以外だった場合に返すエラーメッセージ
        /// </summary>
        public string ReturnMessageIsExceptionDifferentStringFormat()
        {
            return "[!] 入力文字列の形式が正しくありません。";
        }
        /// <summary>
        /// プログラムを終了する場合に返すメッセージ
        /// </summary>
        public string ReturnMessageIsProgramEnd()
        {
            return "<< 終了します >>";
        }
        /// <summary>
        /// nullを返す
        /// </summary>
        public string ReturnNull()
        {
            return null;
        }
        /// <summary>
        /// 機能の一覧表をString型のリスト配列で返す
        /// </summary>
        public List<string> ReturnFunctionList()
        {
            var functionList = new List<string>();
            functionList.Add("+-----------------------------------機能一覧-----------------------------------+");
            functionList.Add("| 1：TODOの追加　 　 2：最初に追加したTODOの表示　3：最後に追加したTODOの表示  |");
            functionList.Add("| 4：TODO一覧の表示　5：最初に追加したTODOの削除　6：最後に追加したTODOの削除  |");
            functionList.Add("| 7：TODOの全削除　　8：TODOの入れ替え            0：終了                      |");
            functionList.Add("+------------------------------------------------------------------------------+");
            return functionList;
        }
    }
}