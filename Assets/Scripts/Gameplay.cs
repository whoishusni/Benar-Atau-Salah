using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using System;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Gameplay : MonoBehaviour
{
    public AudioClip correctClip;
    public AudioClip wrongClip;
    private AudioSource audioSource;
    public Text factText;
    public Text answerText;
    public Text scoreText;
    public Text healtText;
    public Text timerText;
    private float timer;
    public Facts[] facts;
    private static List<Facts> factList = new List<Facts>();
    private Facts currentFacts;
    private bool isClicked;
    private bool temporaryTimer;

   
    void Start()
    {
        temporaryTimer = false;
        timer = 15;
        isClicked = false;
        scoreText.text = ": " + SetupScore.score;
        healtText.text = ": " + Health.health;
        audioSource = GetComponent<AudioSource>();
        if (factList == null || factList.Count == 0) {
            factList = facts.ToList<Facts>();
        }
        SetFacts();
        Debug.Log(currentFacts.fact + "=" + currentFacts.isTrue);

    }

    void Update()
    {
        timer -= Time.deltaTime;
        timerText.text = Mathf.RoundToInt(timer).ToString();
        if (timer <= 0)
        {
            audioSource.PlayOneShot(wrongClip);
            StartCoroutine(TimesUp());
        }
    }

    IEnumerator StartNextFacts()
    {
        isClicked = false;
        factList.Remove(currentFacts);
        yield return new WaitForSeconds(3);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);

    }

    IEnumerator TimesUp() {

        isClicked = false;
        factList.Remove(currentFacts);
        yield return new WaitForSeconds(0);
        Health.health -= 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        if (Health.health <= 0)
        {
            SceneManager.LoadScene(sceneBuildIndex: 3);
        }

    }

    private void SetFacts()
    {
        int indexFacts = UnityEngine.Random.Range(0, factList.Count);
        currentFacts = factList[indexFacts];
        factText.text = currentFacts.fact;
       
    }

    

    public void IfUserSelectTrue() {
        isClicked = true;
        temporaryTimer = true;
        if (isClicked && temporaryTimer) {
            timer = 15f;
            if (currentFacts.isTrue)
            {
                IfTrueAnswer();
            }
            else
            {
                IfFalseAnswer();
            }
        }
        StartCoroutine(StartNextFacts());
    }

    public void IfUserSelectFalse() {
        isClicked = true;
        temporaryTimer = true;
        if (isClicked && temporaryTimer)
        {
            timer = 15f;
            if (!currentFacts.isTrue)
            {
                IfTrueAnswer();
            }
            else
            {
                IfFalseAnswer();
            }
        }
        StartCoroutine(StartNextFacts());
    }
    public void IfTrueAnswer() {
        Debug.Log("Benar");
        audioSource.PlayOneShot(correctClip,3f);
        answerText.text = currentFacts.trueAnswer;
        SetupScore.score += 10;
        scoreText.text = ": " + SetupScore.score;
    }

    public void IfFalseAnswer() {
        Debug.Log("Salah");
        audioSource.PlayOneShot(wrongClip,1f);
        answerText.text = currentFacts.falseAnswer;
        SetupScore.score -= 5;
        Health.health -= 1;
        scoreText.text = ": " + SetupScore.score;
        healtText.text = ": " + Health.health;

        if (Health.health <= 0) {
            SceneManager.LoadScene(sceneBuildIndex:3);
        }
    }
}
