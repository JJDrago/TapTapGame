using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour {

	Image PasekCzasu;       //grafika paska
	public float maxTime = 10f;	//maksymalny czas do ustawienia w inspektorze
	float timeLeft = 20f;		// pozostały czas
	public GameObject menu; //napis na ekranie
   // public GameObject restartButton; //przycisk resetu
    //public GameObject backButton; // przycisk wyjścia
    //public GameObject napisRekord;

    public Licznik _Licznik;
    public Text odliczanie;
    

	// Use this for initialization

	void Start () {

        menu.SetActive(false); //zaczynamy z wyłączonym napisem
       // restartButton.SetActive(false); // zaczynamy bez przycisku resetu
       // backButton.SetActive(false); // zaczynamy bez przycisku resetu
       // napisRekord.SetActive(false);
        PasekCzasu = GetComponent<Image>(); //ustawiamy pasek
        StartCoroutine(Countdown(3));  
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        //uniezależniamy czas od ilości klatek na sekundę
        if (timeLeft > 0)
        {           //Zanim czas się skończy
            timeLeft -= Time.deltaTime;  //odejmujemy upływająco czas
            PasekCzasu.fillAmount = timeLeft / maxTime; // zapełnienie paska równa się pozostałemu czasowi
        }
        else
        {
            menu.SetActive(true); //włączamy napis na ekranie
           // restartButton.SetActive(true); //jak wyżej
          //  quitButton.SetActive(true); // zaczynamy bez przycisku resetu
          //  napisRekord.SetActive(true); // zaczynamy bez przycisku resetu
            Time.timeScale = 0; //zatrzymujemy upływ czasu, bo gra się skończyła
            _Licznik.Rekord();      //wywołujemy funkcję ze skryptu Licznik
        }

    }

    IEnumerator Countdown(int seconds)
    {

        int count = seconds;

        while (count > 0)
        {
            odliczanie.text = count.ToString();

            yield return new WaitForSeconds(1);
            count--;
            if (count == 0)
            {
                odliczanie.text = "GO!";
                yield return new WaitForSeconds(1);
                odliczanie.text = "";
            }


        }

        
        
        timeLeft = maxTime; //startowy czas = maksymalny czas

    }




}
