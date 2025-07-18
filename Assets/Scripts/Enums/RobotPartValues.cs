using UnityEngine;

public enum RobotPartValues
{
    Head, BodyCore, Chest, Back, UpperArm, ForeArm, Hand, UpperLeg, Shin, Foot
}
public static class RobotPartValueMethods
{
    public static bool IsLimb(RobotPartValues part)
    {
        return part == RobotPartValues.UpperArm || part == RobotPartValues.ForeArm || part == RobotPartValues.Hand || part == RobotPartValues.UpperLeg || part == RobotPartValues.Shin || part == RobotPartValues.Foot;
    }
}
