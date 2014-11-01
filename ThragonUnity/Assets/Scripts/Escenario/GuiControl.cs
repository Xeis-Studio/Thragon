using UnityEngine;
using System.Collections;
using UnityEngine.UI;



public class GuiControl : MonoBehaviour 
{	
	public Image calorias;
	public Image caloriasDouble;

	public Image timer;
	public float totalCalories;

	public Image totalActividad;
	public Image actividadDoble;

	private float totalTime;
	private float currentTime;
	private float fillBar;

	const float K_AMOUNT_FOOD = 0.02f;
	const float K_AMOUNT_ACTI = 0.01f;
	const float K_AMOUNT_FOODL = 0.015f;

	const float K_TOTAL_TIME = 600.0f;

	const int K_DAY_TO_LOAD = 3;

	private int isEat;
	private int isPlay;

	private bool horaComer;
	private bool horaJugar;
	private float excedenteTotal;


	void Start () {
	
		GameControl.control.Load();

		totalCalories = GameControl.control.caloriasMaximas;

		totalTime = K_TOTAL_TIME;
		currentTime = GameControl.control.totalTime;

		isEat = GameControl.control.isEat;
		isPlay = GameControl.control.isPlay;
		Debug.Log("Tiempo guardado" + currentTime);
		Debug.Log("Bools :: " +isEat+" "+isPlay);

		float cal = GameControl.control.caloriasAlimentacion;
		float act = GameControl.control.caloriasActividad;
		
		float total = GameControl.control.caloriasAlimentacion;
		float totalEjercicio = GameControl.control.caloriasActividad;

		if(total >= totalCalories)
		{
			float totalCalorias = (cal - totalCalories) / totalCalories;
			calorias.fillAmount = 0;
			caloriasDouble.fillAmount = totalCalorias;

			//Debug.Log("Calorias" + totalCalorias);
			
		}else{
			
			caloriasDouble.fillAmount = 0;
			float totalCalorias = cal / totalCalories;
			calorias.fillAmount = totalCalorias;


		}

		if(totalEjercicio >= totalCalories)
		{
			float caloriasActividadTotales = (act - totalCalories) / totalCalories;
			totalActividad.fillAmount = 0;
			actividadDoble.fillAmount = caloriasActividadTotales;
		}else{
			actividadDoble.fillAmount = 0;
			float totalAct = act / totalCalories;
			totalActividad.fillAmount = totalAct;
		}



	}

	public bool canEat(){
		return horaComer;
	}

	public bool canPlay(){
		return horaJugar;
	}
	
