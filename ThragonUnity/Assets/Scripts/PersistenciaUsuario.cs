using UnityEngine;
using System.Collections;

public class PersistenciaUsuario {

	public static string getNombre(){
		return PlayerPrefs.GetString("nombre","Thragon");
	}

	public static void setNombre(string nombre){
		PlayerPrefs.SetString("nombre",nombre);
	}

	public static float getPeso(){
		return PlayerPrefs.GetFloat("peso",-1.0f);
	}

	public static void setPeso(float peso){
		PlayerPrefs.SetFloat("peso", peso);
	}

	public static float getAltura(){
		return PlayerPrefs.GetFloat("altura",-1.0f);
	}

	public static void setAltura(float altura){
		PlayerPrefs.SetFloat("altura", altura);
	}

	public static int getEdad(){
		return PlayerPrefs.GetInt("edad",-1);
	}

	public static void setEdad(int edad){
		PlayerPrefs.SetInt("edad",edad);
	}

	public static Sexo getSexo(){

		string sexString = PlayerPrefs.GetString("sexo","hombre");
		if(sexString == "mujer"){
			return Sexo.mujer;
		}
		return Sexo.hombre;
	}

	public static void setSexo(Sexo s){
		switch(s){
		case Sexo.hombre:
			PlayerPrefs.SetString("sexo","hombre");
			break;
		case Sexo.mujer:
			PlayerPrefs.SetString("sexo","mujer");
			break;
		}
	}

	public static bool existenDatos(){
		bool hayNombre = PlayerPrefs.HasKey("nombre");
		bool hayPeso = PlayerPrefs.HasKey("peso");
		bool hayAltura = PlayerPrefs.HasKey("altura");
		bool hayEdad = PlayerPrefs.HasKey("edad");
		bool haySexo = PlayerPrefs.HasKey("sexo");
		return hayNombre && hayAltura && hayEdad && hayPeso && haySexo;
	}
}
