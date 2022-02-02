using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class ExerciseType
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string Equipment { get; set; }
        public double TimePrRep { get; set; }

        public ExerciseType(int iD, string name, string description, string equipment, double timePrRep)
        {
            ID = iD;
            Name = name;
            Description = description;
            Equipment = equipment;
            TimePrRep = timePrRep;
        }

        public ExerciseType()
        {
        }
    }
}
