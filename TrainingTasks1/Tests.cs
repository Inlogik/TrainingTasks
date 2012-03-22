using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NUnit.Framework;

namespace TrainingTasks1
{
    [TestFixture]
    public class Tests
    {
        // 1. Should implement 3 rules (must have a number, must have an uppercase letter, must be min of 10 in length). More may be needed later.
        // 2  A Blank password is not valid
        // 3. Tests should cover all functionality
        // 4. SOLID principles should be adhered to

        [Test]
        public void A_Blank_Password_Is_Not_Valid()
        {
            IPasswordValidator validator = null;
            var result = validator.Validate("");

            Assert.False(result);
        }
    }
}
