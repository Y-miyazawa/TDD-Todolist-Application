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
            var showMessage = "";
            var inputNumber = 0;

            string csvCreateMessage = csvManager.CheckCsvFileCreate();  
            if(csvCreateMessage != null)
                consoleManager.ShowStringMessage(csvCreateMessage);

            while (true)
            {
                var functionDisplayList = operationSelect.ReturnFunctionList();
                consoleManager.ShowStringTypeList(functionDisplayList);

                var numberInputDisplayText = operationSelect.ReturnMessageIsInputNumber();
                consoleManager.ShowNonbreakingMessage(numberInputDisplayText);

                inputNumber = consoleManager.InputNumberFromConsole();
                inputNumber = operationSelect.CheckUsableNumber(inputNumber);
                
                if (inputNumber == 1)
                {
                    var addTodoDisplayText = operationSelect.ReturnMessageIsInputAddTodo();
                    consoleManager.ShowNonbreakingMessage(addTodoDisplayText);
                    var inputTodoString = consoleManager.InputStringFromConsole();
                    showMessage = operationSelect.OperationNumber1SelectedInAddProcess(inputTodoString);
                }
                if (inputNumber == 4)
                {
                    var displayTodoList = operationSelect.GetAllTodoList();
                    consoleManager.ShowAllTodo(displayTodoList);
                }

                if (inputNumber == 8)
                {
                    var displayTodoList = operationSelect.GetAllTodoList();
                    consoleManager.ShowAllTodo(displayTodoList);

                    var iputSwapNumber1DisplayMessage = operationSelect.ReturnMessageIsInputSwapTodoNumber1();
                    consoleManager.ShowNonbreakingMessage(iputSwapNumber1DisplayMessage);
                    var inputNumber1 = consoleManager.InputNumberFromConsole();

                    var inputSwapNumber2DisplayMessage = operationSelect.ReturnMessageIsInputSwapTodoNumber2();
                    consoleManager.ShowNonbreakingMessage(inputSwapNumber2DisplayMessage);
                    var inputNumber2 = consoleManager.InputNumberFromConsole();

                    showMessage = operationSelect.CheckReturnExceptionMessage(inputNumber1, inputNumber2);
                }
                if (inputNumber != 1 && inputNumber !=4 && inputNumber != 8)
                {
                    showMessage = operationSelect.InvokeInputedNumberFixProcess(inputNumber);
                }

                if (showMessage != null)
                    consoleManager.ShowStringMessage(showMessage);

                if (operationSelect.IsCheckEndMessage(showMessage))
                    break;
                
            }
        }
    }
}
