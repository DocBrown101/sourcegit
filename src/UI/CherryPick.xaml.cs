using System.Windows;
using System.Windows.Controls;

namespace SourceGit.UI {

    /// <summary>
    ///     Cherry pick commit dialog.
    /// </summary>
    public partial class CherryPick : UserControl {
        private Git.Repository repo = null;
        private string commitSHA = null;

        /// <summary>
        ///     Constructor.
        /// </summary>
        /// <param name="opened"></param>
        /// <param name="commit"></param>
        public CherryPick(Git.Repository opened, Git.Commit commit) {
            InitializeComponent();

            repo = opened;
            commitSHA = commit.SHA;
            desc.Text = $"{commit.ShortSHA}  {commit.Subject}";
        }

        /// <summary>
        ///     Display this dialog.
        /// </summary>
        /// <param name="repo"></param>
        /// <param name="commit"></param>
        public static void Show(Git.Repository repo, Git.Commit commit) {
            repo.GetPopupManager()?.Show(new CherryPick(repo, commit));
        }

        /// <summary>
        ///     Start pick.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Start(object sender, RoutedEventArgs e) {
            repo.CherryPick(commitSHA, chkCommitChanges.IsChecked != true);
            repo.GetPopupManager()?.Close();
        }

        /// <summary>
        ///     Cancel.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Cancel(object sender, RoutedEventArgs e) {
            repo.GetPopupManager()?.Close();
        }
    }
}