using System.Windows.Forms;

namespace DiceWinForm
{
    partial class Form1
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">
        /// 관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.
        /// </param>
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.label1 = new System.Windows.Forms.Label();
            this.txtCount = new System.Windows.Forms.TextBox();
            this.btnRoll = new System.Windows.Forms.Button();
            this.listResult = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBoxHistogram = new System.Windows.Forms.PictureBox();
            this.btnRefresh = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHistogram)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "Number of rolls :";
            this.label1.Click += new System.EventHandler(this.label1_Click);
            // 
            // txtCount
            // 
            this.txtCount.Location = new System.Drawing.Point(114, 11);
            this.txtCount.Name = "txtCount";
            this.txtCount.Size = new System.Drawing.Size(100, 21);
            this.txtCount.TabIndex = 1;
            this.txtCount.Text = "1000";
            // 
            // btnRoll
            // 
            this.btnRoll.BackColor = System.Drawing.SystemColors.Info;
            this.btnRoll.Location = new System.Drawing.Point(220, 10);
            this.btnRoll.Name = "btnRoll";
            this.btnRoll.Size = new System.Drawing.Size(72, 23);
            this.btnRoll.TabIndex = 2;
            this.btnRoll.Text = "Roll!";
            this.btnRoll.UseVisualStyleBackColor = false;
            this.btnRoll.Click += new System.EventHandler(this.btnRoll_Click);
            // 
            // listResult
            // 
            this.listResult.BackColor = System.Drawing.SystemColors.Window;
            this.listResult.FormattingEnabled = true;
            this.listResult.ItemHeight = 12;
            this.listResult.Location = new System.Drawing.Point(14, 39);
            this.listResult.Name = "listResult";
            this.listResult.Size = new System.Drawing.Size(344, 160);
            this.listResult.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 202);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(37, 12);
            this.label2.TabIndex = 4;
            this.label2.Text = "graph";
            // 
            // pictureBoxHistogram
            // 
            this.pictureBoxHistogram.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pictureBoxHistogram.Location = new System.Drawing.Point(12, 217);
            this.pictureBoxHistogram.Name = "pictureBoxHistogram";
            this.pictureBoxHistogram.Size = new System.Drawing.Size(344, 153);
            this.pictureBoxHistogram.TabIndex = 5;
            this.pictureBoxHistogram.TabStop = false;
            // 
            // btnRefresh
            // 
            this.btnRefresh.BackColor = System.Drawing.SystemColors.ControlLight;
            this.btnRefresh.Location = new System.Drawing.Point(298, 11);
            this.btnRefresh.Name = "btnRefresh";
            this.btnRefresh.Size = new System.Drawing.Size(60, 23);
            this.btnRefresh.TabIndex = 6;
            this.btnRefresh.Text = "Reset";
            this.btnRefresh.UseVisualStyleBackColor = false;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(366, 381);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.pictureBoxHistogram);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.listResult);
            this.Controls.Add(this.btnRoll);
            this.Controls.Add(this.txtCount);
            this.Controls.Add(this.label1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.Text = "Rolling Dice";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxHistogram)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtCount;
        private System.Windows.Forms.Button btnRoll;
        private System.Windows.Forms.ListBox listResult;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBoxHistogram;
        private System.Windows.Forms.Button btnRefresh;
    }
}
