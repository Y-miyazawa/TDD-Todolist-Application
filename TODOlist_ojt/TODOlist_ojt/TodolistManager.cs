using System;
using System.Collections.Generic;
using System.Linq;

namespace TODOlist_ojt
{
    /// <summary>
    /// TODOリストに対する操作を行うクラス
    /// </summary>
    public class TodoListManager
    {
        CsvManager CM = new CsvManager();
        public List<string> TodoList = new List<string>();

        /// <summary>
        /// CSVデータの内容をリストに取得する
        /// </summary>
        public void LoadCsvFileToTodoList()
        {
            TodoList = CM.WriteCsvFileLoadedIntoCreatedTemporaryList();
            TodoList.RemoveAll(s => s == "");
        }
        /// <summary>
        /// TODOリストの内容の空かどうか判定
        /// </summary>
        public bool IsTodoListContentEmpty(List<string> todoList)
        {
            return !todoList.Any() ? true : false;
        }
        /// <summary>
        /// リストにTODOを追加する
        /// </summary>
        public string AddTodoContentToTodoListProcess(string addTodoContent)
        {
            LoadCsvFileToTodoList();
            TodoList.RemoveAll(s => s == "");
            TodoList.Add(addTodoContent); 
            return CM.WritingProcessToCsvFile(TodoList);
        }

        /// <summary>
        /// 最初のTODOを取得する
        /// </summary>
        public string AcquisitionFirstTodo()
        {
            LoadCsvFileToTodoList();
            if (IsTodoListContentEmpty(TodoList))
                return ReturnMessageIsListEmpty();
            return TodoList[0];
        }
        /// <summary>
        /// 最後のTODOを取得する
        /// </summary>
        public string AcquisitionLastTodo()
        {
            LoadCsvFileToTodoList();
            if (IsTodoListContentEmpty(TodoList))
                return ReturnMessageIsListEmpty();
            return TodoList[TodoList.Count - 1];
        }
        /// <summary>
        /// TodoListを返す
        /// </summary>
        public List<string> ReturnTodoListContent()
        {
            return TodoList;
        }

        /// <summary>
        /// 全てのTODOを出力する処理
        /// </summary>
        public string OutputAllTodo()
        {
            LoadCsvFileToTodoList();
            if (IsTodoListContentEmpty(TodoList))
                return ReturnMessageIsListEmpty();
            ReturnTodoListContent();
            return ReturnMessageIsOutputAllTodo();
        }

