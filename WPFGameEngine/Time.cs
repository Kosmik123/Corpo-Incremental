namespace WPFGameEngine
{
    public static class Time
    {
        public static double DeltaTimeDouble { get; internal set; }
        public static float DeltaTime => (float)DeltaTimeDouble;
    }
}
