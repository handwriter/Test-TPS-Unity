using System;

public static class Utils
{
    public static T[] Shuffle<T>(T[] a)
    {
        T[] b = new T[a.Length];
        a.CopyTo(b, 0);
        for (int i = b.Length - 1; i > 0; i--)
        {
            // Randomize a number between 0 and i (so that the range decreases each time)
            int rnd = UnityEngine.Random.Range(0, i);

            // Save the value of the current i, otherwise it'll overright when we swap the values
            object temp = b.GetValue(i);

            // Swap the new and old values
            b.SetValue(b.GetValue(rnd), i);
            b.SetValue(temp, rnd);
        }

        return b;
    }
}
