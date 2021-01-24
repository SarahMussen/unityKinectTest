﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    //public GameObject poopPrefab;
    public ObjectPool poopPool;

    private float spawnPosX;
    private float spawnPosY;
    private float spawnPosZ;

    private float startDelay = 3;
    private float spawnInterval = 1.5f;


    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("SpawnPoop", startDelay, spawnInterval);
        InvokeRepeating("SpawnPoop", startDelay, spawnInterval);

    }

    // Update is called once per frame
    void Update()
    {

    }

    void SpawnPoop()
    {
        spawnPosX = transform.position.x;
        spawnPosY = transform.position.y;
        spawnPosZ = transform.position.z;

        Vector3 spawnPos = new Vector3(spawnPosX, spawnPosY, spawnPosZ);
        //Instantiate(poopPrefab, spawnPos, poopPrefab.transform.rotation);

        GameObject poop = poopPool.GetObject();
        poop.transform.position = spawnPos;
    }
}