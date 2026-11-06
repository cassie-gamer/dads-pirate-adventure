using UnityEngine;

/// <summary>
/// Dad's Pirate Adventure — RockHazard.cs
/// Sharp rocks and swirling whirlpools. Hitting one costs Dad a
/// shield, so steer around them! Also in this file: GlowingWave
/// (ride it for a speed boost) and HeartPickup (repairs a shield).
/// </summary>
public class RockHazard : MonoBehaviour
{
    [Header("Hazard")]
    public float driftSpeed = 2f;
    public bool isWhirlpool = false;
    public float spinSpeed = 60f;

    void Update()
    {
        // Rocks drift slowly across the sea; whirlpools spin.
        transform.position += Vector3.left * driftSpeed * Time.deltaTime;
        if (isWhirlpool) transform.Rotate(0f, 0f, spinSpeed * Time.deltaTime);
        if (transform.position.x < -12f) Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        DadShip dad = other.GetComponent<DadShip>();
        if (dad == null) return;
        dad.HitHazard();
        // A rock breaks after it hits the ship, so it cannot hit twice.
        Destroy(gameObject);
    }
}

/// <summary>A glowing wave. Sail over it for a speed boost!</summary>
public class GlowingWave : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        DadShip dad = other.GetComponent<DadShip>();
        if (dad == null) return;
        dad.RideGlowingWave();
    }
}

/// <summary>A floating heart. Grab it to repair one shield.</summary>
public class HeartPickup : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        DadShip dad = other.GetComponent<DadShip>();
        if (dad == null) return;
        dad.RepairHeart();
        Destroy(gameObject);
    }
}
