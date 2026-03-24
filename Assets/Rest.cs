using UnityEngine;

public class Rest : GAction
{
    Nurse thisNurse;
    public override bool PrePerform()
    {
        return true;
    }
    public override bool PostPerform()
    {
        beliefs.RemoveState("exhausted");
        thisNurse = this.gameObject.GetComponent<Nurse>();
        thisNurse.resetPatient();
        return true;
    }
}