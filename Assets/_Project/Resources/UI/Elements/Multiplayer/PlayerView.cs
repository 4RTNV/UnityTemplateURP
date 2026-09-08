using SourceKettle;
using UnityEngine;
using UnityEngine.UIElements;

namespace _Project.UI.Views.Elements
{
    [UxmlElement]
    public partial class PlayerView : VisualElement
    {
        [Query] private Label _name;
        [Query] private Image _profilePicture;
        [Query] private Label _status;

        public PlayerView()
        {
            var template = Resources.Load<VisualTreeAsset>("UI/Elements/Multiplayer/PlayerView");
            template.CloneTree(this);

            BindQueries(this);
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
