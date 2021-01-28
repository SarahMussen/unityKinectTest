using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }

    private int catchedPoop = 0;
    private int missedPoop = 0;

    private bool winner = false;
    private bool gameEnded = false;

    private int itemsUnlocked = 0;


    //TEST 
    [SerializeField]
    private TextMeshProUGUI missedPoopText;

    //downgrade canvas
    [SerializeField]
    private Slider downgradeSlider;

    //upgrade canvas
    [SerializeField]
    private Slider upgradeSlider;
    [SerializeField]
    private TextMeshProUGUI upgradeText;

    [SerializeField]
    private RawImage[] itemIcons;
    [SerializeField]
    private Texture[] itemTextures;


    //popup canvas
    [SerializeField]
    private Canvas popUpCanvas;
    [SerializeField]
    private RawImage popUp;
    /*  [SerializeField]
        private RawImage popUpImg;
        [SerializeField]
        private TextMeshProUGUI popUpTitle;
        [SerializeField]
        private TextMeshProUGUI popUpText;*/
    [SerializeField]
    private Button popUpButton;

    /*    [SerializeField]
    private string[] itemDescriptions;
    [SerializeField]
    private Texture[] popupImages;*/
    [SerializeField]
    private Texture[] popUps;

    //ending canvas
    [SerializeField]
    private Canvas endingCanvas;
    [SerializeField]
    private RawImage endingImg;
    [SerializeField]
    private TextMeshProUGUI endingTitle;
    [SerializeField]
    private Button endingButton;
    [SerializeField]
    private Texture winnerImg;


    void Awake()
    {
        if (Instance == null) 
        { 
            Instance = this;
        }
    }

    public void addCathedPoop()
    {
        catchedPoop++;

        updateScoreGUI();

        if (catchedPoop == 5)
        {
            itemsUnlocked++;
            openPopUp(itemsUnlocked);
        }
    }

    public void addMissedPoop()
    {
        missedPoop++;
        missedPoopText.text = "missed: " + missedPoop;  //TEST

        if(missedPoop%5 == 0)
        {
            updateDowngradeGUI();
        }
    }

    private void updateScoreGUI()
    {
        upgradeText.text = catchedPoop + "/5";
    }

    private void openPopUp(int itemToUnlock)
    {
        itemIcons[itemToUnlock-1].texture = itemTextures[itemToUnlock-1];
         /*popUpImg.texture = popupImages[itemToUnlock-1];
         popUpText.text = itemDescriptions[itemToUnlock-1];*/

        popUp.texture = popUps[itemToUnlock - 1];
        popUpCanvas.gameObject.SetActive(true);

        Time.timeScale = 0;

        if (itemToUnlock == 4)
        {
            gameEnded = true;
            winner = true;
        }
    }

    private void updateDowngradeGUI()
    {
        downgradeSlider.value = downgradeSlider.value - 25;

        if(downgradeSlider.value == 0)
        {
            gameEnded = true;
            winner = false;
            endGame();
        }

    }

    public void closePopUp()
    {

        if (gameEnded)
        {
            endGame();
        }
        else
        {
            catchedPoop = 0;
            popUpCanvas.gameObject.SetActive(false);
            Time.timeScale = 1;
        }
    }

    private void endGame()
    {
        if (winner)
        {
            endingImg.texture = winnerImg;
            endingTitle.text = "Je hebt gewonnen";
        }

        Time.timeScale = 0;
        endingCanvas.gameObject.SetActive(true);
    }

    public void restartGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
