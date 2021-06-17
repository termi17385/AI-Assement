using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Waypoints : MonoBehaviour
{
    [SerializeField] private List<Transform> waypoints = new List<Transform>();
    [FormerlySerializedAs("_agents")] [SerializeField] private AgentManager[] agents;
    [SerializeField] private Color waypointColor;
    [SerializeField] private Color agentColor;
    
    // Update is called once per frame
    void Update()
    {
        // loops through the agents in the array and gets the index
        // sets the destination of the agent and checks the distance between
        // from the agent and the current waypoint
        foreach (var t in agents)
        {
            var script = t.GetComponent<Index>();                                               // gets the agents index
            if(t.gameObject.activeSelf) t.SetDestination(waypoints[script.index].position);     // sets the destination to the current waypoint
            
            // when the agent reaches the current waypoint
            // change to the next waypoint in the list
            if(Vector3.Distance(t.transform.position, waypoints[script.index].position) < 0.5f)
            {
                script.index++;
                if (script.index >= waypoints.Count)
                {
                    script.index = 0;
                    //break;
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        if(waypoints != null)
        {
            if (waypoints.Count >= 2)
            {
                for (int i = 1; i < waypoints.Count; i++)
                {
                    Debug.DrawLine(waypoints[i - 1].position, waypoints[i].position, waypointColor);
                }
            }
            if(agents != null)
            {
                for (int i = 0; i < agents.Length; i++)
                {
                    var script = agents[i].GetComponent<Index>();

                    Debug.DrawLine(agents[i].transform.position,
                    waypoints[script.index].position, agentColor);
                }
            }
        }
    }
}
