using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BakeButtonInteractioon : MonoBehaviour, IInteractable
{
	public string _RotuloInteracao { get => "Ligar Forno"; }

	public void Interagir()
	{
		Debug.Log("Ligar forno foi apertado");
	}
	public bool ChecarInteracao()
	{
		return Input.GetKeyDown(KeyCode.E);
	}
}
