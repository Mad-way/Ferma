using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class Clicker : MonoBehaviour
{
    public static int clicks, coefficient = 1, autoCoefficient = 0;
    public Text clicksText;
    //public AudioSource myFx;
    public AudioClip audioClick;

    public static UnityEvent Click = new UnityEvent();
   

    private void Awake()
    {
        Click.AddListener(() => UpdateClicks());
        clicks = 0;
        coefficient = 1; //Коэффициент добавляемый животными
    }
    public void UpdateClicks()
    {
        clicksText.text = clicks.ToString();
        //myFx.PlayOneShot(audioClick);
    }

    IEnumerator AddClicks() {
        while (true) {
            yield return new WaitForSeconds(5f);
            clicks += autoCoefficient; //Коэффициент добавляемый зданиями
            Click?.Invoke();
        }
    }

    private void Start()
    {
        StartCoroutine(AddClicks());
    }

}
