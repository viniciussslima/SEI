using UnityEngine;
using UnityEngine.SceneManagement;

public class WiinController : MonoBehaviour
{
    public void GoToMenu()
    {
        SceneManager.LoadScene("Menu");
    }
}
