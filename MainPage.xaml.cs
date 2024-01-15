namespace QRScanner;
using Microsoft.Maui.Controls;

public partial class MainPage : ContentPage
{

    public MainPage()
    {
        InitializeComponent();
    }

    private void OnPhotoClicked(object sender, EventArgs e)
    {
        TakePhoto();
    }

    private void OnScanClicked(object sender, EventArgs e)
    {

    }

    public async void TakePhoto()
    {
        if (MediaPicker.Default.IsCaptureSupported)
        {
            FileResult photo = await MediaPicker.Default.CapturePhotoAsync();

            if (photo != null)
            {
                string localFilePath = Path.Combine(FileSystem.CacheDirectory, photo.FileName);

                using Stream sourceStream = await photo.OpenReadAsync();
                using FileStream localFileStream = File.OpenWrite(localFilePath);

                await sourceStream.CopyToAsync(localFileStream);

                capturedImage.Source = localFilePath;
            }
        }
    }

}
