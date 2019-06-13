using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Unsplasharp;

namespace Sunsplash
{
    // Learn more about making custom code visible in the Xamarin.Forms previewer
    // by visiting https://aka.ms/xamarinforms-previewer
    [DesignTimeVisible(false)]
    public partial class MainPage : ContentPage
    {
        ObservableCollection<SunsplashImage> list_collection = new ObservableCollection<SunsplashImage>();
        UnsplasharpClient client = new UnsplasharpClient("0589e5912b4fcde9f7ebec500d0a0a16ac5f06813a482aa34d0cce57964853aa");
        public MainPage()
        {
            InitializeComponent();
            getImage();
            getUser();

        }

        public async void getImage()
        {
            //var photoWidthHeight = await client.GetPhoto(id: "CPsdlpiqiog", width:150,height:150);
            //string url = photoWidthHeight.Urls.Full;
            //url=System.Uri.EscapeUriString(url);
            var userPhotos = await client.ListUserPhotos("tiqdesign");

            foreach (var VARIABLE in userPhotos)
            {
                SunsplashImage img_user = new SunsplashImage();
                string url = VARIABLE.Urls.Full;
                url = System.Uri.EscapeUriString(url);
                img_user.url = url;
                img_user.description = VARIABLE.Description;
                list_collection.Add(img_user);

            }

            lw_img.ItemsSource = list_collection;

        }

        public async void getUser()
        {
            var user = await client.GetUser("tiqdesign");
            lb_user.Text = user.FirstName + " " + user.LastName;
        }
    }
}
