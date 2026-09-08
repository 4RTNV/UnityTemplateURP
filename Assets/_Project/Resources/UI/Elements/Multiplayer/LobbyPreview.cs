using System;
using SourceKettle;
using UnityEngine;
using UnityEngine.UIElements;

namespace _Project.UI.ViewModels.Multiplayer
{
    [UxmlElement]
    public partial class LobbyPreview : VisualElement
    {
        [Query] private Label _lobbyName;
        [Query] private Label _lobbyPlayersCount;
        [Query] private Label _lobbyStatus;

        public LobbyPreview()
        {
            var template = Resources.Load<VisualTreeAsset>("UI/Elements/Multiplayer/LobbyPreview");
            template.CloneTree(this);

            BindQueries(this);

            RegisterCallback<ClickEvent>(evt => Clicked?.Invoke());
        }

        public event Action Clicked;

        public string Name
        {
            get => _lobbyName.text;
            set => _lobbyName.text = value;
        }

        public int PlayersCount
        {
            get => Convert.ToInt32(_lobbyPlayersCount.text);
            set => _lobbyPlayersCount.text = value.ToString();
        }

        public string Status
        {
            get => _lobbyStatus.text;
            set => _lobbyStatus.text = value;
        }
    }
}
