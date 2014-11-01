using UnityEngine;
using System.Collections;

public class StartMenuControl : MonoBehaviour 
{
	
	public void StartLevel()
	{
		if(PersistenciaUsuario.existenDatos())
		{
			GameControl.control.Load();
			AdministradorNiveles.cargarPrincipal();
		}else{
			PlayerPrefs.SetInt("configuration",0);//<-nueva partida
			AdministradorNiveles.cargarCapturaDatos();
		}
	}

	public void Creditos()
	{
		//Creditos
		AdministradorNiveles.cargarCreditos();
	}

	public void Configuracion()
	{
		//Configuracion
		PlayerPrefs.SetInt("configuration",1);//<- cambiar datos o reiniciar
		AdministradorNiveles.cargarCapturaDatos();
	}
}
