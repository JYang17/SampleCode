using Microsoft.VisualStudio.TestTools.UnitTesting;
using Rhino.Mocks;

namespace LiviosPizzeria.Test
{

    /// <summary>
    /// Some examples about the usage of RhinoMock.
    /// More information here:
    /// http://ayende.com/wiki/Rhino+Mocks+3.5.ashx
    /// 
    /// Some general rules always good to remember:
    /// 1) Arrange - Act - Assert syntax
    /// 2) One assertion for each test
    /// 3) The new RhinoMock (3.5 and 3.6) suggest the usage of STUBS as much as you can
    /// 4) Mock are only recommended when you need expectations
    /// 5) StrictMock are generally bad. Use it carefully
    /// 
    /// </summary>
    /// 
    [TestClass]
    public class PizzaMakerFixture
    {
        /// Test 1.
        /// A basic test to introduce the GenerateStub and GenerateMock and the current syntax.
        /// The old syntax (mockrepository.CreateMock) is deprecated. It generates StrictMock, which are bad ,we'll see this later on.
        /// For this reason we use the "GenerateStub" call. 
        /// We are testing the STATE here. Not the behaviors of the method.
        /// 
        /// In this test we use stubs. We show that the stub objects in this test are not influent. 
        /// They are not the key point of our test as we just check that the state of PizzaMaker is properly set.
        /// 
        [TestMethod]
        public void WhenMakePizzaEndsThenPizzaMakerIsReadyForAnotherPizza()
        {
            // ARRANGE
            var stubIngredientsProvider = MockRepository.GenerateStub<IIngredientsProvider>();
            var stubRawPizzaBUilder = MockRepository.GenerateStub<IRawPizzaBuilder>();
            var stubOven = MockRepository.GenerateStub<IOven>();

            // ACT
            var sut = new PizzaMaker(stubIngredientsProvider, stubRawPizzaBUilder, stubOven);
            var pizza = sut.MakePizza();

            // ASSERT
            Assert.IsTrue(sut.ReadyForMakePizza);
        }

        /// <summary>
        /// Test 2
        /// With this test we test the Behavior.
        /// We are still using the "GenerateStub" call, but we are now using the "AssertWasCalled" assertion.
        /// </summary>
        /// <remarks>
        /// We could have done this also using a GenerateMock and setting an Expectation.
        /// Ayende discourages this usage and reserves MockObjects only for complex expectations
        /// </remarks>
        [TestMethod]
        public void WeNeverForgetToCookPizzaInTheOven()
        {
            // ARRANGE
            var stubIngredientsProvider = MockRepository.GenerateStub<IIngredientsProvider>();
            var stubRawPizzaBUilder = MockRepository.GenerateStub<IRawPizzaBuilder>();
            var mockOven = MockRepository.GenerateStub<IOven>();
            
            mockOven.Stub(oven => oven.CookPizza(Arg<IRawPizza>.Is.Anything));

            // ACT
            var sut = new PizzaMaker(stubIngredientsProvider, stubRawPizzaBUilder, mockOven);
            var pizza = sut.MakePizza();

            // ASSERT
            mockOven.AssertWasCalled(oven => oven.CookPizza(Arg<IRawPizza>.Is.Anything));
        }

        /// <summary>
        /// Test 3
        /// With this test we are still testing a Behavior but this is the only case
        /// where we really need to use the "GenerateMock" call.
        /// 
        /// This is because we CAN'T set expectations on a stub object. We set expectation on a mock object.
        /// We can SET a property on a stub object, and the object will have this property value, but we
        /// CAN't check on a stub if the property has been set from someoneelse during the execution.
        /// 
        /// If I try to use "GenerateStub", apparently it builds but I get an exception because I was
        /// trying to set an expectation on a stub
        /// </summary>
        /// <remarks>
        /// From a design point of view is absolutely BAD directly set a property of an object from a different object.
        /// However, in legacy code, we could have this situation and this is a way to test it.
        /// </remarks>
        [TestMethod]
        public void PizzaMakerSetOvenToTheProperTemperature()
        {
            // ARRANGE
            IIngredientsProvider stubIngredientsProvider = MockRepository.GenerateStub<IIngredientsProvider>();
            IRawPizzaBuilder stubRawPizzaBUilder = MockRepository.GenerateStub<IRawPizzaBuilder>();

            // this won't work. We can't verify this call. If you comment out the property settings in the method under test, this test won't fail
            //IOven mockOven = MockRepository.GenerateStub<IOven>();
            //mockOven.Temperature = 300;
            //mockOven.Temperature = 150;

            //this is the proper way to check settings on property
            IOven mockOven = MockRepository.GenerateMock<IOven>();
            mockOven.Expect(oven => oven.Temperature = 300);
            mockOven.Expect(oven => oven.Temperature = 150);
            
            // ACT
            var sut = new PizzaMaker(stubIngredientsProvider, stubRawPizzaBUilder, mockOven);
            var pizza = sut.MakePizza();

            // ASSERT
            mockOven.VerifyAllExpectations();
        }

        /// <summary>
        /// Test 4
        /// This test points out the behavior of strict mock. Every time I change / improve / refactor 
        /// the method under test, the test will fail also if the test is testing something completely 
        /// different from what we changed (in this example, if I add a new method call to the oven (like AutoClean), the test will fail)
        /// </summary>
        [TestMethod]
        public void WhyTheStrictMockIsGenerallyBad()
        {
            //ARRANGE
            var stubIngredientsProvider = MockRepository.GenerateStub<IIngredientsProvider>();
            var stubRawPizzaBuilder = MockRepository.GenerateStub<IRawPizzaBuilder>();

            var mockOven = MockRepository.GenerateStrictMock<IOven>(); //DISCOURAGED
            mockOven.Expect(oven => oven.Temperature = 300);
            mockOven.Expect(oven => oven.Temperature = 150);
            mockOven.Expect(oven => oven.CookPizza(Arg<IRawPizza>.Is.Anything));

            // ACT
            var sut = new PizzaMaker(stubIngredientsProvider, stubRawPizzaBuilder, mockOven);
            sut.MakePizza();

            // ASSERT
            mockOven.VerifyAllExpectations();
        }



    }
}
