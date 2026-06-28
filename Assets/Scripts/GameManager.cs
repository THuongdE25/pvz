using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    [SerializeField]private GameObject main;
    [SerializeField]private GameObject lose;
    [SerializeField]private GameObject win;
    [SerializeField]private GameObject pause;
    [SerializeField] private GameObject cutGrassPrefabs;
    [SerializeField] private Transform[] cutPos;
    private void Awake() {
        Instance=this;
    }
    void Start()
    {
        main.SetActive(true);
        lose.SetActive(false);
        win.SetActive(false);
        pause.SetActive(false);
    }
    public void restartGame()
    {
        Time.timeScale=1;

        Plants[]plants=FindObjectsByType<Plants>(FindObjectsSortMode.None);
        foreach(Plants plant in plants)
        {
            plant.Die();
        }
        Zombies[]zombies=FindObjectsByType<Zombies>(FindObjectsSortMode.None);
        foreach(Zombies zombie in zombies)
        {
            Destroy(zombie.gameObject);
        }
        CutGrass[]cutgrass=FindObjectsByType<CutGrass>(FindObjectsSortMode.None);
        foreach(CutGrass cutGrass in cutgrass)
        {
            Destroy(cutGrass.gameObject);
        }
        Sun[]suns=FindObjectsByType<Sun>(FindObjectsSortMode.None);
        foreach(Sun sun in suns)
        {
            Destroy(sun.gameObject);
        }

        SunManager.Instance.SetCurrentSun(SunManager.Instance.startSun);
        ZombiesManager.Instance.restartSpawn();
        spawnCutGrass();
        main.SetActive(false);
        lose.SetActive(false);
        win.SetActive(false);
        pause.SetActive(false);
    }
    public void startGame()
    {
        restartGame();
    }
    public void resumeGame()
    {
        Time.timeScale=1;
        main.SetActive(false);
        lose.SetActive(false);
        win.SetActive(false);
        pause.SetActive(false);
    }
    public void mainMenu()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void loseMenu()
    {
        Time.timeScale=0;
        main.SetActive(false);
        lose.SetActive(true);
        win.SetActive(false);
        pause.SetActive(false);
    }
    public void winMenu()
    {
        Time.timeScale=0;
        main.SetActive(false);
        lose.SetActive(false);
        win.SetActive(true);
        pause.SetActive(false);
    }
    public void pauseMenu()
    {
        Time.timeScale=0;
        main.SetActive(false);
        lose.SetActive(false);
        win.SetActive(false);
        pause.SetActive(true);
    }
    public void QuitGame()
    {
        Application.Quit();
    }
    public void spawnCutGrass()
    {
        for(int i = 0; i < cutPos.Length; i++)
        {
            Instantiate(cutGrassPrefabs,cutPos[i].position,Quaternion.identity);
        }
    }
}
