using Code.GameManager;
using UnityEngine;

namespace Code.UI.View
{
    public class UIViewSettings : MonoBehaviour, IUIViewSettings
    {
        private IGameManager gameManager;

        void Awake()
        {
            gameManager = FindObjectOfType<GameManager.GameManager>();
        }
        
        public void SelectAIType(bool honest)
        {
            gameManager.ActivateHonestAI(honest);
        }

        public void SelectAIDishonestyLevel(float dishonestyLevel)
        {
            gameManager.SetOpponentAIDishonesty(dishonestyLevel);
        }

        public void CloseSettingsPanel()
        {
            gameObject.SetActive(false);
        }

        public void OpenSettingsPanel()
        {
            gameObject.SetActive(true);
        }
    }
}
