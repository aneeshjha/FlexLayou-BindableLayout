using System;
using DemoFlex_bindable_cntrlTemplate.Effects;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ResolutionGroupName("DemoFlex_bindable_cntrlTemplate")]
[assembly: ExportEffect(typeof(DemoFlex_bindable_cntrlTemplate.Droid.Effects.ViewShadowEffect), "ViewShadowEffect")]
namespace DemoFlex_bindable_cntrlTemplate.Droid.Effects
{
    public class ViewShadowEffect : PlatformEffect
    {
        protected override void OnAttached()
        {
            try
            {
                var control = Control ?? Container as Android.Views.View;

                double radius = ShadowEffect.GetRadius(Element);

                control.StateListAnimator = null;

                control.Elevation = (float)radius;

                control.SetBackgroundColor(Android.Graphics.Color.SandyBrown);

                control.TranslationZ = (float)((ShadowEffect.GetDistanceX(Element) + ShadowEffect.GetDistanceY(Element)) / 2);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Cannot set property on attached control. Error: {0}", ex.Message);
            }
        }

        protected override void OnDetached()
        {
        }
    }
}
