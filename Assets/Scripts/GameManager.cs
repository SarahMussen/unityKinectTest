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

    //environment
    [SerializeField]
    private GameObject tree1;
    [SerializeField]
    private GameObject tree2;
    [SerializeField]
    private GameObject tree3;
    [SerializeField]
    private GameObject tree4;
    [SerializeField]
    private GameObject tree5;
    [SerializeField]
    private GameObject tree6;
    [SerializeField]
    private Material applesBad;
    [SerializeField]
    private Material treeBad;
    [SerializeField]
    private Material treeTrunkBad;

    [SerializeField]
    private GameObject flowerRed1;
    [SerializeField]
    private GameObject flowerRed2;
    [SerializeField]
    private GameObject flowerPurple3;
    [SerializeField]
    private GameObject flowerPurple4;
    [SerializeField]
    private GameObject flowerPink5;
    [SerializeField]
    private GameObject flowerPink6;
    [SerializeField]
    private Material flowerCenterBad;
    [SerializeField]
    private Material flowerStemBad;
    [SerializeField]
    private Material flowerRedLeafBad;
    [SerializeField]
    private Material flowerPinkLeafBad;
    [SerializeField]
    private Material flowerPurpleLeafBad;

    [SerializeField]
    private GameObject plane;
    [SerializeField]
    private Material grassBad;
    [SerializeField]
    private Material waterBad;

    [SerializeField]
    private GameObject airFarmer;
    [SerializeField]
    private GameObject airCow;

    //renderers
    private Renderer rendBody;
    private Renderer rendLegLeft;
    private Renderer rendLegRight;

    private Renderer rendAppleTree1;
    private Renderer rendAppleTree2;
    private Renderer rendTree3;
    private Renderer rendTree4;
    private Renderer rendTree5;
    private Renderer rendTree6;

    private Renderer rendRedFlower1;
    private Renderer rendRedFlower2;
    private Renderer rendPurpleFlower3;
    private Renderer rendPurpleFlower4;
    private Renderer rendPinkFlower5;
    private Renderer rendPinkFlower6;

    private Renderer rendPlane;
/*    private Renderer rendAirFarmer;
    private Renderer rendAirCow;*/

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

        rendAppleTree1 = tree1.GetComponent<Renderer>();
        rendAppleTree2 = tree2.GetComponent<Renderer>();
        rendTree3 = tree3.GetComponent<Renderer>();
        rendTree4 = tree4.GetComponent<Renderer>();
        rendTree5 = tree5.GetComponent<Renderer>();
        rendTree6 = tree6.GetComponent<Renderer>();

        rendRedFlower1 = flowerRed1.GetComponent<Renderer>();
        rendRedFlower2 = flowerRed2.GetComponent<Renderer>();
        rendPurpleFlower3 = flowerPurple3.GetComponent<Renderer>();
        rendPurpleFlower4 = flowerPurple4.GetComponent<Renderer>();
        rendPinkFlower5 = flowerPink5.GetComponent<Renderer>();
        rendPinkFlower6 = flowerPink6.GetComponent<Renderer>();

        rendPlane = plane.GetComponent<Renderer>();

/*        rendAirFarmer = airFarmer.GetComponent<Renderer>();
        rendAirCow = rendAirCow.GetComponent<Renderer>();*/
    }

    public int getCatchedPoop()
    {
        return catchedPoop;
    }

    public int getMissedPoop()
    {
        return missedPoop;
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

        switch (downgradeSlider.value)
        {
            //bloemen en gras
            case 3:
                var matsRedFlower = rendRedFlower1.materials;
                var matsPinkFlower = rendPinkFlower5.materials;
                var matsPurpleFlower = rendPurpleFlower3.materials;

                matsRedFlower[0] = flowerRedLeafBad;
                matsRedFlower[1] = flowerCenterBad;
                matsRedFlower[2] = flowerStemBad;

                rendRedFlower1.materials = matsRedFlower;
                rendRedFlower2.materials = matsRedFlower;

                matsPurpleFlower[0] = flowerPurpleLeafBad;
                matsPurpleFlower[1] = flowerCenterBad;
                matsPurpleFlower[2] = flowerStemBad;

                rendPurpleFlower3.materials = matsPurpleFlower;
                rendPurpleFlower4.materials = matsPurpleFlower;

                matsPinkFlower[0] = flowerPinkLeafBad;
                matsPinkFlower[1] = flowerCenterBad;
                matsPinkFlower[2] = flowerStemBad;

                rendPinkFlower5.materials = matsPinkFlower;
                rendPinkFlower6.materials = matsPinkFlower;

                var matsPlane = rendPlane.materials;
                matsPlane[1] = grassBad;
                rendPlane.materials = matsPlane;
                break;

            //bomen
            case 2:
                var matsAppleTree = rendAppleTree1.materials;
                matsAppleTree[0] = applesBad;
                matsAppleTree[1] = treeBad;
                matsAppleTree[2] = treeTrunkBad;
                rendAppleTree1.materials = matsAppleTree;
                rendAppleTree2.materials = matsAppleTree;

                var matsTree = rendTree3.materials;
                matsTree[0] = treeBad;
                matsTree[1] = treeTrunkBad;
                rendTree3.materials = matsTree;
                rendTree4.materials = matsTree;
                rendTree5.materials = matsTree;
                rendTree6.materials = matsTree;
                break;

            //lucht en water
            case 1:


                matsPlane = rendPlane.materials;
                matsPlane[3] = waterBad;
                rendPlane.materials = matsPlane;

                break;
            default:
                break;
        }

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
