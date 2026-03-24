using UnityEngine;

public class GoToCubicle : GAction
{
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
        // Avisem a la infermera que s'ha cansat
        Nurse n = this.gameObject.GetComponent<Nurse>();
        if (n != null)
        {
            n.IncreaseFatigue(2); // Sumem 2 punts de cansament per pacient
        }
        return true;
    }
}
