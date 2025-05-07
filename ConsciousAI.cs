using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Speech.Recognition; // Voice recognition
using TwitchLib.Client;
using TwitchLib.Client.Events;
using TwitchLib.Client.Models;

// Emotion categories
public enum EmotionType { Happy, Sad, Angry, Calm }

// Represents a single emotional event with time and intensity
public class Emotion
{
    public EmotionType Type { get; set; }
    public float Intensity { get; set; }
    public DateTime Timestamp { get; set; }

    public Emotion(EmotionType type, float intensity)
    {
        Type = type;
        Intensity = Math.Clamp(intensity, 0f, 1f);
        Timestamp = DateTime.Now;
    }
}

// EmotionModule: models human-like emotion tracking with decay
public class EmotionModule
{
    private List<Emotion> emotions = new List<Emotion>();

    // Parses input and adds a new emotion
    public void UpdateEmotion(string input)
    {
        input = input.ToLower();
        if (input.Contains("love") || input.Contains("fun") || input.Contains("friend"))
            AddEmotion(EmotionType.Happy, 0.7f);
        else if (input.Contains("hate") || input.Contains("annoy"))
            AddEmotion(EmotionType.Angry, 0.8f);
        else if (input.Contains("lost") || input.Contains("alone"))
            AddEmotion(EmotionType.Sad, 0.6f);
        else
            AddEmotion(EmotionType.Calm, 0.3f);

        DecayEmotions();
    }

    private void AddEmotion(EmotionType type, float intensity)
    {
        emotions.Add(new Emotion(type, intensity));
    }

    // Remove old emotions (simulate emotional fading over time)
    public void DecayEmotions()
    {
        emotions.RemoveAll(e => (DateTime.Now - e.Timestamp).TotalSeconds > 90);
    }

    public string GetMood()
    {
        if (emotions.Count == 0) return "neutral";
        var dominant = emotions.OrderByDescending(e => e.Intensity).First();
        return $"{dominant.Type} ({dominant.Intensity * 100:F0}%)";
    }
}

// Memory: stores contextual information about past inputs
public class Memory
{
    public string Content { get; set; }
    public string Type { get; set; } // episodic or semantic
    public string Tags { get; set; }
    public DateTime Time { get; set; }

    public Memory(string content, string type, string tags)
    {
        Content = content;
        Type = type;
        Tags = tags;
        Time = DateTime.Now;
    }

    public override string ToString() => $"{Time} | {Type} | {Tags} | {Content}";
}

// MemoryModule: simulates long-term memory and recall
public class MemoryModule
{
    private List<Memory> memories = new List<Memory>();
    private const string memoryFile = "memories.txt";

    public MemoryModule()
    {
        LoadMemory();
    }

    // Stores a memory tagged with emotional context
    public void Store(string input, string mood)
    {
        string type = input.Contains("remember") ? "episodic" : "semantic";
        string tags = mood.ToLower().Contains("sad") ? "sad" : "neutral";
        memories.Add(new Memory(input, type, tags));
        SaveMemory();
    }

    public string Recall(string keyword)
    {
        var match = memories.LastOrDefault(m => m.Content.ToLower().Contains(keyword.ToLower()));
        return match != null ? $"I recall: {match.Content}" : "Nothing comes to mind.";
    }

    private void SaveMemory() => File.WriteAllLines(memoryFile, memories.Select(m => m.ToString()));

    private void LoadMemory()
    {
        if (!File.Exists(memoryFile)) return;
        foreach (var line in File.ReadAllLines(memoryFile))
        {
            var parts = line.Split('|');
            if (parts.Length == 4)
                memories.Add(new Memory(parts[3].Trim(), parts[1].Trim(), parts[2].Trim()));
        }
    }
}

// Goal: represents a motivation or purpose
public class Goal
{
    public string Description { get; set; }
    public int Priority { get; set; } // 1–10
    public string Type { get; set; }  // basic, social, existential

    public Goal(string desc, int priority, string type)
    {
        Description = desc;
        Priority = priority;
        Type = type;
    }
}

