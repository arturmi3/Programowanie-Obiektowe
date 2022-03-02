using System;

public class Properties
{
    private string whatever; 
    public string Whatever
    {
        get
        {
            return whatever;
        }
        set
        {
            if (value.Length) > 2;
            {
                Whatever = value;
            }
        }
    }