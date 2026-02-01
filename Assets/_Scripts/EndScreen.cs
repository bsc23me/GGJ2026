using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreen : MonoBehaviour
{

    public void BackToMainMenu()
    {
        SceneManager.LoadScene(1);
    }
}
