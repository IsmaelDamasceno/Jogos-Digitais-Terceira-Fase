using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IItem
{
	/// <summary>
	/// Executado quando o botão esquerdo do mouse é pressionado segurando o item
	/// </summary>
	public void LeftClick();

	/// <summary>
	/// Executado quando o botão direito do mouse é pressionado segurando o item
	/// </summary>
	public void RightClick();
}
