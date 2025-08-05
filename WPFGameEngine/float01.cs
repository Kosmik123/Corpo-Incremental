namespace WPFGameEngine
{
    public struct float01
    {
        private float _value;

        public static float01 FromFloat(float floatValue) => new float01 { _value = Math.Clamp(floatValue, 0, 1) };

        public static implicit operator float01(float floatValue) => FromFloat(floatValue);
        public static implicit operator float01(int intValue) => FromFloat(intValue);
        public static implicit operator float(float01 @float01) => @float01._value;
    }
}
