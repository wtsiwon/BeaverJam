using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class BeaverText : MonoBehaviour
{
    private Image img;
    private void OnEnable()
    {
        StartCoroutine(nameof(RepeatFadeinout));
    }

    private void Start()
    {
        img = GetComponent<Image>();
    }

    private IEnumerator RepeatFadeinout()
    {
        for (int i = 0; i < 3; i++)
        {
            img.DOFade(0, 1f);
            yield return new WaitForSeconds(1f);
            img.DOFade(255,1f);
            yield return new WaitForSeconds(1f);
        }
    }
}
