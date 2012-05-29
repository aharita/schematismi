﻿using System.Windows.Controls;
using Schematismi.Prism.EditorModule.ViewModel;
using Schematismi.Prism.Infrastructure;

namespace Schematismi.Prism.EditorModule.View
{
    /// <summary>
    /// Interaction logic for EditorView.xaml
    /// </summary>
    public partial class EditorView : UserControl, IView
    {
        public EditorView(IEditorViewModel viewModel)
        {
            InitializeComponent();

            ViewModel = viewModel;
        }

        public IViewModel ViewModel
        {
            get
            {
                return (IViewModel)DataContext;
            }
            set
            {
                DataContext = value;
            }
        }
    }
}