using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TimerScript : MonoBehaviour {

	Image PasekCzasu;
	public float maxTime = 10f;	//maksymalny czas do ustawienia w inspektorze
	float timeLeft;		// pozostały czas
	public GameObject napisTimesUp; //napis na ekranie

	// Use this for initialization
	void Start () {
		napisTimesUp.SetActive (false); //zaczynamy z wyłączonym napisem
		PasekCzasu = GetComponent<Image> (); //ustawiamy pasek
		timeLeft = maxTime; //startowy czas = maksymalny czas
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {             //uniezależniamy czas od ilości klatek na sekundę
		if (timeLeft > 0) {			//Zanim czas się skończy
			timeLeft -= Time.deltaTime;  //odejmujemy upływająco czas
			PasekCzasu.fillAmount = timeLeft / maxTime; // zapełnienie paska równa się pozostałem czasowi
		} else {
			napisTimesUp.SetActive (true); //włączamy napis na ekranie
			Time.timeScale = 0; //zatrzymujemy upływ czasu, bo gra się skończyła
		}
		
	}
}
