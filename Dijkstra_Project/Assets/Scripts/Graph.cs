using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Graph
{
    List<Connection> mConnections;

    // an array of connections outgoing from the given node
    public List<Connection> getConnections(Node fromNode)
    {
        List<Connection> connections = new List<Connection>();
        foreach (Connection c in mConnections)
        {
            if (c.getFromNode() == fromNode)
            {
                connections.Add(c);
            }
        }
        return connections;
    }



    public void Build()
    {
        // find all nodes in scene
        // iterate over the nodes
        //   create connection objects,
        //   stuff them in mConnections
        mConnections = new List<Connection>();

        Node[] nodes = GameObject.FindObjectsOfType<Node>();
        foreach (Node fromNode in nodes)
        {
            foreach (Node toNode in fromNode.ConnectsTo)
            {
                float costMult = toNode.CostMult;
                //Debug.Log("CostMult = " + costMult);
                float cost = ((toNode.transform.position * costMult) - fromNode.transform.position).magnitude;
                Connection c = new Connection(cost, costMult, fromNode, toNode);
                mConnections.Add(c);
            }
        }
    }
}

public class Connection
{
    float cost;
    float costMult;
    Node fromNode;
    Node toNode;

    public Connection(float cost, float costMult, Node fromNode, Node toNode)
    {
        this.cost = cost;
        this.costMult = costMult;
        this.fromNode = fromNode;
        this.toNode = toNode;
    }
    public float getCost()
    {
        return cost;
    }

    public float getCostMult()
    {
        return costMult;
    }

    public Node getFromNode()
    {
        return fromNode;
    }

    public Node getToNode()
    {
        return toNode;
    }

    
}