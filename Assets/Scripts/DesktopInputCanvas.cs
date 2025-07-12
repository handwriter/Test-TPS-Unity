using UnityEngine;

namespace DefaultNamespace
{
    public class DesktopInputCanvas : MonoBehaviour
    {
        [SerializeField] private GameObject _watchAdLabel;

        public void SendEvent(string eventName)
        {
            switch (eventName)
            {
                case "show_survive_ad": _watchAdLabel.SetActive(true); break;
                case "hide_survive_ad": _watchAdLabel.SetActive(false); break;
            }
        }
    }
}