using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct PizzaIngridient
{
    public PizzaIngridient(int id, string textureName)
    {
        this.Id = id;
        this.Texture = Resources.Load<Texture>(textureName);
    }

    public int Id;
    public Texture Texture;
}

public static class PizzaTextureSet
{
    public static PizzaIngridient[] s_ingridientList =
    {
        new PizzaIngridient(0, "PizzaBase"),
        new PizzaIngridient(1, "PizzaSauce"),
        new PizzaIngridient(2, "PizzaMuzzarela"),
        new PizzaIngridient(3, "PizzaPepperoni")
    };
}
