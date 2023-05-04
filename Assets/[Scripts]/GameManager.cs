using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public List<Item> items = new List<Item>();

    public GameObject panel;

    public TextMeshProUGUI totalScoreTxt;
    public int TotalScore;

    public AudioClip audioClip;
    public AudioSource audioSource;

    public InputManager inputManager;
    public MouseController mouseController;
    public MouseLook mouseLook;
    public PlayerController playerController;


    public static GameManager instance;

    private void Awake()
    {
        instance = this;
    }
    public void SuccessSound()
    {
        audioSource.PlayOneShot(audioClip);
    }
    public void ScoreDisplay()
    {
        foreach (var item in items)
        {
            TotalScore += item.itemScore;
        }
        Enabled();
        totalScoreTxt.text = "SCORE :" + TotalScore.ToString();
    }
    public void FinalState()
    {
       
        ScoreDisplay();
        panel.SetActive(true);

    }
    public void RestartButtonOnClick()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Enabled()
    {
        inputManager.enabled = false;
        mouseController.enabled = false;
        mouseLook.enabled = false;
        playerController.enabled = false;
    }
}
