using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentActivation : MonoBehaviour
{
    [SerializeField] private List<GameObject> agents = new List<GameObject>();
    private void Start() => StartCoroutine(EngageAgents());
    private IEnumerator EngageAgents()
    {
        foreach (GameObject _obj in agents)
        {
            yield return new WaitForSeconds(5);
            _obj.SetActive(true);
        }
    }
}