        /// <summary>
        /// 最初のTODOを削除する
        /// </summary>
        public string RemoveFirstTodo()
        {
            LoadCsvFileToTodoList();
            if (IsTodoListContentEmpty(TodoList))
                return ReturnMessageIsListEmpty();
            var firstContent = 0;
            TodoList.RemoveAt(firstContent);
            TodoList.RemoveAll(s => s == "");
            CM.WritingProcessToCsvFile(TodoList);
            return ReturnMessageIsRemoveTodo();
        }
        /// <summary>
        /// 最後のTODOを削除する
        /// </summary>
        public string RemoveLastTodo()
        {
            LoadCsvFileToTodoList();
            if (IsTodoListContentEmpty(TodoList))
                return ReturnMessageIsListEmpty();
            var lastContent = TodoList.Count - 1;
            TodoList.RemoveAt(lastContent);
            TodoList.RemoveAll(s => s == "");
            CM.WritingProcessToCsvFile(TodoList);
            return ReturnMessageIsRemoveTodo();
        }
        /// <summary>
        /// 全てのTODOを削除する
        /// </summary>
        public string RemoveAllTodo()
        {
            LoadCsvFileToTodoList();
            if (IsTodoListContentEmpty(TodoList))
                return ReturnMessageIsListEmpty();
            TodoList.Clear();
            CM.WritingProcessToCsvFile(TodoList);
            return ReturnMessageIsRemoveAllTodo();
        }
        /// <summary>
        /// TODOを入れ替える処理
        /// </summary>
        public string SwapTodo(int replacingPosition, int taegetPosition)
        {
            LoadCsvFileToTodoList();
            if (IsTodoListContentEmpty(TodoList))
                return ReturnMessageIsListEmpty();

            if (IsCheckListElementsCountTwoLessThan())
                return ReturnMessageIsTodoListElementsCountIsOne();

            if (IsCheckReplacePosition(replacingPosition) || 
                IsCheckReplacePosition(taegetPosition))
                return ReturnMessageIsNumberRangeOutsideTodo();

            if (IsCheckEqualValueSpecified(replacingPosition, taegetPosition))
                return ReturnMessageIsEqualValueSpecified();

            SwapSelectedTwoTodoOrder(replacingPosition, taegetPosition);
                CM.WritingProcessToCsvFile(TodoList);
                return ReturnMessageIsSwapTodo();
        }
        /// <summary>
        /// TODOリストの要素数が２未満かチェックする
        /// </summary>
        public bool IsCheckListElementsCountTwoLessThan()
        {
            return TodoList.Count < 2 ? true : false;
        }
        /// <summary>
        /// 選択された要素番号がTODOリストの要素数を超えていないかチェックを行う
        /// </summary>
        public bool IsCheckReplacePosition(int checkPosition)
        {
            return checkPosition <= 0 || TodoList.Count < checkPosition ? true : false;
        }
        /// <summary>
        /// 選択された要素番号が同一の値かチェックする
        /// </summary>
        private bool IsCheckEqualValueSpecified(int replacingPosition, int taegetPosition)
        {
            return replacingPosition == taegetPosition ? true : false;
        }
        /// <summary>
        /// 選択された二つのTODOの順番を入れ替える
        /// </summary>
        public void SwapSelectedTwoTodoOrder(int replacing, int taeget)
        {
            var replacingPosition = replacing - 1;
            var taegetPosition = taeget - 1;
            var temporaryTodoList = new List<string>(TodoList);
            TodoList.Clear();
            for(int i=0; i < temporaryTodoList.Count; i++)
            {
                if (i == replacingPosition)
                    TodoList.Add(temporaryTodoList[taegetPosition]);
                if (i == taegetPosition)
                    TodoList.Add(temporaryTodoList[replacingPosition]);
                if(i != taegetPosition && i != replacingPosition)
                    TodoList.Add(temporaryTodoList[i]);
            }
        }
        /// <summary>
        /// リストが空の場合に返すメッセージ
        /// </summary>
        public string ReturnMessageIsListEmpty()
        {
            return "[！] リストにTODOデータが存在しません。";
        }
        /// <summary>
        /// 選択された要素番号が同じだった場合に返すメッセージ
        /// </summary>
        public string ReturnMessageIsEqualValueSpecified()
        {
            return "[！] 入力された二つのTODO番号が同じ値です。";
        }

        /// <summary>
        /// TODOの削除を行った場合に返すメッセージ
        /// </summary>
        public string ReturnMessageIsRemoveTodo()
        {
            return "<< 削除しました >>";
        }
        /// <summary>
        /// TODOの一覧表示を行った場合に返すメッセージ
        /// </summary>
        public string ReturnMessageIsOutputAllTodo()
        {
            return "<< 一覧を表示しました >>";
        }

        /// <summary>
        /// リストのTODOをすべて削除した場合に返すメッセージ
        /// </summary>
        public string ReturnMessageIsRemoveAllTodo()
        {
            return "<< TODOをすべて削除しました >>";
        }
        /// <summary>
        /// TODOを入れ替えた場合に返すメッセージ
        /// </summary>
        public string ReturnMessageIsSwapTodo()
        {
            return "<< TODOを入れ替えました >>";
        }
        /// <summary>
        /// 選択した数値がリストの範囲外だった場合に返すメッセージ
        /// </summary>
        public string ReturnMessageIsNumberRangeOutsideTodo()
        {
            return "[！] 選択した数値がリストの範囲外です。";
        }
        /// <summary>
        /// TODOの要素数が一個だった場合に返すメッセージ
        /// </summary>
        public string ReturnMessageIsTodoListElementsCountIsOne()
        {
            return "[！] TODOが一件しかありません。";
        }
    }
}
