using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// Dad's Pirate Adventure — DadShip.cs
/// Dad is the pirate captain of his own ship! He steers with big touch
/// buttons on a phone, or with the arrow keys / WASD on a keyboard.
/// Sailing over a glowing wave gives a speed boost. Bumping a sharp
/// rock or getting caught in a whirlpool costs one shield. A heart
/// repairs one shield. Dad cheers himself on in a "Dad says" bubble.
/// </summary>
public class DadShip : MonoBehaviour
{
    [Header("Sailing")]
    public float sailSpeed = 8f;
    public float boostSpeed = 14f;
    public float boostTime = 2f;
    public float minX = -8f, maxX = 8f;
    public float minY = -4f, maxY = 4f;

    [Header("Dad")]
    public int maxShields = 3;
    public int shields;
    public Text dadSaysText; // "Dad says" speech bubble

    private float boostLeft = 0f;
    private bool isBoosting = false;

    void Start()
    {
        shields = maxShields;
        Say("All aboard! Adventure time, me hearties!");
    }

    void Update()
    {
        // Keyboard steering: arrows or WASD.
        float steerX = Input.GetAxis("Horizontal");
        float steerY = Input.GetAxis("Vertical");

        // Touch steering is added by the on-screen buttons, which call
        // SteerTouch(x, y) every frame while they are held down.
        float speed = isBoosting ? boostSpeed : sailSpeed;
        Vector3 move = new Vector3(steerX, steerY, 0f) * speed * Time.deltaTime;
        transform.position += move;

        // Keep Dad's ship on the sea.
        float x = Mathf.Clamp(transform.position.x, minX, maxX);
        float y = Mathf.Clamp(transform.position.y, minY, maxY);
        transform.position = new Vector3(x, y, transform.position.z);

        // Little sailing bob and tilt, so the ship feels alive.
        transform.rotation = Quaternion.Euler(0f, 0f, -steerX * 8f);

        if (boostLeft > 0f)
        {
            boostLeft -= Time.deltaTime;
            if (boostLeft <= 0f) isBoosting = false;
        }

        // Spacebar = BOOST (same as the big BOOST button on touch).
        if (Input.GetKeyDown(KeyCode.Space)) Boost();
    }

    /// <summary>Called by the touch LEFT / RIGHT / UP / DOWN buttons.</summary>
    public void SteerTouch(float x, float y)
    {
        float speed = isBoosting ? boostSpeed : sailSpeed;
        transform.position += new Vector3(x, y, 0f) * speed * Time.deltaTime;
    }

    /// <summary>Called by the big BOOST button on touch.</summary>
    public void Boost()
    {
        isBoosting = true;
        boostLeft = boostTime;
        Say("Full sail ahead! Woo-hoo!");
    }

    /// <summary>Sailing over a glowing wave gives a speed boost.</summary>
    public void RideGlowingWave()
    {
        Boost();
        Say("A glowing wave! Hold on tight!");
    }

    /// <summary>Called when the ship hits a sharp rock or a whirlpool.</summary>
    public void HitHazard()
    {
        shields -= 1;
        if (shields <= 0)
        {
            shields = 0;
            Say("Oh no! My ship needs a rest... let's try again!");
            FindObjectOfType<PirateLevelManager>()?.OnShipSunk();
        }
        else
        {
            Say("Ouch! That rock was sharp! " + shields + " shields left!");
        }
    }

    /// <summary>Called when Dad grabs a floating heart.</summary>
    public void RepairHeart()
    {
        shields = Mathf.Min(maxShields, shields + 1);
        Say("A heart! Ship all fixed up!");
    }

    public void Say(string words)
    {
        if (dadSaysText != null) dadSaysText.text = "Dad says: \"" + words + "\"";
    }
}
