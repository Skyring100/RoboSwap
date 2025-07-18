using System.Collections.Generic;
using UnityEngine;

public abstract class AttackAbility
{
    protected int baseDamage;
    protected TargetMethod targetMethod;
    protected Dictionary<RobotStatValues, int> minimumStatRequirement;
    public RobotPart source;

    protected AttackAbility(int baseDamage, TargetMethod targetMethod, Dictionary<RobotStatValues, int> minimumStatRequirement)
    {
        this.baseDamage = baseDamage;
        this.targetMethod = targetMethod;
        this.minimumStatRequirement = minimumStatRequirement;
    }
    public bool CanUse(RobotCharacter c)
    {
        foreach (KeyValuePair<RobotStatValues, int> requirement in minimumStatRequirement)
        {
            if (c.GetStat(requirement.Key) < requirement.Value)
            {
                return false;
            }
        }
        return true;
    }
    public abstract void DoAbilityAttack(RobotCharacter character, GameObject[] targets);
}
