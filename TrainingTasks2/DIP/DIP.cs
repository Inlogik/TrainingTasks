using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TrainingTasks2.DIP
{
    public class BirthdayCalculator
    {
        private readonly List<Birthday> _birthdays;

        public BirthdayCalculator()
        {
            var birthdayService = new BirthdayService();
            _birthdays = birthdayService.GetAllBirthdays();
        }

        public List<Birthday> Birthdays
        {
            get { return _birthdays; }
        }

        public List<Birthday> GetTodaysBirthdays()
        {
            return _birthdays
                .Where(bd => bd.Date == DateTime.Now.Date)
                .ToList();
        }
    }
}
