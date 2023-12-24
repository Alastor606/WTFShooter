using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(AIHealth))]
public class AIMovement : MonoBehaviour
{
    [SerializeField] private NavMeshAgent _agent;
    private AIHealth _health;
    public float Health { get {return _health.Value;} set { _health.Value = value; } }
    public float Speed = 3;
    void Awake()
    {
        _health = GetComponent<AIHealth>();
        _agent.destination = PlayerCamera.Singleton.transform.position;
        _agent.speed = Speed;
    }

}
