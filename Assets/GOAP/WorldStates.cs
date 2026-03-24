using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WorldState
{
    public string key;
    public int value;
}

public class WorldStates
{
    public Dictionary<string, int> states;

    public WorldStates()
    {
        states = new Dictionary<string, int>();
    }

    public bool HasStatge(string key)
    {
        return states.ContainsKey(key);
    }

    public void AddState(string key, int value)
    {
        states[key] = value;
    }

    public void ModifyState(string key, int value)
    {
        if (states.ContainsKey(key))
        {
            states[key] += value;
            if (states[key] < 0) states[key] = 0; // No deixem que sigui negatiu
        }
        else
        {
            // Si intentem restar un estat que no existeix, el posem a 0
            states.Add(key, Mathf.Max(0, value));
        }
    }

    public void RemoveState(string key)
    {
        if (states.ContainsKey(key))
        {
            states.Remove(key);
        }
    }

    public void SetState(string key, int value)
    {
        if (states.ContainsKey(key))
        {
            states[key] = value;
        }
        else
        {
            states.Add(key, value);
        }
    }

    public Dictionary<string,int> GetStates()
    {
        return states;
    }
}
