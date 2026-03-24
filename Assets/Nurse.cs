using UnityEngine;

public class Nurse : GAgent
{
    private int currentFatiguePriority = 0;

    // Guardem la referència aquí per no haver de crear-ne de nous
    private SubGoal restGoal;

    protected override void Start()
    {
        base.Start();
        // Objectiu constant: tractar pacients (Prioritat 5)
        SubGoal s1 = new SubGoal("treatPatient", 1, false);
        goals.Add(s1, 5);

        // Objectiu de descans: comença amb prioritat 0 (no vol descansar encara)
        // Creem l'objectiu de descans i en guardem la referència
        restGoal = new SubGoal("exhausted", 0, false);
        goals.Add(restGoal, currentFatiguePriority);
    }

    public void IncreaseFatigue(int amount)
    {
        currentFatiguePriority += amount;

        // Ara modifiquem directament la prioritat fent servir la referència 'restGoal'
        if (goals.ContainsKey(restGoal))
        {
            goals[restGoal] = currentFatiguePriority;
        }

        if (currentFatiguePriority >= 10)
        {
            beliefs.ModifyState("exhausted", 1);
        }
    }

    public void ResetFatigue()
    {
        currentFatiguePriority = 0;
        beliefs.RemoveState("exhausted");

        // Tornem la prioritat a 0 usant la mateixa clau
        if (goals.ContainsKey(restGoal))
        {
            goals[restGoal] = 0;
        }
    }
}
