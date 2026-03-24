using UnityEngine;

public class Nurse : GAgent
{
    private int patientsTreated = 0;
    protected override void Start()
    {
        base.Start();
        SubGoal s1 = new SubGoal("treatPatient", 1, false);
        goals.Add(s1, 5);

        SubGoal s2 = new SubGoal("rested", 1, false);
        goals.Add(s2, 7);

        Invoke("GetTired", Random.Range(10, 20));
    }

    void GetTired()
    {
        if(patientsTreated>Random.Range(2,5)) beliefs.ModifyState("exhausted", 0);
        Invoke("GetTired", Random.Range(10, 20));
    }

    public void incrementPatient()
    {
        patientsTreated++;
    }
    
    public void resetPatient()
    {
        patientsTreated=0;
    }
    
}
