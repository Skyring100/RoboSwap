using System;
using System.Collections.Generic;
using UnityEngine;

public class RobotCharacter : MonoBehaviour
{
    private Dictionary<RobotPartValues, RobotPart> mainRobotParts = new Dictionary<RobotPartValues, RobotPart> { { RobotPartValues.Head, null }, { RobotPartValues.BodyCore, null } };
    private Dictionary<RobotPartValues, RobotPart> rightLimbs = new Dictionary<RobotPartValues, RobotPart> { { RobotPartValues.UpperArm, null }, { RobotPartValues.ForeArm, null },{ RobotPartValues.Hand, null },
    { RobotPartValues.UpperLeg, null }, { RobotPartValues.Shin, null }, { RobotPartValues.Foot, null } };
    private Dictionary<RobotPartValues, RobotPart> leftLimbs = new Dictionary<RobotPartValues, RobotPart> { { RobotPartValues.UpperArm, null }, { RobotPartValues.ForeArm, null },{ RobotPartValues.Hand, null },
    { RobotPartValues.UpperLeg, null }, { RobotPartValues.Shin, null }, { RobotPartValues.Foot, null } };
    private int armorStat;
    private int mobilityStat;
    private int energyStat;
    private int computationStat;
    private void ComputeRobotPartStats()
    {
        // Should be used upon confirming robot part selection. If stats change during gameplay (such as getting part disabled), do not fully recompute for performance reasons
        // For every robot part, add the bonuses each one provides to this robot's stats
        foreach (RobotPart part in mainRobotParts.Values)
        {
            foreach (KeyValuePair<RobotStatValues, int> statBonus in part.GetStatBonus())
            {
                switch (statBonus.Key)
                {
                    case RobotStatValues.Armor:
                        armorStat += statBonus.Value;
                        break;
                    case RobotStatValues.Mobility:
                        mobilityStat += statBonus.Value;
                        break;
                    case RobotStatValues.Energy:
                        energyStat += statBonus.Value;
                        break;
                    case RobotStatValues.Computation:
                        computationStat += statBonus.Value;
                        break;
                }
            }
        }
    }
    public int GetStat(RobotStatValues s)
    {
        switch (s)
        {
            case RobotStatValues.Armor:
                return armorStat;
            case RobotStatValues.Mobility:
                return mobilityStat;
            case RobotStatValues.Energy:
                return energyStat;
            case RobotStatValues.Computation:
                return computationStat;
            default:
                throw new InvalidOperationException(gameObject.name + " has no stat " + s);
        }

    }
    public void EquipRobotPart(RobotPart part, bool isRight)
    {
        if (!RobotPartValueMethods.IsLimb(part.GetPartType()))
        {
            mainRobotParts[part.GetPartType()] = part;
        }
        else
        {
            if (isRight)
            {
                rightLimbs[part.GetPartType()] = part;
            }
            else
            {
                leftLimbs[part.GetPartType()] = part;
            }
        }

    }
    public void EquipRobotPart(RobotPart part)
    {
        if (RobotPartValueMethods.IsLimb(part.GetPartType()))
        {
            throw new InvalidOperationException("This robot part is a limb, please specify left or right side to equipt");
        }
        mainRobotParts[part.GetPartType()] = part;
    }
}
