using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TODOlist_ojt
{
    public class ConsoleManager
    {
        /// <summary>
        /// コンソールからint型数値の入力
        /// 例外時は101を返す
        /// </summary>
        public int InputNumberFromConsole()
        {
            try
            {
                var inputNumber = int.Parse(Console.ReadLine());
                return inputNumber;
            }
            catch
            {
                return 101;
            }
        }
        /// <summary>
        /// コンソールからString型文字列の入力を行う
        /// </summary>
        public string InputStringFromConsole()
        {
            var inputString = Console.ReadLine();
            return inputString;
        }

        /// <summary>
        /// 受け取ったString型文字列を出力する
        /// </summary>
        public void ShowStringMessage(string showText)
        {
            Console.WriteLine(showText);
        }

        /// <summary>
        /// 受け取ったString型のリスト配列を出力する
        /// </summary>
        public void ShowStringTypeList(List<string> list)
        {
            
        }

    }
}
