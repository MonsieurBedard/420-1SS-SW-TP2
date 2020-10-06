using ApiHelper;
using DogFetchApp.Commands;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.IO;
using System.Net.Http;
using System.Text;
using System.Windows;
using static System.Net.Mime.MediaTypeNames;

namespace DogFetchApp.ViewModels
{
    class MainViewModel : BaseViewModel
    {

        private string selectedBreed;
        public string SelectedBreed {
            get => selectedBreed;
            set 
            {
                selectedBreed = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<string> breeds;
        public ObservableCollection<string> Breeds
        {
            get => breeds;
            set
            {
                breeds = value;
                OnPropertyChanged();
            }
        }

        private string selectedImage;
        public string SelectedImage
        {
            get => selectedImage;
            set
            {
                selectedImage = value;
                OnPropertyChanged();
            }
        }


        private ObservableCollection<string> images;
        public ObservableCollection<string> Images
        {
            get => images;
            set
            {
                images = value;
                OnPropertyChanged();
            }
        }

        private string imagesNumber;
        public string ImagesNumber
        {
            get => imagesNumber;
            set
            {
                imagesNumber = value;
                OnPropertyChanged();
                Debug.WriteLine(imagesNumber);
            }
        }

        private int selectedRequestNumber;
        public int SelectedRequestNumber
        {
            get => selectedRequestNumber;
            set
            {
                selectedRequestNumber = value;
                OnPropertyChanged();
            }
        }

        private ObservableCollection<int> requestNumbers;
        public ObservableCollection<int> RequestNumbers
        {
            get => requestNumbers;
            set
            {
                requestNumbers = value;
                OnPropertyChanged();
            }
        }


        public DelegateCommand<string> FetchCommand { get; private set; }
        public DelegateCommand<string> ChangeLangCommand { get; private set; }

        public MainViewModel()
        {
            OnAsyncLoad();

            FetchCommand = new DelegateCommand<string>(OnFetch);
            ChangeLangCommand = new DelegateCommand<string>(ChangeLang);
        }

        public async void OnAsyncLoad()
        { 
            Breeds = new ObservableCollection<string>(await DogApiProcessor.LoadBreedList());
            SelectedBreed = Breeds[0];
            ImagesNumber = "1";

            RequestNumbers = new ObservableCollection<int>();
            RequestNumbers.Add(1);
            RequestNumbers.Add(3);
            RequestNumbers.Add(5);
            RequestNumbers.Add(10);
            SelectedRequestNumber = RequestNumbers[0];
        }

        public async void OnFetch(string arg)
        {
            Images = new ObservableCollection<string>(await DogApiProcessor.GetImageUrl(SelectedBreed, SelectedRequestNumber));
            SelectedImage = Images[0];
        }

        public void ChangeLang(string lang)
        {
            Properties.Settings.Default.Language = lang;
            Properties.Settings.Default.Save();

            MessageBoxResult result = MessageBox.Show($"{Properties.Resources.text_confirmation}", "App", MessageBoxButton.YesNo, MessageBoxImage.Question, MessageBoxResult.No);
            switch (result)
            {
                case MessageBoxResult.Yes:
                    Restart();
                    break;
                case MessageBoxResult.No:
                    break;
            }
        }

        public void Restart()
        {
            var filename = System.Windows.Application.ResourceAssembly.Location;
            var newFile = Path.ChangeExtension(filename, ".exe");
            Process.Start(newFile);
            System.Windows.Application.Current.Shutdown();
        }
    }
}
