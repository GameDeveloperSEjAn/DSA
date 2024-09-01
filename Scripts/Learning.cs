using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Learning : MonoBehaviour
{
    void Start()
    {
        Guy.LogInstanceCount();
        Guy guy = new Guy ("jisan", 4, true );
        Guy.LogInstanceCount();
    }
}
public class Guy
{
    public static int NumberOfInstances = 0;

    public string name;
    public int netWorth;
    public bool canBeDefeated;

    public Guy(string name, int netWorth, bool canBeDefeated)
    {
        NumberOfInstances += 1;

        this.name = name;
        this.netWorth = netWorth;
        this.canBeDefeated = canBeDefeated;
    }
    public void LogInfo()
    {
        Debug.Log("Guy's Name is : " + this.name + " and NetWorth is : " + this.netWorth + " Defeatable : " + this.canBeDefeated);
    }
    public static void LogInstanceCount()
    {
        Debug.Log("Number of Item instances is : " + NumberOfInstances);
    }
}