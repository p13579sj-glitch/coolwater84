using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SimpleCalculator
{
    internal class Clac
    {
       
        public Clac(CalculatorForm formInstance) 
        {
            form = formInstance;
        }





        public double getResult() // 계산하는 함수
        {

            bool listEmpty = true;
            List<double> numberList = new List<double>();
            List<string> operationList = new List<string>();
            string recordFrom = form.record;

            recordFrom = "47@+45@*6";

           

                string[] resultArray = recordFrom.Split('@');

                foreach (string result in resultArray)
                {
                    // 숫자와 연산자가 혼합된 경우 처리
                    string tempNumber = "";
                    foreach (char c in result)
                    {
                        if (char.IsDigit(c))
                        {
                            tempNumber += c;
                        }
                        else
                        {
                            // tempNumber가 비어있지 않은 경우 숫자로 변환하여 numberList에 추가
                            if (!string.IsNullOrEmpty(tempNumber))
                            {
                                numberList.Add(double.Parse(tempNumber));
                                tempNumber = ""; // 초기화
                            }
                            // 연산자를 operationList에 추가
                            operationList.Add(c.ToString());
                        }
                    }
                    // 남아있는 숫자가 있는 경우 numberList에 추가
                    if (!string.IsNullOrEmpty(tempNumber))
                    {
                        numberList.Add(double.Parse(tempNumber));
                    }
                }

                // 숫자 리스트 출력
                foreach (double number in numberList)
                {
                    Console.WriteLine(number + "\r\n여기는 숫자 리스트 목록입니다.\r\n");
                }
                while (listEmpty)
                {
                // 연산자 리스트 출력
                for (int i = 0; i < operationList.Count; i++)
                {
                    string operation = operationList[i];
                    Console.WriteLine(operation + "\r\n여기는 연산자 리스트 목록입니다.\r\n");

                    double result = 0;

                    if (operation == "*" || operation == "/" || operation == "%")
                    {

                        switch (operation)
                        {
                            case "*":
                                result = numberList[i] * numberList[i + 1];
                                numberList[i] = result;
                                numberList.RemoveAt(i + 1);
                                operationList.RemoveAt(i);
                                break;
                            case "/":
                                result = numberList[i] / numberList[i + 1];
                                numberList[i] = result;
                                numberList.RemoveAt(i + 1);
                                operationList.RemoveAt(i);
                                break;
                            case "%":
                                result = numberList[i] % numberList[i + 1];
                                numberList[i] = result;
                                numberList.RemoveAt(i + 1);
                                operationList.RemoveAt(i);
                                break;
                            default:
                                Console.WriteLine("*/% 전용 연산 로직 연산 끝");
                                break;
                        }

                       

                    }
                    
                }

                for (int i = 0; i < operationList.Count; i++)
                {

                    string operation = operationList[0];
                    double result = 0;
                    switch (operation)
                    {
                       
                        case "+":
                            result = numberList[0] + numberList[1];
                            numberList[0] = result;
                            numberList.RemoveAt(1);
                            operationList.RemoveAt(0);
                            break;
                        case "-":
                            result = numberList[0] - numberList[1];
                            numberList[0] = result;
                            numberList.RemoveAt(1);
                            operationList.RemoveAt(0);
                            break;
                        default:
                            Console.WriteLine("*/% 전용 연산 로직에 문제가 생김");
                            break;
                    }

                }

                if (operationList.Count == 0)
                {
                    listEmpty = false;
                    
                }

            }//end of while문

            double finalResult = numberList[0];
            Console.WriteLine(finalResult+"이게 최종 연산 결과다!");
            return finalResult;


        }//end of getResult method



    }
}
