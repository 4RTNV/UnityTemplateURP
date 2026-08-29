using System;
using UnityEngine;
using UnityEngine.UIElements;

namespace _Project.UI.Elements
{
    [UxmlElement]
    public partial class LobbyPreview : VisualElement
    {
        private readonly Label _lobbyName;
        private readonly Label _lobbyPlayersCount;
        private readonly Label _lobbyStatus;

        public LobbyPreview()
        {
            var template = Resources.Load<VisualTreeAsset>("UI/Elements/Multiplayer/LobbyPreview");
            template.CloneTree(this);
            _lobbyName = this.Q<Label>("Name");
            _lobbyStatus = this.Q<Label>("Status");
            _lobbyPlayersCount = this.Q<Label>("PlayersCount");

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
