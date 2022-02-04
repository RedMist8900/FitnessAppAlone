using DataStorage;
using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Text.RegularExpressions;

namespace Funktion
{
    public class FitnessFunction : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        private void RaisePropertyChanged(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new
                PropertyChangedEventArgs(propName));
            }
        }
        FitnessData data = new FitnessData();
        private Regex mailReg = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
        private Regex passwordReg = new Regex(@"^.*(?=.{8,})(?=.*\d)(?=.*[a-z])(?=.*[A-Z]).*$");
        public User currentUser = new User(-1, "", "", "");

        public ObservableCollection<User> UserOversigt
        {
            get
            {
                return data.UserOversigt;
            }
        }

        public ObservableCollection<ExerciseType> ExerciseTypeOversigt
        {
            get
            {
                return data.ExerciseTypeOversigt;
            }
        }

        public ObservableCollection<Exercise> ExerciseOversigt
        {
            get
            {
                return data.ExerciseOversigt;
            }
        }

        public ObservableCollection<ExercisePlan> ExercisePlanListe
        {
            get
            {
                return data.ExercisePlanOversigt;
            }
        }

        public ObservableCollection<ExercisePlan> currExPlanList
        {
            get
            {
                ObservableCollection<ExercisePlan> planListe = new ObservableCollection<ExercisePlan>();
                foreach (ExercisePlan plan in ExercisePlanListe)
                {
                    if (plan.UserRef == currentUser.ID)
                    {
                        planListe.Add(plan);
                    }
                }
                return planListe;
            }
        }

        public void UpdateCurrExPlanList()
        {
            foreach (ExercisePlan plan in ExercisePlanListe)
            {
                if (plan.ID == currentUser.ID)
                {
                    currExPlanList.Add(plan);
                }
            }
        }

        // RegEx Encrypts Password
        public static string EncodePasswordToBase64(string password)
        {
            try
            {
                byte[] encData_byte = new byte[password.Length];
                encData_byte = System.Text.Encoding.UTF8.GetBytes(password);
                string encodedData = Convert.ToBase64String(encData_byte);
                return encodedData;
            }
            catch (Exception ex)
            {
                throw new Exception("Error in base64Encode" + ex.Message);
            }
        }


        //this function Convert to Decord your Password
        public string DecodeFrom64(string encodedData)
        {
            System.Text.UTF8Encoding encoder = new System.Text.UTF8Encoding();
            System.Text.Decoder utf8Decode = encoder.GetDecoder();
            byte[] todecode_byte = Convert.FromBase64String(encodedData);
            int charCount = utf8Decode.GetCharCount(todecode_byte, 0, todecode_byte.Length);
            char[] decoded_char = new char[charCount];
            utf8Decode.GetChars(todecode_byte, 0, todecode_byte.Length, decoded_char, 0);
            string result = new String(decoded_char);
            return result;
        }

        public bool LogIn(string username, string password)
        {
            if (data.LogInd(username, EncodePasswordToBase64(password)))
            {
                foreach (User user in UserOversigt)
                {
                    if (user.Name == username && DecodeFrom64(user.Password) == password)
                    {
                        currentUser.ID = user.ID;
                        UpdateCurrExPlanList();
                    }
                }
                return true;
            }

            throw new Exception("Forkert password eller brugernavn");
        }

        public void OpretUser(string name, string password, string email)
        {
            #region Fejlhåndtering
            Match match1 = mailReg.Match(email);
            Match match2 = passwordReg.Match(password);

            foreach (User user in UserOversigt)
            {
                if (user.Name == name)
                {
                    throw new Exception("Username eksisterer allerede.");
                }
            }

            if (!match1.Success)
            {
                throw new Exception("Email was incorrect format please try again");
            }

            if (!match2.Success)
            {
                throw new Exception("Password was incorrect format please try again");
            }
            #endregion

            data.OpretUser(name, EncodePasswordToBase64(password), email);
        }

        public void DeleteUser(User user)
        {
            try
            {
                if(user == null)
                {
                    throw new Exception("No User to Delete");
                }
                data.DeleteUser(user);
            }
            catch (Exception)
            {
                throw new Exception("Error in Function Deleting User");
            }
        }

        public void OpretExercisePlan(DateTime date, string totalTime)
        {
            try
            {
                data.OpretExercisePlan(date, totalTime);
            }
            catch(Exception)
            {
                throw new Exception("Error in Function");
            }
        }

        public void DeleteExercisePlan(ExercisePlan exPlan)
        {
            try
            {
                if(exPlan == null)
                {
                    throw new Exception("No ExercisePlan to Delete");
                }
                else
                {
                    data.DeleteExercisePlan(exPlan);
                }
            }
            catch (Exception)
            {
                throw new Exception("Error in Deleting");
            }
        }

        public void OpretExerciseType(string name, string description, string equipment, string timePrRep)
        {
            try
            {
                data.OpretExerciseType(name, description, equipment, timePrRep);
            }catch(Exception)
            {
                throw new Exception("Error in Function");
            }
        }

        public void OpretExercise(string repAmount, string timeToDo)
        {
            try
            {
                data.OpretExercise(repAmount, timeToDo);
            }
            catch (Exception)
            {
                throw new Exception("Error in function");
            }
        }

        public void DeleteExercise(Exercise exer)
        {
            try
            {
                if(exer == null)
                {
                    throw new Exception("No Exercise Selected to delete");
                }
                else
                {
                    data.DeleteExercise(exer);
                }
            }
            catch (Exception)
            {
                throw new Exception("Error in Deleting Exercise");
            }
        }
    }
}
