using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PizzaMount : MonoBehaviour
{

    private Material m_pizzaMat;
    private float m_currentIngridient;

    void Start()
    {
        m_pizzaMat = GetComponent<Renderer>().material;
        m_currentIngridient = 0;
    }

    void Update()
    {
        
    }

    public bool MountIngridient(float id)
    {
        if (GetComponent<SkinnedMeshRenderer>().GetBlendShapeWeight(0) < 1f)
        {
            return false;
        }

        if (Mathf.Floor(m_currentIngridient) + 1 == Mathf.Floor(id) || ((Mathf.Floor(m_currentIngridient) == Mathf.Floor(id)) && (m_currentIngridient < id)))
        {
            float newIngridientId = id;
            foreach(PizzaIngridient itrIngridient in PizzaTextureSet.s_ingridientList)
            {
                if (itrIngridient.Id == newIngridientId)
                {
                    m_pizzaMat.SetTexture("_MainTex", itrIngridient.Texture);
                    m_currentIngridient = newIngridientId;
                    return true;
                }
            }
            throw new UnityException($"Id {newIngridientId} n�o existe na lista");
        }

        return false;
    }
}
