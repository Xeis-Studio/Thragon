using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CalculosDeCalorias : MonoBehaviour {

	public float caloriasThragon;

	public int QuemaCaloricaDeseable;
	public int QuemaCaloricaDiariaMinima;
	public int QuemaCaloricaMaxima;
	public int QuemaCaloricaNatural;

	public int CaloriasConsumidas;
	public int CaloriasDiariasMinima;
	public int CaloriasConsumidasMaximas;

	public Text calorias;
	public Text foodNameText;
	public Image grupoInfo;



	public void OpenWindow(GameObject popit){
		if(popit != null){

			InformacionPorAlimento Fooddata = gameObject.GetComponent<InformacionPorAlimento>();
			popit.gameObject.GetComponent<PopitScript>().setFoodName(this.gameObject.name);
			calorias.text = ""+Fooddata.calorias;
			caloriasThragon = Fooddata.calorias;
			foodNameText.text = this.gameObject.name;
			popit.gameObject.SetActive(true);
			grupoInfo.sprite = Fooddata.groupImage;
		}

	}

	// Use this for initialization
	void Start () {
		//Inicializamos calorias desde el modelo
		caloriasThragon = GameControl.control.caloriasMaximas;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public float getCalorias(float caloriasAñadidas){
		//Aqui extremos del core la info de calorias guardadas
		return caloriasThragon+caloriasAñadidas;
	}

	public void setCalorias(float NumeroCalorias){
		GameControl.control.Load();
		GameControl.control.caloriasAlimentacion = GameControl.control.caloriasAlimentacion+NumeroCalorias;
		GameControl.control.Save();

		Debug.Log("Calorias Guardadas :: "+ GameControl.control.caloriasAlimentacion);

		Debug.Log("Calorias: "+NumeroCalorias);
		//Seteamos los valores al core de persistencia
	}



}
