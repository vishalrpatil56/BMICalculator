using System;
using System.Data;
using System.Data.SQLite;
using System.IO;
using System.Windows.Forms;

namespace BMICalculator
{
    public partial class Form1 : Form
    {
        private SQLiteConnection? connection;
        private string? dbPath;

        
        private int? selectedId = null;

        public Form1()
        {
            InitializeComponent();
            InitializeDatabase();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            LoadRecords();
        }

        private void InitializeDatabase()
        {
            string folder = AppDomain.CurrentDomain.BaseDirectory;
            dbPath = Path.Combine(folder, "bmi.db");

            bool newDb = !File.Exists(dbPath);

            connection = new SQLiteConnection($"Data Source={dbPath};Version=3;");
            connection.Open();

            if (newDb)
            {
                string createTable = @"
                    CREATE TABLE IF NOT EXISTS Records (
                        Id INTEGER PRIMARY KEY AUTOINCREMENT,
                        Name TEXT NOT NULL,
                        Height REAL NOT NULL,
                        Weight REAL NOT NULL,
                        BMI REAL NOT NULL,
                        Result TEXT NOT NULL
                    );";
                using var cmd = new SQLiteCommand(createTable, connection);
                cmd.ExecuteNonQuery();
            }
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show(
                    "Please enter the person's name.",
                    "Missing Name",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            
            if (!double.TryParse(txtHeight.Text, out double heightCm) || heightCm <= 0)
            {
                MessageBox.Show(
                    "Please enter a valid positive height in centimeters.",
                    "Invalid Height",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (!double.TryParse(txtWeight.Text, out double weightKg) || weightKg <= 0)
            {
                MessageBox.Show(
                    "Please enter a valid positive weight in kilograms.",
                    "Invalid Weight",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            double heightM = heightCm / 100.0;
            double bmi = weightKg / (heightM * heightM);

            string result;
            if (bmi < 18.5)
                result = "Underweight";
            else if (bmi < 25)
                result = "Normal";
            else if (bmi < 30)
                result = "Overweight";
            else
                result = "Obese";

            lblBMI.Text = $"BMI: {bmi:F1}";
            lblResult.Text = $"Result: {result}";

            SaveToDatabase(name, heightCm, weightKg, bmi, result);
            MessageBox.Show(
                "Record saved successfully.",
                "Saved",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            LoadRecords();
            selectedId = null;
        }

        private void SaveToDatabase(string name, double height, double weight, double bmi, string result)
        {
            string insert = @"
                INSERT INTO Records (Name, Height, Weight, BMI, Result)
                VALUES (@name, @height, @weight, @bmi, @result);";

            using var cmd = new SQLiteCommand(insert, connection);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@height", height);
            cmd.Parameters.AddWithValue("@weight", weight);
            cmd.Parameters.AddWithValue("@bmi", bmi);
            cmd.Parameters.AddWithValue("@result", result);
            cmd.ExecuteNonQuery();
        }

        private void LoadRecords()
        {
            if (connection == null) return;

            string select = "SELECT Id, Name, Height, Weight, BMI, Result FROM Records ORDER BY Id DESC;";
            using var adapter = new SQLiteDataAdapter(select, connection);
            var table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            txtName.Clear();
            txtHeight.Clear();
            txtWeight.Clear();
            txtSearch.Clear();
            lblBMI.Text = "BMI:";
            lblResult.Text = "Result:";
            txtName.Focus();
            selectedId = null;
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            if (row.Cells["Id"].Value == null) return;

            selectedId = Convert.ToInt32(row.Cells["Id"].Value);
            txtName.Text = row.Cells["Name"].Value?.ToString();
            txtHeight.Text = row.Cells["Height"].Value?.ToString();
            txtWeight.Text = row.Cells["Weight"].Value?.ToString();
            lblBMI.Text = $"BMI: {row.Cells["BMI"].Value}";
            lblResult.Text = $"Result: {row.Cells["Result"].Value}";
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (selectedId == null)
            {
                MessageBox.Show(
                    "Please select a record from the table to update.",
                    "No Record Selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            string name = txtName.Text.Trim();
            if (string.IsNullOrWhiteSpace(name))
            {
                MessageBox.Show(
                    "Please enter the person's name.",
                    "Missing Name",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            if (!double.TryParse(txtHeight.Text, out double heightCm) || heightCm <= 0)
            {
                MessageBox.Show(
                    "Please enter a valid positive height in centimeters.",
                    "Invalid Height",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            if (!double.TryParse(txtWeight.Text, out double weightKg) || weightKg <= 0)
            {
                MessageBox.Show(
                    "Please enter a valid positive weight in kilograms.",
                    "Invalid Weight",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
                return;
            }

            double heightM = heightCm / 100.0;
            double bmi = weightKg / (heightM * heightM);

            string result;
            if (bmi < 18.5)
                result = "Underweight";
            else if (bmi < 25)
                result = "Normal";
            else if (bmi < 30)
                result = "Overweight";
            else
                result = "Obese";

            lblBMI.Text = $"BMI: {bmi:F1}";
            lblResult.Text = $"Result: {result}";

            string update = @"
                UPDATE Records
                SET Name = @name,
                    Height = @height,
                    Weight = @weight,
                    BMI = @bmi,
                    Result = @result
                WHERE Id = @id;";

            using var cmd = new SQLiteCommand(update, connection);
            cmd.Parameters.AddWithValue("@name", name);
            cmd.Parameters.AddWithValue("@height", heightCm);
            cmd.Parameters.AddWithValue("@weight", weightKg);
            cmd.Parameters.AddWithValue("@bmi", bmi);
            cmd.Parameters.AddWithValue("@result", result);
            cmd.Parameters.AddWithValue("@id", selectedId.Value);
            cmd.ExecuteNonQuery();

            MessageBox.Show(
                "Record updated successfully.",
                "Updated",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            LoadRecords();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (selectedId == null)
            {
                MessageBox.Show(
                    "Please select a record from the table to delete.",
                    "No Record Selected",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            var confirm = MessageBox.Show(
                "Are you sure you want to delete the selected record?",
                "Delete Confirmation",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            string delete = "DELETE FROM Records WHERE Id = @id;";

            using var cmd = new SQLiteCommand(delete, connection);
            cmd.Parameters.AddWithValue("@id", selectedId.Value);
            cmd.ExecuteNonQuery();

            MessageBox.Show(
                "Record deleted successfully.",
                "Deleted",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);

            selectedId = null;
            btnClear_Click(sender, e);
            LoadRecords();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            if (connection == null) return;

            string keyword = txtSearch.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                LoadRecords();
                return;
            }

            string select = @"
                SELECT Id, Name, Height, Weight, BMI, Result
                FROM Records
                WHERE Name LIKE @keyword
                ORDER BY Id DESC;";

            using var adapter = new SQLiteDataAdapter(select, connection);
            adapter.SelectCommand.Parameters.AddWithValue("@keyword", "%" + keyword + "%");
            var table = new DataTable();
            adapter.Fill(table);
            dataGridView1.DataSource = table;

            if (table.Rows.Count == 0)
            {
                MessageBox.Show(
                    "No records found matching the search text.",
                    "Search Result",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            if (disposing && connection != null)
            {
                connection.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
