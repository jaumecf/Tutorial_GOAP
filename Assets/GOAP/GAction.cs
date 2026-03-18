using System;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;

public abstract class GAction : MonoBehaviour
{

    public string actionName = "Action";
    public float cost = 1.0f;
    public GameObject target;
    public string targetTag;
    public float duration = 0;
    public WorldState[] preConditions;
    public WorldState[] afterConditions;
    public NavMeshAgent agent;

    public Dictionary<string, int> preconditions;
    public Dictionary<string, int> effects;

    public WorldStates agentBeliefs;
    public bool running = false;
    public GAction()
    {
        preconditions = new Dictionary<string, int>();
        effects = new Dictionary<string, int>();
    }


    public void Awake()
    {
        // En lloc d'AddComponent, fem GetComponent
        // Això agafa l'agent que ja té el personatge
        agent = this.gameObject.GetComponent<NavMeshAgent>();

        // Opcional: Si vols ser molt segur, pots fer:
        if (agent == null)
        {
            agent = this.gameObject.AddComponent<NavMeshAgent>();
        }

        if (preConditions != null)
            foreach(WorldState w  in preConditions)
            {
                preconditions.Add(w.key, w.value);
            }
        if (afterConditions != null)
            foreach (WorldState w in afterConditions)
            {
                effects.Add(w.key, w.value);
            }
    }

    public bool IsAchievable()
    {
        return true;
    }

    public bool IsAchievableGiven(Dictionary<string, int> conditions)
    {
        foreach(KeyValuePair<string, int> c in preconditions)
        {
            if(!conditions.ContainsKey(c.Key))
                return false;
        }
        return true;
    }

    public abstract bool PrePerform();
    public abstract bool PostPerform();
}
