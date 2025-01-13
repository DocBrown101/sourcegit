using Avalonia.Interactivity;

namespace SourceGit.Views
{
    public partial class ConfirmCommitWithoutFiles : ChromelessWindow
    {
        public ConfirmCommitWithoutFiles()
        {
            InitializeComponent();
        }

        private void Sure(object _1, RoutedEventArgs _2)
        {
            if (DataContext is ViewModels.ConfirmCommitWithoutFiles vm)
            {
                vm.Continue();
            }

            Close();
        }

        private void CloseWindow(object _1, RoutedEventArgs _2)
        {
            Close();
        }
    }
}