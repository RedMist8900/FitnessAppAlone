using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Model
{
    public class ExercisePlan
    {
        public int ID { get; set; }
        public int UserRef { get; set; }
        public ObservableCollection<Exercise> Exercises { get; set; }
        public DateTime Date { get; set; }
        public double TotalTime { get; set; }

        public ExercisePlan(int iD, ObservableCollection<Exercise> exercises, DateTime date, double totalTime)
        {
            ID = iD;
            Exercises = exercises;
            Date = date;
            TotalTime = totalTime;
        }

        public ExercisePlan()
        {
        }
    }
}
