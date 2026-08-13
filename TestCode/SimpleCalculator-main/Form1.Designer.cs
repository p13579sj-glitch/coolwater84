namespace SimpleCalculator
{
    partial class closePastHistoryButton
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnDelete = new System.Windows.Forms.Button();
            this.btnHistory = new System.Windows.Forms.Button();
            this.btnEqual = new System.Windows.Forms.Button();
            this.btnPlus = new System.Windows.Forms.Button();
            this.btnMinus = new System.Windows.Forms.Button();
            this.btnMultiply = new System.Windows.Forms.Button();
            this.btnDivide = new System.Windows.Forms.Button();
            this.btnMod = new System.Windows.Forms.Button();
            this.btn0 = new System.Windows.Forms.Button();
            this.btn8 = new System.Windows.Forms.Button();
            this.btn9 = new System.Windows.Forms.Button();
            this.btn5 = new System.Windows.Forms.Button();
            this.btn6 = new System.Windows.Forms.Button();
            this.btn3 = new System.Windows.Forms.Button();
            this.btn2 = new System.Windows.Forms.Button();
            this.textResult = new System.Windows.Forms.TextBox();
            this.textInput = new System.Windows.Forms.TextBox();
            this.btnToggleSign = new System.Windows.Forms.Button();
            this.btn7 = new System.Windows.Forms.Button();
            this.btn4 = new System.Windows.Forms.Button();
            this.btn1 = new System.Windows.Forms.Button();
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.textProcess = new System.Windows.Forms.TextBox();
            this.radioButtonHexadecimal = new System.Windows.Forms.RadioButton();
            this.radioButtonDecimal = new System.Windows.Forms.RadioButton();
            this.radioButtonBinary = new System.Windows.Forms.RadioButton();
            this.pastHistory = new System.Windows.Forms.ListBox();
            this.button2 = new System.Windows.Forms.Button();
            this.resetPastHistory = new System.Windows.Forms.Button();
            this.openEveryHistory = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnClear
            // 
            this.btnClear.Font = new System.Drawing.Font("굴림", 12F);
            this.btnClear.Location = new System.Drawing.Point(400, 269);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(91, 82);
            this.btnClear.TabIndex = 39;
            this.btnClear.Text = "C";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnDelete
            // 
            this.btnDelete.Font = new System.Drawing.Font("굴림", 12F);
            this.btnDelete.Location = new System.Drawing.Point(400, 365);
            this.btnDelete.Name = "btnDelete";
            this.btnDelete.Size = new System.Drawing.Size(91, 82);
            this.btnDelete.TabIndex = 38;
            this.btnDelete.Text = "Del";
            this.btnDelete.UseVisualStyleBackColor = true;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
            // 
            // btnHistory
            // 
            this.btnHistory.Font = new System.Drawing.Font("굴림", 12F);
            this.btnHistory.Location = new System.Drawing.Point(400, 465);
            this.btnHistory.Name = "btnHistory";
            this.btnHistory.Size = new System.Drawing.Size(91, 82);
            this.btnHistory.TabIndex = 37;
            this.btnHistory.Text = "History";
            this.btnHistory.UseVisualStyleBackColor = true;
            this.btnHistory.Click += new System.EventHandler(this.btnHistory_Click);
            // 
            // btnEqual
            // 
            this.btnEqual.Font = new System.Drawing.Font("굴림", 12F);
            this.btnEqual.Location = new System.Drawing.Point(400, 555);
            this.btnEqual.Name = "btnEqual";
            this.btnEqual.Size = new System.Drawing.Size(191, 82);
            this.btnEqual.TabIndex = 36;
            this.btnEqual.Text = "=";
            this.btnEqual.UseVisualStyleBackColor = true;
            this.btnEqual.Click += new System.EventHandler(this.btnEqual_Click);
            // 
            // btnPlus
            // 
            this.btnPlus.Font = new System.Drawing.Font("굴림", 12F);
            this.btnPlus.Location = new System.Drawing.Point(303, 269);
            this.btnPlus.Name = "btnPlus";
            this.btnPlus.Size = new System.Drawing.Size(91, 82);
            this.btnPlus.TabIndex = 35;
            this.btnPlus.Text = "+";
            this.btnPlus.UseVisualStyleBackColor = true;
            this.btnPlus.Click += new System.EventHandler(this.btnPlus_Click);
            // 
            // btnMinus
            // 
            this.btnMinus.Font = new System.Drawing.Font("굴림", 12F);
            this.btnMinus.Location = new System.Drawing.Point(303, 365);
            this.btnMinus.Name = "btnMinus";
            this.btnMinus.Size = new System.Drawing.Size(91, 82);
            this.btnMinus.TabIndex = 34;
            this.btnMinus.Text = "-";
            this.btnMinus.UseVisualStyleBackColor = true;
            this.btnMinus.Click += new System.EventHandler(this.btnMinus_Click);
            // 
            // btnMultiply
            // 
            this.btnMultiply.Font = new System.Drawing.Font("굴림", 12F);
            this.btnMultiply.Location = new System.Drawing.Point(303, 463);
            this.btnMultiply.Name = "btnMultiply";
            this.btnMultiply.Size = new System.Drawing.Size(91, 82);
            this.btnMultiply.TabIndex = 33;
            this.btnMultiply.Text = "*";
            this.btnMultiply.UseVisualStyleBackColor = true;
            this.btnMultiply.Click += new System.EventHandler(this.btnMultiply_Click);
            this.btnMultiply.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textInput_KeyPress);
            // 
            // btnDivide
            // 
            this.btnDivide.Font = new System.Drawing.Font("굴림", 12F);
            this.btnDivide.Location = new System.Drawing.Point(303, 555);
            this.btnDivide.Name = "btnDivide";
            this.btnDivide.Size = new System.Drawing.Size(91, 82);
            this.btnDivide.TabIndex = 32;
            this.btnDivide.Text = "/";
            this.btnDivide.UseVisualStyleBackColor = true;
            this.btnDivide.Click += new System.EventHandler(this.btnDivide_Click);
            // 
            // btnMod
            // 
            this.btnMod.Font = new System.Drawing.Font("굴림", 12F);
            this.btnMod.Location = new System.Drawing.Point(206, 269);
            this.btnMod.Name = "btnMod";
            this.btnMod.Size = new System.Drawing.Size(91, 82);
            this.btnMod.TabIndex = 31;
            this.btnMod.Text = "%";
            this.btnMod.UseVisualStyleBackColor = true;
            this.btnMod.Click += new System.EventHandler(this.btnMod_Click);
            // 
            // btn0
            // 
            this.btn0.Font = new System.Drawing.Font("굴림", 12F);
            this.btn0.Location = new System.Drawing.Point(109, 269);
            this.btn0.Name = "btn0";
            this.btn0.Size = new System.Drawing.Size(91, 82);
            this.btn0.TabIndex = 30;
            this.btn0.Text = "0";
            this.btn0.UseVisualStyleBackColor = true;
            this.btn0.Click += new System.EventHandler(this.btnNumber_Click);
            // 
            // btn8
            // 
            this.btn8.Font = new System.Drawing.Font("굴림", 12F);
            this.btn8.Location = new System.Drawing.Point(109, 365);
            this.btn8.Name = "btn8";
            this.btn8.Size = new System.Drawing.Size(91, 82);
            this.btn8.TabIndex = 29;
            this.btn8.Text = "8";
            this.btn8.UseVisualStyleBackColor = true;
            this.btn8.Click += new System.EventHandler(this.btnNumber_Click);
            // 
            // btn9
            // 
            this.btn9.Font = new System.Drawing.Font("굴림", 12F);
            this.btn9.Location = new System.Drawing.Point(206, 365);
            this.btn9.Name = "btn9";
            this.btn9.Size = new System.Drawing.Size(91, 82);
            this.btn9.TabIndex = 28;
            this.btn9.Text = "9";
            this.btn9.UseVisualStyleBackColor = true;
            this.btn9.Click += new System.EventHandler(this.btnNumber_Click);
            // 
            // btn5
            // 
            this.btn5.Font = new System.Drawing.Font("굴림", 12F);
            this.btn5.Location = new System.Drawing.Point(109, 463);
            this.btn5.Name = "btn5";
            this.btn5.Size = new System.Drawing.Size(91, 82);
            this.btn5.TabIndex = 27;
            this.btn5.Text = "5";
            this.btn5.UseVisualStyleBackColor = true;
            this.btn5.Click += new System.EventHandler(this.btnNumber_Click);
            // 
            // btn6
            // 
            this.btn6.Font = new System.Drawing.Font("굴림", 12F);
            this.btn6.Location = new System.Drawing.Point(206, 463);
            this.btn6.Name = "btn6";
            this.btn6.Size = new System.Drawing.Size(91, 82);
            this.btn6.TabIndex = 26;
            this.btn6.Text = "6";
            this.btn6.UseVisualStyleBackColor = true;
            this.btn6.Click += new System.EventHandler(this.btnNumber_Click);
            // 
            // btn3
            // 
            this.btn3.Font = new System.Drawing.Font("굴림", 12F);
            this.btn3.Location = new System.Drawing.Point(206, 555);
            this.btn3.Name = "btn3";
            this.btn3.Size = new System.Drawing.Size(91, 82);
            this.btn3.TabIndex = 25;
            this.btn3.Text = "3";
            this.btn3.UseVisualStyleBackColor = true;
            this.btn3.Click += new System.EventHandler(this.btnNumber_Click);
            // 
            // btn2
            // 
            this.btn2.Font = new System.Drawing.Font("굴림", 12F);
            this.btn2.Location = new System.Drawing.Point(109, 555);
            this.btn2.Name = "btn2";
            this.btn2.Size = new System.Drawing.Size(91, 82);
            this.btn2.TabIndex = 24;
            this.btn2.Text = "2";
            this.btn2.UseVisualStyleBackColor = true;
            this.btn2.Click += new System.EventHandler(this.btnNumber_Click);
            // 
            // textResult
            // 
            this.textResult.Font = new System.Drawing.Font("굴림", 20F);
            this.textResult.Location = new System.Drawing.Point(12, 188);
            this.textResult.Multiline = true;
            this.textResult.Name = "textResult";
            this.textResult.Size = new System.Drawing.Size(579, 75);
            this.textResult.TabIndex = 23;
            this.textResult.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textResult.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textResult_KeyPress);
            // 
            // textInput
            // 
            this.textInput.Font = new System.Drawing.Font("굴림", 20F);
            this.textInput.ImeMode = System.Windows.Forms.ImeMode.Disable;
            this.textInput.Location = new System.Drawing.Point(12, 23);
            this.textInput.Multiline = true;
            this.textInput.Name = "textInput";
            this.textInput.Size = new System.Drawing.Size(579, 82);
            this.textInput.TabIndex = 22;
            this.textInput.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            this.textInput.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textInput_KeyPress);
            // 
            // btnToggleSign
            // 
            this.btnToggleSign.Font = new System.Drawing.Font("굴림", 12F);
            this.btnToggleSign.Location = new System.Drawing.Point(12, 269);
            this.btnToggleSign.Name = "btnToggleSign";
            this.btnToggleSign.Size = new System.Drawing.Size(91, 82);
            this.btnToggleSign.TabIndex = 43;
            this.btnToggleSign.Text = "+/-";
            this.btnToggleSign.UseVisualStyleBackColor = true;
            this.btnToggleSign.Click += new System.EventHandler(this.btnToggleSign_Click);
            // 
            // btn7
            // 
            this.btn7.Font = new System.Drawing.Font("굴림", 12F);
            this.btn7.Location = new System.Drawing.Point(12, 365);
            this.btn7.Name = "btn7";
            this.btn7.Size = new System.Drawing.Size(91, 82);
            this.btn7.TabIndex = 42;
            this.btn7.Text = "7";
            this.btn7.UseVisualStyleBackColor = true;
            this.btn7.Click += new System.EventHandler(this.btnNumber_Click);
            // 
            // btn4
            // 
            this.btn4.Font = new System.Drawing.Font("굴림", 12F);
            this.btn4.Location = new System.Drawing.Point(12, 463);
            this.btn4.Name = "btn4";
            this.btn4.Size = new System.Drawing.Size(91, 82);
            this.btn4.TabIndex = 41;
            this.btn4.Text = "4";
            this.btn4.UseVisualStyleBackColor = true;
            this.btn4.Click += new System.EventHandler(this.btnNumber_Click);
            // 
            // btn1
            // 
            this.btn1.Font = new System.Drawing.Font("굴림", 12F);
            this.btn1.Location = new System.Drawing.Point(12, 555);
            this.btn1.Name = "btn1";
            this.btn1.Size = new System.Drawing.Size(91, 82);
            this.btn1.TabIndex = 40;
            this.btn1.Text = "1";
            this.btn1.UseVisualStyleBackColor = true;
            this.btn1.Click += new System.EventHandler(this.btnNumber_Click);
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(61, 4);
            // 
            // textProcess
            // 
            this.textProcess.BackColor = System.Drawing.SystemColors.ControlLightLight;
            this.textProcess.Font = new System.Drawing.Font("굴림", 20F);
            this.textProcess.Location = new System.Drawing.Point(12, 111);
            this.textProcess.Multiline = true;
            this.textProcess.Name = "textProcess";
            this.textProcess.ReadOnly = true;
            this.textProcess.Size = new System.Drawing.Size(579, 71);
            this.textProcess.TabIndex = 44;
            this.textProcess.TextAlign = System.Windows.Forms.HorizontalAlignment.Right;
            // 
            // radioButtonHexadecimal
            // 
            this.radioButtonHexadecimal.AutoSize = true;
            this.radioButtonHexadecimal.Font = new System.Drawing.Font("굴림", 12F);
            this.radioButtonHexadecimal.Location = new System.Drawing.Point(510, 501);
            this.radioButtonHexadecimal.Name = "radioButtonHexadecimal";
            this.radioButtonHexadecimal.Size = new System.Drawing.Size(92, 24);
            this.radioButtonHexadecimal.TabIndex = 53;
            this.radioButtonHexadecimal.TabStop = true;
            this.radioButtonHexadecimal.Text = "16진수";
            this.radioButtonHexadecimal.UseVisualStyleBackColor = true;
            this.radioButtonHexadecimal.CheckedChanged += new System.EventHandler(this.radioButtonHexadecimal_CheckedChanged);
            // 
            // radioButtonDecimal
            // 
            this.radioButtonDecimal.AutoSize = true;
            this.radioButtonDecimal.Font = new System.Drawing.Font("굴림", 12F);
            this.radioButtonDecimal.Location = new System.Drawing.Point(510, 394);
            this.radioButtonDecimal.Name = "radioButtonDecimal";
            this.radioButtonDecimal.Size = new System.Drawing.Size(92, 24);
            this.radioButtonDecimal.TabIndex = 52;
            this.radioButtonDecimal.TabStop = true;
            this.radioButtonDecimal.Text = "10진수";
            this.radioButtonDecimal.UseVisualStyleBackColor = true;
            this.radioButtonDecimal.CheckedChanged += new System.EventHandler(this.radioButtonDecimal_CheckedChanged);
            // 
            // radioButtonBinary
            // 
            this.radioButtonBinary.AutoSize = true;
            this.radioButtonBinary.Font = new System.Drawing.Font("굴림", 12F);
            this.radioButtonBinary.Location = new System.Drawing.Point(510, 298);
            this.radioButtonBinary.Name = "radioButtonBinary";
            this.radioButtonBinary.Size = new System.Drawing.Size(81, 24);
            this.radioButtonBinary.TabIndex = 51;
            this.radioButtonBinary.TabStop = true;
            this.radioButtonBinary.Text = "2진수";
            this.radioButtonBinary.UseVisualStyleBackColor = true;
            this.radioButtonBinary.CheckedChanged += new System.EventHandler(this.radioButtonBinary_CheckedChanged);
            // 
            // pastHistory
            // 
            this.pastHistory.FormattingEnabled = true;
            this.pastHistory.ItemHeight = 15;
            this.pastHistory.Location = new System.Drawing.Point(608, 27);
            this.pastHistory.Name = "pastHistory";
            this.pastHistory.Size = new System.Drawing.Size(339, 79);
            this.pastHistory.TabIndex = 54;
            // 
            // button2
            // 
            this.button2.BackColor = System.Drawing.Color.White;
            this.button2.Location = new System.Drawing.Point(916, 23);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(31, 31);
            this.button2.TabIndex = 56;
            this.button2.Text = "X";
            this.button2.UseVisualStyleBackColor = false;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // resetPastHistory
            // 
            this.resetPastHistory.Location = new System.Drawing.Point(608, 125);
            this.resetPastHistory.Name = "resetPastHistory";
            this.resetPastHistory.Size = new System.Drawing.Size(103, 37);
            this.resetPastHistory.TabIndex = 57;
            this.resetPastHistory.Text = "초기화";
            this.resetPastHistory.UseVisualStyleBackColor = true;
            this.resetPastHistory.Click += new System.EventHandler(this.resetPastHistory_Click);
            // 
            // openEveryHistory
            // 
            this.openEveryHistory.Location = new System.Drawing.Point(608, 23);
            this.openEveryHistory.Name = "openEveryHistory";
            this.openEveryHistory.Size = new System.Drawing.Size(124, 31);
            this.openEveryHistory.TabIndex = 58;
            this.openEveryHistory.Text = "모든기록보기";
            this.openEveryHistory.UseVisualStyleBackColor = true;
            this.openEveryHistory.Click += new System.EventHandler(this.openEveryHistory_Click);
            // 
            // closePastHistoryButton
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(959, 686);
            this.Controls.Add(this.openEveryHistory);
            this.Controls.Add(this.resetPastHistory);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.pastHistory);
            this.Controls.Add(this.radioButtonHexadecimal);
            this.Controls.Add(this.radioButtonDecimal);
            this.Controls.Add(this.radioButtonBinary);
            this.Controls.Add(this.textProcess);
            this.Controls.Add(this.btnToggleSign);
            this.Controls.Add(this.btn7);
            this.Controls.Add(this.btn4);
            this.Controls.Add(this.btn1);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnHistory);
            this.Controls.Add(this.btnEqual);
            this.Controls.Add(this.btnPlus);
            this.Controls.Add(this.btnMinus);
            this.Controls.Add(this.btnMultiply);
            this.Controls.Add(this.btnDivide);
            this.Controls.Add(this.btnMod);
            this.Controls.Add(this.btn0);
            this.Controls.Add(this.btn8);
            this.Controls.Add(this.btn9);
            this.Controls.Add(this.btn5);
            this.Controls.Add(this.btn6);
            this.Controls.Add(this.btn3);
            this.Controls.Add(this.btn2);
            this.Controls.Add(this.textResult);
            this.Controls.Add(this.textInput);
            this.Name = "closePastHistoryButton";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnDelete;
        private System.Windows.Forms.Button btnHistory;
        private System.Windows.Forms.Button btnEqual;
        private System.Windows.Forms.Button btnPlus;
        private System.Windows.Forms.Button btnMinus;
        private System.Windows.Forms.Button btnMultiply;
        private System.Windows.Forms.Button btnDivide;
        private System.Windows.Forms.Button btnMod;
        private System.Windows.Forms.Button btn0;
        private System.Windows.Forms.Button btn8;
        private System.Windows.Forms.Button btn9;
        private System.Windows.Forms.Button btn5;
        private System.Windows.Forms.Button btn6;
        private System.Windows.Forms.Button btn3;
        private System.Windows.Forms.Button btn2;
        private System.Windows.Forms.TextBox textResult;
        private System.Windows.Forms.TextBox textInput;
        private System.Windows.Forms.Button btnToggleSign;
        private System.Windows.Forms.Button btn7;
        private System.Windows.Forms.Button btn4;
        private System.Windows.Forms.Button btn1;

        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.TextBox textProcess;
        private System.Windows.Forms.RadioButton radioButtonHexadecimal;
        private System.Windows.Forms.RadioButton radioButtonDecimal;
        private System.Windows.Forms.RadioButton radioButtonBinary;
        private System.Windows.Forms.ListBox pastHistory;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button resetPastHistory;
        private System.Windows.Forms.Button openEveryHistory;
    }
}

