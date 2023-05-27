using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
	public static IItem _ItemEquipado = null;
	private static ItemController s_instancia;

	public static Vector3 PosicaoSoltar => GetInstancia().transform.position + GetInstancia().transform.forward;

	private void Start()
	{
		if (s_instancia == null)
		{
			s_instancia = this;
		}
	}

	private void Update()
	{
		ChecarUso();
	}

	private void ChecarUso()
	{
		if (Input.GetMouseButtonDown(0))
		{
			if (_ItemEquipado != null)
			{
				_ItemEquipado.CliquePrincipal();
			}
		}
		else if (Input.GetMouseButton(2))
		{
			if (_ItemEquipado != null)
			{
				_ItemEquipado.CliqueSecundario();
			}
		}

		if (Input.GetKeyDown(KeyCode.Space))
		{
			Pegaritem(null);
		}
	}

	public static ItemController GetInstancia()
	{
		return s_instancia;
	}

	public static void Pegaritem(IItem itemParaPegar)
	{
		if (_ItemEquipado != null)
		{
			_ItemEquipado.AoSoltar();
		}
		_ItemEquipado = itemParaPegar;
		if (_ItemEquipado != null)
		{
			_ItemEquipado.AoPegar();
		}
	}
}
