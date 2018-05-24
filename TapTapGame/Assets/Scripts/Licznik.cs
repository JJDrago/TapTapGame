using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Licznik : MonoBehaviour {

    public UnityEngine.UI.Text licznikPunktow;  //Nasz licznik punktów na ekranie
    public int punkty = 0;		// startowa ilość punktów

	
	void Update ()
	{
		licznikPunktow.text = "Points: " + punkty;		//Tekst naszego licznika to słowo "punkty" i ich wartość
		if (Input.touchCount == 1)
		{				//Jeżeli został wykryty dotyk
			if (Input.GetTouch (0).phase == TouchPhase.Began) 
			{								//dodajemy punkty tylko za "początek" dotykania. Inaczej punkty dodawały by się przez cały okres trzymania palca na ekranie.
				punkty++;
			}
		}


	}

}