	// Update is called once per frame
	void Update () 
	{
		fillBar = currentTime / totalTime;
		timer.fillAmount = fillBar;

		GameControl.control.totalTime = currentTime;

		Debug.Log("Current Time :: "+currentTime);
		if(timer.fillAmount < 1.0)
		{
			if(timer.fillAmount >= 0.0 && timer.fillAmount <= 0.18)
			{
				//Desayuno
				Debug.Log("Desayuno");
				horaComer = true;
				horaJugar = false;
				currentTime += K_AMOUNT_FOOD;
				if(isEat == 1)
				{
					Debug.Log("Saltar 1 ::"+timer.fillAmount);
					currentTime = K_TOTAL_TIME*0.19f;
					GameControl.control.totalTime = K_TOTAL_TIME*0.19f;
					isPlay = 0;
					isEat = 0;
					GameControl.control.Save();
				}
			}
			
			if(timer.fillAmount >= 0.18 && timer.fillAmount <= 0.24)
			{
				//Primer Actividad
				Debug.Log("Primer Actividad");
				horaComer = false;
				horaJugar = true;
				currentTime += K_AMOUNT_ACTI;
				if(isPlay == 1)
				{
					Debug.Log("Saltar 2");
					currentTime = K_TOTAL_TIME*0.25f;
					GameControl.control.totalTime = K_TOTAL_TIME*0.25f;
					isPlay = 0;
					isEat = 0;
					GameControl.control.Save();
				}
			}
			
			if(timer.fillAmount >= 0.24 && timer.fillAmount <= 0.35)
			{
				//Almuerzo
				Debug.Log("Almuerzo");
				horaComer = true;
				horaJugar = false;
				currentTime += K_AMOUNT_FOODL;
				if(isEat == 1)
				{
					Debug.Log("Saltar 3");
					currentTime = K_TOTAL_TIME*0.36f;
					GameControl.control.totalTime = K_TOTAL_TIME*0.36f;
					isPlay = 0;
					isEat = 0;
					GameControl.control.Save();
				}
			}
			
			if(timer.fillAmount >= 0.35 && timer.fillAmount <= 0.40)
			{
				//Segunda Actividad
				Debug.Log("Segunda Actividad");
				horaComer = false;
				horaJugar = true;
				currentTime += K_AMOUNT_ACTI;
				if(isPlay == 1)
				{
					Debug.Log("Saltar 4");
					currentTime = K_TOTAL_TIME*0.41f;
					GameControl.control.totalTime = K_TOTAL_TIME*0.41f;
					isPlay = 0;
					isEat = 0;
					GameControl.control.Save();
				}
			}
			
			if(timer.fillAmount >= 0.40 && timer.fillAmount <= 0.58)
			{
				//Comida
				Debug.Log("Comida");
				horaComer = true;
				horaJugar = false;
				currentTime += K_AMOUNT_FOOD;
				if(isEat == 1)
				{
					Debug.Log("Saltar 5");
					currentTime = K_TOTAL_TIME*0.58f;
					GameControl.control.totalTime = K_TOTAL_TIME*0.59f;
					timer.fillAmount = 0.58f;
					isPlay = 0;
					isEat = 0;
					GameControl.control.Save();
				}
			}
			
			if(timer.fillAmount >= 0.58 && timer.fillAmount <= 0.64)
			{
				//Tercer Actividad
				Debug.Log("Tercera Actividad");
				horaComer = false;
				horaJugar = true;
				currentTime += K_AMOUNT_ACTI;
				if(isPlay == 1)
				{
					Debug.Log("Saltar 6");
					currentTime = K_TOTAL_TIME*0.65f;
					GameControl.control.totalTime = K_TOTAL_TIME*0.65f;
					isPlay = 0;
					isEat = 0;
					GameControl.control.Save();
				}
			}
			
			if(timer.fillAmount >= 0.64 && timer.fillAmount <= 0.75)
			{
				//Snack
				Debug.Log("Snack");
				horaComer = true;
				horaJugar = false;
				currentTime += K_AMOUNT_FOODL;
				if(isEat == 1)
				{
					Debug.Log("Saltar 7");
					currentTime = K_TOTAL_TIME*0.76f;
					GameControl.control.totalTime = K_TOTAL_TIME*0.76f;
					isPlay = 0;
					isEat = 0;
					GameControl.control.Save();
				}
			}
			
			if(timer.fillAmount >= 0.75 && timer.fillAmount <= 0.80)
			{
				//Cuarta Actividad
				Debug.Log("Cuarta Actividad");
				horaComer = false;
				horaJugar = true;
				currentTime += K_AMOUNT_ACTI;
				if(isPlay == 1)
				{
					Debug.Log("Saltar 8");
					currentTime = K_TOTAL_TIME*0.81f;
					GameControl.control.totalTime = K_TOTAL_TIME*0.81f;
					isPlay = 0;
					isEat = 0;
					GameControl.control.Save();
				}
			}
			
			if(timer.fillAmount >= 0.80 && timer.fillAmount <= 1.0)
			{
				//Cena
				Debug.Log("Cena");
				horaComer = true;
				horaJugar = false;
				currentTime += K_AMOUNT_FOOD;
				if(isEat == 1)
				{
					Debug.Log("Saltar 9");
					currentTime = K_TOTAL_TIME*1.0f;
					GameControl.control.totalTime = K_TOTAL_TIME*1.0f;
					isPlay = 0;
					isEat = 0;
					GameControl.control.isEat = 0;
					GameControl.control.isPlay = 0;
					GameControl.control.Save();
				}
			}

		}else{
			//Se carga pantalla final de resumen
		
			Debug.Log("Dia Actual: " + GameControl.control.actualDay);

			if(GameControl.control.actualDay == K_DAY_TO_LOAD)
			{
				GameControl.control.Save();
				Application.LoadLevel(6);
			
			}else if(GameControl.control.actualDay < K_DAY_TO_LOAD)
			{
				GameControl.control.actualDay += 1;
				excedenteTotal = GameControl.control.caloriasAlimentacion - GameControl.control.caloriasActividad;
				GameControl.control.excedenteTotal = excedenteTotal;
				GameControl.control.Save();

				Debug.Log("Calorias Acumuladas: "+ GameControl.control.excedenteTotal);
				AdministradorNiveles.cargarDormir();
			}


		
		//Debug.Log("Time Transcurred: " + currentTime);
	}
}
}