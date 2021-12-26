using System;
using System.Collections.Generic;

namespace MapObjects.Services
{
    public interface IService : ITickable
    {
        string Key { get; }
    }
}