using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaMount : MonoBehaviour
{

    private Material m_pizzaMat;
    private int m_currentIngridient;

    void Start()
    {
        m_pizzaMat = GetComponent<Renderer>().material;
        m_currentIngridient = 0;
    }

    void Update()
    {
        
    }

    public int GetIngrediente()
    {
        return m_currentIngridient;
    }

    public bool MontarIngrediente(int id)
    {

		if (GetComponent<SkinnedMeshRenderer>().GetBlendShapeWeight(0) < 1f)
        {
            DialogController.MostrarMsg("Amasse a pizza primeiro!");
			return false;
        }

        if (m_currentIngridient + 1 == id)
        {
            int newIngridientId = id;

            m_pizzaMat.SetTexture("_MainTex", PizzaTextureSet.s_ingridientList[newIngridientId].Texture);
            m_currentIngridient = newIngridientId;
            return true;
        }
        else
        {
			DialogController.MostrarMsg("Ordem de ingredientes Incorreta!");
			return false;
		}
	}
    public bool ForcarIngrediente(int id)
    {
		if (GetComponent<SkinnedMeshRenderer>().GetBlendShapeWeight(0) < 1f)
		{
			DialogController.MostrarMsg("Amasse a pizza primeiro!");
			return false;
		}

		int newIngridientId = id;

		m_pizzaMat.SetTexture("_MainTex", PizzaTextureSet.s_ingridientList[newIngridientId].Texture);
		m_currentIngridient = newIngridientId;
		return true;
	}
}
