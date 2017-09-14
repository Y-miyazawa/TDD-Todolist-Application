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
            var csvManager = new CsvManager();
            var showString = "";
            var inputNumber = 0;

            string showText = csvManager.CheckCsvFileCreate();
            consoleManager.ShowMessageIsCreateCsvFile(showText);
            
            while (true)
            {
                var functionList = operationSelect.ReturnFunctionList();
                consoleManager.ShowStringTypeList(functionList);

                var inputNumberText = operationSelect.ReturnMessageIsInputNumber();
                consoleManager.ShowNonbreakingMessage(inputNumberText);

                inputNumber = consoleManager.InputNumberFromConsole();
                inputNumber = operationSelect.CheckNumberAvailableRange(inputNumber);
                
                if (inputNumber == 1)
                {
                    var addTodoText = operationSelect.ReturnMessageIsInputAddTodo();
                    consoleManager.ShowNonbreakingMessage(addTodoText);
                    var inputString = consoleManager.InputStringFromConsole();
                    showString = operationSelect.OperationNumber1SelectedInAddProcess(inputString);
                }
                if (inputNumber == 4)
                {
                    var todoList = operationSelect.GetAllTodoList();
                    consoleManager.ShowAllTodo(todoList);
                }

                if (inputNumber == 8)
                {
                    var todoList = operationSelect.GetAllTodoList();
                    consoleManager.ShowAllTodo(todoList);

                    var displayMessageIsInputSwapNumber1 = operationSelect.ReturnMessageIsInputSwapTodoNumber1();
                    consoleManager.ShowNonbreakingMessage(displayMessageIsInputSwapNumber1);
                    var inputNumber1 = consoleManager.InputNumberFromConsole();

                    var displayMessageIsInputSwapNumber2 = operationSelect.ReturnMessageIsInputSwapTodoNumber2();
                    consoleManager.ShowNonbreakingMessage(displayMessageIsInputSwapNumber2);
                    var inputNumber2 = consoleManager.InputNumberFromConsole();

                    showString = operationSelect.PassingTodoReplacementElement(inputNumber1, inputNumber2);
                }
                if (inputNumber != 1 && inputNumber !=4 && inputNumber != 8)
                {
                    showString = operationSelect.InvokeInputedNumberFixProcess(inputNumber);
                }

                if (showString != null)
                    consoleManager.ShowStringMessage(showString);

                if (operationSelect.IsCheckEndString(showString))
                    break;
                
            }
        }
    }
}
