using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements.Experimental;

public class Patroller : MonoBehaviour
{
    private Transform[] patrolPoints;
    private List<Transform> GetUnsortedPatrolPoints()
    {
        // get the Transform of each child in the Patroller : 
        Transform[] children = gameObject.GetComponentsInChildren<Transform>();

        // Declare a Local List storing Transforms : 
        var points = new List<Transform>();
        for (int i = 0; i < children.Length; i++)
        {
            // Check if the child's name starts with the "Patrol Point" : 
            if (children[i].gameObject.name.StartsWith("Patrol Point("))
            {
                // if so add it to the ' points ' list : 
                points.Add(children[i]);
            }
        }   

        // Return the point list :
        return points;
    }
    private void Start()
    {
        // Get an Unsorted List of Patrol Points : 
        List <Transform> points = GetUnsortedPatrolPoints();
        // only continue if we found at least one patrol point : 
        if (points.Count > 0)
        {
            // prepare our array of Patrol Points : 
            patrolPoints = new Transform[points.Count];

            for (int i = 0; i < points.Count; i++)
            {
                // Quick Reference to the CurrentPoint : 
                Transform point = points[i];
            }
        }
    }
}