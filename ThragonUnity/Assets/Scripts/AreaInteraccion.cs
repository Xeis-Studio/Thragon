using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AreaInteraccion : MonoBehaviour {

	private Collider areaDeteccion;
	private GameObject thragon;
	public Graphic contenedor;

	// Use this for initialization
	void Start () {
		areaDeteccion = this.collider;
		thragon = GameObject.FindGameObjectWithTag("thragon");
		if(contenedor != null){
			contenedor.gameObject.SetActive(false);
		}
	}
	
	void OnTriggerEnter(Collider other){
		//verificar que choco con thragon
		if(other.gameObject.tag != "thragon"){
			return;
		}
		var agent = thragon.GetComponent<AgentScript>();
		if(agent != null)
		agent.canMove = false;

		if(contenedor != null){
			//Debug.Log("Colision");
			contenedor.gameObject.SetActive(true);
		}
	}

	void OnTriggerExit(Collider other){
		contenedor.gameObject.SetActive(false);

		var agent = thragon.GetComponent<AgentScript>();
		if(agent != null)
			agent.canMove = true;
		//this.gameObject.SetActive(false);
	}
}
