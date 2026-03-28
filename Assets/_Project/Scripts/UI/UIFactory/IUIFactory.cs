using _Project.UI.Views;

namespace _Project.UI.Services.Factory
{
    public interface IUIFactory 
    {
        void CreateUIRoot();
        TView CreateViewWithInjection<TView>() where TView : View;
    }
}