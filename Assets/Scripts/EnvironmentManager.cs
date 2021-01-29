using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentManager : MonoBehaviour
{

    private int catchedPoop;
    private int missedPoop;

    private bool firstCompleted = false;

    [SerializeField]
    private GameObject farmer;
    [SerializeField]
    private Material blue;

    private Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = farmer.GetComponent<Renderer>();
        rend.enabled = true;
    }

    // Update is called once per frame
    void Update()
    {
        catchedPoop = GameManager.Instance.getCatchedPoop();
        missedPoop = GameManager.Instance.getMissedPoop();

        if(catchedPoop == 5 && !firstCompleted)
        {
            Debug.Log("clothes changed!");
            var mats = rend.materials;
            mats[1] = blue;
            rend.materials = mats;
            firstCompleted = true;
        }
    }
}
