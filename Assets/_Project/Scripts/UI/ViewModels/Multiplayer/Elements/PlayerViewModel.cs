using System;
using _Project.Multiplayer;
using Unity.AppUI.MVVM;
using UnityEngine;

namespace _Project.UI.ViewModels.Multiplayer
{
    [ObservableObject]
    public partial class PlayerViewModel
    {
        [ObservableProperty] private readonly Texture _avatar;
        [ObservableProperty] private readonly string _id;
        [ObservableProperty] private readonly bool _playingSameGame;
        [ObservableProperty] private readonly string _status;
        [ObservableProperty] private string _name;

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
