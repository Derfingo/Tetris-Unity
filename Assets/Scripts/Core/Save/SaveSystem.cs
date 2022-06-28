using UnityEngine;

namespace Core
{
    public class SaveSystem : ISaveSystem
    {
        private const string BEST_SCORE_KEY = "best_score";
        private const string TUTORIAL_KEY = "tutorial_complited";

        public void Save(SaveData data)
        {
            PlayerPrefs.SetInt(BEST_SCORE_KEY, data.BestScore);
            PlayerPrefs.SetInt(TUTORIAL_KEY, data.IsTutorialCompleted ? 1 : 0);
            PlayerPrefs.Save();
        }

        public SaveData Load()
        {
            var data = new SaveData();
            if (PlayerPrefs.HasKey(BEST_SCORE_KEY))
            {
                data.BestScore = PlayerPrefs.GetInt(BEST_SCORE_KEY);
            }

            if (PlayerPrefs.HasKey(TUTORIAL_KEY))
            {
                data.IsTutorialCompleted = PlayerPrefs.GetInt(TUTORIAL_KEY) == 1;
            }

            return data;
        }
    }
}
