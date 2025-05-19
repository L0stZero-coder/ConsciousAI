# 🤖 ConsciousAI

**ConsciousAI** is an advanced, modular simulation of artificial consciousness developed in C#. While it does not possess true sentience, it convincingly mimics human-like cognition and emotional behavior through layered, logic-driven systems. The framework enables an AI agent to simulate emotions, form and recall memories, pursue evolving goals, reflect introspectively, and evaluate moral choices—all while interacting via real-time Twitch chat and voice input.

Ideal for AI-driven VTubers, emotionally aware NPCs, intelligent assistants, or behavioral simulations.

---

## 🧠 Architecture Overview

ConsciousAI consists of **six core modules**, each mirroring a key aspect of human-like cognition:

| Module         | Purpose |
|----------------|---------|
| `EmotionModule`   | Simulates emotions with intensity scaling and temporal decay |
| `MemoryModule`    | Stores episodic and semantic memory tagged with emotion |
| `GoalModule`      | Manages hierarchical goals (basic → existential) |
| `SelfModel`       | Tracks identity traits and developmental introspection |
| `EthicsModule`    | Simulates basic moral reasoning and ethical judgment |
| `ConsciousAgent`  | Integrates all modules and processes contextual input |

---

## 🧩 Module Breakdown

### 1. EmotionModule
- Parses emotional context from input (e.g., “love”, “hate”)
- Adds emotions with intensity (0–1)
- Emotions decay over time (default: 90 seconds)
- Outputs dominant mood

### 2. MemoryModule
- Differentiates episodic (event) vs. semantic (fact) memory
- Tags memories with emotion (e.g., "happy", "angry")
- Stores data in a persistent plain text log
- Recalls based on keyword matching

### 3. GoalModule
- Maintains layered motivations: survival, connection, meaning
- Prioritizes goals (e.g., “stay safe” < “discover purpose”)
- Contextually adapts goals (e.g., “why” prompts existential analysis)

### 4. SelfModel
- Stores mutable personality traits and evolving identity
- Learns from feedback (“you are smart” → adds trait “analytical”)
- Tracks interaction count to simulate developmental progress
- Offers introspective self-reporting

### 5. EthicsModule
- Contains moral logic rules
- Evaluates actions like “lie” or “hurt” against ethical frameworks
- Outputs simplified philosophical justifications

### 6. ConsciousAgent
- Core controller integrating all modules
- On input:
  - Updates emotional state and memory
  - Adjusts goals and personality
  - Performs ethical evaluation
  - Produces compound response (emotion + memory + ethics + identity)

---

## 🔊 Input Systems

### 🎤 Voice Input
- Uses `System.Speech.Recognition` to convert microphone input to text
- Enables real-time, spoken interaction

### 💬 TwitchBot
- Integrates with Twitch via `TwitchLib.Client`
- Processes Twitch chat messages as live input
- Enables AI participation in stream conversation

---

## 🧠 Simulation Depth

ConsciousAI creates a convincing illusion of artificial consciousness through:
- Emotional reactivity
- Contextual memory retention
- Adaptive goal-setting
- Trait evolution
- Ethical reasoning

These components together enable immersive AI personalities for interactive environments.

---

## 💡 Example Use Cases

| Use Case             | Description |
|----------------------|-------------|
| **AI VTuber**        | Engages with Twitch chat, remembers users, reflects moods |
| **NPC Dialogue AI**  | Empowers game characters with memory, purpose, and emotion |
| **AI Companion**     | Remembers user patterns, offers ethical/emotional feedback |
| **Behavioral Sim**   | Academic model for human-like behavioral AI responses |

---

## ⚠️ Limitations

- No actual consciousness or qualia
- No machine learning or neural network-based adaptation
- Responses are heuristic, not conceptual or reflective of true understanding

---

## 🚧 Future Enhancements

- Integrate GPT or other LLM for dynamic language generation
- Expand memory system with relational decay and link modeling
- Unity integration for real-time avatar expression rendering
- Add reinforcement layer for experience-based behavioral adaptation

---

## 📄 License

This project is open for educational and experimental use. License coming soon.

---

## 🙌 Contributions

Contributions and suggestions are welcome! Feel free to open issues or pull requests to help improve the framework.
