using System.Collections.Generic;

public static class CeepDestroying
{
    public static List<string> objs = new();
    public static int oo = 0;
    public static void AddToArray(string obj)
    {
        oo++;
        objs.Add(obj);
    }
    public static List<string> GetObjs()
    {
        return objs;
    }
    public static void SetObjs(List<string>obj, int numbobjs)
    {
        objs = new();
        for (int i = 0; i < numbobjs; i++)
        {
            objs.Add(obj[i]);
        }
    }
}
