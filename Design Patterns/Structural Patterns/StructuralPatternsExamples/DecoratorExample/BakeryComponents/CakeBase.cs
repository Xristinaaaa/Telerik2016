namespace DecoratorExample.BakeryComponents
{
    class CakeBase : BakeryComponent
    {
        private string m_Name = "Cake Base";
        private double m_Price = 200.0;

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
