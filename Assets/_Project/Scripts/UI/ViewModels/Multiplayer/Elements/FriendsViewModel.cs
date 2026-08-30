using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using _Project.Multiplayer;
using Unity.AppUI.MVVM;
using UnityEngine;

namespace _Project.UI.ViewModels.Multiplayer
{
    [ObservableObject]
    public sealed partial class FriendsViewModel
    {
        private readonly IFriendsCatalog _catalog;

        [ObservableProperty] private ObservableCollection<PlayerViewModel> _friends = new();

        public FriendsViewModel(IFriendsCatalog catalog)
        {
            _catalog = catalog;
            LoadFriendsCommand = new AsyncRelayCommand(LoadFriendsAsync);
            LoadFriendsCommand.Execute(null);
        }

        private IAsyncRelayCommand LoadFriendsCommand { get; }

        private async Task LoadFriendsAsync()
        {
            try
            {
                await foreach (var player in _catalog.GetFriendsAsync())
                    Friends.Add(new PlayerViewModel(player));
            }
            catch (Exception e)
            {
                Debug.LogError($"Failed to load friends: {e.Message}");
            }
        }
    }
}
