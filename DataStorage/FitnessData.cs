using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using Model;

namespace DataStorage
{
    public class FitnessData : INotifyPropertyChanged
    {
        SqlAccess sqlAccess = new SqlAccess();
        TableToObjectConverter converter;
        public event PropertyChangedEventHandler PropertyChanged;

        private void RaisePropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new
                PropertyChangedEventArgs(propName));
            }
        }
        public ObservableCollection<User> UserOversigt
        {
            get
            {
                return converter.GetUsersListe(sqlAccess.ExecuteSql("select * from Users"));
            }
        }

        public ObservableCollection<ExerciseType> ExerciseTypeOversigt
        {
            get
            {
                return converter.GetExerciseTypesListe(sqlAccess.ExecuteSql("select * from ExerciseTypes"));
            }
        }

        public ObservableCollection<Exercise> ExerciseOversigt
        {
            get
            {
                return converter.GetExerciseListe(sqlAccess.ExecuteSql("select * from Exercises"));
            }
        }

        public ObservableCollection<ExercisePlan> ExercisePlanOversigt
        {
            get
            {
                return converter.GetExercisePlanListe(sqlAccess.ExecuteSql("select * from ExercisePlan"));
            }
        }



        public void OpretUser(string name, string password, string email)
        {
            sqlAccess.ExecuteSql($"Insert into Users (Username, Password, Email) values ('{name}', '{password}', '{email}')");
            RaisePropertyChanged("UserOversigt");
        }

        public bool LogInd(string username, string password)
        {
            foreach (User user in UserOversigt)
            {
                if (user.Name == username && user.Password == password)
                {
                    return true;
                }
            }
            return false;
        }

        public void DeleteUser(User user)
        {
            sqlAccess.ExecuteSql($"delete * from Users where id={user.ID}");
            RaisePropertyChanged("UserOversigt");
        }

        public void OpretExercisePlan(DateTime date, string totalTime)
        {
            sqlAccess.ExecuteSql($"insert into ExercisePlans (Date, TotalTime) values ({date}, {Convert.ToDouble(totalTime)})");
            RaisePropertyChanged("ExercisePlanOversigt");
        }

        public void DeleteExercisePlan(ExercisePlan exPlan)
        {
            sqlAccess.ExecuteSql($"delete * from ExercisePlans where id={exPlan.ID}");
            RaisePropertyChanged("ExercisePlanOversigt");
        }

        public void OpretExerciseType(string name, string description, string equipment, string timePrRep)
        {
            sqlAccess.ExecuteSql($"insert into ExerciseTypes (Name, Description, Equipment, TimePrRep) values ('{name}', '{description}', '{equipment}', {Convert.ToDouble(timePrRep)})");
            RaisePropertyChanged("ExerciseTypeOversigt");
        }

        public void OpretExercise(string repAmount, string timeToDo)
        {
            sqlAccess.ExecuteSql($"insert into Exercises (RepAmount, TimeToDo) values ({Convert.ToInt32(repAmount)}, {Convert.ToDouble(timeToDo)})");
            RaisePropertyChanged("ExerciseOversigt");
        }

        public void DeleteExercise(Exercise exer)
        {
            sqlAccess.ExecuteSql($"delete * from Exercise where id={exer.ID}");
            RaisePropertyChanged("ExerciseOversigt");
        }
    }
}
