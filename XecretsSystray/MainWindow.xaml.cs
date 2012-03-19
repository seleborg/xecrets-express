using System;
using System.Collections.Generic;
using System.Linq;
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

namespace XecretsSystray
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private bool m_searchFieldShowsPrompt = true;
        private string m_filter;
        private Xecrets m_xecrets = new Xecrets();
        private List<Secret> m_secrets = new List<Secret>();

        public MainWindow()
        {
            InitializeComponent();

            this.KeyDown += new KeyEventHandler(OnKeyDown);
            m_resultListView.PreviewKeyDown += new KeyEventHandler(m_resultListView_PreviewKeyDown);
            m_searchField.GotKeyboardFocus += new KeyboardFocusChangedEventHandler(m_searchField_GetKeyboardFocus);
            m_searchField.TextChanged += new TextChangedEventHandler(m_searchField_TextChanged);
            m_searchField.PreviewKeyDown += new KeyEventHandler(m_searchField_PreviewKeyDown);

            m_secrets = m_xecrets.DownloadListOfSecrets();
            MoveFocusToSearchField();
            m_searchFieldShowsPrompt = false;
        }

        
        private void MoveFocusToSearchField()
        {
            m_searchField.Focus();
        }


        private void m_searchField_GetKeyboardFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            m_searchField.SelectAll();
            e.Handled = true;
        }


        private void m_searchField_TextChanged(object sender, TextChangedEventArgs e)
        {
            e.Handled = true;
            if (m_searchFieldShowsPrompt)
            {
                return;
            }

            TextBox box = (TextBox)sender;
            m_filter = box.Text;
            FilterResults();
        }

        
        private void FilterResults()
        {
            if (m_filter.Length == 0)
            {
                m_resultListView.ItemsSource = null;
            }
            else
            {
                m_resultListView.ItemsSource = m_secrets;
                string searchString = m_searchField.Text.ToLower();
                m_resultListView.Items.Filter = (s)=>
                {
                    var secret = (Secret)s;
                    return secret.m_title.ToLower().Contains(searchString)
                        || secret.m_content.ToLower().Contains(searchString);
                };
            }
        }


        private void m_resultListView_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            Clipboard.SetText(m_xecrets.FetchSecret((Secret)m_resultListView.SelectedItem));
            e.Handled = true;
        }


        private void m_searchField_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Down)
            {
                MoveFocusToFirstItemInList();
                e.Handled = true;
            }
        }

        
        private void MoveFocusToFirstItemInList()
        {
            if (m_resultListView.HasItems)
            {
                m_resultListView.SelectedItem = m_resultListView.Items[0];
                m_resultListView.Focus();
                m_resultListView.MoveFocus(new TraversalRequest(FocusNavigationDirection.First));
            }
        }


        private void m_resultListView_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Enter:
                    if (m_resultListView.SelectedItem != null)
                    {
                        m_xecrets.FetchSecret((Secret)m_resultListView.SelectedItem);
                        e.Handled = true;
                    }
                    break;

                case Key.Space:
                    if (m_resultListView.SelectedItem != null)
                    {
                        ShowDetails((Secret)m_resultListView.SelectedItem);
                        e.Handled = true;
                    }
                    break;

                case Key.Up:
                    if (m_resultListView.SelectedIndex == 0)
                    {
                        MoveFocusToSearchField();
                        e.Handled = true;
                    }
                    break;

                default:
                    break;
            }

        }

        
        private void OnKeyDown(object sender, KeyEventArgs e)
        {
            switch (e.Key)
            {
                case Key.Escape:
                    m_detailsBox.Visibility = Visibility.Hidden;
                    m_searchBox.Visibility = Visibility.Visible;
                    //MoveFocusToFirstItemInList();
                    m_resultListView.Focus();
                    m_resultListView.MoveFocus(new TraversalRequest(FocusNavigationDirection.Right));
                    e.Handled = true;
                    break;

                default:
                    break;
            }
        }


        private void ShowDetails(Secret secret)
        {
            m_secretTitle.Text = secret.m_title;
            m_secretDetails.Text = secret.m_content;
            m_secretSecret.Text = m_xecrets.FetchSecret(secret);
            m_detailsBox.Visibility = Visibility.Visible;
            m_searchBox.Visibility = Visibility.Hidden;
            m_secretDetails.Focus();
        }
    }
}
