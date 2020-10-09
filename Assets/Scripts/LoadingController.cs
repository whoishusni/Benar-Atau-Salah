using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadingController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        AdsManagerr ads = new AdsManagerr();
        ads.HideBanner();
        SetupScore.score = 0;
        Health.health = 3;
        StartCoroutine(StartTheGame());
    }

    IEnumerator StartTheGame() {
        yield return new WaitForSeconds(1);
        SceneManager.LoadScene("Gameplay");
    }

   
}
