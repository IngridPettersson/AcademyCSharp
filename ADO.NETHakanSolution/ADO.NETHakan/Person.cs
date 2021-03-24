namespace ADO.NETHakan
{
    internal class Person
    {
        public int ID { get; set; }
        public int? Sektion { get; set; } // int? byts i kompilatorn ut mot Nullable<int>
        public string Titel { get; set; }
        public string Namn { get; set; }
        public decimal Lön { get; set; }
        public int? ChefsID { get; set; }
    }
}