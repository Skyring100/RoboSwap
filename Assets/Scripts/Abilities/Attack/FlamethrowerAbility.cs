using System.Collections.Generic;
using UnityEngine;

public class FlamethrowerAbility : AttackAbility
{
    public FlamethrowerAbility(int baseDamage, TargetMethod targetMethod, Dictionary<RobotStatValues, int> minimumStatRequirement) : base(baseDamage, targetMethod, minimumStatRequirement)
    {

    }

    public override void DoAbilityAttack(RobotCharacter character, GameObject[] targets)
    {
        // Check if user can use ability
        if (CanUse(character)) {
            Debug.Log(character.gameObject.name+" did "+(baseDamage + character.GetStat(RobotStatValues.Energy))+" damage to "+ targets[0].name);
        }
    }
}
