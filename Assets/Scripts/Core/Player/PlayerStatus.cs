namespace Core
{
    public class PlayerStatus
    {
        private readonly ISaveSystem _saveSystem;
        private SaveData _saveData;
        private readonly int _multiple = 1000;
        private int _score = 0;
        public int Score => _score;
        public int BestScore => _saveData.BestScore;

        public PlayerStatus(ISaveSystem saveSystem)
        {
            _saveSystem = saveSystem;
            LoadData();
        }

        public void SaveData()
        {
            _saveData = new SaveData();
            if (_score > _saveData.BestScore)
            {
                _saveData.BestScore = _score;
            }
            _saveSystem.Save(_saveData);
        }

        private void LoadData()
        {
            _saveData = _saveSystem.Load();
        }

        public void AddScore(int score)
        {
            _score += score * _multiple;
        }

        public void ResetScore()
        {
            _score = 0;
        }
    }
}
