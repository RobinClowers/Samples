namespace DependencyInjectionDemo
{
    public class ShoppingCart
    {
        readonly Inventory inventory;

        public ShoppingCart(Inventory inventory)
        {
            this.inventory = inventory;
        }

        public void AddTo(string item)
        {
            inventory.Remove(item);
        }
    }
}