namespace LiviosPizzeria
{
    public interface IOven
    {
        int Temperature { get; set; }
        Pizza CookPizza(IRawPizza rawPizza);
        void AutoClean();
    }
}