using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace TaskSystem.Core.Domain.Enums.TaskComplexity
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TaskComplexityEnum
    {
        VeryEasy = 10,
        Easy = 20,
        Medium = 30,
        Hard = 40,
        VeryHard = 50,
    }
}
