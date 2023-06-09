using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(SphereCollider))]
public class FlockAgent : MonoBehaviour
{
    Flock agentFlock;
    public Flock AgentFlock { get { return agentFlock; } }

    List<FlockAgent> agent1 ;

    public List<Transform> food;

    SphereCollider agentCollider;
    public SphereCollider AgentCollider { get{ return agentCollider; } }
    void Start()
    {
        agentCollider = GetComponent<SphereCollider>();
    }

    public void Initialize(Flock flock,List<FlockAgent> a)
    {
        agentFlock = flock;
        agent1 = a;
    }

    public void Move(Vector3 velocity)
    {
        transform.forward = velocity;
        transform.position += (Vector3)velocity * Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Predator"))
        {
            Destroy(gameObject);

            agent1.Remove(this);
        }
    }
    
}
