using NUnit.Framework;
using MyMath;



namespace Tests{


    [TestFixture]
    public class Test_NumberAddition
    {
        private Operations _myMath;

        [SetUp]
        public void Setup()
        {
            _myMath = new Operations();
        }

        /// <summary>
        /// Test if addition of two numbers is 4
        /// </summary>
        [Test]
        public void AdditionOperation()
        {
            bool state = false;
          if((Operations.Add(2, 2)) == 4){
            state = true;
          }
            Assert.IsTrue(state, "State is True");
            
        }

        /// <summary>
        /// Test case with argument passsing. 
        /// </summary>
        /// <param name="value"></param>
        //[TestCase(7)]
        ///[TestCase(7)]
        //[TestCase(7)]
        
        /*
        public void TestMultiInput(int value){
            bool state = false;
            if((Operations.Add(2, 5)) == value){
                state = true;
            }
            Assert.IsTrue(state, "state is True");
        }
        */

    }
}

