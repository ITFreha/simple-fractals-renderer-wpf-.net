using fractals_renderer.Interface;
using fractals_renderer.Model;
using fractals_renderer.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media.Imaging;

namespace fractals_renderer.ViewModel
{
    public class MainWindowViewModel : BaseViewModel
    {
        private WriteableBitmap imageSoure;
        private string bottomInfoText;
        private IDialogService dialogService;
        private IFileService fileService;

        public ICommand GoToThePlaceFromDbCommand { get; set; }
        public ICommand GoToThePlaceByCenterAndViewCommand { get; set; }
        public ICommand OpenSettingsCommand { get; set; }
        public ICommand OpenSavePlaceCommand { get; set; }
        public ICommand OpenChangeResolutionCommand { get; set; }
        public ICommand MouseLeftClickCommand { get; set; }
        public ICommand MouseRightClickCommand { get; set; }
        public ICommand LoadedWindowCommand { get; set; }
        public ICommand SaveImageCommand { get; set; }

        public MainWindowViewModel(IDialogService dialogService, IFileService fileService)
        {
            this.dialogService = dialogService;
            this.fileService = fileService;
            GoToThePlaceFromDbCommand = new RelayCommand(arg => GoToThePlaceFromDbMethod());
            GoToThePlaceByCenterAndViewCommand = new RelayCommand(arg => GoToThePlaceByCenterAndViewMethod());
            OpenSettingsCommand = new RelayCommand(arg => OpenSettingsMethod());
            OpenSavePlaceCommand = new RelayCommand(arg => OpenSavePlaceMethod());
            OpenChangeResolutionCommand = new RelayCommand(arg => OpenChangeResolutionMethod());
            MouseLeftClickCommand = new RelayCommand(sender => MouseClickMethod(sender, true));
            MouseRightClickCommand = new RelayCommand(sender => MouseClickMethod(sender, false));
            LoadedWindowCommand = new RelayCommand((arg) => LoadedWindowMethod());
            SaveImageCommand = new RelayCommand((arg) => SaveImageMethod());
        }
        
        public WriteableBitmap ImageSource
        {
            get { return imageSoure; }
            set { imageSoure = value; OnPropertyChanged(); }
        }

        public string BottomInfoText
        {
            get { return bottomInfoText; }
            set { bottomInfoText = value; OnPropertyChanged(); }
        }

        private void LoadedWindowMethod()
        {
            Fractal fractal = new Fractal();
            ((App)Application.Current).Fractal = fractal;
            ImageSource = fractal.Bitmap;
            fractal.RenderBitmap();
        }

        private void SaveImageMethod()
        {
            if (dialogService.SaveFileDialog())
                fileService.Save(dialogService.FilePath, ((App)Application.Current).Fractal.GetImage());
        }

        private void MouseClickMethod(object sender, bool isLeftClick)
        {
            Point pos = Mouse.GetPosition((IInputElement)sender);
            Fractal fractal = ((App)Application.Current).Fractal;

            double ratioX = pos.X / ((Image)sender).ActualWidth;
            double ratioY = pos.Y / ((Image)sender).ActualHeight;

            if (isLeftClick)
                    fractal.ChangeView(ratioX, ratioY, 1.0 / fractal.ScaleKoef);
            else
                    fractal.ChangeView(ratioX, ratioY, fractal.ScaleKoef);

            fractal.RenderBitmap();
        }

        private void OpenChangeResolutionMethod()
        {
            ViewRequest.RequestOpenChangeResolution(new ChangeResolutionViewModel());
        }

        private void OpenSavePlaceMethod()
        {
            ViewRequest.RequestOpenSavePlace(new SavePlaceToDbViewModel());
        }

        private void GoToThePlaceFromDbMethod()
        {
            ViewRequest.RequestGoToThePlaceFromDb(new PlacesFromDbViewModel());
        }

        private void GoToThePlaceByCenterAndViewMethod()
        {
            ViewRequest.RequestGoToThePlaceByCenterAndView(new PlaceByCenterAndView());
        }

        private void OpenSettingsMethod()
        {
            ViewRequest.RequestOpenSettings(new SettingsViewModel());
        }
    }
}
