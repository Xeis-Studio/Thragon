using UnityEngine;
using System.Collections;

public class TasaMetabolicaBasal {

	public static float tasaHombre(float peso, float altura, int edad){
		return (10.0f * peso) + (6.25f * altura) - (5.0f * edad) + 5.0f; 
	}

	public static float tasaMujer(float peso, float altura, int edad){
		return (10.0f * peso) + (6.25f * altura) - (5.0f * edad) - 161.0f; 
	}

	public static float kiloCaloriasRequeridas(float tbm, Ejercicio ej){
		float multiplicador = 1.0f;
		switch(ej){
		case Ejercicio.PocoNinguno:
			multiplicador = 1.2f;
			break;
		case Ejercicio.Ligero:
			multiplicador = 1.375f;
			break;
		case Ejercicio.Moderado:
			multiplicador = 1.55f;
			break;
		case Ejercicio.Fuerte:
			multiplicador = 1.725f;
			break;
		case Ejercicio.MuyFuerte:
			multiplicador = 1.9f;
			break;
		}
		return tbm * multiplicador;
	}
}
