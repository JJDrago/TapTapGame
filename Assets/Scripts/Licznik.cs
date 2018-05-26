﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Licznik : MonoBehaviour
{

    public Text licznikPunktow;  //Nasz licznik punktów na ekranie
    public int punkty = 0;      // startowa ilość punktów
    public Text rekordNapis;         // napis wyświetlający nasz rekord
    public int rekord;

        
    void Start()
    {
        rekordNapis.text = "HIGH SCORE: " + PlayerPrefs.GetInt("Rekord", 0).ToString();
    }
    
    void Update()
    {
        licznikPunktow.text = "Points: " + punkty;      //Tekst naszego licznika to słowo "punkty" i ich wartość
        if (Input.touchCount == 1)
        {               //Jeżeli został wykryty dotyk
            if (Input.GetTouch(0).phase == TouchPhase.Began)
            {                               //dodajemy punkty tylko za "początek" dotykania. Inaczej punkty dodawały by się przez cały okres trzymania palca na ekranie.
                punkty++;
            }
        }
               
    }

    public void Rekord()
    {
        if (punkty > PlayerPrefs.GetInt("Rekord", 0))
        {
            PlayerPrefs.SetInt("Rekord", punkty);
        }

    }

}
