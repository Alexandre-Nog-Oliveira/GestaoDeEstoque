using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoGestaoEstoque
{
    [System.Serializable]

    class Course : Produto, IEstoque
    {
        public string author;
        private int vacancies;

        public Course(string name, float price, string author)
        {
            this.name = name;
            this.price = price;
            this.author = author;
        }
        public void AddInput()
        {
            Console.WriteLine("Adicionar vagas no curso {0}", name);
            Console.WriteLine("Digite a quantidade de vagas");
            int inputVacanciesCourse = int.Parse(Console.ReadLine());
            vacancies += inputVacanciesCourse;
            Console.WriteLine("Entradas de vagas registradas");
            Console.ReadLine();

        }
        public void AddOutput()
        {
            Console.WriteLine("Consumir vagas no curso {0}", name);
            Console.WriteLine("Digite a quantidade de vagas quer preencher");
            int OutputVacanciesCourse = int.Parse(Console.ReadLine());
            vacancies -= OutputVacanciesCourse;
            Console.WriteLine("Vagas preenchidas registradas");
            Console.ReadLine();
        }
        public void Display()
        {
            Console.WriteLine("Nome: {0}", name);
            Console.WriteLine("Autor do curso: {0}", author);
            Console.WriteLine("Preço: {0}", price);
            Console.WriteLine("Vagas restantes: {0}", vacancies);
            Console.WriteLine("=================================");
        }
    }
}
