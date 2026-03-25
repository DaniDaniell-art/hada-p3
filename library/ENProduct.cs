using System;

namespace library
{
    public class ENProduct
    {
        // Atributos privados
        private string _code;
        private string _name;
        private int _amount;
        private float _price;
        private int _category;
        private DateTime _creationDate;

        // Propiedades públicas
        public string Code { get { return _code; } set { _code = value; } }
        public string Name { get { return _name; } set { _name = value; } }
        public int Amount { get { return _amount; } set { _amount = value; } }
        public float Price { get { return _price; } set { _price = value; } }
        public int Category { get { return _category; } set { _category = value; } }
        public DateTime CreationDate { get { return _creationDate; } set { _creationDate = value; } }

        // Constructores
        public ENProduct() { }

        public ENProduct(string code, string name, int amount, float price, int category, DateTime creationDate)
        {
            this.Code = code;
            this.Name = name;
            this.Amount = amount;
            this.Price = price;
            this.Category = category;
            this.CreationDate = creationDate;
        }

        // Métodos de operaciones
        public bool create() { CADProduct cad = new CADProduct(); return cad.create(this); }
        public bool update() { CADProduct cad = new CADProduct(); return cad.update(this); }
        public bool delete() { CADProduct cad = new CADProduct(); return cad.delete(this); }
        public bool read() { CADProduct cad = new CADProduct(); return cad.read(this); }
        public bool readFirst() { CADProduct cad = new CADProduct(); return cad.readFirst(this); }
        public bool readNext() { CADProduct cad = new CADProduct(); return cad.readNext(this); }
        public bool readPrev() { CADProduct cad = new CADProduct(); return cad.readPrev(this); }
    }
}