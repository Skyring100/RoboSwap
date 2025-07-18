using System.Collections.Generic;
public class RobotPart
{
    protected string partName;
    protected Dictionary<RobotStatValues, int> statBonuses;
    protected RobotPartValues partType;
    protected AttackAbility attackAbility;
    protected PassiveAbility passiveAbility;
    public RobotPart(string partName, Dictionary<RobotStatValues, int> statBonuses, RobotPartValues partType)
    {
        this.partName = partName;
        this.statBonuses = statBonuses;
        this.partType = partType;
    }
    public void SetAttackAbility(AttackAbility attackAbility)
    {
        this.attackAbility = attackAbility;
        attackAbility.source = this;
    }

    public void SetPassiveAbility(PassiveAbility passiveAbility)
    {
        this.passiveAbility = passiveAbility;
        passiveAbility.source = this;
    }

    public string GetPartName()
    {
        return partName;
    }
    public RobotPartValues GetPartType()
    {
        return partType;
    }
    public Dictionary<RobotStatValues, int> GetStatBonus()
    {
        return statBonuses;
    }
}
