using UnityEngine;

public class Rest : GAction
{
    public override bool PrePerform()
    {
        return true;
    }
    public override bool PostPerform()
    {
        //beliefs.RemoveState("exhausted");
        Nurse n = this.gameObject.GetComponent<Nurse>();
        if (n != null)
        {
            n.ResetFatigue();
        }
        return true;
    }
}
