using Funktion;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Tests
{
    [TestClass]
    public class UnitTests
    {
        public FitnessFunction func = new FitnessFunction();
        [TestMethod]
        public void TestMethod1()
        {
        }

        public void TestData()
        {
            func.OpretExerciseType("Upper Arms", "Trains Biceps", "Dumbels", "120");
            func.OpretExerciseType("Pecks", "Trains the pecks", "Machine", "122");
            func.OpretExerciseType("Upper Legs", "Lunges", "Weights", "120");
            func.OpretExerciseType("Abs", "Trains the Stomach Abs", "Nothing", "120");

            func.OpretUser("Test", "Data", "test@gmail.com");
            func.OpretUser("Data", "Test", "data@gmail.com");
        }
    }
}
