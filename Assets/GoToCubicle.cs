using UnityEngine;

public class GoToCubicle : GAction
{
    Nurse thisNurse;
    public override bool PrePerform()
    {
        target = inventory.FindItemWithTag("Cubicle");
        if(target == null)
            return false;
        return true;
    }
    public override bool PostPerform()
    {
        GWorld.Instance.GetWorld().ModifyState("TreatingPatient", 1);
        GWorld.Instance.AddCubicle(target);
        inventory.RemoveItem(target);
        GWorld.Instance.GetWorld().ModifyState("FreeCubicle", 1);
        thisNurse = this.gameObject.GetComponent<Nurse>();
        thisNurse.incrementPatient();
        return true;
    }
}
