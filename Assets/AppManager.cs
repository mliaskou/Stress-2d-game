using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;

public class AppManager : MonoBehaviour
{
    public static AppManager s_Instance;
    private UIController _uiController;
    public UIController _UIController { get => _uiController; }

    private InformationStatusScreen _informationStatusScreen;
    public InformationStatusScreen _InformationStatusScreen { get => _informationStatusScreen; }

    [Header("Referencies")]
    [SerializeField] Player _player;
    public bool _InitialisationHasCompleted;
    IEnumerator Start()
    {
        if (s_Instance == null)
        {
            s_Instance = this;
        }
        yield return InitializeInformationStatusScreen();
        yield return InitializeUI();
        yield return InitializePlayer();

        _InitialisationHasCompleted = true;
        _uiController.SetTimeScreen();
    }

    private IEnumerator InitializeInformationStatusScreen()
    {
        yield return AddressablesLoader.LoadAddressablesAsync("InformationStatusScreen",
          (gameObjectAsyncOperationHandle) =>
          {
              GameObject informationScreen = Instantiate((GameObject)gameObjectAsyncOperationHandle.Result);

              _informationStatusScreen = informationScreen.GetComponent<InformationStatusScreen>();
          });
    }
    private IEnumerator InitializePlayer()
    {
        yield return _player.InitializePlayer(_uiController);
    }
    private IEnumerator InitializeUI()
    {
        yield return AddressablesLoader.LoadAddressablesAsync("FirstSceneUICanvas",
         (gameObjectAsyncOperationHandle) =>
         {
             GameObject controller = Instantiate((GameObject)gameObjectAsyncOperationHandle.Result);
             _uiController = controller.GetComponent<UIController>();
         });
        yield return _uiController.InitializeUIController(_informationStatusScreen);
    }


    public void ReloadScenePanel()
    {
        //reloadScenePanel.SetActive(true);
    }
    public void ReloadScene()
    {
        SceneManager.LoadScene("SampleScene");
    }

    public void GameQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }

    public void PanelBeforeTheNextScene()
    {
        //panelBeforeTheNextScene.SetActive(true);
    }

}
