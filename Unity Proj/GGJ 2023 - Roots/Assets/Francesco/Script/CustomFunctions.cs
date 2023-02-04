using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CustomFunctions //: MonoBehaviour
{
	public static float NuovaOndaSenoMinMax(float min, float max, float x)
	{
		float m = 1,  //la mezza ampiezza dell'onda
			  q = 0,  //spostamento del centro delll'onda sull'asse Y
			  dist, maggiore;

		//Assicura che Min e Max siano il minimo e il massimo
		min = Mathf.Min(min, max);
		max = Mathf.Max(min, max);

		//Calcola la M
		dist = Mathf.Abs(max - min); //Calcola l'ampiezza dell'onda
		m = dist / 2.0f;

		//Calcola la Q
		maggiore = Mathf.Abs(max) > Mathf.Abs(min) ? max : min; //Prende il maggiore tra |min| e |max|
		q = maggiore > 0 ? maggiore - m : maggiore + m; //Calcola la distanza dall'origine (0; 0)


		return (m * Mathf.Sin(x)) + q;  //Ritorna la nuova onda seno
	}
}
