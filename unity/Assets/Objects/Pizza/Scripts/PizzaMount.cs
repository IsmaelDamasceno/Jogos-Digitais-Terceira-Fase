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

    public bool MountIngridient(int id)
    {
        if (GetComponent<SkinnedMeshRenderer>().GetBlendShapeWeight(0) < 1f)
        {
            DialogController.MostrarMsg("Amasse a pizza primeiro!");
			return false;
        }

        if (m_currentIngridient + 1 == id)
        {
            int newIngridientId = id;
            foreach(PizzaIngridient itrIngridient in PizzaTextureSet.s_ingridientList)
            {
                if (itrIngridient.Id == newIngridientId)
                {
                    m_pizzaMat.SetTexture("_MainTex", itrIngridient.Texture);
                    m_currentIngridient = newIngridientId;
                    return true;
                }
            }
            throw new UnityException($"Id {newIngridientId} não existe na lista");
        }
        else
        {
            DialogController.MostrarMsg("Ordem de ingredientes Incorreta!");
        }

        return false;
    }
}
