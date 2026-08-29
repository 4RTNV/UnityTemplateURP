using System;
using UnityEngine.UIElements;

namespace _Project.UI._Project.Scripts.UI.ViewModels.Multiplayer
{
    public class FriendsViewModel : INotifyBindablePropertyChanged
    {
        public event EventHandler<BindablePropertyChangedEventArgs> propertyChanged;
    }
}
