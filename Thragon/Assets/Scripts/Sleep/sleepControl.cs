using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class sleepControl : MonoBehaviour {

	public Text advise;

	private int index;
	private string[] advises;
	// Use this for initialization
	void Start () 
	{
		index = 0;
		advises = new string[]{"Comer es divertido… ¡Disfruta la comida!","El desayuno es una comida importante.","Come fruta y verdura en cada comida, ¡y también entre horas!","El exceso de grasas no es bueno para la salud.","Sacia la sed. Bebe cuanto puedas.","Cepíllate los dientes al menos dos veces al día.","Haz ejercicio a diario."};

	}
	
	// Update is called once per frame
	void Update () 
	{
		if(index <= 6)
		{
			advise.text = advises[index];
		}
	}

	public void Regresar()
	{
		GameControl.control.caloriasActividad = 0;
		GameControl.control.caloriasAlimentacion = 0;
		GameControl.control.totalTime = 0.0f;
		GameControl.control.Save();
		//Application.LoadLevel(3);
		AdministradorNiveles.cargarPrincipal();
	}

	public void NextStep()
	{
		if(index <= 6)
		{
			index ++;
		}
	}
	
	public void PreviousStep()
	{
		if(index != 0)
		{
			index --;
		}
	}
}
