using System;
using System.Collections;
using System.Collections.Generic;

public class TNTRandomGenerator
{
    private const long m = 4294967296; 
    private const long a = 1664525;
    private const long c = 1013904223;
    private long _last;

    public TNTRandomGenerator()
    {
        _last = DateTime.Now.Ticks % m;
    }

    public TNTRandomGenerator(long seed)
    {
        _last = seed;
    }

    public long Next()
    {
        _last = ((a * _last) + c) % m;

        return _last;
    }

    public long Next(long maxValue)
    {
        return Next() % maxValue;
    }

}
