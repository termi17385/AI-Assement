using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraHandler : MonoBehaviour
{
    #region Classes
    [System.Serializable] private class CameraStuff { public List<GameObject> camObjects = new List<GameObject>(); }
    [System.Serializable] private class AgentTypes
    {
        public Transform[] rgb;
        public SpriteRenderer[] agentSprites;
    }
    #endregion
    #region Variables  
    [SerializeField, Tooltip("Camera Related objects for the 'set level'")] 
    private List<CameraStuff> cameraStuffs = new List<CameraStuff>();
    [SerializeField,Tooltip("the different agent types for swapping between")] 
    private AgentTypes[] agents;
    [SerializeField] 
    private CinemachineVirtualCamera[] cmVCams;
    
    private int index = 0;
    private int agentPos; // just so that the camera method can tell what the last agent was
    #endregion

    private void Start() => AgentSelect(0);
    private void Update() => SwapCamera();
    
    /// <summary>
    /// Lets the spectator choose which agent to follow <br/>
    /// in the current level
    /// </summary>
    /// <param name="_agent">which agent to view</param>
    public void AgentSelect(int _agent)
    {
        var transform = agents[index].rgb[_agent];
        cmVCams[index].m_Follow = transform;
        cmVCams[index].m_LookAt = transform;

        var _agents = agents[index];
        foreach (var t in _agents.agentSprites) t.color = ActiveUnit(false);
        agents[index].agentSprites[_agent].color = ActiveUnit(true);

        agentPos = _agent;
    }
    /// <summary>
    /// Swaps between The different cameras (to see the other agent types)
    /// </summary>
    private void SwapCamera()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            var x = true;
            index = 0;
            AgentSelect(agentPos);
            for (int i = 0; i < cameraStuffs.Count;  i++)
            {
                x = i == 0;
                foreach (GameObject obj in cameraStuffs[i].camObjects)
                    obj.SetActive(x);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            var x = true;
            index = 1;
            AgentSelect(agentPos);
            for (int i = 0; i < cameraStuffs.Count;  i++)
            {
                x = i == 1;
                foreach (GameObject obj in cameraStuffs[i].camObjects)
                    obj.SetActive(x);
            }
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            var x = true;
            index = 2;
            AgentSelect(agentPos);
            for (int i = 0; i < cameraStuffs.Count;  i++)
            {
                x = i == 2;
                foreach (GameObject obj in cameraStuffs[i].camObjects)
                    obj.SetActive(x);
            }
        }
    }
    /// <summary>
    /// changes the color of the selected and non selected agents
    /// </summary>
    /// <returns>the color of the agent</returns>
    private Color ActiveUnit(bool _active)
    {
        return _active switch
        {
            true => Color.yellow,
            false => Color.white
        };
    }
}
