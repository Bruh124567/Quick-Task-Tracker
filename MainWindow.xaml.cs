using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Quick_Task_Tracker
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, RoutedEventArgs e)
        {
            string title = TaskInput.Text;

            string priority = (PriorityDropdown.SelectedItem as ComboBoxItem).Content.ToString();

            if (!string.IsNullOrWhiteSpace(title))
            {
                //Add the text from the box to the list
                TaskItem newTask = new TaskItem(title, priority);
                TaskListBox.Items.Add(newTask);

                //Clear the input for the next task
                TaskInput.Clear();
                TaskInput.Focus();
            }
            else
            {
                MessageBox.Show("Please enter a task first!", "Wait a second...");
            }
        }

        private void DeleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (TaskListBox.SelectedIndex != -1)
            {
                TaskListBox.Items.RemoveAt(TaskListBox.SelectedIndex);
                TaskListBox.SelectedIndex = -1;
                DeleteButton.Visibility = Visibility.Collapsed;
                TaskInput.Focus();
            }
            else
            {
                MessageBox.Show("Select a task to delete first!", "Oops");
            }
        }

        private void TaskListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (TaskListBox.SelectedIndex != -1)
            {
                DeleteButton.Visibility = Visibility.Visible;
            }
            else
            {
                DeleteButton.Visibility = Visibility.Collapsed;
            }
        }

        private void TaskInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(TaskInput.Text))
            {
                AddButton.IsEnabled = true;
            }
            else
            {
                AddButton.IsEnabled = false;
            }
        }

        private void TaskInput_KeyDown(object sender, KeyEventArgs e)
        {
            if(e.Key == Key.Enter)
            {
                if (AddButton.IsEnabled)
                {
                    AddButton_Click(this, new RoutedEventArgs());
                }
            }
        }

        private void ClearCompletedButton_Click(object sender, RoutedEventArgs e)
        {
            var completedTasks = TaskListBox.Items.Cast<TaskItem>()
                                                   .Where(t => t.IsCompleted)
                                                   .ToList();
            foreach (var task in completedTasks)
            {
                TaskListBox.Items.Remove(task);
                TaskListBox.SelectedIndex = -1;
                TaskInput.Focus();
            }
        }
    }
}
