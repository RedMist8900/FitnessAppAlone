using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Text;

namespace DataStorage
{
    public class TableToObjectConverter
    {
        SqlAccess sqlAccess;

        public TableToObjectConverter(SqlAccess sqlAccess)
        {
            this.sqlAccess = sqlAccess;
        }

        public ObservableCollection<User> GetUsersListe(DataTable table)
        {
            ObservableCollection<User> liste = new ObservableCollection<User>();
            foreach (DataRow row in table.Rows)
            {
                User user = GetUsers(row);
                liste.Add(user);
            }
            return liste;
        }

        public ObservableCollection<ExercisePlan> GetExercisePlanListe(DataTable table)
        {
            ObservableCollection<ExercisePlan> liste = new ObservableCollection<ExercisePlan>();
            foreach (DataRow row in table.Rows)
            {
                ExercisePlan exPlan = GetExercisePlan(row);
                liste.Add(exPlan);
            }
            return liste;
        }

        public ObservableCollection<Exercise> GetExerciseListe(DataTable table)
        {
            ObservableCollection<Exercise> liste = new ObservableCollection<Exercise>();
            foreach (DataRow row in table.Rows)
            {
                Exercise exercise = GetExercise(row);
                liste.Add(exercise);
            }
            return liste;
        }

        public ObservableCollection<ExerciseType> GetExerciseTypesListe(DataTable table)
        {
            ObservableCollection<ExerciseType> liste = new ObservableCollection<ExerciseType>();
            foreach (DataRow row in table.Rows)
            {
                ExerciseType exercisetypes = GetExerciseTypes(row);
                liste.Add(exercisetypes);
            }
            return liste;
        }

        private User GetUsers(DataRow row)
        {
            User user = new User();
            user.Name = (string)row["Username"];
            user.Password = (string)row["Password"];
            user.Email = (string)row["Email"];
            user.ID = (int)row["CustomerID"];
            return user;
        }

        private ExercisePlan GetExercisePlan(DataRow row)
        {
            ExercisePlan exPlan = new ExercisePlan();
            exPlan.Exercises = GetExerciseList(sqlAccess.ExecuteSql("select * from Exercises where ExPlanID = " + row["ID"].ToString()));
            exPlan.Date = (DateTime)row["Date"];
            exPlan.TotalTime = (double)row["TotalTime"];
            exPlan.ID = (int)row["ID"];
            //exPlan.CustomerRef = (int)row["CustomerRef"];
            return exPlan;
        }

        private Exercise GetExercise(DataRow row)
        {
            Exercise exercise = new Exercise();
            exercise.RepAmount = (int)row["RepAmount"];
            exercise.TimeToDo = (double)row["TimeToDo"];
            exercise.ID = (int)row["ID"];
            exercise.ExTypeID = GetExerciseTypes(GetExerciseTypesRow(row["ExID"].ToString()));
            return exercise;
        }

        private ExerciseType GetExerciseTypes(DataRow row)
        {
            ExerciseType ext = new ExerciseType();
            ext.Name = (string)row["Name"];
            ext.Description = (string)row["Description"];
            ext.Equipment = (string)row["Equipment"];
            ext.TimePrRep = (double)row["TimePrRep"];
            ext.ID = (int)row["ID"];
            return ext;
        }

        private DataRow GetExerciseTypesRow(string id)
        {
            return sqlAccess.ExecuteSql("select * from ExerciseTypes where Id = " + id).Rows[0];
        }

        private ObservableCollection<Exercise> GetExerciseList(DataTable dataTable)
        {
            ObservableCollection<Exercise> exList = new ObservableCollection<Exercise>();

            foreach (DataRow row in dataTable.Rows)
            {
                exList.Add(GetExercise(row));
            }

            return exList;
        }
    }
}
