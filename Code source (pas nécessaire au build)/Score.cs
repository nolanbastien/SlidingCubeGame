using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] Transform playerTransform;
    [SerializeField] PlayerControl player;
    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] float forceIncreasePlayer = 1.0005f;
    [SerializeField] int scoreStepForIncreaseForce = 10;
    [SerializeField] bool increasePlayerForce = true;
    private int score = 0;
    private float initialForce;

    private void Start() {
        initialForce = player.forwardForce;
    }

    void Update()
    {
        score = (int) playerTransform.position.z / 10;
        scoreText.text = score.ToString();

        if (score % scoreStepForIncreaseForce == 0 && score != 0 && increasePlayerForce)
        {
            player.forwardForce = forceIncreasePlayer * initialForce * (1.0f - (float)Mathf.Exp(- score / 50.0f) ) + initialForce;
            Debug.Log(player.forwardForce);
        }
    }
}
