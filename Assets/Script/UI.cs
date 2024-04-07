using UnityEngine;
using UnityEngine.SceneManagement;

public class UI : MonoBehaviour
{
    [SerializeField] GameObject addPlayer;
    [SerializeField] GameObject startMatch;
    [SerializeField] GameObject selectTeam;
    [SerializeField] GameObject mainMenu;

    public void LoadScene(int sceneId)
    {
        LoadScene((Scene)sceneId);
    }

    public void LoadScene(Scene scene)
    {
        var gameObj = scene switch
        {
            Scene.AddPlayer => addPlayer,
            Scene.StartMatch => startMatch,
            Scene.MainMenu => mainMenu,
            Scene.SelectMatch => selectTeam,
            _ => mainMenu,
        };

        addPlayer.SetActive(false);
        startMatch.SetActive(false);
        mainMenu.SetActive(false);
        selectTeam.SetActive(false);

        gameObj.SetActive(true);
    }

    public void RestartScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public enum Scene
    {
        AddPlayer = 1,
        StartMatch = 2,
        SelectMatch = 3,
        MainMenu = 0
    }
}