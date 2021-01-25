using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }

    private int catchedPoop = 0;
    private int missedPoop = 0;

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
    }


    /// <summary>
    /// adds one to the missedPoop variable when the player misses a poop
    /// </summary>
    public void addMissedPoop()
    {
        missedPoop++;
        missedPoopText.text = "score: " + missedPoop;
        updateDowngradeGUI();
    }

    /// <summary>
    /// Updates the upgrade gui depending on how much catched poop; changes the slider and the corresponding image
    /// </summary>
    private void updateUpgradeGUI()
    {
        switch (catchedPoop)
        {
            case 5:
                upgradeSlider.value = 25;
                upgradeText.text = "1/4 items gevonden";
                firstItemImg.texture = firstItemTexture;
                break;
            case 10:
                upgradeSlider.value = 50;
                upgradeText.text = "2/4 items gevonden";
                secondItemImg.texture = secondItemTexture;
                break;
            case 15:
                upgradeSlider.value = 75;
                upgradeText.text = "3/4 items gevonden";
                thirdItemImg.texture = thirdItemTexture;
                break;
            case 20:
                upgradeSlider.value = 100;
                upgradeText.text = "4/4 items gevonden";
                fourthItemImg.texture = fourthItemTexture;
                break;
            default:
                break;
        }
    }

    /// <summary>
    /// Updates the downgrade gui depending on how much missed poop; changes the slider and the corresponding image
    /// </summary>
    private void updateDowngradeGUI()
    {
        switch (missedPoop)
        {
            case 5:
                downgradeSlider.value = 75;
                downgradeText.text = "75% omgeving";
                break;
            case 10:
                downgradeSlider.value = 50;
                downgradeText.text = "50% omgeving";

                break;
            case 15:
                downgradeSlider.value = 25;
                downgradeText.text = "25% omgeving";
                break;
            case 20:
                downgradeSlider.value = 0;
                downgradeText.text = "0% omgeving";
                break;
            default:
                break;
        }
    }




}
