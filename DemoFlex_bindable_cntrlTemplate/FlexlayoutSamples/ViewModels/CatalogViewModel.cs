using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows.Input;
using Acr.UserDialogs;
using DemoFlex_bindable_cntrlTemplate.ApiServices;
using DemoFlex_bindable_cntrlTemplate.FlexlayoutSamples.Models;
using PropertyChanged;
using Xamarin.Essentials;
using Xamarin.Forms;

namespace DemoFlex_bindable_cntrlTemplate.FlexlayoutSamples.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class CatalogViewModel: BaseViewModel
    {
        public ObservableCollection<Article> Data { get; private set; } = new ObservableCollection<Article>();
        public ObservableCollection<BottomUIElements> BottomUIElementsData { get; private set; } = new ObservableCollection<BottomUIElements>();
        public Command Tap { get; set; }
        public bool IsLoading { get; set; }
        public bool IsEmptyVisible { get; set; }
        public CatalogViewModel()
        {
            if (Data==null || Data.Count==0)
            {
                IsEmptyVisible = true;
            }
            Tap = new Command(click1);
            LoadBottomUIElements();
        }

        private void LoadBottomUIElements()
        {
            BottomUIElementsData.Add(new BottomUIElements
            {
                GifImageSource="News.gif",
                Title="News"
            });

            BottomUIElementsData.Add(new BottomUIElements
            {
                GifImageSource = "Animals.gif",
                Title = "Animals"
            });

            BottomUIElementsData.Add(new BottomUIElements
            {
                GifImageSource = "Movies",
                Title = "Movies"
            });
            BottomUIElementsData.Add(new BottomUIElements
            {
                GifImageSource = "News.gif",
                Title = "News"
            });

            BottomUIElementsData.Add(new BottomUIElements
            {
                GifImageSource = "Animals.gif",
                Title = "Animals"
            });

            BottomUIElementsData.Add(new BottomUIElements
            {
                GifImageSource = "Movies",
                Title = "Movies"
            });
        }

        private async void click1(object obj)
        {
            IsEmptyVisible = false;
            IsLoading = true;
            Data.Clear();
            if (obj is BottomUIElements item)
            {
                DisplayedImageGif = item.GifImageSource;
                switch (item.Title)
                {
                    case "News":
                        await LoadNewsData();
                        break;
                    case "Animals":
                        await LoadAnimalData();
                        break;
                    case "Movies":
                        await LoadMoviesdata();
                        break;
                    default:
                        break;
                }
            }
            IsLoading = false;

        }
        //Animals Data
        private async Task LoadAnimalData()
        {
            Data.Add(new Article
            {
                Title = "American Black Bear",
                Author = "North America",
                Description = "The American black bear is a medium-sized bear native to North America. It is the continent's smallest and most widely distributed bear species.",
                UrlToImage = "https://upload.wikimedia.org/wikipedia/commons/0/08/01_Schwarzbär.jpg"

            });
            Data.Add(new Article
            {
                Title = "American Black Bear",
                Author = "North America",
                Description = "The American black bear is a medium-sized bear native to North America. It is the continent's smallest and most widely distributed bear species.",
                UrlToImage = "https://upload.wikimedia.org/wikipedia/commons/0/08/01_Schwarzbär.jpg"

            });
            Data.Add(new Article
            {
                Title = "American Black Bear",
                Author = "North America",
                Description = "The American black bear is a medium-sized bear native to North America. It is the continent's smallest and most widely distributed bear species.",
                UrlToImage = "https://upload.wikimedia.org/wikipedia/commons/0/08/01_Schwarzbär.jpg"

            });
            Data.Add(new Article
            {
                Title = "American Black Bear",
                Author = "North America",
                Description = "The American black bear is a medium-sized bear native to North America. It is the continent's smallest and most widely distributed bear species.",
                UrlToImage = "https://upload.wikimedia.org/wikipedia/commons/0/08/01_Schwarzbär.jpg"

            });
            Data.Add(new Article
            {
                Title = "American Black Bear",
                Author = "North America",
                Description = "The American black bear is a medium-sized bear native to North America. It is the continent's smallest and most widely distributed bear species.",
                UrlToImage = "https://upload.wikimedia.org/wikipedia/commons/0/08/01_Schwarzbär.jpg"

            });
        }

        //Movies Data
        private async Task LoadMoviesdata()
        {
            Data.Add(new Article
            {
                Title = "Dice Ludo",
                Author = "North America",
                Description = "The American black bear is a medium-sized bear native to North America. It is the continent's smallest and most widely distributed bear species.",
                UrlToImage = "https://www.gstatic.com/webp/gallery3/3_webp_ll.png"

            });
            Data.Add(new Article
            {
                Title = "Dice Ludo",
                Author = "North America",
                Description = "The American black bear is a medium-sized bear native to North America. It is the continent's smallest and most widely distributed bear species.",
                UrlToImage = "https://www.gstatic.com/webp/gallery3/3_webp_ll.png"

            });
            Data.Add(new Article
            {
                Title = "Dice Ludo",
                Author = "North America",
                Description = "The American black bear is a medium-sized bear native to North America. It is the continent's smallest and most widely distributed bear species.",
                UrlToImage = "https://www.gstatic.com/webp/gallery3/3_webp_ll.png"

            });
            Data.Add(new Article
            {
                Title = "Dice Ludo",
                Author = "North America",
                Description = "The American black bear is a medium-sized bear native to North America. It is the continent's smallest and most widely distributed bear species.",
                UrlToImage = "https://www.gstatic.com/webp/gallery3/3_webp_ll.png"

            });
            Data.Add(new Article
            {
                Title = "Dice Ludo",
                Author = "North America",
                Description = "The American black bear is a medium-sized bear native to North America. It is the continent's smallest and most widely distributed bear species.",
                UrlToImage = "https://www.gstatic.com/webp/gallery3/3_webp_ll.png"

            });
        }

        private async Task LoadNewsData()
        {
            ServiceManager serviceManager = new ServiceManager();
            var result = await serviceManager.GetNewsApi();
            if (result?.Status =="ok")
            {
                foreach (var item in result.Articles)
                {
                    Data.Add(item);
                }
            }
        }
    }
}
