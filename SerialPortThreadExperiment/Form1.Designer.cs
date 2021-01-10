
namespace SerialPortThreadExperiment
{
    partial class Form1
    {
        /// <summary>
        /// 必要なデザイナー変数です。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 使用中のリソースをすべてクリーンアップします。
        /// </summary>
        /// <param name="disposing">マネージド リソースを破棄する場合は true を指定し、その他の場合は false を指定します。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows フォーム デザイナーで生成されたコード

        /// <summary>
        /// デザイナー サポートに必要なメソッドです。このメソッドの内容を
        /// コード エディターで変更しないでください。
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.txtCommNumber = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnCommOpen = new System.Windows.Forms.Button();
            this.btnCommClose = new System.Windows.Forms.Button();
            this.serialPort1 = new System.IO.Ports.SerialPort(this.components);
            this.btnSendCR = new System.Windows.Forms.Button();
            this.lblReceivedText = new System.Windows.Forms.Label();
            this.btnCRAndWaitResponse = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // txtCommNumber
            // 
            this.txtCommNumber.Location = new System.Drawing.Point(48, 6);
            this.txtCommNumber.Name = "txtCommNumber";
            this.txtCommNumber.Size = new System.Drawing.Size(28, 19);
            this.txtCommNumber.TabIndex = 0;
            this.txtCommNumber.Text = "3";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(30, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "COM";
            // 
            // btnCommOpen
            // 
            this.btnCommOpen.Location = new System.Drawing.Point(82, 4);
            this.btnCommOpen.Name = "btnCommOpen";
            this.btnCommOpen.Size = new System.Drawing.Size(75, 23);
            this.btnCommOpen.TabIndex = 2;
            this.btnCommOpen.Text = "OPEN";
            this.btnCommOpen.UseVisualStyleBackColor = true;
            this.btnCommOpen.Click += new System.EventHandler(this.BtnCommOpen_Click);
            // 
            // btnCommClose
            // 
            this.btnCommClose.Enabled = false;
            this.btnCommClose.Location = new System.Drawing.Point(163, 4);
            this.btnCommClose.Name = "btnCommClose";
            this.btnCommClose.Size = new System.Drawing.Size(75, 23);
            this.btnCommClose.TabIndex = 3;
            this.btnCommClose.Text = "CLOSE";
            this.btnCommClose.UseVisualStyleBackColor = true;
            this.btnCommClose.Click += new System.EventHandler(this.BtnCommClose_Click);
            // 
            // serialPort1
            // 
            this.serialPort1.DataReceived += new System.IO.Ports.SerialDataReceivedEventHandler(this.SerialPort1_DataReceived);
            // 
            // btnSendCR
            // 
            this.btnSendCR.Location = new System.Drawing.Point(14, 47);
            this.btnSendCR.Name = "btnSendCR";
            this.btnSendCR.Size = new System.Drawing.Size(224, 23);
            this.btnSendCR.TabIndex = 4;
            this.btnSendCR.Text = "CR送信";
            this.btnSendCR.UseVisualStyleBackColor = true;
            this.btnSendCR.Click += new System.EventHandler(this.BtnSendCR_Click);
            // 
            // lblReceivedText
            // 
            this.lblReceivedText.BackColor = System.Drawing.Color.White;
            this.lblReceivedText.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.lblReceivedText.Location = new System.Drawing.Point(255, 9);
            this.lblReceivedText.Name = "lblReceivedText";
            this.lblReceivedText.Size = new System.Drawing.Size(396, 392);
            this.lblReceivedText.TabIndex = 5;
            // 
            // btnCRAndWaitResponse
            // 
            this.btnCRAndWaitResponse.Location = new System.Drawing.Point(13, 77);
            this.btnCRAndWaitResponse.Name = "btnCRAndWaitResponse";
            this.btnCRAndWaitResponse.Size = new System.Drawing.Size(225, 23);
            this.btnCRAndWaitResponse.TabIndex = 6;
            this.btnCRAndWaitResponse.Text = "CR送信 -> CC待ち";
            this.btnCRAndWaitResponse.UseVisualStyleBackColor = true;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(672, 420);
            this.Controls.Add(this.btnCRAndWaitResponse);
            this.Controls.Add(this.lblReceivedText);
            this.Controls.Add(this.btnSendCR);
            this.Controls.Add(this.btnCommClose);
            this.Controls.Add(this.btnCommOpen);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtCommNumber);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.Form1_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtCommNumber;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnCommOpen;
        private System.Windows.Forms.Button btnCommClose;
        private System.IO.Ports.SerialPort serialPort1;
        private System.Windows.Forms.Button btnSendCR;
        private System.Windows.Forms.Label lblReceivedText;
        private System.Windows.Forms.Button btnCRAndWaitResponse;
    }
}

