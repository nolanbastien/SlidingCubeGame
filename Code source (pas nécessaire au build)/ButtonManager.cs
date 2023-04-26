using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonManager : MonoBehaviour
{

    public void LoadScene(string sceneName)
    {
        Debug.Log("Clicked!");
        SceneManager.LoadScene(sceneName);
    }
}