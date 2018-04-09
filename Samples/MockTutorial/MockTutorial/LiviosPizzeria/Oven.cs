namespace LiviosPizzeria
{
    public class Oven : IOven
    {
        public int Temperature { get; set; }
        
        public Pizza CookPizza(IRawPizza rawPizza)
        {
            throw new System.NotImplementedException();
        }

        public void AutoClean()
        {
            throw new System.NotImplementedException();
        }
    }
}