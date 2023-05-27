using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemController : MonoBehaviour
{
	public IItem _ItemEquipado = null;

	private void Start()
	{
		
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
				_ItemEquipado.LeftClick();
			}
		}
		else if (Input.GetMouseButton(2))
		{
			if (_ItemEquipado != null)
			{
				_ItemEquipado.RightClick();
			}
		}
	}
}
