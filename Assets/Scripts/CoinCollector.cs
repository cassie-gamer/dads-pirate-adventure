using UnityEngine;

/// <summary>
/// Dad's Pirate Adventure — CoinCollector.cs
/// Shiny gold coins floating on the sea. Dad sails his ship into a
/// coin to collect it. Each coin spins and sparkles so it is easy
/// to spot. The PirateLevelManager counts them.
/// </summary>
public class CoinCollector : MonoBehaviour
{
    [Header("Coin")]
    public int coinValue = 1;
    public float spinSpeed = 120f;
    public float bobAmount = 0.2f;

    private Vector3 startPos;
    private bool collected = false;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        if (collected) return;
        // Spin and bob on the waves.
        transform.Rotate(0f, spinSpeed * Time.deltaTime, 0f);
        float bob = Mathf.Sin(Time.time * 2f) * bobAmount;
        transform.position = new Vector3(startPos.x, startPos.y + bob, startPos.z);
    }

    void OnTriggerEnter(Collider other)
    {
        if (collected) return;
        if (other.GetComponent<DadShip>() == null) return;

        collected = true;
        PirateLevelManager manager = FindObjectOfType<PirateLevelManager>();
        if (manager != null) manager.CollectCoin(coinValue);

        DadShip dad = other.GetComponent<DadShip>();
        if (dad != null) dad.Say("A gold coin! Shiny!");

        // Little sparkle, then the coin is gone.
        Destroy(gameObject);
    }
}
