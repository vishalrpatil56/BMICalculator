using System.Drawing;
using System.Windows.Forms;

namespace BMICalculator
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            lblName = new Label();
            lblHeight = new Label();
            lblWeight = new Label();
            txtName = new TextBox();
            txtHeight = new TextBox();
            txtWeight = new TextBox();
            btnCalculate = new Button();
            lblBMI = new Label();
            lblResult = new Label();
            dataGridView1 = new DataGridView();
            btnClear = new Button();
            txtSearch = new TextBox();
            btnSearch = new Button();
            btnUpdate = new Button();
            btnDelete = new Button();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            
            lblName.AutoSize = true;
            lblName.Font = new Font("Times New Roman", 10.8F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            lblName.Location = new Point(23, 27);
            lblName.Name = "lblName";
            lblName.Size = new Size(59, 20);
            lblName.TabIndex = 0;
            lblName.Text = "Name:";
             
            lblHeight.AutoSize = true;
            lblHeight.Font = new Font("Times New Roman", 10.8F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            lblHeight.Location = new Point(23, 73);
            lblHeight.Name = "lblHeight";
            lblHeight.Size = new Size(71, 20);
            lblHeight.TabIndex = 1;
            lblHeight.Text = "Height :";
            

            lblWeight.AutoSize = true;
            lblWeight.Font = new Font("Times New Roman", 10.8F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            lblWeight.Location = new Point(23, 120);
            lblWeight.Name = "lblWeight";
            lblWeight.Size = new Size(73, 20);
            lblWeight.TabIndex = 2;
            lblWeight.Text = "Weight :";
           

            txtName.Location = new Point(137, 23);
            txtName.Margin = new Padding(3, 4, 3, 4);
            txtName.Name = "txtName";
            txtName.Size = new Size(252, 27);
            txtName.TabIndex = 3;
           

            txtHeight.Location = new Point(137, 66);
            txtHeight.Margin = new Padding(3, 4, 3, 4);
            txtHeight.Name = "txtHeight";
            txtHeight.Size = new Size(252, 27);
            txtHeight.TabIndex = 4;
           

            txtWeight.Location = new Point(137, 116);
            txtWeight.Margin = new Padding(3, 4, 3, 4);
            txtWeight.Name = "txtWeight";
            txtWeight.Size = new Size(252, 27);
            txtWeight.TabIndex = 5;
           

            btnCalculate.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCalculate.Location = new Point(503, 110);
            btnCalculate.Margin = new Padding(3, 4, 3, 4);
            btnCalculate.Name = "btnCalculate";
            btnCalculate.Size = new Size(103, 40);
            btnCalculate.TabIndex = 6;
            btnCalculate.Text = "Calculate";
            btnCalculate.UseVisualStyleBackColor = true;
            btnCalculate.Click += btnCalculate_Click;
            

            lblBMI.AutoSize = true;
            lblBMI.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            lblBMI.Location = new Point(23, 185);
            lblBMI.Name = "lblBMI";
            lblBMI.Size = new Size(47, 23);
            lblBMI.TabIndex = 8;
            lblBMI.Text = "BMI:";
            

            lblResult.AutoSize = true;
            lblResult.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point, 0);
            lblResult.Location = new Point(23, 228);
            lblResult.Name = "lblResult";
            lblResult.Size = new Size(64, 23);
            lblResult.TabIndex = 9;
            lblResult.Text = "Result:";
            

            dataGridView1.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Location = new Point(23, 320);
            dataGridView1.Margin = new Padding(3, 4, 3, 4);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.RowTemplate.Height = 25;
            dataGridView1.Size = new Size(793, 268);
            dataGridView1.TabIndex = 10;
            dataGridView1.CellClick += dataGridView1_CellClick;
            

            btnClear.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClear.Location = new Point(503, 185);
            btnClear.Margin = new Padding(3, 4, 3, 4);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(103, 40);
            btnClear.TabIndex = 7;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = true;
            btnClear.Click += btnClear_Click;
           

            txtSearch.Location = new Point(452, 27);
            txtSearch.Margin = new Padding(3, 4, 3, 4);
            txtSearch.Name = "txtSearch";
            txtSearch.PlaceholderText = "Search by name";
            txtSearch.Size = new Size(364, 27);
            txtSearch.TabIndex = 11;
            

            btnSearch.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnSearch.Location = new Point(682, 81);
            btnSearch.Margin = new Padding(3, 4, 3, 4);
            btnSearch.Name = "btnSearch";
            btnSearch.Size = new Size(103, 40);
            btnSearch.TabIndex = 12;
            btnSearch.Text = "Search";
            btnSearch.UseVisualStyleBackColor = true;
            btnSearch.Click += btnSearch_Click;
            

            btnUpdate.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUpdate.Location = new Point(682, 152);
            btnUpdate.Margin = new Padding(3, 4, 3, 4);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(103, 40);
            btnUpdate.TabIndex = 13;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = true;
            btnUpdate.Click += btnUpdate_Click;
            

            btnDelete.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDelete.Location = new Point(682, 237);
            btnDelete.Margin = new Padding(3, 4, 3, 4);
            btnDelete.Name = "btnDelete";
            btnDelete.Size = new Size(103, 40);
            btnDelete.TabIndex = 14;
            btnDelete.Text = "Delete";
            btnDelete.UseVisualStyleBackColor = true;
            btnDelete.Click += btnDelete_Click;
            

            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(838, 614);
            Controls.Add(btnDelete);
            Controls.Add(btnUpdate);
            Controls.Add(btnSearch);
            Controls.Add(txtSearch);
            Controls.Add(dataGridView1);
            Controls.Add(lblResult);
            Controls.Add(lblBMI);
            Controls.Add(btnClear);
            Controls.Add(btnCalculate);
            Controls.Add(txtWeight);
            Controls.Add(txtHeight);
            Controls.Add(txtName);
            Controls.Add(lblWeight);
            Controls.Add(lblHeight);
            Controls.Add(lblName);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Form1";
            Text = "BMI Calculator";
            Load += Form1_Load;
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblHeight;
        private System.Windows.Forms.Label lblWeight;
        private System.Windows.Forms.TextBox txtName;
        private System.Windows.Forms.TextBox txtHeight;
        private System.Windows.Forms.TextBox txtWeight;
        private System.Windows.Forms.Button btnCalculate;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Label lblBMI;
        private System.Windows.Forms.Label lblResult;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Button btnSearch;
        private System.Windows.Forms.Button btnUpdate;
        private System.Windows.Forms.Button btnDelete;
    }
}
