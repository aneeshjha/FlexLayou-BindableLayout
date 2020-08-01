using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using PropertyChanged;

namespace DemoFlex_bindable_cntrlTemplate.FlexlayoutSamples.Models
{
    [AddINotifyPropertyChangedInterface]
    public class AnimalGroup 
    {
        public string Names { get;  set; }
        public ObservableCollection<Animal> animals { get; set; }

    }
}
