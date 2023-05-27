using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItem
{
	/// <summary>
	/// Executado quando o bot�o esquerdo do mouse � pressionado segurando o item
	/// </summary>
	public void LeftClick();

	/// <summary>
	/// Executado quando o bot�o direito do mouse � pressionado segurando o item
	/// </summary>
	public void RightClick();
}
