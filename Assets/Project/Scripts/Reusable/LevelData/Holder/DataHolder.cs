using UnityEngine.SceneManagement;

public static class DataHolder
{
    public static LevelData LevelData { get; private set; } =
        new LevelData() { Difficulty = Difficulty.Easy };

    private const string SceneName = "Menu";
    public static string LastSceneName;

    public static bool TryChangeDifficulty(Difficulty difficulty)
    {
        if (!CanBeEdited()) return false;

        LevelData = new LevelData() { Difficulty = difficulty };

        return true;
    }

    private static bool CanBeEdited() => SceneManager.GetActiveScene().name == SceneName;
}