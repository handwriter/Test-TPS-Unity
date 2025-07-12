namespace DefaultNamespace
{
    public interface ISaveLoadManager
    {
        public int GetGemsCount();
        public void IncrementGems(int delta);
        public void SetGemsCount(int value);
        public int GetTargetGems();
        public void SetTargetGems(int value);
    }
}