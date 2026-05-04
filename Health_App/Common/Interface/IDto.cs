using System;

namespace Health_App.Common.Interface
{
    public interface IDto
    {
        Guid id { get; set; }
        string name { get; set; }
    }
}
