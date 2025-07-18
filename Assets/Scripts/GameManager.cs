using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.Tilemaps;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public List<RobotPart> robotPartLibrary = new List<RobotPart>();
    [SerializeField] private GameObject robotPartPanelPrefab;
    [SerializeField] private RobotCharacter player;

    [SerializeField] private Tilemap tilemap;
    [SerializeField] private TileBase whiteTile;

    [SerializeField] private GameObject leftRightButton;
    void Start()
    {
        InitializeRobotPartLibrary();
        /*
        GameObject partLibraryPanel = GameObject.Find("Part Library Panel");
        foreach (RobotPart part in robotPartLibrary)
        {
            GameObject partPanel = Instantiate(robotPartPanelPrefab, partLibraryPanel.transform);
            Transform button = partPanel.transform.GetChild(1);
            button.GetComponentInChildren<TextMeshProUGUI>().text = part.GetPartName();
            button.GetComponent<Button>().onClick.AddListener(() => EquipPartButton(part));
        }
        leftRightButton = Instantiate(leftRightButton, GameObject.Find("UI Canvas").transform);
        leftRightButton.SetActive(false);
        */
        CreateMap(10, 10);
    }


    // Update is called once per frame
    void Update()
    {

    }

    private void InitializeRobotPartLibrary()
    {
        RobotPart numbSkull = new RobotPart("NumbSkull", new Dictionary<RobotStatValues, int> { { RobotStatValues.Armor, 3 }, { RobotStatValues.Computation, -3 } }, RobotPartValues.Head);
        robotPartLibrary.Add(numbSkull);

        RobotPart basicCore = new RobotPart("Basic Core", new Dictionary<RobotStatValues, int> { { RobotStatValues.Armor, 1 }, { RobotStatValues.Mobility, 1 }, { RobotStatValues.Energy, 1 }, { RobotStatValues.Computation, 1 } }, RobotPartValues.BodyCore);
        robotPartLibrary.Add(basicCore);

        RobotPart energizedChest = new RobotPart("Energized Chest", new Dictionary<RobotStatValues, int>{ { RobotStatValues.Energy, 3 } }, RobotPartValues.Chest);
        robotPartLibrary.Add(energizedChest);

        RobotPart orbitalStrike = new RobotPart("Orbital Strike", new Dictionary<RobotStatValues, int> { { RobotStatValues.Computation, 1 } }, RobotPartValues.Back);
        //add ability
        robotPartLibrary.Add(orbitalStrike);

        RobotPart gasJets = new RobotPart("Gas Jets", new Dictionary<RobotStatValues, int> { { RobotStatValues.Mobility, 1 } }, RobotPartValues.UpperArm);
        //add ability
        robotPartLibrary.Add(gasJets);

        RobotPart boosterJetForeArms = new RobotPart("Booster Jet Forearms", new Dictionary<RobotStatValues, int>{}, RobotPartValues.ForeArm);
        //add passive ability
        robotPartLibrary.Add(boosterJetForeArms);

        RobotPart flamethrower = new RobotPart("Flamethrower", new Dictionary<RobotStatValues, int> { }, RobotPartValues.Hand);
        flamethrower.SetAttackAbility(new FlamethrowerAbility(3, TargetMethod.AOE, new Dictionary<RobotStatValues, int>() { { RobotStatValues.Energy, 3 } }));
        robotPartLibrary.Add(flamethrower);

        RobotPart thunderThighs = new RobotPart("Thunder Thighs", new Dictionary<RobotStatValues, int>{ { RobotStatValues.Armor, 1}, {RobotStatValues.Energy, 1} }, RobotPartValues.UpperLeg);
        //add passive ability
        robotPartLibrary.Add(thunderThighs);

        RobotPart shinShankers = new RobotPart("Shin Shankers", new Dictionary<RobotStatValues, int>{}, RobotPartValues.Shin);
        //add ability
        robotPartLibrary.Add(shinShankers);

        RobotPart rocketBoots = new RobotPart("Rocket Boots", new Dictionary<RobotStatValues, int> { { RobotStatValues.Mobility, 2 } }, RobotPartValues.Foot);
        //add ability
        robotPartLibrary.Add(rocketBoots);
    }

    public void ShowRobotPartLibrary()
    {

    }
    public void CreateMap(int xSize, int ySize)
    {
        for (int x = -xSize; x < xSize; x++)
        {
            for (int y = -ySize; y < ySize; y++)
            {
                tilemap.SetTile(new Vector3Int(x, y, 0), whiteTile);
            }
        }
    }
    public void EquipPartButton(RobotPart part)
    {
        if (RobotPartValueMethods.IsLimb(part.GetPartType()))
        {
            Button[] buttonList = leftRightButton.GetComponentsInChildren<Button>();
            //buttonList[0].onClick.AddListener();
            //buttonList[1].onClick.AddListener();
            leftRightButton.SetActive(true);
        }
        player.EquipRobotPart(part);
    }

}
