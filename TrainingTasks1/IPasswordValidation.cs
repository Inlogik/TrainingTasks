using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainingTasks1
{
    public interface IPasswordValidation
    {
        PasswordValidationResult Validate(string password);
    }
}
