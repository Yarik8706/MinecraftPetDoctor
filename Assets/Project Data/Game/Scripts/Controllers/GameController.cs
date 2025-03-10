using UnityEngine;
using Watermelon.Store;

namespace Watermelon
{
    public class GameController : MonoBehaviour
    {
        private static GameController instance;
        
        [Header("Refferences")]
        [SerializeField] private LevelController levelController;
        [SerializeField] private PoolManager poolManager;
        [SerializeField] private CurrenciesController currenciesController;
        [SerializeField] private ItemController itemController;
        [SerializeField] private UpgradesController upgradesController;
        [SerializeField] private ParticlesController particlesController;
        [SerializeField] private FloatingTextController floatingTextController;
        [SerializeField] private UIController uiController;
        [SerializeField] private NavigationController navigationController;
        [SerializeField] private TutorialController tutorialController;

        private void Awake()
        {
            instance = this;
            SaveController.Initialise(true);
        }

        private void Start()
        {
            InitialiseGame();
        }

        public void InitialiseGame()
        {
            uiController.Initialise();
            itemController.Initialise();
            currenciesController.Initialise();
            upgradesController.Initialise();
            navigationController.Initialise();
            StoreController.Init();
            levelController.Initialise();
            particlesController.Initialise();
            floatingTextController.Inititalise();
            tutorialController.Initialise();
            uiController.InitialisePages();
            UIController.ShowPage<UIGame>();
            PlayerRatingShower.Instance.Initialise();
            OnGameLoaded();
        }

        public static void OnGameLoaded()
        {
            GameLoading.MarkAsReadyToHide();

            // Unzoom camera
            CameraController.EnableCamera(CameraType.Main);

            instance.levelController.OnGameLoaded();
        }

        public static void Unload(Tween.TweenCallback onSceneUnloaded)
        {
            Tween.RemoveAll();

            ParticlesController.ClearParticles();
            FloatingTextController.Unload();
            NavigationController.Unload();
            TutorialController.Unload();
            ItemController.Unload();

            instance.levelController.UnloadLevel(onSceneUnloaded);
        }

#region Debug
        [Button("Remove Save")]
        private void RemoveSave()
        {
            if(!Application.isPlaying)
            {
                Serializer.DeleteFileAtPDP("save");
            }
        }
#endregion
    }
}