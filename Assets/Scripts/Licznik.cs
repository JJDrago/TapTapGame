using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Licznik : MonoBehaviour
{

    public Text licznikPunktow;  //Nasz licznik punktów na ekranie
    public int punkty = 0;      // startowa ilość punktów
    public Text rekordNapis;         // napis wyświetlający nasz rekord
    public int rekord;              //wartość rekordu
    public TimerScript timerScript; //odniesienie do skyptu TimerScript

        
    void Start()
    {
        rekordNapis.text = "HIGH SCORE: " + PlayerPrefs.GetInt("Rekord", 0).ToString(); //Wczytujemy zapisany wynik gracza
    }
    
    void Update()
    {
        licznikPunktow.text = "Points: " + punkty;      //Tekst naszego licznika to słowo "punkty" i ich wartość
        if (Input.touchCount == 1 && timerScript.granie == true)   //blokada liczeniapunktówpoza czasem gry
        {               
            if (Input.GetTouch(0).phase == TouchPhase.Began) //Jeżeli został wykryty dotyk
            {                                                //dodajemy punkty tylko za "początek" dotykania. Inaczej punkty dodawały by się przez cały okres trzymania palca na ekranie.
                punkty++;                                    //dodajemy punkt
            }
        }               
    }

    public void Rekord()        //tu robimy zapisywanie rekordu. Jest ono wywoływane przez game object TouchManager
    {
        if (punkty > PlayerPrefs.GetInt("Rekord", 0)) //Jeżeli aktualny wynik jest większy niż zapamiętany rekord
        {
            PlayerPrefs.SetInt("Rekord", punkty);       //to go podmieniamy
            rekordNapis.text = "HIGH SCORE: " + PlayerPrefs.GetInt("Rekord", 0).ToString(); //i wyświetlamy. Napotrzeby tego zadania jest schowany podczas gry.
        }

    }

}
