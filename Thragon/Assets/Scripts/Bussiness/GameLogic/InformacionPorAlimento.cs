using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class InformacionPorAlimento : MonoBehaviour {

	public int calorias;
	public int grasas;
	public int carbohidratos;
	public int proteinas;
	public GameObject foodPrefab;
	public Sprite groupImage;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void saveFoodInfo(GameObject Popit){
		Popit.gameObject.SetActive(true);
//		CalculosDeCalorias negocio = gameObject.GetComponent<CalculosDeCalorias>();
//		negocio.setCalorias(this.calorias);
	}
}
