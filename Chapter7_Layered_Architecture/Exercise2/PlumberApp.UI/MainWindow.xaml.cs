﻿using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;
using PlumberApp.AppLogic;
using PlumberApp.Domain;
using PlumberApp.UI.Annotations;

namespace PlumberApp.UI
{
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public ObservableCollection<IWorkload> AllWorkloads { get; set; }

        public Visibility ShowSelectedWorkload => SelectedWorkload == null ? Visibility.Hidden : Visibility.Visible;

        public IWorkload SelectedWorkload { get; set; }

        public MainWindow(IWorkloadRepository workloadRepository)
        {
            InitializeComponent();
            workloadRepository.GetAll();
        }

        private void OnWorkloadSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            this.SelectedWorkload = new Workload(WorkloadNameTextBox.Text, 10);
        }

        private void OnAddWorkloadClick(object sender, RoutedEventArgs e)
        {
            this.AllWorkloads.Add(this.SelectedWorkload);

        }

        private void OnAddJobClick(object sender, RoutedEventArgs e)
        {
            //TODO: add job
            if (SelectedWorkload == null)
            {

            } else
            {
                this.SelectedWorkload.AddJob(JobDescriptionTextBox.Text);
                //this.SelectedWorkload
                JobsListView.Items.Refresh(); //Makes sure the added job is shown in the UI
            }

        }

        public event PropertyChangedEventHandler PropertyChanged;

        [NotifyPropertyChangedInvocator]
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
