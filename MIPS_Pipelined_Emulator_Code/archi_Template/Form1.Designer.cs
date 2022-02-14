namespace archi_Template
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
               this.runCycleBtn = new System.Windows.Forms.Button();
               this.StartPCTxt = new System.Windows.Forms.TextBox();
               this.label5 = new System.Windows.Forms.Label();
               this.inializeBtn = new System.Windows.Forms.Button();
               this.label3 = new System.Windows.Forms.Label();
               this.label2 = new System.Windows.Forms.Label();
               this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
               this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
               this.PiplineGrid = new System.Windows.Forms.DataGridView();
               this.valueCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
               this.registerCol = new System.Windows.Forms.DataGridViewTextBoxColumn();
               this.label1 = new System.Windows.Forms.Label();
               this.MipsRegisterGrid = new System.Windows.Forms.DataGridView();
               this.UserCodetxt = new System.Windows.Forms.TextBox();
               ((System.ComponentModel.ISupportInitialize)(this.PiplineGrid)).BeginInit();
               ((System.ComponentModel.ISupportInitialize)(this.MipsRegisterGrid)).BeginInit();
               this.SuspendLayout();
               // 
               // runCycleBtn
               // 
               this.runCycleBtn.Font = new System.Drawing.Font("Book Antiqua", 10F, System.Drawing.FontStyle.Bold);
               this.runCycleBtn.Location = new System.Drawing.Point(608, 679);
               this.runCycleBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
               this.runCycleBtn.Name = "runCycleBtn";
               this.runCycleBtn.Size = new System.Drawing.Size(218, 64);
               this.runCycleBtn.TabIndex = 23;
               this.runCycleBtn.Text = "Run 1 Cycle";
               this.runCycleBtn.UseVisualStyleBackColor = true;
               this.runCycleBtn.Click += new System.EventHandler(this.runCycleBtn_Click);
               // 
               // StartPCTxt
               // 
               this.StartPCTxt.Location = new System.Drawing.Point(83, 700);
               this.StartPCTxt.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
               this.StartPCTxt.Name = "StartPCTxt";
               this.StartPCTxt.Size = new System.Drawing.Size(171, 26);
               this.StartPCTxt.TabIndex = 21;
               this.StartPCTxt.Text = "1000";
               // 
               // label5
               // 
               this.label5.AutoSize = true;
               this.label5.Font = new System.Drawing.Font("Book Antiqua", 10F, System.Drawing.FontStyle.Bold);
               this.label5.Location = new System.Drawing.Point(33, 699);
               this.label5.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
               this.label5.Name = "label5";
               this.label5.Size = new System.Drawing.Size(36, 24);
               this.label5.TabIndex = 20;
               this.label5.Text = "PC";
               // 
               // inializeBtn
               // 
               this.inializeBtn.Font = new System.Drawing.Font("Book Antiqua", 10F, System.Drawing.FontStyle.Bold);
               this.inializeBtn.Location = new System.Drawing.Point(325, 679);
               this.inializeBtn.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
               this.inializeBtn.Name = "inializeBtn";
               this.inializeBtn.Size = new System.Drawing.Size(163, 64);
               this.inializeBtn.TabIndex = 22;
               this.inializeBtn.Text = "Initialize ";
               this.inializeBtn.UseVisualStyleBackColor = true;
               this.inializeBtn.Click += new System.EventHandler(this.inializeBtn_Click);
               // 
               // label3
               // 
               this.label3.AutoSize = true;
               this.label3.Font = new System.Drawing.Font("Book Antiqua", 11F, System.Drawing.FontStyle.Bold);
               this.label3.Location = new System.Drawing.Point(950, 52);
               this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
               this.label3.Name = "label3";
               this.label3.Size = new System.Drawing.Size(182, 27);
               this.label3.TabIndex = 17;
               this.label3.Text = "Pipline Registers";
               // 
               // label2
               // 
               this.label2.AutoSize = true;
               this.label2.Font = new System.Drawing.Font("Book Antiqua", 11F, System.Drawing.FontStyle.Bold);
               this.label2.Location = new System.Drawing.Point(522, 52);
               this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
               this.label2.Name = "label2";
               this.label2.Size = new System.Drawing.Size(168, 27);
               this.label2.TabIndex = 16;
               this.label2.Text = "MIPS Registers";
               // 
               // dataGridViewTextBoxColumn2
               // 
               this.dataGridViewTextBoxColumn2.HeaderText = "Value";
               this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
               this.dataGridViewTextBoxColumn2.ReadOnly = true;
               // 
               // dataGridViewTextBoxColumn1
               // 
               this.dataGridViewTextBoxColumn1.HeaderText = "Register";
               this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
               this.dataGridViewTextBoxColumn1.ReadOnly = true;
               // 
               // PiplineGrid
               // 
               this.PiplineGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
               this.PiplineGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2});
               this.PiplineGrid.Location = new System.Drawing.Point(955, 85);
               this.PiplineGrid.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
               this.PiplineGrid.Name = "PiplineGrid";
               this.PiplineGrid.ReadOnly = true;
               this.PiplineGrid.Size = new System.Drawing.Size(416, 572);
               this.PiplineGrid.TabIndex = 14;
               // 
               // valueCol
               // 
               this.valueCol.HeaderText = "Value";
               this.valueCol.Name = "valueCol";
               this.valueCol.ReadOnly = true;
               // 
               // registerCol
               // 
               this.registerCol.HeaderText = "Register";
               this.registerCol.Name = "registerCol";
               this.registerCol.ReadOnly = true;
               // 
               // label1
               // 
               this.label1.AutoSize = true;
               this.label1.Font = new System.Drawing.Font("Book Antiqua", 11F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
               this.label1.Location = new System.Drawing.Point(16, 52);
               this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
               this.label1.Name = "label1";
               this.label1.Size = new System.Drawing.Size(117, 27);
               this.label1.TabIndex = 15;
               this.label1.Text = "User Code";
               // 
               // MipsRegisterGrid
               // 
               this.MipsRegisterGrid.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
               this.MipsRegisterGrid.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.registerCol,
            this.valueCol});
               this.MipsRegisterGrid.Location = new System.Drawing.Point(527, 85);
               this.MipsRegisterGrid.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
               this.MipsRegisterGrid.Name = "MipsRegisterGrid";
               this.MipsRegisterGrid.ReadOnly = true;
               this.MipsRegisterGrid.Size = new System.Drawing.Size(372, 572);
               this.MipsRegisterGrid.TabIndex = 13;
               // 
               // UserCodetxt
               // 
               this.UserCodetxt.Location = new System.Drawing.Point(21, 85);
               this.UserCodetxt.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
               this.UserCodetxt.Multiline = true;
               this.UserCodetxt.Name = "UserCodetxt";
               this.UserCodetxt.Size = new System.Drawing.Size(457, 572);
               this.UserCodetxt.TabIndex = 12;
               // 
               // Form1
               // 
               this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
               this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
               this.ClientSize = new System.Drawing.Size(1397, 808);
               this.Controls.Add(this.runCycleBtn);
               this.Controls.Add(this.StartPCTxt);
               this.Controls.Add(this.label5);
               this.Controls.Add(this.inializeBtn);
               this.Controls.Add(this.label3);
               this.Controls.Add(this.label2);
               this.Controls.Add(this.PiplineGrid);
               this.Controls.Add(this.label1);
               this.Controls.Add(this.MipsRegisterGrid);
               this.Controls.Add(this.UserCodetxt);
               this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
               this.Name = "Form1";
               this.Text = "MIPS Emulator";
               ((System.ComponentModel.ISupportInitialize)(this.PiplineGrid)).EndInit();
               ((System.ComponentModel.ISupportInitialize)(this.MipsRegisterGrid)).EndInit();
               this.ResumeLayout(false);
               this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button runCycleBtn;
        private System.Windows.Forms.TextBox StartPCTxt;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Button inializeBtn;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridView PiplineGrid;
        private System.Windows.Forms.DataGridViewTextBoxColumn valueCol;
        private System.Windows.Forms.DataGridViewTextBoxColumn registerCol;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridView MipsRegisterGrid;
        private System.Windows.Forms.TextBox UserCodetxt;
    }
}

