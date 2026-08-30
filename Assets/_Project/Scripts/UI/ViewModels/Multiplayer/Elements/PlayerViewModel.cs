using System;
using _Project.Multiplayer;
using Unity.AppUI.MVVM;
using UnityEngine;

namespace _Project.UI.ViewModels.Multiplayer
{
    [ObservableObject]
    public partial class PlayerViewModel
    {
        [ObservableProperty] private Texture _avatar;
        [ObservableProperty] private string _id;
        [ObservableProperty] private string _name;
        [ObservableProperty] private bool _playingSameGame;
        [ObservableProperty] private string _status;

        public PlayerViewModel(PlayerModel player)
        {
            _name = player.Name;
            _avatar = player.Avatar;
            _status = Enum.GetName(player.State.GetType(), player.State);
            _id = player.Id;
            _playingSameGame = player.PlayingSameGame;
        }
    }
}
