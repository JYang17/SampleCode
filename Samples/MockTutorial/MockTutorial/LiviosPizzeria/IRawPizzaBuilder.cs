namespace LiviosPizzeria
{
    public interface IRawPizzaBuilder
    {
        RawPizza CreatePizza(Ingredients ingredients);
    }
}