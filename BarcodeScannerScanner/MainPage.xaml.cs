using Java.Util;
using Microsoft.Maui.Controls;
using Xamarin.Google.MLKit.Vision.BarCode;
using BarcodeScanner.Mobile;

namespace BarcodeScannerScanner;

public partial class MainPage : ContentPage
{
	int count = 0;
    CameraView cameraView;
	public MainPage()
	{
		InitializeComponent();
        //this.BindingContext = new MainPageViewModel();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        BarcodeScanner.Mobile.Methods.AskForRequiredPermission();
        cameraView = new CameraView
        {
            IsScanning = true,
            IsEnabled = true,
            IsVisible = true,
            VibrationOnDetected = true
        };

        cameraView.OnDetected += CameraView_OnDetected;
        ScannerView.Children.Insert(0, cameraView);
    }

    protected override void OnDisappearing()
    {
        base.OnDisappearing();
        if(ScannerView.Children.Contains(cameraView))
        {
            ScannerView.Children.Remove(cameraView);
            
        }
    }

    void CameraView_OnDetected(System.Object? sender, BarcodeScanner.Mobile.OnDetectedEventArg e)
    {
        var text = e.BarcodeResults[0].DisplayValue;
        var textType = e.BarcodeResults[0].BarcodeFormat;

        Dispatcher.Dispatch(async() =>
        {
            ScanningResult.Text = $"Scanning Result: {text} \nBarcodeFormat: {textType}";
            cameraView.IsScanning = true;
        });

    }
}


