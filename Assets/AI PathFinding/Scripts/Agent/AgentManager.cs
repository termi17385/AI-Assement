using Unity.Collections;
using UnityEngine;
using UnityEngine.AI;
using UnityStandardAssets.Characters.ThirdPerson;

[RequireComponent(typeof(Index))]
[RequireComponent(typeof(NavMeshAgent))]
[RequireComponent(typeof(ThirdPersonCharacter))]
public class AgentManager : MonoBehaviour
{
    [SerializeField] private ThirdPersonCharacter animationController;
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private bool jump = false;
    [SerializeField] private bool crouch = false;
    [SerializeField, ReadOnly] Vector3 debugVelocity;

    // Start is called before the first frame update
    void Start()
    {
        animationController = GetComponent<ThirdPersonCharacter>();
        agent = GetComponent<NavMeshAgent>();

        agent.updateRotation = false;
    }
    
    private void Update() => animationController.Move((debugVelocity = agent.desiredVelocity), crouch, jump);
    public void SetDestination(Vector3 _move) => agent.SetDestination(_move);
}
