namespace DefaultNamespace
{
    public class SaveLoadManager : ISaveLoadManager
    {
        private int _gems;
        private int _targetGems;

        public int GetGemsCount() => _gems;

        public void IncrementGems(int delta) => _gems += delta;

        public void SetGemsCount(int value) => _gems = value;

        public int GetTargetGems() => _targetGems;
        public void SetTargetGems(int value) => _targetGems = value;
    }
}