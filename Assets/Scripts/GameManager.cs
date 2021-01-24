using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public static GameManager Instance { get; private set; }

    private int catchedPoop = 0;
    private int missedPoop = 0;

    [SerializeField]
    private TextMeshProUGUI catchedPoopText;
    [SerializeField]
    private TextMeshProUGUI missedPoopText;

    void Awake()
    {
        if (Instance == null) 
        { 
            Instance = this; 
        }
    }

    //update score when poop is catched
    public void addCathedPoop()
    {
        catchedPoop++;
        updateGUI();
    }

    public void addMissedPoop()
    {
        missedPoop++;
        updateGUI();
    }

    //updates the GUI
    private void updateGUI()
    {
        catchedPoopText.text = "Score: " + catchedPoop;
        missedPoopText.text = "Missed: " +missedPoop;
    }


}
