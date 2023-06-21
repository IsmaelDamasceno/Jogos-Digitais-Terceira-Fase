using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public struct PizzaIngridient
{
    public PizzaIngridient(float id, string textureName)
    {
        this.Id = id;
        this.Texture = Resources.Load<Texture>(textureName);
    }

    public float Id;
    public Texture Texture;
}

public static class PizzaTextureSet
{
    public static PizzaIngridient[] s_ingridientList =
    {
        new PizzaIngridient(0f, "PizzaBase"),
        new PizzaIngridient(1f, "PizzaSauce"),
        new PizzaIngridient(2.1f, "PizzaMuzzarela"),
        new PizzaIngridient(2.2f, "PizzaPepperoni")
    };
}
