using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Dad's Pirate Adventure — PirateLevelManager.cs
/// Dad sails 3 levels to collect 20 gold coins in total:
///   Level 1 — Sunny Bay:        5 coins, calm and sunny.
///   Level 2 — Stormy Seas:      7 coins, sharp rocks and whirlpools.
///   Level 3 — Treasure Island:  8 coins, then dig up the treasure chest!
/// Landing on Treasure Island with all 20 coins wins the game:
/// "Best Dad in the Whole Wide Sea!"
/// </summary>
public class PirateLevelManager : MonoBehaviour
{
    [System.Serializable]
    public class PirateLevel
    {
        public string name = "Sunny Bay";
        public int coinsNeeded = 5;
        public string welcome = "Welcome to Sunny Bay!";
    }

    [Header("Levels")]
    public PirateLevel[] levels = new PirateLevel[]
    {
        new PirateLevel { name = "Sunny Bay", coinsNeeded = 5, welcome = "Sunny Bay! Calm seas, shiny coins!" },
        new PirateLevel { name = "Stormy Seas", coinsNeeded = 7, welcome = "Stormy Seas! Watch out for rocks and whirlpools!" },
        new PirateLevel { name = "Treasure Island", coinsNeeded = 8, welcome = "Treasure Island! Find the chest!" },
    };

    [Header("UI")]
    public Text levelText;
    public Text coinText;
    public Text winText;
    public GameObject treasureChest; // Appears on Treasure Island

    private int levelIndex = 0;
    private int coinsInLevel = 0;
    private int totalCoins = 0;
    private bool hasWon = false;

    void Start()
    {
        totalCoins = 0;
        StartLevel(0);
    }

    void StartLevel(int index)
    {
        levelIndex = index;
        coinsInLevel = 0;
        PirateLevel level = levels[levelIndex];
        if (levelText != null) levelText.text = "Level " + (levelIndex + 1) + ": " + level.name;
        UpdateCoinText();
        DadShip dad = FindObjectOfType<DadShip>();
        if (dad != null) dad.Say(level.welcome);
        if (treasureChest != null) treasureChest.SetActive(false);
    }

    public void CollectCoin(int value)
    {
        if (hasWon) return;
        coinsInLevel += value;
        totalCoins += value;
        UpdateCoinText();

        PirateLevel level = levels[levelIndex];
        if (coinsInLevel >= level.coinsNeeded)
        {
            if (levelIndex < levels.Length - 1)
            {
                StartLevel(levelIndex + 1);
            }
            else
            {
                // All 20 coins! The treasure chest appears on Treasure Island.
                if (treasureChest != null) treasureChest.SetActive(true);
                DadShip dad = FindObjectOfType<DadShip>();
                if (dad != null) dad.Say("All 20 coins! Now dig up the treasure chest!");
            }
        }
    }

    /// <summary>Called when Dad sails into the treasure chest on Treasure Island.</summary>
    public void DigUpTreasure()
    {
        if (hasWon) return;
        if (totalCoins < 20) return; // Need all 20 coins first.
        hasWon = true;
        if (winText != null) winText.text = "Best Dad in the Whole Wide Sea!";
        DadShip dad = FindObjectOfType<DadShip>();
        if (dad != null) dad.Say("We found the treasure! Best Dad in the Whole Wide Sea!");
    }

    /// <summary>Called when Dad runs out of shields.</summary>
    public void OnShipSunk()
    {
        DadShip dad = FindObjectOfType<DadShip>();
        if (dad != null) dad.Say("Don't give up, Captain! Try again!");
        // Restart the current level (coins in this level reset).
        coinsInLevel = 0;
        StartLevel(levelIndex);
    }

    void UpdateCoinText()
    {
        if (coinText != null) coinText.text = "Gold coins: " + totalCoins + " / 20";
    }
}
