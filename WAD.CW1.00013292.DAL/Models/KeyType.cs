namespace WAD.CW1._00013292.Models
{
    public class KeyType
    {
        public int KeyTypeId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public ICollection<KeyItem> KeyItems { get; set; }
    }
}
