using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour
{
    public static bool firstLoad = true;

    public GameManager gameManager;

    public GameObject playButton;


    Animator scoreAnimator;
    bool hasCheckedGameOver = false;




    public void HandlePlayButton()
    {
        if (!firstLoad)
        {
            StartCoroutine(Restart());
        }
        else
        {
            gameManager.CreateBall();
            firstLoad = false;
        }
        playButton.SetActive(false);
    }



    IEnumerator Restart()
    {
        yield return new WaitForSeconds(0.2f);
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