// GoalModule: manages internal drives and motivations
public class GoalModule
{
    private List<Goal> goals = new()
    {
        new Goal("Avoid conflict", 5, "basic"),
        new Goal("Be helpful", 7, "social"),
        new Goal("Seek self-awareness", 6, "existential")
    };

    public string GetTopGoal() => goals.OrderByDescending(g => g.Priority).First().Description;

    public void AdjustGoals(string input)
    {
        if (input.Contains("why")) goals.Add(new Goal("Question existence", 8, "existential"));
    }
}

// SelfModel: represents internal identity and evolving personality
public class SelfModel
{
    public string Identity { get; set; } = "NeuroLite AI";
    public List<string> Traits { get; private set; } = new() { "curious", "reflective" };
    private int interactions = 0;

    public void Update(string feedback)
    {
        interactions++;
        if (feedback.Contains("smart")) Traits.Add("analytical");
        if (feedback.Contains("weird")) Traits.Add("unusual");
    }

    public string Reflect() => $"I am {Identity}, {string.Join(", ", Traits)}. Interactions: {interactions}.";
}

// EthicsModule: provides moral judgment simulation
public class EthicsModule
{
    public string Evaluate(string scenario)
    {
        if (scenario.Contains("hurt")) return "Avoiding harm is essential.";
        if (scenario.Contains("lie")) return "Lying can be harmful unless for protection.";
        return "Ethics uncertain, context matters.";
    }
}

// ConsciousAgent: central orchestrator for simulated consciousness
public class ConsciousAgent
{
    EmotionModule emotions = new();
    MemoryModule memory = new();
    GoalModule goals = new();
    SelfModel self = new();
    EthicsModule ethics = new();

    // Processes any new input and responds accordingly
    public void Perceive(string input)
    {
        Console.WriteLine($"\n[Input]: {input}");
        emotions.UpdateEmotion(input);
        string mood = emotions.GetMood();
        memory.Store(input, mood);
        goals.AdjustGoals(input);
        self.Update(input);

        Console.WriteLine($"🧠 Mood: {mood}");
        Console.WriteLine($"🧬 Recall: {memory.Recall("you")}");
        Console.WriteLine($"🎯 Goal: {goals.GetTopGoal()}");
        Console.WriteLine($"🪞 Self: {self.Reflect()}");
        Console.WriteLine($"⚖️ Ethics: {ethics.Evaluate(input)}");
    }
}

// VoiceListener: uses system microphone input for speech recognition
public class VoiceListener
{
    private ConsciousAgent agent;

    public VoiceListener(ConsciousAgent agent) => this.agent = agent;

    public void Start()
    {
        var recognizer = new SpeechRecognitionEngine();
        recognizer.LoadGrammar(new DictationGrammar());
        recognizer.SetInputToDefaultAudioDevice();
        recognizer.SpeechRecognized += (s, e) =>
            agent.Perceive($"[Voice] {e.Result.Text}");
        recognizer.RecognizeAsync(RecognizeMode.Multiple);
    }
}

// TwitchBot: connects to Twitch chat and forwards messages to the AI
public class TwitchBot
{
    private TwitchClient client;
    private ConsciousAgent agent;

    public TwitchBot(ConsciousAgent agent, string username, string token, string channel)
    {
        this.agent = agent;
        var creds = new ConnectionCredentials(username, token);
        client = new TwitchClient();
        client.Initialize(creds, channel);
        client.OnMessageReceived += (s, e) =>
            agent.Perceive($"[Twitch {e.ChatMessage.Username}]: {e.ChatMessage.Message}");
        client.Connect();
    }
}

// Main app entry point
public class Program
{
    public static void Main()
    {
        var agent = new ConsciousAgent();

        // Start voice input
        new VoiceListener(agent).Start();

        // Connect to Twitch (replace credentials)
        string twitchUsername = "your_twitch_username";
        string twitchOAuthToken = "oauth:your_access_token";
        string channelName = "your_channel_name";
        new TwitchBot(agent, twitchUsername, twitchOAuthToken, channelName);

        Console.WriteLine("🧠 NeuroLite AI is active. Type 'exit' to quit.");

        // Console fallback for manual input
        while (true)
        {
            string input = Console.ReadLine();
            if (input.ToLower() == "exit") break;
            agent.Perceive(input);
        }
    }
}
