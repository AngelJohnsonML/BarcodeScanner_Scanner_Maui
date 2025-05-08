using System;
using Microsoft.Maui;
using Microsoft.Maui.Controls;
using System.Windows.Input;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using Xamarin.Google.MLKit.Vision.BarCode;
using BarcodeScanner.Mobile;

namespace BarcodeScannerScanner
{
	public partial class MainPageViewModel: ObservableObject
	{
		//ctor
		public MainPageViewModel()
		{
           // BarcodeDetectedCommand = new RelayCommand<OnDetectedEventArg>(BarcodeDetected);
        }

		[ObservableProperty]
		private string scanResult = string.Empty;

        [ObservableProperty]
        private bool isScanning;

        [RelayCommand]
        private void BarcodeDetected(OnDetectedEventArg e)
        {
            if (e?.BarcodeResults == null || e.BarcodeResults.Count == 0)
                return;

            var result = e.BarcodeResults[0];
            ScanResult = $"Scanning Result: {result.DisplayValue} \nBarcodeFormat: {result.BarcodeFormat}";

            // Optionally resume scanning
            IsScanning = true;
        }
    }
}

