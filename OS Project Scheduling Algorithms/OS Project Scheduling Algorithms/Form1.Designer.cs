
namespace OS_Project_Scheduling_Algorithms
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
            this.SCHEDULING_ALGORITHMS = new System.Windows.Forms.Label();
            this.Enter_Number_of_Processes_You_Want_To_Have = new System.Windows.Forms.Label();
            this.Number_of_Processes_TextBox = new System.Windows.Forms.TextBox();
            this.Enter_Button = new System.Windows.Forms.Button();
            this.EmptyTable = new System.Windows.Forms.DataGridView();
            this.Reset_Button = new System.Windows.Forms.Button();
            this.Close_Button = new System.Windows.Forms.Button();
            this.Compute_Button = new System.Windows.Forms.Button();
            this.Enter_Scheduling_Algorithim_you_want_to_have_label = new System.Windows.Forms.Label();
            this.AlgorithmSelector_ComboBox = new System.Windows.Forms.ComboBox();
            this.Enter_Quantum_Time_Slice_label = new System.Windows.Forms.Label();
            this.Time_Slice_Textbox = new System.Windows.Forms.TextBox();
            ((System.ComponentModel.ISupportInitialize)(this.EmptyTable)).BeginInit();
            this.SuspendLayout();
            // 
            // SCHEDULING_ALGORITHMS
            // 
            this.SCHEDULING_ALGORITHMS.AutoSize = true;
            this.SCHEDULING_ALGORITHMS.Font = new System.Drawing.Font("Times New Roman", 22.2F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.SCHEDULING_ALGORITHMS.Location = new System.Drawing.Point(224, 9);
            this.SCHEDULING_ALGORITHMS.Name = "SCHEDULING_ALGORITHMS";
            this.SCHEDULING_ALGORITHMS.Size = new System.Drawing.Size(526, 44);
            this.SCHEDULING_ALGORITHMS.TabIndex = 0;
            this.SCHEDULING_ALGORITHMS.Text = "SCHEDULING ALGORITHMS";
            // 
            // Enter_Number_of_Processes_You_Want_To_Have
            // 
            this.Enter_Number_of_Processes_You_Want_To_Have.AutoSize = true;
            this.Enter_Number_of_Processes_You_Want_To_Have.Font = new System.Drawing.Font("Times New Roman", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Enter_Number_of_Processes_You_Want_To_Have.Location = new System.Drawing.Point(38, 80);
            this.Enter_Number_of_Processes_You_Want_To_Have.Name = "Enter_Number_of_Processes_You_Want_To_Have";
            this.Enter_Number_of_Processes_You_Want_To_Have.Size = new System.Drawing.Size(604, 34);
            this.Enter_Number_of_Processes_You_Want_To_Have.TabIndex = 1;
            this.Enter_Number_of_Processes_You_Want_To_Have.Text = "Enter Number of Processes You Want To Have:";
            // 
            // Number_of_Processes_TextBox
            // 
            this.Number_of_Processes_TextBox.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Number_of_Processes_TextBox.Location = new System.Drawing.Point(679, 81);
            this.Number_of_Processes_TextBox.Multiline = true;
            this.Number_of_Processes_TextBox.Name = "Number_of_Processes_TextBox";
            this.Number_of_Processes_TextBox.Size = new System.Drawing.Size(294, 33);
            this.Number_of_Processes_TextBox.TabIndex = 2;
            // 
            // Enter_Button
            // 
            this.Enter_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Enter_Button.Location = new System.Drawing.Point(464, 117);
            this.Enter_Button.Name = "Enter_Button";
            this.Enter_Button.Size = new System.Drawing.Size(99, 47);
            this.Enter_Button.TabIndex = 3;
            this.Enter_Button.Text = "Enter";
            this.Enter_Button.UseVisualStyleBackColor = true;
            this.Enter_Button.Click += new System.EventHandler(this.Enter_Button_Click);
            // 
            // EmptyTable
            // 
            this.EmptyTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.EmptyTable.Location = new System.Drawing.Point(44, 218);
            this.EmptyTable.Name = "EmptyTable";
            this.EmptyTable.RowHeadersWidth = 51;
            this.EmptyTable.RowTemplate.Height = 24;
            this.EmptyTable.Size = new System.Drawing.Size(907, 286);
            this.EmptyTable.TabIndex = 4;
            this.EmptyTable.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.EmptyTable_CellContentClick);
            // 
            // Reset_Button
            // 
            this.Reset_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Reset_Button.Location = new System.Drawing.Point(582, 571);
            this.Reset_Button.Name = "Reset_Button";
            this.Reset_Button.Size = new System.Drawing.Size(99, 47);
            this.Reset_Button.TabIndex = 5;
            this.Reset_Button.Text = "Reset";
            this.Reset_Button.UseVisualStyleBackColor = true;
            this.Reset_Button.Click += new System.EventHandler(this.Reset_Button_Click);
            // 
            // Close_Button
            // 
            this.Close_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Close_Button.Location = new System.Drawing.Point(426, 624);
            this.Close_Button.Name = "Close_Button";
            this.Close_Button.Size = new System.Drawing.Size(99, 47);
            this.Close_Button.TabIndex = 6;
            this.Close_Button.Text = "Close";
            this.Close_Button.UseVisualStyleBackColor = true;
            this.Close_Button.Click += new System.EventHandler(this.Close_Button_Click);
            // 
            // Compute_Button
            // 
            this.Compute_Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Compute_Button.Location = new System.Drawing.Point(269, 571);
            this.Compute_Button.Name = "Compute_Button";
            this.Compute_Button.Size = new System.Drawing.Size(99, 47);
            this.Compute_Button.TabIndex = 7;
            this.Compute_Button.Text = "Compute";
            this.Compute_Button.UseVisualStyleBackColor = true;
            this.Compute_Button.Click += new System.EventHandler(this.Compute_Button_Click);
            // 
            // Enter_Scheduling_Algorithim_you_want_to_have_label
            // 
            this.Enter_Scheduling_Algorithim_you_want_to_have_label.AutoSize = true;
            this.Enter_Scheduling_Algorithim_you_want_to_have_label.Font = new System.Drawing.Font("Times New Roman", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Enter_Scheduling_Algorithim_you_want_to_have_label.Location = new System.Drawing.Point(64, 181);
            this.Enter_Scheduling_Algorithim_you_want_to_have_label.Name = "Enter_Scheduling_Algorithim_you_want_to_have_label";
            this.Enter_Scheduling_Algorithim_you_want_to_have_label.Size = new System.Drawing.Size(603, 34);
            this.Enter_Scheduling_Algorithim_you_want_to_have_label.TabIndex = 8;
            this.Enter_Scheduling_Algorithim_you_want_to_have_label.Text = "Enter Scheduling Algorithim you want to have:";
            // 
            // AlgorithmSelector_ComboBox
            // 
            this.AlgorithmSelector_ComboBox.FormattingEnabled = true;
            this.AlgorithmSelector_ComboBox.Items.AddRange(new object[] {
            "FCFS",
            "SJF",
            "Round-Robin",
            "Priority"});
            this.AlgorithmSelector_ComboBox.Location = new System.Drawing.Point(709, 186);
            this.AlgorithmSelector_ComboBox.Name = "AlgorithmSelector_ComboBox";
            this.AlgorithmSelector_ComboBox.Size = new System.Drawing.Size(238, 24);
            this.AlgorithmSelector_ComboBox.TabIndex = 9;
            this.AlgorithmSelector_ComboBox.SelectedIndexChanged += new System.EventHandler(this.AlgorithmSelector_ComboBox_SelectedIndexChanged);
            // 
            // Enter_Quantum_Time_Slice_label
            // 
            this.Enter_Quantum_Time_Slice_label.AutoSize = true;
            this.Enter_Quantum_Time_Slice_label.Enabled = false;
            this.Enter_Quantum_Time_Slice_label.Font = new System.Drawing.Font("Times New Roman", 18F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Italic))), System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Enter_Quantum_Time_Slice_label.Location = new System.Drawing.Point(157, 518);
            this.Enter_Quantum_Time_Slice_label.Name = "Enter_Quantum_Time_Slice_label";
            this.Enter_Quantum_Time_Slice_label.Size = new System.Drawing.Size(388, 34);
            this.Enter_Quantum_Time_Slice_label.TabIndex = 11;
            this.Enter_Quantum_Time_Slice_label.Text = "Enter Quantum Time Slice(t):";
            // 
            // Time_Slice_Textbox
            // 
            this.Time_Slice_Textbox.Enabled = false;
            this.Time_Slice_Textbox.Font = new System.Drawing.Font("Times New Roman", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Time_Slice_Textbox.Location = new System.Drawing.Point(582, 519);
            this.Time_Slice_Textbox.Multiline = true;
            this.Time_Slice_Textbox.Name = "Time_Slice_Textbox";
            this.Time_Slice_Textbox.Size = new System.Drawing.Size(168, 33);
            this.Time_Slice_Textbox.TabIndex = 12;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(985, 683);
            this.Controls.Add(this.Time_Slice_Textbox);
            this.Controls.Add(this.Enter_Quantum_Time_Slice_label);
            this.Controls.Add(this.AlgorithmSelector_ComboBox);
            this.Controls.Add(this.Enter_Scheduling_Algorithim_you_want_to_have_label);
            this.Controls.Add(this.Compute_Button);
            this.Controls.Add(this.Close_Button);
            this.Controls.Add(this.Reset_Button);
            this.Controls.Add(this.EmptyTable);
            this.Controls.Add(this.Enter_Button);
            this.Controls.Add(this.Number_of_Processes_TextBox);
            this.Controls.Add(this.Enter_Number_of_Processes_You_Want_To_Have);
            this.Controls.Add(this.SCHEDULING_ALGORITHMS);
            this.Name = "Form1";
            this.Text = "Scheduling Algorithms";
            ((System.ComponentModel.ISupportInitialize)(this.EmptyTable)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label SCHEDULING_ALGORITHMS;
        private System.Windows.Forms.Label Enter_Number_of_Processes_You_Want_To_Have;
        private System.Windows.Forms.Button Enter_Button;
        public System.Windows.Forms.TextBox Number_of_Processes_TextBox;
        public System.Windows.Forms.DataGridView EmptyTable;
        private System.Windows.Forms.Button Reset_Button;
        private System.Windows.Forms.Button Close_Button;
        private System.Windows.Forms.Button Compute_Button;
        private System.Windows.Forms.Label Enter_Scheduling_Algorithim_you_want_to_have_label;
        private System.Windows.Forms.ComboBox AlgorithmSelector_ComboBox;
        private System.Windows.Forms.Label Enter_Quantum_Time_Slice_label;
        public System.Windows.Forms.TextBox Time_Slice_Textbox;
    }
}

