using DG.Tweening;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private bool up = true;
    private bool isFlipping = false;

    private void OnMouseDown()
    {
        TryFlipCoin();
    }

    private void TryFlipCoin()
    {
        if(isFlipping) { return; }

        StartCoroutine(FlipCoin());
       
    }

    private IEnumerator FlipCoin()
    {
        isFlipping = true;

        up = !up;

        float rotation = up ? -90f : 90f;
        float targetRotation = rotation == 90f ? -90f : 90f;

        var tweener = DOTween.To(() => rotation, x => rotation = x, targetRotation, 1f)
            .OnUpdate(() => transform.eulerAngles = new Vector3(rotation, 0f, 0f));

        while (tweener.IsActive()) { yield return null; }

        isFlipping = false;


    }
}
