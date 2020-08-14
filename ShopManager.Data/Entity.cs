namespace ShopManager.Data
{
    public abstract class Entity
    {
        public int Id { get; set; }
        public string DisplayName { get; set; }
        public string SystemName { get; set; }

    }
}