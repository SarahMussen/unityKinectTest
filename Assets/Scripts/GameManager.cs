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
    [SerializeField]
    private Button popUpButton;
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

    //unlocked items
    [SerializeField]
    private GameObject farmerBody;
    [SerializeField]
    private GameObject farmerLegLeft;
    [SerializeField]
    private GameObject farmerLegRight;
    [SerializeField]
    private Material blue;

    [SerializeField]
    private GameObject toilet;
    [SerializeField]
    private GameObject toiletPaper;
    [SerializeField]
    private GameObject cowPot;

    //renderers
    private Renderer rendBody;
    private Renderer rendLegLeft;
    private Renderer rendLegRight;


    void Awake()
    {
        if (Instance == null) 
        { 
            Instance = this;
        }
    }

    void Start()
    {
        rendBody = farmerBody.GetComponent<Renderer>();
        rendLegLeft = farmerLegLeft.GetComponent<Renderer>();
        rendLegRight = farmerLegRight.GetComponent<Renderer>();
        rendBody.enabled = true;
        rendLegLeft.enabled = true;
        rendLegRight.enabled = true;
    }

    public int getCatchedPoop()
    {
        return catchedPoop;
    }

    public int getMissedPoop()
    {
        return missedPoop;
    }

    /// <summary>
    /// increases the catchedPoop score with 1
    /// calls the updateScoreGUI function
    /// if the catchedPoop score equals 5, it increases the itemsUnlocked value en calls the openPopUp function
    /// </summary>
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
        upgradeSlider.value++;
        itemIcons[itemToUnlock-1].texture = itemTextures[itemToUnlock-1];

        popUp.texture = popUps[itemToUnlock - 1];
        popUpCanvas.gameObject.SetActive(true);

        Time.timeScale = 0;

        if (itemToUnlock == 1)
        {
            var matsBody = rendBody.materials;
            matsBody[1] = blue;
            rendBody.materials = matsBody;

            var matsLegLeft = rendLegLeft.materials;
            matsLegLeft[0] = blue;
            rendLegLeft.materials = matsLegLeft;

            var matsLegRight = rendLegRight.materials;
            matsLegRight[0] = blue;
            rendLegRight.materials = matsLegRight;
        }

        if(itemToUnlock == 2)
        {
            toilet.SetActive(true);
        }

        if (itemToUnlock == 3)
        {
            toiletPaper.SetActive(true);
        }

        if (itemToUnlock == 4)
        {
            cowPot.SetActive(true);
            gameEnded = true;
            winner = true;
        }
    }

    private void updateDowngradeGUI()
    {
        downgradeSlider.value = downgradeSlider.value - 1;

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
        popUpCanvas.gameObject.SetActive(false);
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
