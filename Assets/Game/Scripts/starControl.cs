using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class starControl : MonoBehaviour
{
    public GameObject star1, star2, star3;



    public void whichStar(int value)
    {
        switch(value)
        {
            case 1:
                StartCoroutine(starActive(1));
                break;
            case 2:
                StartCoroutine(starActive(1));
                break;
            case 3:
                StartCoroutine(starActive(2));
                break;
            case 4:
                StartCoroutine(starActive(2));
                break;
            case 5:
                StartCoroutine(starActive(3));
                break;
            case 6:
                StartCoroutine(starActive(3));
                break;
        }
    }


    IEnumerator  starActive(int number)
    {
        yield return new WaitForSeconds(0.4f);

        switch (number)
        {
            case 1:
                star1.SetActive(true);
                star1.transform.GetChild(0).DOScale(2.5f, 2).SetEase(Ease.OutElastic);
                soundManager.instance.StarSound();
                break;

            case 2:
                star2.SetActive(true);
                star2.transform.GetChild(0).DOScale(2.5f, 2).SetEase(Ease.OutElastic);
                soundManager.instance.StarSound();
                yield return new WaitForSeconds(1);
                star2.transform.GetChild(1).DOScale(2.5f, 2).SetEase(Ease.OutElastic);
                soundManager.instance.StarSound();
                break;

            case 3:
                star3.SetActive(true);

                star3.transform.GetChild(0).DOScale(2.5f, 2).SetEase(Ease.OutElastic);
                soundManager.instance.StarSound();
                yield return new WaitForSeconds(0.5f);
                star3.transform.GetChild(1).DOScale(2.5f, 2).SetEase(Ease.OutElastic);
                soundManager.instance.StarSound();
                yield return new WaitForSeconds(0.5f);
                star3.transform.GetChild(2).DOScale(2.5f, 2).SetEase(Ease.OutElastic);
                soundManager.instance.StarSound();
                yield return new WaitForSeconds(0.5f);               
                break;
        }

    }


    
}
