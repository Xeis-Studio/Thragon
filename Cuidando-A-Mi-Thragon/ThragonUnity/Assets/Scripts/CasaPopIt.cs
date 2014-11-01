using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CasaPopIt : MonoBehaviour {

	public Button comer;
	public Button jugar;
	public GuiControl controlGuiTiempo;

	private GameObject thragon;
	// Use this for initialization
	void Start () {
		thragon = GameObject.FindGameObjectWithTag("thragon");
		//controlGuiTiempo = GameObject.FindObjectOfType<GuiControl>();
	}

	public void cerrarVentana(){
		var agent = thragon.GetComponent<AgentScript>();
		if(agent != null)
		agent.canMove = true;
		this.gameObject.SetActive(false);
	}

	public void irAComer()
	{
		GameControl.control.isEat = 1;
		GameControl.control.isPlay = 0;
		GameControl.control.Save();
		//Application.LoadLevel(4);
		AdministradorNiveles.cargarCocina();
	}

	public void irAJugar()
	{
		GameControl.control.isEat = 0;
		GameControl.control.isPlay = 1;
		GameControl.control.Save();
		//Application.LoadLevel(5);
		AdministradorNiveles.cargarEjercicio();
	}

	public void Salir()
	{
		GameControl.control.Save();
		AdministradorNiveles.cargarInicio();
	}

	void OnEnable(){
		if(controlGuiTiempo.canEat()){
			comer.gameObject.SetActive(true);
		}
		if(controlGuiTiempo.canPlay()){
			jugar.gameObject.SetActive(true);
		}
	}

	void OnDisable(){
		comer.gameObject.SetActive(false);
		jugar.gameObject.SetActive(false);
	}
}
