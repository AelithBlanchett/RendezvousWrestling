using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;

namespace RendezvousWrestling.Common.Utils
{
    public class BaseEntityTypeConverter<T> : ITypeConverter<int, T> where T : BaseEntityType<T>
    {
        T ITypeConverter<int, T>.Convert(int source, T destination, ResolutionContext context)
        {
            destination = destination.FromValue(source);
            return destination;
        }
    }
}
