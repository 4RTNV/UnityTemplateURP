using UnityEngine;
using UnityEngine.UIElements;

namespace _Project
{
    [UxmlElement]
    public partial class PlayerView : VisualElement
    {
        private readonly Label _name;
        private readonly Image _profilePicture;
        private readonly Label _status;

        public PlayerView()
        {
            var template = Resources.Load<VisualTreeAsset>("UI/Elements/Multiplayer/PlayerView");
            template.CloneTree(this);

            _name = this.Q<Label>("Name");
            _status = this.Q<Label>("Status");
            _profilePicture = this.Q<Image>("ProfilePicture");
        }

        public string Name
        {
            get => _name.text;
            set => _name.text = value;
        }

        public Texture ProfilePicture
        {
            get => _profilePicture.image;
            set => _profilePicture.image = value;
        }

        public string Status
        {
            get => _status.text;
            set => _status.text = value;
        }
    }
}
