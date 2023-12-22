using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

// Адаптер для перетворення масиву даних у множину даних та навпаки
public class DataAdapter
{
    public HashSet<int> ConvertArrayToSet(int[] array)
    {
        return new HashSet<int>(array);
    }

    public int[] ConvertSetToArray(HashSet<int> set)
    {
        return set.ToArray();
    }
}

// Головна форма програми
public class MainForm : Form
{
    private TextBox arrayInputTextBox;
    private Button convertToSetButton;
    private Button convertToArrayButton;
    private TextBox resultTextBox;

    private DataAdapter dataAdapter;

    public MainForm()
    {
        InitializeComponent();
        dataAdapter = new DataAdapter();
    }

    private void InitializeComponent()
    {
        arrayInputTextBox = new TextBox();
        convertToSetButton = new Button();
        convertToArrayButton = new Button();
        resultTextBox = new TextBox();

        arrayInputTextBox.Location = new System.Drawing.Point(12, 12);
        arrayInputTextBox.Size = new System.Drawing.Size(200, 20);

        convertToSetButton.Location = new System.Drawing.Point(12, 40);
        convertToSetButton.Size = new System.Drawing.Size(200, 30);
        convertToSetButton.Text = "Convert to Set";
        convertToSetButton.Click += ConvertToSetButton_Click;

        convertToArrayButton.Location = new System.Drawing.Point(12, 80);
        convertToArrayButton.Size = new System.Drawing.Size(200, 30);
        convertToArrayButton.Text = "Convert to Array";
        convertToArrayButton.Click += ConvertToArrayButton_Click;

        resultTextBox.Location = new System.Drawing.Point(12, 120);
        resultTextBox.Size = new System.Drawing.Size(200, 20);
        resultTextBox.ReadOnly = true;

        Controls.Add(arrayInputTextBox);
        Controls.Add(convertToSetButton);
        Controls.Add(convertToArrayButton);
        Controls.Add(resultTextBox);

        Text = "Data Adapter Example";
        Size = new System.Drawing.Size(240, 200);
    }

    private void ConvertToSetButton_Click(object sender, EventArgs e)
    {
        try
        {
            int[] array = Array.ConvertAll(arrayInputTextBox.Text.Split(','), int.Parse);
            HashSet<int> dataSet = dataAdapter.ConvertArrayToSet(array);
            resultTextBox.Text = string.Join(", ", dataSet);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }

    private void ConvertToArrayButton_Click(object sender, EventArgs e)
    {
        try
        {
            HashSet<int> dataSet = new HashSet<int>(arrayInputTextBox.Text.Split(',').Select(int.Parse));
            int[] array = dataAdapter.ConvertSetToArray(dataSet);
            resultTextBox.Text = string.Join(", ", array);
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }
    }
}

class Program
{
    [STAThread]
    static void Main()
    {
        Application.EnableVisualStyles();
        Application.Run(new MainForm());
    }
}
