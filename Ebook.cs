using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoGestaoEstoque
{
    [System.Serializable]

    class Ebook : Produto, IEstoque
    {
        public string author;
        private int sales;

        public Ebook(string name, float price, string author)
        {
            this.author = author;
            this.name = name;
            this.price = price;
        }
        public void AddInput()
        {
            Console.WriteLine("Não é possível dar entrada no estoque de um Ebook");
            Console.Read();
        }
        public void AddOutput()
        {
            Console.WriteLine("Adicionar vendas no E-book {0}", name);
            Console.WriteLine("Digite a quantidade de vendas");
            int OutputSalesEbook = int.Parse(Console.ReadLine());
            sales += OutputSalesEbook;
            Console.WriteLine("Quantidades de vendas registradas");
            Console.ReadLine();
        }
        public void Display()
        {
            Console.WriteLine("Nome: {0}", name);
            Console.WriteLine("Autor do curso: {0}", author);
            Console.WriteLine("Preço: {0}", price);
            Console.WriteLine("Vendas: {0}", sales);
            Console.WriteLine("=================================");
        }
    }
}
