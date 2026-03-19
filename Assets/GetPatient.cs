using UnityEngine;

public class GetPatient : GAction
{
    GameObject resource;
    public override bool PrePerform()
    {
        target = GWorld.Instance.RemovePatient();
        if(target == null) return false;
        resource = GWorld.Instance.RemoveCubicle();
        if (resource == null)
        {
            GWorld.Instance.AddPatient(target);
            target = null;
            return false;
        }
        else
        {
            inventory.AddItem(resource);
        }
        GWorld.Instance.GetWorld().ModifyState("FreeCubicle", -1);
        return true;
    }
    public override bool PostPerform()
    {
        GWorld.Instance.GetWorld().ModifyState("Waiting", -1);
        if(target) target.GetComponent<GAgent>().inventory.AddItem(resource);
        return true;
    }
}
