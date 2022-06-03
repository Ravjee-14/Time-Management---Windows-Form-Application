using System;
using System.Collections.Generic;
using System.Text;

namespace WPF___POE
{
    abstract class values
    {
        public abstract double Module();
        public abstract double Working();
        public abstract double Semester();
    }

    class Module
    {
        public string Code 
        { get; set; }

        public string Name
        { get; set; }

        public double Credits
        { get; set; }

        public double HoursWeekly
        { get; set; }
    }

    class Working
    {
        public double HoursWorked
        { get; set; }

        public string ModuleWork
        { get; set; }

        public double StudyHoursWeekly
        { get; set; }

        public string DateWorking
        { get; set; }
    }

    class Semester
    {
        public double NumWeeks
        { get; set; }

        public string DateSemester
        { get; set; }
    }
}
