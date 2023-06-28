using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public enum PizzaEstado
{
	Inteira,
	Crua,
	ParaAssar,
	Assada
}

public struct PizzaIngridient
{
    public PizzaIngridient(string textureName)
    {
        this.Texture = Resources.Load<Texture>(textureName);
        this.TextureName = textureName;
    }

    public Texture Texture;
    public string TextureName;
}

public static class PizzaTextureSet
{
    public static PizzaIngridient[] s_ingridientList =
    {
        new PizzaIngridient("PizzaBase"),
        new PizzaIngridient("PizzaSauce"),
        new PizzaIngridient("PizzaMuzzarela"),
        new PizzaIngridient("PizzaPepperoni"),
        new PizzaIngridient("PizzaMuzzarelaBaked"),
        new PizzaIngridient("PizzaPepperoniBaked")
    };
    private static readonly int[] s_readyToBakeList = { 2, 3 };
    private static readonly int[] s_bakedList = { 4, 5 };
	private static readonly Vector2Int[] s_rawToBaked = {
		new Vector2Int(2, 4),
		new Vector2Int(3, 5)
	};

    public static int GetId(string nomeTextura)
    {
        int i = 0;
        foreach(PizzaIngridient itrIngrediente in s_ingridientList)
        {
            if (itrIngrediente.TextureName == nomeTextura)
            {
                return i;
            }
            i++;
        }
        return -1;
    }

	#region Associar pizza assada à pizza crua
    public static int PizzaVersaoAssada(GameObject pizza)
    {
		return PizzaVersaoAssada(pizza.GetComponent<PizzaMount>().GetIngrediente());
    }
	public static int PizzaVersaoAssada(PizzaMount pizza)
	{
		return PizzaVersaoAssada(pizza.GetIngrediente());
	}
	public static int PizzaVersaoAssada(int pizza)
	{
		foreach (Vector2Int pair in s_rawToBaked)
		{
			if (pair.x == pizza)
			{
				return pair.y;
			}
		}
		return -1;
	}
	#endregion

	#region Pizza Pronta Para Assar
	public static bool PizzaProntaAssar(GameObject pizza)
	{
		return PizzaProntaAssar(pizza.GetComponent<PizzaMount>().GetIngrediente());
	}
	public static bool PizzaProntaAssar(PizzaMount pizzaMount)
	{
		return PizzaProntaAssar(pizzaMount.GetIngrediente());
	}
	public static bool PizzaProntaAssar(int id)
	{
		return (Array.IndexOf(s_readyToBakeList, id) > -1);
	}
	#endregion

	public static PizzaEstado PizzaGetEstado(GameObject pizza)
	{
		return PizzaGetEstado(pizza.GetComponent<PizzaMount>());
	}
	public static PizzaEstado PizzaGetEstado(PizzaMount pizza)
	{
		float pizzaWeight = pizza.GetComponent<SkinnedMeshRenderer>().GetBlendShapeWeight(0);
		if (pizzaWeight < 1f)
		{
			return PizzaEstado.Inteira;
		}
		else if (PizzaProntaAssar(pizza))
		{
			return PizzaEstado.ParaAssar;
		}
		else if (PizzaAssada(pizza))
		{
			return PizzaEstado.Assada;
		}
		else
		{
			return PizzaEstado.Crua;
		}
	}

	#region Pizza Assada
	public static bool PizzaAssada(GameObject pizza)
	{
		return PizzaAssada(pizza.GetComponent<PizzaMount>().GetIngrediente());
	}
	public static bool PizzaAssada(PizzaMount pizzaMount)
	{
		return PizzaAssada(pizzaMount.GetIngrediente());
	}
	public static bool PizzaAssada(int id)
	{
		return (Array.IndexOf(s_bakedList, id) > -1);
	}
	#endregion

}
