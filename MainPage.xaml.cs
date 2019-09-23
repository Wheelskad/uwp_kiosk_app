using System;
using Windows.Storage;
using Windows.Storage.Pickers;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using System.Linq;
using System.Text;
using Windows.System;

// Pour plus d'informations sur le modèle d'élément Page vierge, consultez la page https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace uwp_kiosk
{
    /// <summary>
    /// Une page vide peut être utilisée seule ou constituer une page de destination au sein d'un frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void Button_ClickAsync(object sender, RoutedEventArgs e)
        {
            try
            {
                ResetMessage();
                var picker = new FileOpenPicker();
                picker.ViewMode = PickerViewMode.Thumbnail;
                picker.SuggestedStartLocation = PickerLocationId.ComputerFolder;
                picker.FileTypeFilter.Add(".txt");
                picker.FileTypeFilter.Add(".xls");
                picker.FileTypeFilter.Add(".xlsx");
                picker.FileTypeFilter.Add(".xlsm");
                picker.FileTypeFilter.Add(".doc");
                picker.FileTypeFilter.Add(".docx");
                picker.FileTypeFilter.Add(".pdf");
                StorageFile file = await picker.PickSingleFileAsync();
                if (file != null)
                {
                    var fileSupported = await Launcher.QueryFileSupportAsync(file);
                    var  handlers = await Launcher.FindFileHandlersAsync(file.FileType);
                    var sb = new StringBuilder();
                    var appHandlers = handlers.ToList();

                    foreach (var appInfo in appHandlers)
                    {
                        sb.AppendLine($"Id: {appInfo.Id}, AUMID: {appInfo.AppUserModelId}, Package: {appInfo.PackageFamilyName}, Supported: {fileSupported}");
                    }
                    fileInfo.Text = sb.ToString();

                    filePick.Text = "Picked file: " + file.Name;
                    var promptOptions = new LauncherOptions();
                    promptOptions.DisplayApplicationPicker = true;
                    var success = await Launcher.LaunchFileAsync(file, promptOptions);
                    if (success)
                    {
                        message.Text = $"Launch file {file.Name} success";
                    }
                    else
                    {
                        message.Text = $"Launch file {file.Name} error";
                    }
                }
                else
                {
                    filePick.Text = "Operation cancelled";
                }
            }
            catch(Exception ex)
            {
                message.Text = ex.Message;
            }
        }

        private void ResetMessage()
        {
            filePick.Text = string.Empty;
            fileInfo.Text = string.Empty;
            message.Text = string.Empty;
        }
    }
}
