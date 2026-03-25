using System;

namespace library
{
    public class ENProduct
    {
        [cite_start] private string _code; [cite: 425]
        [cite_start] private string _name; [cite: 426]
        [cite_start] private int _amount; [cite: 427]
        [cite_start] private float _price; [cite: 428]
        [cite_start] private int _category; [cite: 429]
        [cite_start] private DateTime _creationDate; [cite: 430]

        public string Code { get => _code; set => _code = value; }
        [cite: 431, 464]
        public string Name { get => _name; set => _name = value; }
        [cite: 432, 464]
        public int Amount { get => _amount; set => _amount = value; }
        [cite: 433, 464]
        public float Price { get => _price; set => _price = value; }
        [cite: 434, 464]
        public int Category { get => _category; set => _category = value; }
        [cite: 435, 464]
        public DateTime CreationDate { get => _creationDate; set => _creationDate = value; }
        [cite: 436, 464]

        [cite_start]
        public ENProduct()
        {
            [cite: 437, 465]
            _code = "";
            _name = "";
            _amount = 0;
            _price = 0f;
            _category = 0;
            _creationDate = DateTime.Now;
        }

        [cite_start]
        public ENProduct(string code, string name, int amount, float price, int category, DateTime creationDate)
        {
            [cite: 438, 466]
            this._code = code;
            this._name = name;
            this._amount = amount;
            this._price = price;
            this._category = category;
            this._creationDate = creationDate;
        }

        [cite_start]
        public bool Create()
        {
            [cite: 439, 467]
            CADProduct cad = new CADProduct();
            return cad.Create(this);
        }

        [cite_start]
        public bool Read()
        {
            [cite: 442, 473]
            CADProduct cad = new CADProduct();
            return cad.Read(this);
        }

        [cite_start]// Implementar: Update(), Delete(), ReadFirst(), ReadNext(), ReadPrev() [cite: 440, 441, 443]
    }
}