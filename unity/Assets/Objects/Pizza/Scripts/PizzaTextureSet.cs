using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

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
    private static int[] s_readyToBakeList = { 2, 3 };
    private static int[] s_bakedList = { 4, 5 };

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
