namespace DecoratorExample.BakeryComponents
{
    class PastryBase : BakeryComponent
    {
        private string m_Name = "Pastry Base";
        private double m_Price = 20.0;

        public override string GetName()
        {
            return m_Name;
        }

        public override double GetPrice()
        {
            return m_Price;
        }
    }
}
