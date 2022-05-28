using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoGestaoEstoque
{
    [System.Serializable]
    class PhysicalProduct : Produto, IEstoque
    {
        public float freight;
        private int stock;
        private ulong barcode;

        public PhysicalProduct(string name, float price, float freight, ulong barcode)
        {
            this.name = name;
            this.price = price;
            this.barcode = barcode;
            this.freight = freight;
            

        }
        public void AddInput()
        {
            Console.WriteLine("Adicionar Entrada no estoque do produto {0}", name);
            Console.WriteLine("Digite a quantidade de entrada do produto");
            int inputPhysicalProductStock = int.Parse(Console.ReadLine());
            stock += inputPhysicalProductStock;
            Console.WriteLine("Entrada registrada");
            Console.ReadLine();
        }
        public void AddOutput()
        {
            Console.WriteLine("Adicionar saida no estoque do produto {0}", name);
            Console.WriteLine("Digite a quantidade para dar baixa do produto");
            int OutpurPhysicalProductStock = int.Parse(Console.ReadLine());
            stock -= OutpurPhysicalProductStock;
            Console.WriteLine("Saída registrada");
            Console.ReadLine();
        }
        public void Display()
        {
            Console.WriteLine("Nome: {0}", name);
            Console.WriteLine("Preço: {0}", price);
            Console.WriteLine("Frete: {0}", freight);
            Console.WriteLine("Estoque: {0}", stock);
            Console.WriteLine("Código de barras: {0}", barcode);
            Console.WriteLine("=================================");
        }
    }
}
