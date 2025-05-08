using Java.Util;
using Microsoft.Maui.Controls;
using Xamarin.Google.MLKit.Vision.BarCode;

namespace BarcodeScannerScanner;

public partial class MainPage : ContentPage
{
	int count = 0;

	public MainPage()
	{
		InitializeComponent();
        //this.BindingContext = new MainPageViewModel();
	}

    protected override void OnAppearing()
    {
        base.OnAppearing();
        BarcodeScanner.Mobile.Methods.AskForRequiredPermission();
    }

    void CameraView_OnDetected(System.Object sender, BarcodeScanner.Mobile.OnDetectedEventArg e)
    {
        var text = e.BarcodeResults[0].DisplayValue;
        var textType = e.BarcodeResults[0].BarcodeFormat;

        Dispatcher.Dispatch(async() =>
        {
            ScanningResult.Text = $"Scanning Result: {text} \nBarcodeFormat: {textType}";
            barcodeScanner.IsScanning = true;
        });

    }
}


