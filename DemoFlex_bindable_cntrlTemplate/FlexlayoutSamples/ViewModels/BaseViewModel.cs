using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using DemoFlex_bindable_cntrlTemplate.FlexlayoutSamples.Views;
using PropertyChanged;
using Xamarin.Forms;

namespace DemoFlex_bindable_cntrlTemplate.FlexlayoutSamples.ViewModels
{
    [AddINotifyPropertyChangedInterface]
    public class BaseViewModel
    {
        public Command BurgerButtonCommand { get; set; }
        public Command Outside_TappedCommand { get; set; }
        public Command Expand_Command { get; set; }
        public Command Navigate_Command { get; set; }
        public Command ChangeThemeCommand { get; set; }
        public bool IsVisibleTapoutside { get; set; }
        public string DisplayedImageGif { get; set; }
        public ObservableCollection<parent> parents { get; set; } = new ObservableCollection<parent>();
        public ObservableCollection<ThemeColor> themeColors { get; set; } = new ObservableCollection<ThemeColor>();
        public BaseViewModel()
        {
            IsVisibleTapoutside = false;
            DisplayedImageGif = string.Empty;
            BurgerButtonCommand = new Command(MenuCommandAsync);
            Outside_TappedCommand = new Command(Outside_TappedCommandAsync);
            Expand_Command = new Command(Expand_CommandAsync);
            Navigate_Command = new Command(Navigate_CommandAsync);
            ChangeThemeCommand = new Command(ChangeThemeCommandAsync);
            LoadHamburgerData();
            LoadFooter();

        }

        private void ChangeThemeCommandAsync(object obj)
        {
            if (obj is ThemeColor theme)
            {
                App.Current.Resources["PrimaryColor"] = (Color)App.Current.Resources[theme.ColorName];
                App.Current.Resources["Black"] = (Color)App.Current.Resources[theme.HeaderName];
            }
        }

        private void LoadFooter()
        {
            themeColors.Add(
                new ThemeColor
                {
                    Color= "#3f4350",
                    ColorName= "MajorColor",
                    HeaderName= "Header"
                }
                );
            themeColors.Add(
                new ThemeColor
                {
                    Color = "#F3AB40",
                    ColorName= "Amber",
                    HeaderName = "SmokyGray"
                }
                );
            themeColors.Add(
                new ThemeColor
                {
                    Color = "#1670b7",
                    ColorName= "PrimaryBlue",
                    HeaderName= "DarkModerateLimeGreen"
                }
                );
            themeColors.Add(
                new ThemeColor
                {
                    Color = "#eeeeee",
                    ColorName= "LightGrey",
                    HeaderName = "SmokyGray"
                }
                );
            themeColors.Add(
                new ThemeColor
                {
                    Color = "#C63742",
                    ColorName= "BrickRed",
                    HeaderName = "SmokyGray"
                }
                );
        }

        private void LoadHamburgerData()
        {
            parents.Add
                (
                new parent()
                {
                    Header = "Header_1",
                    childs = new ObservableCollection<child>()
                    {
                        new child()
                        {
                            Name="FirstPage",
                            subChilds= new ObservableCollection<subChild>()
                            {
                                new subChild()
                                {
                                    SubChildName="SubChild"
                                },
                                new subChild()
                                {
                                    SubChildName="SubChild"
                                }
                            }
                        },
                        new child()
                        {
                            Name="FirstPage",
                            subChilds= new ObservableCollection<subChild>()
                            {
                                new subChild()
                                {
                                    SubChildName="SubChild"
                                },
                                new subChild()
                                {
                                    SubChildName="SubChild"
                                }
                            }
                        }
                    }
                }
                );
            parents.Add
                (
                new parent()
                {
                    Header = "Header_2",
                    childs = new ObservableCollection<child>()
                    {
                        new child()
                    {
                            Name="SecondPage",
                            subChilds= new ObservableCollection<subChild>()
                            {
                                new subChild()
                                {
                                    SubChildName="SubChild"
                                }
                            }
                        }
                    }
                }
                );
            parents.Add
                (
                new parent()
                {
                    Header = "Header_3",
                    childs = new ObservableCollection<child>()
                    {
                        new child()
                    {
                            Name="ThirdPage",
                            subChilds= new ObservableCollection<subChild>()
                            {
                                new subChild()
                                {
                                    SubChildName="SubChild"
                                }
                            }
                        }
                    }
                }
                );
        }

        private async void Navigate_CommandAsync(object obj)
        {
            IsVisibleTapoutside = !IsVisibleTapoutside;
            if (obj is child item)
            {
                switch (item.Name)
                {
                    case "FirstPage": await Application.Current.MainPage.Navigation.PushAsync(new CatalogView(), true);
                        break;
                    case "SecondPage": await Application.Current.MainPage.Navigation.PushAsync(new GalleryView(), true);
                        break;
                    case "ThirdPage":
                        await Application.Current.MainPage.Navigation.PushAsync(new CardView(), true);
                        break;
                    default:
                        break;
                }
            }
        }

        private void Expand_CommandAsync(object obj)
        {
            if (obj is child childitem)
            {
                childitem.isChildExpanded = !childitem.isChildExpanded;
            }
            if (obj is parent item)
            {
                item.isExpanded = !item.isExpanded;
            }
        }

        private void Outside_TappedCommandAsync(object obj)
        {
            IsVisibleTapoutside = !IsVisibleTapoutside;
        }

        private void MenuCommandAsync(object obj)
        {
            IsVisibleTapoutside = !IsVisibleTapoutside;
        }
    }

    [AddINotifyPropertyChangedInterface]
    public class subChild
    {
        public string SubChildName { get; set; }
    }

    [AddINotifyPropertyChangedInterface]
    public class child
    {
        public string Name { get; set; }
        public bool isChildExpanded { get; set; } = false;
        public ObservableCollection<subChild> subChilds { get; set; } = new ObservableCollection<subChild>();
    }

    [AddINotifyPropertyChangedInterface]
    public class parent
    {
        public string Header { get; set; }
        public bool isExpanded { get; set; } = false;
        public ObservableCollection<child> childs { get; set; }= new ObservableCollection<child>();
    }

    [AddINotifyPropertyChangedInterface]
    public class ThemeColor
    {
        public string Color { get; set; }
        public string ColorName { get; set; }
        public string HeaderName { get; set; }
    }
}
