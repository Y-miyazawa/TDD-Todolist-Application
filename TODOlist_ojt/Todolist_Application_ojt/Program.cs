using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TODOlist_ojt;

namespace Todolist_Application_ojt
{
    public class Program
    {

        static void Main(string[] args)
        {
            var operationSelect = new OperationSelect();
            var consoleManager = new ConsoleManager();
            var ShowString = "";
            var inputNumber = 0;

            while (true)
            {
                operationSelect.ShowFunctionList();
                inputNumber = consoleManager.InputNumberFromConsole();
                inputNumber = operationSelect.CheckNumberAvailableRange(inputNumber);

                if (inputNumber == 1)
                {
                    operationSelect.ShowMessageIsInputAddTodo();
                    var inputString = consoleManager.InputStringFromConsole();
                    ShowString = operationSelect.OperationNumber1SelectedInAddProcess(inputString);
                }
                if (inputNumber == 8)
                {
                    operationSelect.OperationNumber8SelectedInOutputProcess();
                    operationSelect.ShowMessageIsInputSwapTodoNumber1();
                    var inputNumber1 = consoleManager.InputNumberFromConsole();
                    operationSelect.ShowMessageIsInputSwapTodoNumber2();
                    var inputNumber2 = consoleManager.InputNumberFromConsole();
                    ShowString = operationSelect.PassingTodoReplacementElement(inputNumber1, inputNumber2);
                }
                if (inputNumber != 1 && inputNumber != 8)
                {
                    ShowString = operationSelect.InvokeInputedNumberFixProcess(inputNumber);
                }

                operationSelect.ShowReturnMessage(ShowString);

                if (operationSelect.IsCheckEndString(ShowString))
                    break;
                
            }
        }



    }
}
