using System.Windows.Controls;
using System.Speech.Synthesis;
using System.Diagnostics;

namespace SEW
{
    public partial class Settings : Page
    {
        MainWindow mainw;

        public Settings(MainWindow mainW)
        {
            mainw = mainW;
            InitializeComponent();

            CreateList();
            if (Properties.Settings.Default.Theme == "Dark") CBTheme.IsChecked = true;
            else CBTheme.IsChecked = false;
        }

        //Сохранить изменения
        private void BSave_Click(object sender, System.Windows.RoutedEventArgs e)
        {
            if (CBTheme.IsChecked == true) Properties.Settings.Default.Theme = "Dark";
            else Properties.Settings.Default.Theme = "Light";

            Properties.Settings.Default.Voice = (VoicesList.SelectedItem as ListBoxItem).Content.ToString();
            Properties.Settings.Default.Save();
            MainWindow.UpdateTheme();
        }

        //Создать список доступных на данном пк голосов
        ListBoxItem Vitem;
        void CreateList()
        {
            using (SpeechSynthesizer synth = new SpeechSynthesizer())
            {
                // Вся информация о установленных голосах   
                foreach (InstalledVoice voice in synth.GetInstalledVoices())
                {
                    VoiceInfo info = voice.VoiceInfo;

                    //Новый элемент списка
                    Vitem = new ListBoxItem()
                    {
                        Height = 40,
                        Content = info.Name
                    };
                    //Стоит ли по у.
                    if (info.Name == Properties.Settings.Default.Voice)
                        Vitem.IsSelected = true;

                    Vitem.SetResourceReference(StyleProperty, "VoicesListBoxItems");
                    Vitem.SetResourceReference(TemplateProperty, "ListVoice");
                    VoicesList.Items.Add(Vitem);
                }
            }
        }

        private void BBack_Click(object sender, System.Windows.RoutedEventArgs e) => mainw.GoToLastPage();

        private void ClickHelpVoice(object sender, System.Windows.Input.MouseButtonEventArgs e)
        {
            //Помощь
            Process.Start(
            @"https://support.office.com/ru-ru/article/как-скачать-языки-преобразования-текста-в-речь-для-windows-10-d5a6b612-b3ae-423f-afa5-4f6caf1ec5d3?omkt=ru-RU&ui=ru-RU&rs=ru-RU&ad=RU"
            );
        }
    }
}
