﻿using System;
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
            m_searchField.GotKeyboardFocus += new KeyboardFocusChangedEventHandler(OnSearchFieldGotFocus);

            m_searchField.SelectAll();
            m_searchField.Focus();
            m_secrets = m_xecrets.DownloadListOfSecrets();
            m_searchFieldShowsPrompt = false;
        }

        private void OnSearchFieldGotFocus(object sender, KeyboardFocusChangedEventArgs e)
        {
            m_searchField.SelectAll();
        }


        private void textBox1_TextChanged(object sender, TextChangedEventArgs e)
        {
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
        }

        private void m_searchField_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Down)
            {
                MoveFocusToFirstItemInList();
            }
        }

        private void MoveFocusToFirstItemInList()
        {
            if (m_resultListView.HasItems)
            {
                m_resultListView.Focus();
                m_resultListView.SelectedItem = m_resultListView.Items[0];
            }
        }

        private void m_resultListView_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            Console.Out.WriteLine("OnKeyDown from m_resultListView: {0}", e.ToString());
            switch (e.Key)
            {
                case Key.Enter:
                    if (m_resultListView.SelectedItem != null)
                    {
                        m_xecrets.FetchSecret((Secret)m_resultListView.SelectedItem);
                    }
                    break;

                case Key.Space:
                    if (sender == m_resultListView)
                    {
                        ShowDetails((Secret)m_resultListView.SelectedItem);
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
                    m_tabs.SelectedIndex = 0;
                    m_resultListView.Focus();
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
            m_tabs.SelectedIndex = 1;
            m_secretDetails.Focus();
        }
    }
}
