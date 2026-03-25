using System;

namespace library
{
    public class ENCategory
    {
        private int _id;
        private string _name;

        public int Id { get { return _id; } set { _id = value; } }
        public string Name { get { return _name; } set { _name = value; } }

        public ENCategory() { }

        public ENCategory(int id, string name)
        {
            this.Id = id;
            this.Name = name;
        }

        public bool read() { CADCategory cad = new CADCategory(); return cad.read(this); }
    }
}