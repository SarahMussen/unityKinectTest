﻿using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }

    private int catchedPoop = 0;
    private int missedPoop = 0;

    private bool winner = false;
    private bool gameEnded = false;

    [SerializeField]
    private TextMeshProUGUI catchedPoopText;
    [SerializeField]
    private TextMeshProUGUI missedPoopText;


    [SerializeField]
    private Slider upgradeSlider;
    [SerializeField]
    private Slider downgradeSlider;
    [SerializeField]
    private TextMeshProUGUI upgradeText;
    [SerializeField]
    private TextMeshProUGUI downgradeText;


    [SerializeField]
    private RawImage firstItemImg;
    [SerializeField]
    private Texture firstItemTexture;
    [SerializeField]
    private RawImage secondItemImg;
    [SerializeField]
    private Texture secondItemTexture;
    [SerializeField]
    private RawImage thirdItemImg;
    [SerializeField]
    private Texture thirdItemTexture;
    [SerializeField]
    private RawImage fourthItemImg;
    [SerializeField]
    private Texture fourthItemTexture;

    [SerializeField]
    private RawImage firstEnvironmentImg;
    [SerializeField]
    private Texture firstEnvironmentTexture;
    [SerializeField]
    private RawImage secondEnvironmentImg;
    [SerializeField]
    private Texture secondEnvironmentTexture;
    [SerializeField]
    private RawImage thirdEnvironmentImg;
    [SerializeField]
    private Texture thirdEnvironmentTexture;
    [SerializeField]
    private RawImage fourthEnvironmentImg;
    [SerializeField]
    private Texture fourthEnvironmentTexture;

    [SerializeField]
    private Canvas popUpCanvas;
    [SerializeField]
    private RawImage popUpImg;
    [SerializeField]
    private TextMeshProUGUI popUpTitle;
    [SerializeField]
    private TextMeshProUGUI popUpText;
    [SerializeField]
    private Button popUpButton;

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

    /// <summary>
    /// adds one to the catched variable when the player catches a poop
    /// </summary>
    public void addCathedPoop()
    {
        catchedPoop++;
        catchedPoopText.text = "score: " + catchedPoop;
        updateUpgradeGUI();

        if(catchedPoop == 20)
        {
            winner = true;
        }
    }


    /// <summary>
    /// adds one to the missedPoop variable when the player misses a poop
    /// </summary>
    public void addMissedPoop()
    {
        missedPoop++;
        missedPoopText.text = "missed: " + missedPoop;
        updateDowngradeGUI();
    }

    /// <summary>
    /// Updates the upgrade gui depending on how much catched poop;
    /// Changes the slider, the text and the image
    /// </summary>
    private void updateUpgradeGUI()
    {
        switch (catchedPoop)
        {
            case 5:
                upgradeSlider.value = 25;
                upgradeText.text = "1/4 items gevonden";
                firstItemImg.texture = firstItemTexture;

                openPopUp(firstItemTexture, "Je hebt genoeg mest verzameld om je allereerste item te maken, namelijk een t-shirt!");
                break;
            case 10:
                upgradeSlider.value = 50;
                upgradeText.text = "2/4 items gevonden";
                secondItemImg.texture = secondItemTexture;

                openPopUp(secondItemTexture, "Je hebt genoeg mest verzameld om een tweede item te maken, namelijk een cowpot!");

                break;
            case 15:
                upgradeSlider.value = 75;
                upgradeText.text = "3/4 items gevonden";
                thirdItemImg.texture = thirdItemTexture;

                openPopUp(thirdItemTexture, "Je hebt genoeg mest verzameld om een derde item te maken, namelijk een merdapot!");

                break;
            case 20:
                upgradeSlider.value = 100;
                upgradeText.text = "4/4 items gevonden";
                fourthItemImg.texture = fourthItemTexture;
                gameEnded = true;
                openPopUp(fourthItemTexture, "Je hebt genoeg mest verzameld om een vierde item te maken, namelijk wc papier!");
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// Updates the downgrade gui depending on how much missed poop;
    /// Changes the slider, the text and the image
    /// </summary>
    private void updateDowngradeGUI()
    {
        switch (missedPoop)
        {
            case 5:
                downgradeSlider.value = 75;
                downgradeText.text = "75% omgeving";
                firstEnvironmentImg.texture = firstEnvironmentTexture;
                break;
            case 10:
                downgradeSlider.value = 50;
                downgradeText.text = "50% omgeving";
                secondEnvironmentImg.texture = secondEnvironmentTexture;
                break;
            case 15:
                downgradeSlider.value = 25;
                downgradeText.text = "25% omgeving";
                thirdEnvironmentImg.texture = thirdEnvironmentTexture;
                break;
            case 20:
                downgradeSlider.value = 0;
                downgradeText.text = "0% omgeving";
                fourthEnvironmentImg.texture = fourthEnvironmentTexture;
                gameEnded = true;
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// A popup is shown with a certain image, title and text. When the popup opens, the game is paused
    /// </summary>
    /// <param name="img">The texture that needs to be shown in the popup</param>
    /// <param name="detailText">The explanation of the unlocked item/environmental change</param>
    private void openPopUp(Texture img, string detailText)
    {
        popUpImg.texture = img;
        popUpText.text = detailText;
        popUpCanvas.gameObject.SetActive(true);

        Time.timeScale = 0;
    }

    /// <summary>
    /// close popUp canvas and continues game. 
    /// has to be publid so the button can access the function
    /// </summary>
    public void closePopUp()
    {
        popUpCanvas.gameObject.SetActive(false);

        if (gameEnded)
        {
            endGame();
        } else
        {
            Time.timeScale = 1;
        }
    }

    /// <summary>
    /// changes the ending popup if the player is the winner, pauses the game en shows the ending popup
    /// </summary>
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

    /// <summary>
    /// restarts the game
    /// </summary>
    public void restartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
