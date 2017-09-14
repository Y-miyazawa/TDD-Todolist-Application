using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODOlist_ojt
{
    /// <summary>
    /// 値を受け取り、その値に対応する処理を呼び出すクラス
    /// </summary>
    public class OperationManager
    {
        TodoListManager todolistManager = new TodoListManager();

        /// <summary>
        /// 入力した数値に応じた処理を呼び出す(２～７の場合)
        /// </summary>
        public string InvokeProcessFixOperationNumber(int operationNumber)
        {
            if (operationNumber == 2)
                return RequestOutputFirstTodo();
            if (operationNumber == 3)
                return RequestOutputLastTodo();
            if (operationNumber == 5)
                return RequestRemoveFirstTodo();
            if (operationNumber == 6)
                return RequestRemoveLastTodo();
            if (operationNumber == 7)
                return RequestRemoveAllTodo();
            return null;
       }
        /// <summary>
        /// 受け取った数値が１の場合の処理（TODOの追加）
        /// </summary>
        public string ReceivedNumber1WhenAddProcess(string addTodoString)
        {
            return RequestAddTodo(addTodoString);
        }
        /// <summary>
        /// 受け取った数値が８の場合、TODOの一覧を表示する
        /// </summary>
        public void ReceivedNumber8WhenOutputProcess()
        {
            todolistManager.ReturnTodoListContent();
        }
        /// <summary>
        /// 受け取った数値が８の場合の処理（TODOの入れ替え）
        /// </summary>
        public string ReceivedNumber8WhenSwapProcess(int replacingPosition, int targetPosition)
        {
            return RequestSwapTwoTodo(replacingPosition, targetPosition);
        }
        /// <summary>
        /// TODO追加の処理を呼び出す
        /// </summary>
        public string RequestAddTodo(string addTodoString)
        {
            return todolistManager.AddTodoContentToTodoListProcess(addTodoString);
        }
        /// <summary>
        /// 最初に追加したTODOの取得処理を呼び出す
        /// </summary>
        public string RequestOutputFirstTodo()
        {
            return todolistManager.AcquisitionFirstTodo();
        }
        /// <summary>
        /// 最後に追加したTODOの取得処理を呼び出す
        /// </summary>
        public string RequestOutputLastTodo()
        {
            return todolistManager.AcquisitionLastTodo();
        }
        /// <summary>
        /// 全てのTODOの取得処理を呼び出す
        /// </summary>
        public List<string> RequestOutputAllTodo()
        {
            return todolistManager.ReturnTodoListContent();
        }
        /// <summary>
        /// 最初のTODOの削除処理を呼び出す
        /// </summary>
        public string RequestRemoveFirstTodo()
        {
            return todolistManager.RemoveFirstTodo();
        }
        /// <summary>
        /// 最後のTODOの削除処理を呼び出す
        /// </summary>
        public string RequestRemoveLastTodo()
        {
            return todolistManager.RemoveLastTodo();
        }
        /// <summary>
        /// 全てのTODOの削除処理を呼び出す
        /// </summary>
        public string RequestRemoveAllTodo()
        {
            return todolistManager.RemoveAllTodo();
        }
        /// <summary>
        /// TODOの入れ替え処理を呼び出す
        /// </summary>
        public string RequestSwapTwoTodo(int replacingPosition, int targetPosition)
        {
            return todolistManager.SwapTodo(replacingPosition, targetPosition);
        }
    }
}
