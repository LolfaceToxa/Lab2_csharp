using System;

namespace lab2_csharp
{
    interface IDateAndCopy //интерфейс IDateAndCopy
    {
        object DeepCopy();
        DateTime Date { get; set; }

    }
}
