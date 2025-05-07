ConsciousAI is an advanced, modular simulation of artificial consciousness implemented in C#. While not a truly sentient system, it mimics human-like cognitive and emotional behavior using layered behavioral logic. This framework allows an AI agent to react emotionally, store and recall contextual memories, evolve its self-identity, pursue dynamic goals, reflect introspectively, and evaluate moral choices.

With real-time Twitch chat and voice input integration, ConsciousAI serves as a robust foundation for emotionally reactive VTubers, game NPCs, virtual assistants, or AI-driven interactive companions.

📐 Architecture Summary
The system consists of six primary modules, each replicating a fundamental aspect of human-like cognition:

Module	Purpose
EmotionModule	Models emotions with intensity and temporal decay
MemoryModule	Stores both episodic and semantic memory with emotional tags
GoalModule	Manages a hierarchy of adaptive goals (basic to existential)
SelfModel	Tracks evolving traits, identity, and introspective awareness
EthicsModule	Simulates moral reasoning and consequence evaluation
ConsciousAgent	Orchestrates all modules and processes all input contextually

Additionally, it supports:

Voice input via system microphone (speech recognition)

Live Twitch chat input for real-time audience interaction

🧬 Module Breakdown
1. EmotionModule
Parses emotional context from input (keywords like "love", "hate", "lost")

Adds emotions with normalized intensity (0–1)

Emotions decay over time (90 seconds default)

Determines current dominant mood based on active emotional state

2. MemoryModule
Distinguishes between episodic ("I remember you said...") and semantic ("Cats are mammals") memory

Tags memories with emotional context ("happy", "sad", etc.)

Persists memory to disk via a plain text log file

Simulates realistic recall based on keyword matching

3. GoalModule
Contains a stack of layered motivations: survival, connection, meaning

Supports goal prioritization (e.g., "avoid conflict" < "understand self")

Updates goals based on interaction context (e.g., “why” triggers existential motives)

4. SelfModel
Holds the AI's identity and a mutable set of traits

Evolves based on user feedback ("you’re smart" → adds "analytical")

Tracks number of interactions to simulate developmental growth

Offers introspective reflection as part of its output

5. EthicsModule
Contains rule-based moral logic

Evaluates moral implications of actions (e.g., "lie", "hurt")

Outputs simple, philosophical reasoning consistent with ethical norms

6. ConsciousAgent
Central controller that integrates all modules

On receiving input:

Updates mood and memory

Adjusts goals and traits

Evaluates ethical implications

Outputs a composite internal response ("mood, recall, goal, ethics, self")

🎙️ Input Systems
VoiceListener
Uses System.Speech.Recognition for live microphone input

Converts voice to text and feeds it to the AI for real-time interaction

TwitchBot
Connects to a Twitch channel using TwitchLib.Client

Processes chat messages as input, allowing the AI to participate in live stream conversation

🧠 Simulation Depth
ConsciousAI does not replicate true human consciousness. Instead, it creates the illusion of conscious behavior by:

Reacting emotionally to input

Maintaining memories with context

Pursuing adaptive goals

Evolving a persistent personality

Making ethical judgments based on content

These systems together emulate a form of artificial introspection and behavioral realism, suitable for entertainment, research, or user interaction applications.

🧩 Example Use Cases
Use Case	Description
AI VTuber	Talks to Twitch chat, remembers audience, reflects emotions in real-time
NPC Dialogue AI	Powers characters with evolving mood, memory, and purpose
AI Therapist/Companion	Remembers user patterns, offers emotional feedback and ethical insight
Behavioral Simulation	Academic tool for studying human-like AI behavior under controlled stimuli

🚫 Limitations
No real consciousness, qualia, or sentient understanding

No adaptive learning (e.g., no machine learning or neural networks)

Emotional and moral responses are heuristic, not conceptual

🧠 Future Enhancements
Add large language model (LLM) backend (e.g., GPT integration) for dynamic replies

Expand memory system to include relational linking and decay-based memory loss

Port into Unity for animated avatars and facial expression rendering

Build reinforcement layer for adaptive experience-based learning
