using UnityEngine;
using UnityEngine.UI;

namespace Scripts.UI
{
    public class UIManager : MonoBehaviour
    {
        public static UIManager Instance { get; private set; }

        [SerializeField] private GameObject mainMenuContainer;
        [SerializeField] private GameObject settingsMenuContainer;
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
            mainMenuContainer.gameObject.SetActive(false);
            settingsMenuContainer.gameObject.SetActive(true);
        }

        public void OnCloseSettings()
        {
            //Juego se reanuda
            mainMenuContainer.gameObject.SetActive(true);
            settingsMenuContainer.gameObject.SetActive(false);
        }

        #region Music & Sound



        #endregion
    }
}

