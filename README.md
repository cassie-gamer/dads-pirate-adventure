# Dad's Pirate Adventure

A game for Dad — no space, just the sea! Dad is the pirate captain of his own ship.

## The story

Dad sets sail in his big pirate ship to collect 20 lost gold coins and dig up the treasure chest on Treasure Island. He sails through sunny bays and stormy seas, dodges sharp rocks and whirlpools, rides glowing waves for speed boosts, and grabs hearts to repair his ship.

At the end he digs up the treasure chest and wins: **"Best Dad in the Whole Wide Sea!"**

## The 3 levels

1. **Sunny Bay** — collect 5 gold coins. Calm and sunny, a gentle start.
2. **Stormy Seas** — collect 7 gold coins. Sharp rocks and whirlpools — they cost a shield if you bump them!
3. **Treasure Island** — collect 8 gold coins, then sail into the treasure chest to dig it up and win!

Total: **20 gold coins**.

## How to play

- **Touch (phone / tablet):** big on-screen steering buttons to sail left, right, up and down, and a big **BOOST** button.
- **Keyboard (computer):** arrow keys or **WASD** to steer, **Spacebar** to boost.
- **Glowing waves:** sail over one for a speed boost.
- **Hearts:** grab one to repair a shield.
- **Rocks and whirlpools:** steer around them — each hit costs one shield. Lose all your shields and you restart the level.
- **Dad says:** Dad cheers himself on in a speech bubble as he sails.

## Unity scripts (in `Assets/Scripts/`)

- `DadShip.cs` — steering / sailing, BOOST, shields, hearts, glowing waves, "Dad says" speech bubble.
- `CoinCollector.cs` — spinning, sparkling gold coins.
- `RockHazard.cs` — sharp rocks and whirlpools, plus `GlowingWave` speed boosts and `HeartPickup` shield repairs.
- `PirateLevelManager.cs` — the 3 levels (5 / 7 / 8 coins), the treasure chest, and the win message.

## How to play it in Unity on Windows

1. Clone this repo: `git clone https://github.com/cassie-gamer/dads-pirate-adventure.git`
2. Open Unity Hub, click **Add**, and choose the cloned folder.
3. Open the project in Unity (a recent Unity version, e.g. Unity 6).
4. In the Project window, open `Assets/Scripts/` — the scripts above are ready to attach:
   - Attach `DadShip` to Dad's ship, `PirateLevelManager` to an empty GameObject, and `CoinCollector` / `RockHazard` to coins and rocks.
   - Add a Canvas with the steering buttons, BOOST button, coin counter, level text, and the "Dad says" text, and link them in the Inspector.
5. Press **Play** in Unity and sail!

A playable web version also exists as the `dad-s-pirate-adventure` artifact.
