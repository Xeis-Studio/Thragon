using UnityEngine;
using System.Collections;

[System.Serializable]
public class Alimento {

	public int id; 
	public string nombre; 
	public string descripcion;
	public string grupo;
	public float calorias; 
	public float catidadVegetales; 
	public float cantidadGrasas; 
	public float cantidadFrutas; 
	public float cantidadCereales;
	[SerializeField]
	public Sprite imagen; 
	[SerializeField]
	public GameObject prefab; 

	public Alimento(){

	}
}
