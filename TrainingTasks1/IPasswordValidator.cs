using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainingTasks1
{
    public interface IPasswordValidator
    {
        bool Validate(string password);
    }
}
