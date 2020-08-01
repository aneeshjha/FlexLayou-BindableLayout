using PropertyChanged;

namespace DemoFlex_bindable_cntrlTemplate.FlexlayoutSamples.Models
{
    [AddINotifyPropertyChangedInterface]
    public class Animal
    {
        public string Name { get; set; }
        public string Location { get; set; }
        public string Details { get; set; }
        public string ImageUrl { get; set; }
        public string Color { get; set; }
        public float basis { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}
