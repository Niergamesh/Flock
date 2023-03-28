using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Food : MonoBehaviour
{
    public FoodAgent foodPrefeb;
    List<FoodAgent> agents = new List<FoodAgent>();
    [SerializeField] private float time;
    private float d_time;
    private float xOffset;
    private float yOffset;
    private float zOffset;

    [Range(50, 3000)]
    public int startingCount = 50;

    public float AgentDensity = 0.001f;

    void Update()
    {
        xOffset = Random.Range(-40f, 40f);
        yOffset = Random.Range(-40f, 40f);
        zOffset = Random.Range(-40f, 40f);
        d_time += Time.deltaTime;
        if (d_time > time)
        {
            d_time = 0;
            for (int i = 0; i < startingCount; i++)
            {
                FoodAgent newAgent = Instantiate(
                foodPrefeb,
                    Random.insideUnitSphere * startingCount * AgentDensity + new Vector3(xOffset, yOffset, zOffset),
                    new Quaternion(Random.Range(0f, 360f), Random.Range(0f, 360f), Random.Range(0f, 360f),
                    Random.Range(0f, 360f)),
                    transform
                );
                newAgent.name = "Agent" + i;
                newAgent.Initialize(this, agents);
                agents.Add(newAgent);
            }
        }
    }
}
