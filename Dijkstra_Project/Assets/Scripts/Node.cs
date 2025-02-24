using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Node : MonoBehaviour
{
    public Node[] ConnectsTo;

    public float CostMult = 1f;

    public TMP_InputField changeValue;

    public void ChangeMult()
    {
        
        
        if (float.TryParse(changeValue.text, out CostMult))
        {
            CostMult = float.Parse(changeValue.text);
            Debug.Log("New cost = " + CostMult.ToString());
        }
        else
        {
            Debug.Log("Could not convert");
        }
        
    }

    private void OnDrawGizmos()
    {
        foreach (Node n in ConnectsTo)
        {
            Gizmos.color = Color.red;
            //Gizmos.DrawLine(transform.position, n.transform.position);
            Gizmos.DrawRay(transform.position, (n.transform.position - transform.position).normalized * 2);
        }
    }

}
