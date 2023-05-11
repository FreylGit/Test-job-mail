using Mail.ApplicationWpf.ViewModels;
using System.ComponentModel;
using System.Windows;

namespace Mail.ApplicationWpf.Views
{
    /// <summary>
    /// Логика взаимодействия для MessageWindow.xaml
    /// </summary>
    public partial class MessageWindow : Window
    {
        public MessageWindow(ItemMessageViewModel model)
        {
            InitializeComponent();
            if(model != null)
            {
                
                LTitle.Content = model.Title;
                LContent.Content = model.Content;
                LDate.Content = model.DateTime.ToUniversalTime();
            }
        }
       
    }
}
