using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Model
{
    public class Exercise
    {
        public int ID { get; set; }
        public int RepAmount { get; set; }
        public double TimeToDo { get; set; }
        public ExerciseType ExTypeID { get; set; }

        public Exercise(int iD, int repAmount, double timeToDo, ExerciseType extypeID)
        {
            ID = iD;
            RepAmount = repAmount;
            TimeToDo = timeToDo;
            ExTypeID = extypeID;
        }

        public Exercise()
        {
        }
    }
}
