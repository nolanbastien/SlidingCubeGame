using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;
using TMPro;

public class GameManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI tryAgainText;
    [SerializeField] TextMeshProUGUI victoryText;
    private bool gameEnded = false;

    private void OnEnable() {
        
        GameObject[] mainMenuMusicObj = GameObject.FindGameObjectsWithTag("MenuMusic");

        if (mainMenuMusicObj.Length > 0) Destroy(mainMenuMusicObj[0]);

    }

    public void EndGameLost() 
    {
        if (!gameEnded)
        {   
            gameEnded = true;
            Debug.Log("GameOver");

            StartCoroutine(waitToRestart());            
        }
    }

    public void EndGameVictory() 
    {
        if (!gameEnded)
        {   
            Debug.Log("You Won!");
            gameEnded = true;
            StartCoroutine(waitToGoBackToMainMenu());  
        }
    }

    public void ReturnToSelectLevel() 
    {
        SceneManager.LoadScene("Level Selector");
    }


    private IEnumerator waitToRestart()
    {
        tryAgainText.enabled = true;
        while(!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }
        tryAgainText.enabled = false;
        Restart();
    }

    private IEnumerator waitToGoBackToMainMenu()
    {
        victoryText.enabled = true;
        while(!Input.GetKeyDown(KeyCode.Space))
        {
            yield return null;
        }
        victoryText.enabled = false;
        loadMainMenu();
    }

    void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    void loadMainMenu()
    {
        Debug.Log("Load main menu");
        SceneManager.LoadScene("Level Selector");
    }
}
