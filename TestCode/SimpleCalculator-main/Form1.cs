using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace SimpleCalculator
{
    public partial class closePastHistoryButton : Form
    {

        bool solveCheck = false;
        public string record = "0";//계산 결과를 히스토리에 넣는 변수
        public string historyRecord = "0";
        public string[] historyArray = new string[5];//히스토리를 담는 배열
        public string[] startArray = new string[5];
        private List<string> historyList;
        private Clac calculator;
        private string filePath;
        private int result;

        //public CalculatorForm()
        public closePastHistoryButton()
        {
            InitializeComponent();
            textInput.Text = record.ToString();
            calculator = new Clac(this);

            // 사용자의 AppData Roaming 폴더 경로 설정
            string desktopFolder = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            string folderPath = Path.Combine(desktopFolder, "jongho");

            // 폴더가 존재하지 않으면 생성
            Directory.CreateDirectory(folderPath);
            // 파일 경로 설정 (예: 사용자이름 폴더 내의 data.txt 파일)
            filePath = Path.Combine(folderPath, "history.txt");

            // historyArray 초기화 
            List<string> startList = calculator.LoadArrayFromFile(filePath);

            

            foreach ( string item in startList)
            {
                pastHistory.Items.Add(item);
                Console.WriteLine("프로그램 시작시 startList의 아이템들 : "+item);
            }

            historyList = new List<string>();

            foreach (string item in historyList)
            {
                pastHistory.Items.Add(item);
                Console.WriteLine("프로그램 시작시 historyList의 아이템들 : " + item);
            }

          
            Form2 f2 = new Form2(startList);
            f2.ShowDialog();

            historyArray = new string[5]; // 길이가 5인 배열로 초기화

            openEveryHistory.Hide();
            

            Console.WriteLine("프로그램이 시작되자마자 historyArray의 길이 : " + historyArray.Length);

            // 종료 시 이벤트 핸들러 설정
            AppDomain.CurrentDomain.ProcessExit += OnProcessExit;
        }

        private bool newButton;   // 새로 숫자가 시작되어야 하는 것을 말하는 flag
        private char myOperator;  // 현재 계산할 Operator
        private void textInput_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 숫자와 백스페이스를 제외한 모든 키 입력을 막음
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar)
                && e.KeyChar != '+' && e.KeyChar != '-' && e.KeyChar != '*' && e.KeyChar != '/' && e.KeyChar != '%')
            {
                e.Handled = true; // 이벤트 처리 여부를 true로 설정하여 입력을 거부
            }
            if (solveCheck == true)
            {
                if (char.IsDigit(e.KeyChar) || (e.KeyChar != '+' && e.KeyChar != '-' && e.KeyChar != '*' && e.KeyChar != '/' && e.KeyChar != '%'))
                {
                    e.Handled = true;
                }
            }
        }
        private void textResult_KeyPress(object sender, KeyPressEventArgs e)
        {
            // 숫자와 백스페이스를 제외한 모든 키 입력을 막음
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // 이벤트 처리 여부를 true로 설정하여 입력을 거부
            }
        }



        public char checkLastChar(string record) // 히스토리 마지막 character 가져오는 메서드
        {
            char lastChar;
            if (record.Length > 0)
            {
                lastChar = record[record.Length - 1];
                Console.WriteLine(lastChar);
                return lastChar;
            }
            lastChar = '0';
            return lastChar;
        }
        // 숫자 버튼 클릭 이벤트
        private void btnNumber_Click(object sender, EventArgs e)
        {
            if (solveCheck == false)
            {
                Button btn = sender as Button;

                if (textInput.Text == "0" || newButton)
                {
                    textInput.Text = btn.Text;
                    newButton = false; // 새로운 숫자 입력이 시작됨을 표시
                }
                else
                {
                    textInput.Text += btn.Text;
                }
                record += btn.Text;
                historyRecord += btn.Text;
                Console.WriteLine("btn 숫자 버튼 클릭 이벤트 : " + btn.Text);
                Console.WriteLine("숫자 버튼 클릭 이후 record 값 : " + record);
            }
            FormatNumber(); // 포맷팅 적용

            btnPlus.Enabled = true;
            btnMinus.Enabled = true;
            btnMultiply.Enabled = true;
            btnDivide.Enabled = true;
            btnMod.Enabled = true;

        }


        // 맨 뒤의 한 글자를 지우기
        private void btnDelete_Click(object sender, EventArgs e)
        {
            textInput.Text = textInput.Text.Remove(textInput.Text.Length - 1);
            if (textInput.Text.Length == 0)
            {
                textInput.Text = "0";
                solveCheck = false;

            }

            if (record.Length == 0)
            {

                btnPlus.Enabled = false;
                btnMinus.Enabled = false;
                btnMultiply.Enabled = false;
                btnDivide.Enabled = false;
                btnMod.Enabled = false;
            }

            record = calculator.deleteLastElement(record);
            Console.WriteLine(record + "record 한글자 지운 결과\r\n");
            historyRecord = calculator.deleteLastElement(historyRecord);
            Console.WriteLine("historyRecord 한글자 지운 결과\r\n");
            Console.WriteLine($"{historyRecord}");
        }

        // 초기화
        private void btnClear_Click(object sender, EventArgs e)
        {
            textInput.Text = "0";// 입력창 초기화
            textResult.Text = ""; // 결과값 초기화
            textProcess.Text = "";// 계산 과정 텍스트 초기화
            record = "0";
            historyRecord = "0";
            solveCheck = false;
            btnPlus.Enabled = true;
            btnMinus.Enabled = true;
            btnMultiply.Enabled = true;
            btnDivide.Enabled = true;
            btnMod.Enabled = true;
        }


        private void btnPlus_Click(object sender, EventArgs e)
        {
            solveCheck = false;
            if (checkLastChar(record) == '+' || checkLastChar(record) == '-' || checkLastChar(record) == '*' || checkLastChar(record) == '/' || checkLastChar(record) == '%')
            {
                textInput.Text = textInput.Text.Remove(textInput.Text.Length - 1);
                textInput.Text += "+";
                StringBuilder sb = new StringBuilder(record);
                sb.Length--;  // 마지막 문자 제거
                sb.Length--;  // 마지막 문자 제거
                record += "@+";
                StringBuilder sb2 = new StringBuilder(historyRecord);
                sb2.Length--;
                historyRecord += "+";
                Console.WriteLine(checkLastChar(record));

            }
            else
            {
                textInput.Text += "+";
                record += "@+";
                historyRecord += "+";
            }


            newButton = true;


        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            solveCheck = false;
            if (checkLastChar(record) == '+' || checkLastChar(record) == '-' || checkLastChar(record) == '*' || checkLastChar(record) == '/' || checkLastChar(record) == '%')
            {
                textInput.Text = textInput.Text.Remove(textInput.Text.Length - 1);
                textInput.Text += "-";
                StringBuilder sb = new StringBuilder(record);
                sb.Length--;  // 마지막 문자 제거
                sb.Length--;  // 마지막 문자 제거
                record += "@-";
                StringBuilder sb2 = new StringBuilder(historyRecord);
                sb2.Length--;
                historyRecord += "-";
                Console.WriteLine(checkLastChar(record));
            }
            else
            {
                textInput.Text += "-";
                record += "@-";
                historyRecord += "-";
            }
            newButton = true;

        }

        private void btnMultiply_Click(object sender, EventArgs e)
        {
            solveCheck = false;
            if (checkLastChar(record) == '+' || checkLastChar(record) == '-' || checkLastChar(record) == '*' || checkLastChar(record) == '/' || checkLastChar(record) == '%')
            {
                textInput.Text = textInput.Text.Remove(textInput.Text.Length - 1);
                textInput.Text += "*";
                StringBuilder sb = new StringBuilder(record);
                sb.Length--;  // 마지막 문자 제거
                sb.Length--;  // 마지막 문자 제거
                record += "@*";
                StringBuilder sb2 = new StringBuilder(historyRecord);
                sb2.Length--;
                historyRecord += "*";
                Console.WriteLine(checkLastChar(record));
            }
            else
            {
                textInput.Text += "*";
                record += "@*";
                historyRecord += "*";
            }
            newButton = true;

        }

        private void btnDivide_Click(object sender, EventArgs e)
        {
            solveCheck = false;
            if (checkLastChar(record) == '+' || checkLastChar(record) == '-' || checkLastChar(record) == '*' || checkLastChar(record) == '/' || checkLastChar(record) == '%')
            {
                textInput.Text = textInput.Text.Remove(textInput.Text.Length - 1);
                textInput.Text += "/";
                StringBuilder sb = new StringBuilder(record);
                sb.Length--;  // 마지막 문자 제거
                sb.Length--;  // 마지막 문자 제거
                record += "@/";
                StringBuilder sb2 = new StringBuilder(historyRecord);
                sb2.Length--;
                historyRecord += "/";
                Console.WriteLine(checkLastChar(record));
            }
            else
            {
                textInput.Text += "/";
                record += "@/";
                historyRecord += "/";
            }
            newButton = true;

        }

        private void btnMod_Click(object sender, EventArgs e)
        {
            solveCheck = false;
            if (checkLastChar(record) == '+' || checkLastChar(record) == '-' || checkLastChar(record) == '*' || checkLastChar(record) == '/' || checkLastChar(record) == '%')
            {
                textInput.Text = textInput.Text.Remove(textInput.Text.Length - 1);
                textInput.Text += "%";
                StringBuilder sb = new StringBuilder(record);
                sb.Length--;  // 마지막 문자 제거
                sb.Length--;  // 마지막 문자 제거
                record += "@%";
                StringBuilder sb2 = new StringBuilder(historyRecord);
                sb2.Length--;
                historyRecord += "%";
                Console.WriteLine(checkLastChar(record));
            }
            else
            {
                textInput.Text += "%";
                record += "@%";
                historyRecord += "%";
            }
            newButton = true;

        }
        // +/- 버튼 : -기호 붙이기/빼기
        private void btnToggleSign_Click(object sender, EventArgs e)

        {
            if (double.TryParse(textInput.Text, out double v))
            {
                v = Double.Parse(textInput.Text);
                textInput.Text = (-v).ToString();
                FormatNumber(); // 포맷팅 적용
                record = calculator.addMinus(record);
                Console.WriteLine("+/- 사용한 뒤의 record 결과" + record);
                historyRecord = calculator.addMinusHistory(historyRecord);
                Console.WriteLine("+/- 사용한 뒤의 historyRecord 결과" + historyRecord);
            }

        }



        // 포맷팅 이벤트 핸들러 추가
        private void InitializeFormatNumberHandlers()
        {
            foreach (var control in this.Controls)
            {
                if (control is Button btn)
                {
                    if (char.IsDigit(btn.Text, 0))
                    {
                        btn.Click += (sender, e) =>
                        {
                            FormatNumber();
                        };
                    }
                    else if (btn.Text == "Delete")
                    {
                        btn.Click += (sender, e) =>
                        {
                            FormatNumber();
                        };
                    }
                    else if (btn.Text == "Clear")
                    {
                        btn.Click += (sender, e) =>
                        {
                            FormatNumber();
                        };
                    }
                }
            }
        }


        // 입력값 숫자 3자리마다 쉼표 구현
        private void FormatNumber()
        {
            if (decimal.TryParse(textInput.Text.Replace(",", ""), out decimal number))
            {
                textInput.Text = string.Format("{0:n0}", number);
            }


        }

        // 결과값 3자리마다 쉼표 삽입   
        private string FormatNumber(double number)
        {
            // 소수점이 없는 경우 정수 형태로 반환, 소수점이 있는 경우 소수점까지 포함하여 반환
            if (number == Math.Floor(number))
            {
                return string.Format("{0:N0}", number); // 소수점이 없는 경우
            }
            else
            {
                return string.Format("{0:N}", number); // 소수점이 있는 경우
            }
        }

        private bool IsDivideByZero(string record)
        {
            // 수식을 연산자 기준으로 분리하여 분할
            string[] parts = record.Split('@');

            // 분할된 각 부분에 대해 검사
            foreach (string part in parts)
            {
                // 나눗셈 연산이 포함되어 있는 경우
                if (part.Contains("/"))
                {
                    // 연산자를 기준으로 분리하여 오른쪽 피연산자가 0인지 확인
                    string[] operands = part.Split('/');
                    if (operands.Length == 2 && operands[1] == "0")
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        private string GetCalculationProcess(string record)
        {
            StringBuilder sb = new StringBuilder();
            bool lastWasOperator = true; // 직전에 처리한 문자가 연산자였는지 여부 (처음에는 연산자로 가정)
            StringBuilder numberBuffer = new StringBuilder(); // 숫자를 임시로 저장하는 버퍼

            for (int i = 0; i < record.Length; i++)
            {
                char c = record[i];
                if (char.IsDigit(c))
                {
                    numberBuffer.Append(c); // 숫자를 버퍼에 추가
                    lastWasOperator = false; // 숫자 추가했으므로 연산자 플래그를 false로 설정
                }
                else if (c == '+' || c == '-' || c == '*' || c == '/' || c == '%')
                {
                    if (numberBuffer.Length > 0)
                    {
                        // 숫자가 버퍼에 있다면, 포맷하고 결과 문자열에 추가
                        sb.Append(FormatNumber(numberBuffer.ToString()));
                        numberBuffer.Clear(); // 버퍼 초기화
                    }
                    sb.Append($" {c} "); // 연산자 추가하고 연산자 양 옆에 공백 추가
                    lastWasOperator = true; // 연산자 추가했으므로 연산자 플래그를 true로 설정
                }
            }

            // 루프가 끝난 후에도 숫자가 버퍼에 남아있다면, 포맷하고 결과 문자열에 추가
            if (numberBuffer.Length > 0)
            {
                sb.Append(FormatNumber(numberBuffer.ToString()));
            }

            return sb.ToString().Trim(); // 문자열의 앞뒤 공백 제거 후 반환
        }

        // 숫자를 3자리마다 쉼표로 포맷하는 메서드
        private string FormatNumber(string number)
        {
            if (decimal.TryParse(number, out decimal parsedNumber))
            {
                return parsedNumber.ToString("N0");
            }
            return number;
        }
        //}


        private void btnEqual_Click(object sender, EventArgs e)
        {
            Console.WriteLine("btnEqual_Click 눌렀을 때 history 배열의 크기" + historyArray.Length);
            // 0으로 나누기를 체크하는 부분 추가
            if (IsDivideByZero(record))
            {
                MessageBox.Show("0으로 나눌 수 없습니다", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            double finalResult = calculator.getResult();
            Console.WriteLine("계산 직후 finalResult 값 : " + finalResult);

            //string stringResult = FormatNumber(finalResult);
            // 정수 부분만 추출하여 문자열로 변환
            string stringResult = ((int)finalResult).ToString();


            // 결과를 textResult에 표시하고 포맷팅
            textResult.Text = FormatNumber(finalResult);
            //this.result = Convert.ToInt32(textResult.Text.Substring(0, textResult.Text.IndexOf('.')));
            //textResult.Text = stringResult;
            this.result = Convert.ToInt32(stringResult);


            // 계산 과정 문자열 준비
            string calculationProcess = GetCalculationProcess(historyRecord);

            // textProcess에 계산 과정 표시
            textProcess.Text = calculationProcess + " = " + textResult.Text;

            Console.WriteLine("finalResult 음수 확인 직전" + finalResult);
            // 계산 완료 후 계산 기록 초기화
            if (finalResult < 0) // 결과값이 음수일 경우
            {
                record = calculator.ReplaceNegativeSign(finalResult);
                Console.WriteLine("음수 추가 후 record : " + record);
            }
            else
            {
                record = finalResult.ToString();
            }

            historyRecord = calculator.zeroCheck(historyRecord) + " = " + textResult.Text;
            historyList.Add(historyRecord);
            Console.WriteLine("=버튼을 눌렀을 때 연산 후 historyRecord에 들어간 값 : "+historyRecord);
            historyArray = calculator.history(historyRecord);
            Console.WriteLine("=버튼을 눌렀을 때 연산 후 historyArray에 들어간 값" + historyArray[0]);
            historyRecord = finalResult.ToString();

            // solveCheck 설정
            solveCheck = true;

        }

        private void btnHistory_Click(object sender, EventArgs e)
        {
            calculator.showHistory(historyArray);

            string message = "";

            // 배열의 모든 요소를 message에 추가합니다.
            foreach (string item in historyArray)
            {
                message += item + Environment.NewLine; // 각 요소를 새 줄에 출력하기 위해 Environment.NewLine 추가
            }

            // 메시지 박스에 출력합니다.
            MessageBox.Show(message, "연산 기록");
        }

        private void OnProcessExit(object sender, EventArgs e)
        {
            foreach (string item in historyList)
            {
                Console.WriteLine("historyList에 있는 값들: " + item);
            }

            if (File.Exists(filePath))
            {
                // 파일이 이미 존재하면 기존 파일에 추가
                File.AppendAllLines(filePath, historyList);
            }
            else
            {
                // 파일이 없으면 새로 생성하여 기록
                File.WriteAllLines(filePath, historyList);
            }

            Console.WriteLine("프로그램이 종료됩니다. historyList가 파일에 저장되었습니다.");
        }

        private void radioButtonBinary_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonBinary.Checked == true)
            {
                textResult.Text = Convert.ToString(this.result, 2);

            }
        }

        private void radioButtonDecimal_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonDecimal.Checked == true)
            {
                textResult.Text = Convert.ToString(this.result);
            }
        }

        private void radioButtonHexadecimal_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonHexadecimal.Checked == true)
            {
                textResult.Text = Convert.ToString(this.result, 16);
            }
        }

        private void button2_Click(object sender, EventArgs e)//everyHistory 닫기 버튼
        {
            pastHistory.Hide();
            button2.Hide();
            openEveryHistory.Show();
        }

        private void openEveryHistory_Click(object sender, EventArgs e)
        {
            pastHistory.Show();
            button2.Show();
            openEveryHistory.Hide();
        }

        private void resetPastHistory_Click(object sender, EventArgs e)//everyhistory 초기화 버튼
        {
            // 파일 초기화
            File.WriteAllText(filePath, string.Empty);

            // 히스토리 리스트와 리스트박스 초기화
            historyList.Clear();

            pastHistory.Items.Clear();

            // 히스토리 배열 초기화
            historyArray = new string[5];

            // 사용자에게 알림
            MessageBox.Show("모든 기록이 초기화되었습니다.", "초기화 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    
    }
}
    
