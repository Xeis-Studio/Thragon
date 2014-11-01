using UnityEngine;
using System.Collections;

public class Escenario : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ReturnToHome(){
		//Application.LoadLevel(3);
		AdministradorNiveles.cargarPrincipal();
	}
}
