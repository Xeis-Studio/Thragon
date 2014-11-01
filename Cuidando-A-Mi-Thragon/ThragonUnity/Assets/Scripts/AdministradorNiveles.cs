using UnityEngine;
using System.Collections;

public class AdministradorNiveles {

	public static void cargarPrincipal(){
		Application.LoadLevel("Principal");
	}

	public static void cargarCreditos(){
		Application.LoadLevel("Credits");
	}

	public static void cargarCapturaDatos(){
		Application.LoadLevel("GetData");
	}

	public static void cargarEjercicio(){
		Application.LoadLevel("Gym");
	}

	public static void cargarCocina(){
		Application.LoadLevel("Kitchen");
	}

	public static void cargarDormir(){
		Application.LoadLevel("Dormir");
	}

	public static void cargarInicio(){
		Application.LoadLevel("Start");
	}
}
