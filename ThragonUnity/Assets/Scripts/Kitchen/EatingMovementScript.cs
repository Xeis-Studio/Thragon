using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class EatingMovementScript : MonoBehaviour {


	public bool isEating;
	private Animator myAnimation;
	public GameObject spot;
	public Graphic Contenedor;
	public Text calorias;
	public Text proteinas;
	public Text grasas;
	public Text carbohidratos;

	public Material femaleMaterial;
	public Material maleMaterial;
	
	public GameObject tragon;
	
	void Awake (){
		myAnimation = GetComponent<Animator>();
		isEating = false;
		if(Contenedor != null){
			Contenedor.gameObject.SetActive(false);
		}
	}

	// Use this for initialization
	void Start () 
	{
		if(PersistenciaUsuario.getSexo() == Sexo.mujer)
		{
			tragon.renderer.material = femaleMaterial;
			Debug.Log("Mujer");
		}else{
			tragon.renderer.material = maleMaterial;
			Debug.Log("Hombre");
		}
	}

	public void openPopit(GameObject food){
		if(Contenedor != null){
			//		CalculosDeCalorias negocio = gameObject.GetComponent<CalculosDeCalorias>();
//		negocio.setCalorias(this.calorias);
			InformacionPorAlimento data = food.GetComponent<InformacionPorAlimento>();
			calorias.text = "Calorias: "+data.calorias;
			Contenedor.gameObject.SetActive(true);
		}

	}

	public void changeEatingAnimation(){
		if(isEating){
			isEating = false;
		}
		else{
			isEating = true;
		}
	}

	IEnumerator animationCoorutine(string foodName){
		if(!isEating){
			changeEatingAnimation();
			GameObject food = GameObject.Find(foodName);
			food.gameObject.GetComponent<CalculosDeCalorias>().setCalorias(food.gameObject.GetComponent<CalculosDeCalorias>().caloriasThragon);
			GameObject ipa = food.gameObject.GetComponent<InformacionPorAlimento>().foodPrefab;
			Transform tmp = Instantiate(ipa, spot.transform.position, Quaternion.identity) as Transform; 
			//Transform tmp =  Instantiate(food, target.transform.position,Quaternion.identity) as Transform;
			Debug.Log("Nombre prefab : "+food.gameObject.name);
			yield return new WaitForSeconds(1.4f);
			Destroy(GameObject.Find(ipa.gameObject.name+"(Clone)"));
			changeEatingAnimation();
		}
	}

	public void executeEatingLoop(GameObject popit){
		string data = popit.gameObject.GetComponent<PopitScript>().gameobjectName;
		StartCoroutine(animationCoorutine(data));
		popit.gameObject.SetActive(false);
	}


	
	// Update is called once per frame
	void Update () {
		if(isEating){
			myAnimation.SetFloat("velocity", 0.2f);
			myAnimation.SetBool("isEating", true);
			isEating = true;
		}
		else{
			myAnimation.SetBool("isEating", false);
			myAnimation.SetFloat("velocity", 0.0f);
			isEating = false;
		}

	}

	public void openFoodInfo(GameObject food){
		//Abrimos el Pup-it con la info del Alimento, y 2 botones, uno para cerrar y otro para alimentar al Thragon

	}
}
