using UnityEngine;
using System.Collections;
using System;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

public class GameControl : MonoBehaviour {

	public static GameControl control;

	public float caloriasActividad;
	public float caloriasAlimentacion;

	public float caloriasMaximas;

	public float excedenteTotal;
	public float excedenteTotalEjercicio;

	public float totalTime;

	public int isEat;
	public int isPlay;

	public int actualDay;

	// Use this for initialization
	void Awake () 
	{
		if(control == null)
		{
			DontDestroyOnLoad(gameObject);
			control = this;
		}else if(control != this)
		{
			Destroy(gameObject);
		}

		//Delete();
	}
	
	public void Save()
	{
		/*
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.Create(Application.persistentDataPath + "/playerInfo.dat");

		PlayerData data= new PlayerData();
		data.caloriasActividad = caloriasActividad;
		data.caloriasAlimentacion = caloriasAlimentacion;
		data.caloriasMaximas = caloriasMaximas;
		data.excedenteTotal = excedenteTotal;
		data.excedenteTotalEjercicio = excedenteTotalEjercicio;
		data.totalTime = totalTime;
		data.isEat = isEat;
		data.isPlay = isPlay;
		data.actualDay = actualDay;

		bf.Serialize (file, data);
		file.Close();
		*/

		PlayerPrefs.SetFloat("caloriasActividad",caloriasActividad);
		PlayerPrefs.SetFloat("caloriasAlimentacion",caloriasAlimentacion);
		PlayerPrefs.SetFloat("caloriasMaximas",caloriasMaximas);
		PlayerPrefs.SetFloat("excedenteTotal", excedenteTotal);
		PlayerPrefs.SetFloat("excedenteTotalEjercicio",excedenteTotalEjercicio);
		PlayerPrefs.SetFloat("totalTime",totalTime);
		PlayerPrefs.SetInt("isEat",isEat);
		PlayerPrefs.SetInt("isPlay",isPlay);
		PlayerPrefs.SetInt("actualDay",actualDay);

	}

	public void Load()
	{
		/*
		if(File.Exists(Application.persistentDataPath + "/playerInfo.dat"))
		{
			BinaryFormatter bf = new BinaryFormatter();
			FileStream file = File.Open(Application.persistentDataPath + "/playerInfo.dat",FileMode.Open);

			PlayerData data = (PlayerData)bf.Deserialize(file);
			file.Close();

			caloriasActividad = data.caloriasActividad;
			caloriasAlimentacion = data.caloriasAlimentacion;
			caloriasMaximas = data.caloriasMaximas;
			excedenteTotal = data.excedenteTotal;
			excedenteTotalEjercicio = data.excedenteTotalEjercicio;
			totalTime = data.totalTime;
			isEat = data.isEat;
			isPlay = data.isPlay;
			actualDay = data.actualDay;
		}
		*/

		caloriasActividad = PlayerPrefs.GetFloat("caloriasActividad");
		caloriasAlimentacion = PlayerPrefs.GetFloat("caloriasAlimentacion");
		caloriasMaximas = PlayerPrefs.GetFloat("caloriasMaximas");
		excedenteTotal = PlayerPrefs.GetFloat("excedenteTotal");
		excedenteTotalEjercicio = PlayerPrefs.GetFloat("excedenteTotalEjercicio");
		totalTime = PlayerPrefs.GetFloat("totalTime");
		isEat = PlayerPrefs.GetInt("isEat");
		isPlay = PlayerPrefs.GetInt("isPlay");
		actualDay = PlayerPrefs.GetInt("actualDay");
	}

	public void Delete()
	{
		/*
		BinaryFormatter bf = new BinaryFormatter();
		FileStream file = File.OpenWrite(Application.persistentDataPath + "/playerInfo.dat");

		PlayerData data = new PlayerData();

		bf.Serialize(file, data);

		file.Close();
		*/

		PlayerPrefs.SetFloat("caloriasActividad",0.0f);
		PlayerPrefs.SetFloat("caloriasAlimentacion",0.0f);
		PlayerPrefs.SetFloat("caloriasMaximas",0.0f);
		PlayerPrefs.SetFloat("excedenteTotal", 0.0f);
		PlayerPrefs.SetFloat("excedenteTotalEjercicio",0.0f);
		PlayerPrefs.SetFloat("totalTime",0.0f);
		PlayerPrefs.SetInt("isEat",0);
		PlayerPrefs.SetInt("isPlay",0);
		PlayerPrefs.SetInt("actualDay",0);
	}

	/*
	[Serializable]
	class PlayerData
	{
		public float caloriasActividad;
		public float caloriasAlimentacion;
		
		public float caloriasMaximas;

		public float totalTime;

		public bool isEat;
		public bool isPlay;

		public int actualDay;

		public float excedenteTotal;
		public int excedenteTotalEjercicio;
	}
	*/
}
