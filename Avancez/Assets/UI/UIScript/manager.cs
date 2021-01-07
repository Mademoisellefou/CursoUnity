using UnityEngine;
using UnityEngine.SceneManagement;

public class manager : MonoBehaviour
{
    public bool fading;
    public GameObject StartMenu,
    GameOverMenu,
    VictoryMenu,
    missionPanel,
    Settings;
    public float fadespeed;
    public static bool gameOver ,
    victory ;


    public static manager _instance;
    void Awake()
    {
        if (_instance == null)
        {
            _instance = this;
        }
        else
        {
            Destroy(this);
        }
    }




        void Start()
    {

        Time.timeScale = 0;
        gameOver = false;
        victory = false;
        StartMenu.SetActive(true);
        GameOverMenu.SetActive(false);
        VictoryMenu.SetActive(false);
        Settings.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver && !GameOverMenu.activeSelf)
        {
            missionPanel.SetActive(false);
            GameOverMenu.SetActive(true);
        }
        if (victory && !VictoryMenu.activeSelf)
        {
            missionPanel.SetActive(false);
            VictoryMenu.SetActive(true);
        }
        if (fading && StartMenu.GetComponent<CanvasGroup>().alpha > 0)
        {
            StartMenu.GetComponent<CanvasGroup>().alpha -= Time.deltaTime * fadespeed;
        }
        else if (!victory&&!gameOver&&StartMenu.GetComponent<CanvasGroup>().alpha <= 0)
        {
            //remove start panel when alpha is 0
            fading = false;
            StartMenu.SetActive(false);
            missionPanel.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.D)) {
            victory = true;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            gameOver = true;
        }
    }
    public void restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    public void startGame()
    {
        //set timescale to normal and start fading out
        Time.timeScale = 1;
        fading = true;

    }

    public void endGame()
    {
        //end game
        Application.Quit();
    }
    //public void closeSettingsMenu()
    //{
    //    if (!multiplayer)
    //    {
    //        Time.timeScale = 1;
    //    }
    //    settingsMenu.SetActive(false);
    //}
}
