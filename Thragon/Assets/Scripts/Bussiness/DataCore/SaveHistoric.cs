using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;
using UnityEngine.UI;
using System.Collections.Generic;

public class SaveHistoric : MonoBehaviour 
{
	float pesoActual;
	int sexo;
	float pesoIdeal;
	float pesoNuevo;
	float imc;
	float caloriasRecomendadas;

	public Image marcador;

	public Text complexion;
	public Text pesoIdealT;
	public Text caloriasIdeales;
	public Text pesoActualT;

	public Material femaleMaterial;
	public Material maleMaterial;
	
	public GameObject tragon;

	float rotation;
	Vector3 rotationScale;
	Vector3 origin;

	Quaternion originQ;
	Quaternion finalQ;
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

		pesoActual = PersistenciaUsuario.getPeso();

		pesoActualT.text = pesoActual + "";
		
		if(PersistenciaUsuario.getSexo() == Sexo.mujer)
		{
			float pesoIdeal = CalculosGenerales.calcularPesoIdealMujer(PersistenciaUsuario.getAltura());
			GameControl.control.caloriasMaximas = CalculosGenerales.tasaMujer(pesoNuevo,PersistenciaUsuario.getAltura(),PersistenciaUsuario.getEdad());
			caloriasRecomendadas = CalculosGenerales.tasaMujer(pesoIdeal,PersistenciaUsuario.getAltura(),PersistenciaUsuario.getEdad());
			pesoIdealT.text = pesoIdeal + "";
			caloriasIdeales.text = caloriasRecomendadas + " cal";
			Debug.Log("Peso IDEAL: " + pesoIdeal);
		}else{
			
			float pesoIdeal = CalculosGenerales.calcularPesoIdealHombre(PersistenciaUsuario.getAltura());
			GameControl.control.caloriasMaximas = CalculosGenerales.tasaHombre(pesoNuevo,PersistenciaUsuario.getAltura(),PersistenciaUsuario.getEdad());
			caloriasRecomendadas = CalculosGenerales.tasaHombre(pesoIdeal,PersistenciaUsuario.getAltura(),PersistenciaUsuario.getEdad());
			pesoIdealT.text = pesoIdeal + "";
			caloriasIdeales.text = caloriasRecomendadas + " cal";
			Debug.Log("Peso IDEAL: " + pesoIdeal);
		}
		
		pesoNuevo = CalculosGenerales.calcularPeso(GameControl.control.excedenteTotal, pesoActual);
		
		Debug.Log("Peso Nuevo" + pesoNuevo);
		
		Debug.Log("Calorias Nuevas" + GameControl.control.caloriasMaximas);
		
		imc = CalculosGenerales.calcularIMC(pesoNuevo,PersistenciaUsuario.getAltura());
		
		if(imc < 16)
		{
			//Delgadez Severa
			Debug.Log("Delgadez Severa");
			origin = new Vector3 (0,0,0);
			rotationScale = new Vector3(0,0,40);
			
			originQ =  Quaternion.Euler(origin);
			finalQ =  Quaternion.Euler(rotationScale);

			complexion.text = "Delgadez Severa";
		}
		
		if(imc > 16 && imc < 16.99f)
		{
			//Delgadez moderada
			Debug.Log("Delgadez Moderada");
			origin = new Vector3 (0,0,0);
			rotationScale = new Vector3(0,0,40);
			
			originQ =  Quaternion.Euler(origin);
			finalQ =  Quaternion.Euler(rotationScale);

			complexion.text = "Delgadez Moderada";
		}
		
		if(imc > 17 && imc < 18.49f)
		{
			//Delgadez leve
			Debug.Log("Delgadez Leve");
			origin = new Vector3 (0,0,0);
			rotationScale = new Vector3(0,0,40);
			
			originQ =  Quaternion.Euler(origin);
			finalQ =  Quaternion.Euler(rotationScale);

			complexion.text = "Delgadez Leve";
		}
		
		if(imc > 18.5f && imc <24.99f)
		{
			//Normal
			Debug.Log("Indice Normal");
			origin = new Vector3 (0,0,0);
			rotationScale = new Vector3(0,0,0);
			
			originQ =  Quaternion.Euler(origin);
			finalQ =  Quaternion.Euler(rotationScale);

			complexion.text = "Normal";
		}
		
		if(imc > 25 && imc < 29.99f)
		{
			//Preobeso
			Debug.Log("Preobeso");
			origin = new Vector3 (0,0,0);
			rotationScale = new Vector3(0,0,-40);
			
			originQ =  Quaternion.Euler(origin);
			finalQ =  Quaternion.Euler(rotationScale);

			complexion.text = "Preobeso";
		}
		
		if(imc >30 && imc < 34.99f)
		{
			//Obesidad leve
			Debug.Log("Obesidad Leve");
			origin = new Vector3 (0,0,0);
			rotationScale = new Vector3(0,0,-40);
			
			originQ =  Quaternion.Euler(origin);
			finalQ =  Quaternion.Euler(rotationScale);

			complexion.text = "Obesidad Leve";
		}
		
		if(imc > 35 && imc < 39.99)
		{
			//Obesidad moderada
			Debug.Log("Obesidad Moderada");
			origin = new Vector3 (0,0,0);
			rotationScale = new Vector3(0,0,-40);
			
			originQ =  Quaternion.Euler(origin);
			finalQ =  Quaternion.Euler(rotationScale);

			complexion.text = "Obesidad Moderada";
		}
		
		if(imc > 40)
		{
			//Obesidad Morbida
			Debug.Log("Obesidad Morbida");
			origin = new Vector3 (0,0,0);
			rotationScale = new Vector3(0,0,-40);
			
			originQ =  Quaternion.Euler(origin);
			finalQ =  Quaternion.Euler(rotationScale);

			complexion.text = "Delgadez Morbida";
		}


		GameControl.control.caloriasActividad = 0;
		GameControl.control.caloriasAlimentacion = 0;
		GameControl.control.actualDay = 0;
		GameControl.control.totalTime = 0.0f;
		
		GameControl.control.Save();
	}

	void Update()
	{	
		marcador.rectTransform.rotation = Quaternion.Slerp(originQ,finalQ,0.5f*Time.time);
	}

	public void Regresar()
	{
		//Application.LoadLevel(3);
		AdministradorNiveles.cargarPrincipal();
	}
}
