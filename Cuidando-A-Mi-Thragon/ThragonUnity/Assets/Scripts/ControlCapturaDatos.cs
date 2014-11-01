using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ControlCapturaDatos : MonoBehaviour {

	public InputField nombre;
	public InputField edad;
	public InputField altura;
	public InputField peso;
	public Slider sexo;
	public Image alerta;
	public Image alertaReset;
	public Button btnRegresar;

	public Sprite imgH;
	public Sprite imgM;

	private int numEdad = 0;
	private float numPeso = 0.0f;
	private float numAltura = 0.0f;
	private int numSexo = 0;
	private int bandera;

	void Awake(){
		bandera = PlayerPrefs.GetInt("configuration",0);
	}

	// Use this for initialization
	void Start () {
		if(bandera == 0){
			//colocar botones para nueva partida
			btnRegresar.gameObject.SetActive(false);
		}
		if(bandera == 1){
			//colocar botones para reiniciar partida
			btnRegresar.gameObject.SetActive(true);
		}
		if(PersistenciaUsuario.existenDatos()){
			//Application.LoadLevel(1);
			nombre.value = PersistenciaUsuario.getNombre();
			edad.value = ""+ PersistenciaUsuario.getEdad();
			altura.value = ""+PersistenciaUsuario.getAltura();
			peso.value = ""+PersistenciaUsuario.getPeso();
			sexo.value = (float)((int)PersistenciaUsuario.getSexo());
			GameControl.control.Load();
			setImageSexo();
		}
	}

	public void aceptar(){
		if(bandera == 1){
			//mostrar alerta de perdida de datos.
			alertaReset.gameObject.SetActive(true);
			return;
		}


		if(!datosValidos()){
			alerta.gameObject.SetActive(true);
			return;
		}
		PersistenciaUsuario.setNombre(nombre.value);
		PersistenciaUsuario.setAltura(numAltura);
		PersistenciaUsuario.setEdad(numEdad);
		PersistenciaUsuario.setPeso(numPeso);
		PersistenciaUsuario.setSexo((Sexo)numSexo);

		float tbm;

		if(numPeso == 0){
			tbm = TasaMetabolicaBasal.tasaHombre(numPeso,numAltura,numEdad);
		}else{
			tbm = TasaMetabolicaBasal.tasaMujer(numPeso,numAltura,numEdad);
		}

		GameControl.control.caloriasMaximas = (int)TasaMetabolicaBasal.kiloCaloriasRequeridas(tbm,Ejercicio.PocoNinguno);

		GameControl.control.Save();

		AdministradorNiveles.cargarPrincipal();
	}

	public void aceptarReset(){
		alertaReset.gameObject.SetActive(false);

		if(!datosValidos()){
			alerta.gameObject.SetActive(true);
			return;
		}
		GameControl.control.Delete();
		PersistenciaUsuario.setNombre(nombre.value);
		PersistenciaUsuario.setAltura(numAltura);
		PersistenciaUsuario.setEdad(numEdad);
		PersistenciaUsuario.setPeso(numPeso);
		PersistenciaUsuario.setSexo((Sexo)numSexo);
		
		float tbm;
		
		if(numPeso == 0){
			tbm = TasaMetabolicaBasal.tasaHombre(numPeso,numAltura,numEdad);
		}else{
			tbm = TasaMetabolicaBasal.tasaMujer(numPeso,numAltura,numEdad);
		}
		
		GameControl.control.caloriasMaximas = (int)TasaMetabolicaBasal.kiloCaloriasRequeridas(tbm,Ejercicio.PocoNinguno);
		
		GameControl.control.Save();
		
		AdministradorNiveles.cargarPrincipal();
	}

	public void cancelarReset(){
		alertaReset.gameObject.SetActive(false);
	}

	public void regresar(){
		AdministradorNiveles.cargarInicio();
	}

	public void cerrarAlerta(){
		alerta.gameObject.SetActive(false);
	}

	public void cambioSlider(float valor){
		//Debug.Log(valor);
		numSexo = (int) valor;
		setImageSexo();
	}

	private void setImageSexo(){
		int s = (int)sexo.value;
		Image img = sexo.transform.GetChild(0).GetChild(0).GetComponent<Image>();
		if(s==0){
			img.sprite = imgH;
		}else{
			img.sprite = imgM;
		}
	}

	private bool datosValidos(){
		//vacios
		if(nombre.value.Length < 1)
			return false;
		if(edad.value.Length < 1)
			return false;
		if(altura.value.Length < 1)
			return false;
		if(peso.value.Length < 1)
			return false;
		//tipo valido
		if(!int.TryParse(edad.value,out numEdad)){
			edad.value = "";
			return false;
		}
		if(!float.TryParse(altura.value,out numAltura)){
			altura.value = "";
			return false;
		}
		if(!float.TryParse(peso.value,out numPeso)){
			peso.value = "";
			return false;
		}
		//valor valido
		if(numEdad < 1 || numEdad > 99){
			edad.value="";
			return false;
		}
		if(numAltura < 50.0f || numAltura > 300.0f){
			altura.value = "";
			return false;
		}
		if(numPeso < 10.0f || numPeso > 200.0f){
			peso.value = "";
			return false;
		}
		return true;
	}



}
