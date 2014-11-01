using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class RunningAnimation : MonoBehaviour {

	public Animator runningAnimation;
	private bool isRunning;

	public Image calorias;
	public Image caloriasM;

	public Image panel;

	public Text caloriasGastadas;

	public float totalCalories;

	public Material femaleMaterial;
	public Material maleMaterial;
	
	public GameObject tragon;

	void Awake(){
		runningAnimation = GetComponent<Animator>();
		isRunning = false;
	}
	// Use this for initialization
	void Start () {
	
		panel.gameObject.SetActive(false);

		if(PersistenciaUsuario.getSexo() == Sexo.mujer)
		{
			tragon.renderer.material = femaleMaterial;
			Debug.Log("Mujer");
		}else{
			tragon.renderer.material = maleMaterial;
			Debug.Log("Hombre");
		}
	}

	public void changeExeciseAnimation(){
		if(isRunning){
			isRunning = false;
		}
		else{
			isRunning = true;
		}
	}

	IEnumerator animationCoorutine()
	{
		if(!isRunning)
		{
			changeExeciseAnimation();
			yield return new WaitForSeconds(8f);
			changeExeciseAnimation();
			GameControl.control.Load();
			totalCalories = GameControl.control.caloriasMaximas;
			GameControl.control.caloriasActividad = GameControl.control.caloriasActividad+150;
			Debug.Log("Calorias Consumidas :: "+ GameControl.control.caloriasActividad);
	
			panel.gameObject.SetActive(true);
			caloriasGastadas.text = "150";

			if(GameControl.control.caloriasActividad >= totalCalories)
			{
				float totalCalorias = (GameControl.control.caloriasActividad - totalCalories) / totalCalories;
				calorias.fillAmount = 0;
				caloriasM.fillAmount = totalCalorias;
				Debug.Log("Doble: " + totalCalorias);
			}else{
				caloriasM.fillAmount = 0;
				float totalCalorias = GameControl.control.caloriasActividad / totalCalories;
				calorias.fillAmount = totalCalorias;
				Debug.Log("Normal: " + totalCalorias);
			}

			//GameControl.control.caloriasActividad = 0.0f;
			GameControl.control.Save();


		}
	}

	public void startExerciseAnimation()
	{
		panel.gameObject.SetActive(false);
		StartCoroutine(animationCoorutine());

	}
	
	// Update is called once per frame
	void Update () {
		if(isRunning){
			runningAnimation.SetFloat("velocity", 0.2f);
			runningAnimation.SetBool("isRunning", true);
			isRunning = true;
		}
		else{
			runningAnimation.SetBool("isRunning", false);
			runningAnimation.SetFloat("velocity", 0.0f);
			isRunning = false;
		}
	}
}
