namespace LiviosPizzeria
{
    public class PizzaMaker
    {
        readonly IIngredientsProvider _ingredientsProvider;
        readonly IRawPizzaBuilder _rawPizzaBuilder;
        readonly IOven _oven;

        public bool ReadyForMakePizza { get; set; }

        public PizzaMaker(IIngredientsProvider ingredientsProvider, IRawPizzaBuilder rawPizzaBuilder, IOven oven)
        {
            _ingredientsProvider = ingredientsProvider;
            _rawPizzaBuilder = rawPizzaBuilder;
            _oven = oven;
            ReadyForMakePizza = true;
        }

        public Pizza MakePizza()
        {
            Pizza cookedPizza = null;

            ReadyForMakePizza = false;

            var ingredients = _ingredientsProvider.GetIngredients();
            var rawPizza = _rawPizzaBuilder.CreatePizza(ingredients);

            _oven.Temperature = 300;
            cookedPizza = _oven.CookPizza(rawPizza);
            _oven.Temperature = 150;

            //add this new "feature", uncommenting this line below, if you want to break the test #4 (WhyTheStrictMockIsGenerallyBad)
            //_oven.AutoClean();
            
            ReadyForMakePizza = true;
            return cookedPizza;
        }
    }
}
