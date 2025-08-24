using UnityEngine;
using UnityEngine.UI;

namespace Scripts.UI
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance { get; private set; }

        [SerializeField] private Canvas mainMenuContainer;
        [SerializeField] private Canvas settingsMenuContainer;
        [SerializeField] private Button soundButton;
        [SerializeField] private Button musicButton;

        [SerializeField] private Button closeSettingsButton;

        private void Awake()
        {
            if (Instance != null && Instance != this)
            {
                Destroy(this);
            }
            else
            {
                Instance = this;
            }
        }

        private void OnEnable()
        {
            AddListenersOnButtons();
        }

        private void OnDisable()
        {
            RemoveListeners();
        }

        private void Start()
        {

        }

        #region Listeners

        private void AddListenersOnButtons()
        {
            closeSettingsButton.onClick.AddListener(OnCloseSettings);
        }

        private void RemoveListeners()
        {
            closeSettingsButton.onClick.RemoveListener(OnCloseSettings);
        }

        #endregion

        public void OnActiveSettings()
        {
            //Juego se pausa
            settingsMenuContainer.gameObject.SetActive(true);
        }

        public void OnCloseSettings()
        {
            //Juego se reanuda
            settingsMenuContainer.gameObject.SetActive(false);
        }

        #region Music & Sound



        #endregion
    }
}

