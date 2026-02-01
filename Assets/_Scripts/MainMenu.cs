using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{

    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject optionsMenu;

    [SerializeField] private Button startGameButton;
    [SerializeField] private Button optionsButton;
    [SerializeField] private Button quitButton;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        startGameButton.onClick.AddListener(delegate { SceneManager.LoadScene(2); /*AudioManager.Instance.StartGame();*/ });
        quitButton.onClick.AddListener(delegate { Application.Quit(); });
    }
}
