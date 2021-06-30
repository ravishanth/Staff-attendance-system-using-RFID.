namespace windows_file_10
{
    partial class View_Attendance
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
            this.components = new System.ComponentModel.Container();
            this.usersDbDataSet = new windows_file_10.UsersDbDataSet();
            this.attendBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.attendTableAdapter = new windows_file_10.UsersDbDataSetTableAdapters.attendTableAdapter();
            this.tableAdapterManager = new windows_file_10.UsersDbDataSetTableAdapters.TableAdapterManager();
            this.attendDataGridView = new System.Windows.Forms.DataGridView();
            this.dataGridViewTextBoxColumn1 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn2 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dataGridViewTextBoxColumn3 = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.usersDbDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.attendBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.attendDataGridView)).BeginInit();
            this.SuspendLayout();
            // 
            // usersDbDataSet
            // 
            this.usersDbDataSet.DataSetName = "UsersDbDataSet";
            this.usersDbDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // attendBindingSource
            // 
            this.attendBindingSource.DataMember = "attend";
            this.attendBindingSource.DataSource = this.usersDbDataSet;
            // 
            // attendTableAdapter
            // 
            this.attendTableAdapter.ClearBeforeFill = true;
            // 
            // tableAdapterManager
            // 
            this.tableAdapterManager.attendTableAdapter = this.attendTableAdapter;
            this.tableAdapterManager.BackupDataSetBeforeUpdate = false;
            this.tableAdapterManager.registrationTableAdapter = null;
            this.tableAdapterManager.UpdateOrder = windows_file_10.UsersDbDataSetTableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete;
            // 
            // attendDataGridView
            // 
            this.attendDataGridView.AutoGenerateColumns = false;
            this.attendDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.attendDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.dataGridViewTextBoxColumn1,
            this.dataGridViewTextBoxColumn2,
            this.dataGridViewTextBoxColumn3});
            this.attendDataGridView.DataSource = this.attendBindingSource;
            this.attendDataGridView.Location = new System.Drawing.Point(12, 12);
            this.attendDataGridView.Name = "attendDataGridView";
            this.attendDataGridView.Size = new System.Drawing.Size(347, 93);
            this.attendDataGridView.TabIndex = 1;
            // 
            // dataGridViewTextBoxColumn1
            // 
            this.dataGridViewTextBoxColumn1.DataPropertyName = "rfid_card";
            this.dataGridViewTextBoxColumn1.HeaderText = "rfid_card";
            this.dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // dataGridViewTextBoxColumn2
            // 
            this.dataGridViewTextBoxColumn2.DataPropertyName = "status";
            this.dataGridViewTextBoxColumn2.HeaderText = "status";
            this.dataGridViewTextBoxColumn2.Name = "dataGridViewTextBoxColumn2";
            // 
            // dataGridViewTextBoxColumn3
            // 
            this.dataGridViewTextBoxColumn3.DataPropertyName = "DateTime";
            this.dataGridViewTextBoxColumn3.HeaderText = "DateTime";
            this.dataGridViewTextBoxColumn3.Name = "dataGridViewTextBoxColumn3";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(12, 281);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(81, 37);
            this.button1.TabIndex = 2;
            this.button1.Text = "Print Attendance ";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(1171, 591);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(81, 37);
            this.button2.TabIndex = 3;
            this.button2.Text = "Back";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // View_Attendance
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSize = true;
            this.BackgroundImage = global::windows_file_10.Properties.Resources.inde;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.ClientSize = new System.Drawing.Size(1264, 640);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.attendDataGridView);
            this.Name = "View_Attendance";
            this.Text = "View_Attendance";
            this.Load += new System.EventHandler(this.View_Attendance_Load);
            ((System.ComponentModel.ISupportInitialize)(this.usersDbDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.attendBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.attendDataGridView)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private UsersDbDataSet usersDbDataSet;
        private System.Windows.Forms.BindingSource attendBindingSource;
        private UsersDbDataSetTableAdapters.attendTableAdapter attendTableAdapter;
        private UsersDbDataSetTableAdapters.TableAdapterManager tableAdapterManager;
        private System.Windows.Forms.DataGridView attendDataGridView;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn2;
        private System.Windows.Forms.DataGridViewTextBoxColumn dataGridViewTextBoxColumn3;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
    }
}